using DentalClinic.Enums;

namespace DentalClinic.Models;

/// <summary>
/// Сущность "Услуга" (справочник процедур).
/// </summary>
public class Service
{
    /// <summary>Идентификатор</summary>
    public int Id { get; private set; }

    /// <summary>Название услуги</summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>Тип услуги (флаговое перечисление)</summary>
    public ServiceType Type { get; private set; }

    /// <summary>Стоимость услуги</summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private Service() { }

    /// <summary>
    /// Создание новой услуги.
    /// </summary>
    public static Service Create(string name, ServiceType type, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название не может быть пустым");
        if (price < 0) throw new ArgumentException("Цена не может быть отрицательной");

        return new Service { Name = name, Type = type, Price = price };
    }

    /// <summary>
    /// Восстановление услуги из БД.
    /// </summary>
    public static Service Restore(int id, string name, ServiceType type, decimal price)
    {
        var s = Create(name, type, price);
        s.Id = id;
        return s;
    }
}