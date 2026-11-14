using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Repositories;

/// <summary>
/// Репозиторий услуг на приёме (связь многие-ко-многим), работающий с БД.
/// </summary>
public class AppointmentServiceRepositoryDb : IAppointmentServiceRepository
{
    private readonly DataContext _context;
    private readonly ILogger<AppointmentServiceRepositoryDb> _logger;

    public AppointmentServiceRepositoryDb(DataContext context, ILogger<AppointmentServiceRepositoryDb> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить все услуги для конкретного приёма.
    /// </summary>
    public IReadOnlyList<AppointmentService> GetByAppointmentId(int appointmentId)
    {
        return _context.AppointmentServices
            .Where(x => x.AppointmentId == appointmentId)
            .ToList();
    }

    /// <summary>
    /// Добавить услугу к приёму (с использованием транзакции).
    /// </summary>
    public void Add(AppointmentService item)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            _logger.LogInformation($"Добавление услуги ID:{item.ServiceId} к приёму ID:{item.AppointmentId}");

            _context.AppointmentServices.Add(item);
            _context.SaveChanges();

            transaction.Commit();
            _logger.LogInformation("Услуга успешно добавлена (транзакция закоммичена).");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(ex, "Ошибка при добавлении услуги. Транзакция отменена.");
            throw;
        }
    }

    /// <summary>
    /// Удалить услугу из приёма.
    /// </summary>
    public void Delete(int id)
    {
        _logger.LogInformation($"Удаление связи услуги ID: {id}");
        var item = _context.AppointmentServices.Find(id);
        if (item != null)
        {
            _context.AppointmentServices.Remove(item);
            _context.SaveChanges();
        }
    }
}