using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Repositories;

/// <summary>
/// Репозиторий пациентов, работающий с базой данных PostgreSQL.
/// </summary>
public class PatientRepositoryDb : IPatientRepository
{
    private readonly DataContext _context;
    private readonly ILogger<PatientRepositoryDb> _logger;

    public PatientRepositoryDb(DataContext context, ILogger<PatientRepositoryDb> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить список всех пациентов.
    /// </summary>
    public IReadOnlyList<Patient> GetAll()
    {
        _logger.LogInformation("Запрос списка всех пациентов из БД");
        return _context.Patients.ToList();
    }

    /// <summary>
    /// Добавить нового пациента.
    /// </summary>
    public void Add(Patient patient)
    {
        _logger.LogInformation($"Добавление пациента: {patient.FullName}");
        _context.Patients.Add(patient);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновить данные пациента.
    /// </summary>
    public void Update(Patient patient)
    {
        _logger.LogInformation($"Обновление пациента ID: {patient.Id}");
        _context.Patients.Update(patient);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удалить пациента по ID.
    /// </summary>
    public void Delete(int id)
    {
        _logger.LogInformation($"Удаление пациента ID: {id}");
        var patient = _context.Patients.Find(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}