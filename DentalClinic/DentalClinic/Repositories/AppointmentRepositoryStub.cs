using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Repositories;

/// <summary>
/// Репозиторий приёмов, работающий с базой данных PostgreSQL.
/// </summary>
public class AppointmentRepositoryDb : IAppointmentRepository
{
    private readonly DataContext _context;
    private readonly ILogger<AppointmentRepositoryDb> _logger;

    public AppointmentRepositoryDb(DataContext context, ILogger<AppointmentRepositoryDb> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить список всех приёмов.
    /// </summary>
    public IReadOnlyList<Appointment> GetAll()
    {
        return _context.Appointments.ToList();
    }

    /// <summary>
    /// Добавить новый приём.
    /// </summary>
    public void Add(Appointment appointment)
    {
        _logger.LogInformation($"Добавление приёма для пациента ID: {appointment.PatientId}");
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
    }
}