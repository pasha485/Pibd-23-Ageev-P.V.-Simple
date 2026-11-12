using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Repositories;

/// <summary>
/// Репозиторий услуг, работающий с базой данных PostgreSQL.
/// </summary>
public class ServiceRepositoryDb : IServiceRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ServiceRepositoryDb> _logger;

    public ServiceRepositoryDb(DataContext context, ILogger<ServiceRepositoryDb> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Получить список всех услуг.
    /// </summary>
    public IReadOnlyList<Service> GetAll()
    {
        return _context.Services.ToList();
    }

    /// <summary>
    /// Добавить новую услугу.
    /// </summary>
    public void Add(Service service)
    {
        _logger.LogInformation($"Добавление услуги: {service.Name}");
        _context.Services.Add(service);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновить данные услуги.
    /// </summary>
    public void Update(Service service)
    {
        _logger.LogInformation($"Обновление услуги ID: {service.Id}");
        _context.Services.Update(service);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удалить услугу по ID.
    /// </summary>
    public void Delete(int id)
    {
        _logger.LogInformation($"Удаление услуги ID: {id}");
        var service = _context.Services.Find(id);
        if (service != null)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }
    }
}