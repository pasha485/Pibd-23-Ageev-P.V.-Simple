using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Repositories;

/// <summary>
/// Репозиторий врачей, работающий с базой данных PostgreSQL.
/// </summary>
public class DoctorRepositoryDb : IDoctorRepository
{
    private readonly DataContext _context;
    private readonly ILogger<DoctorRepositoryDb> _logger;

    public DoctorRepositoryDb(DataContext context, ILogger<DoctorRepositoryDb> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить список всех врачей.
    /// </summary>
    public IReadOnlyList<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    /// <summary>
    /// Добавить нового врача.
    /// </summary>
    public void Add(Doctor doctor)
    {
        _logger.LogInformation($"Добавление врача: {doctor.FullName}");
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновить данные врача.
    /// </summary>
    public void Update(Doctor doctor)
    {
        _logger.LogInformation($"Обновление врача ID: {doctor.Id}");

        // 1. Ищем существующую запись в базе (или в кэше EF)
        var existing = _context.Doctors.Find(doctor.Id);

        if (existing != null)
        {
            // 2.копируем новые значения в существующий объект
            _context.Entry(existing).CurrentValues.SetValues(doctor);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Удалить врача по ID.
    /// </summary>
    public void Delete(int id)
    {
        _logger.LogInformation($"Удаление врача ID: {id}");
        var doctor = _context.Doctors.Find(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}