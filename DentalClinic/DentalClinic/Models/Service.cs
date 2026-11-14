using System;
using System.ComponentModel.DataAnnotations;
using DentalClinic.Enums;
namespace DentalClinic.Models;

/// <summary>
/// Сущность "Услуга".
/// </summary>
public class Service
{
    /// <summary>Идентификатор</summary>
    [Key]
    public int Id { get; protected internal set; }

    /// <summary>Название услуги</summary>
    [Required]
    [MaxLength(150)]
    public string Name { get; protected internal set; } = string.Empty;

    /// <summary>Тип услуги (флаговое перечисление)</summary>
    [Required]
    public ServiceType Type { get; protected internal set; }

    /// <summary>Стоимость услуги</summary>
    public decimal Price { get; protected internal set; }

    protected internal Service() { }

    public static Service Create(string name, ServiceType type, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название не может быть пустым");
        if (price < 0) throw new ArgumentException("Цена не может быть отрицательной");

        return new Service { Name = name, Type = type, Price = price };
    }

    public static Service Restore(int id, string name, ServiceType type, decimal price)
    {
        var s = Create(name, type, price);
        s.Id = id;
        return s;
    }
}