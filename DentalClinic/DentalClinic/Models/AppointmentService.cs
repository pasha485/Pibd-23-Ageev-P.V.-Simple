using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models;

/// <summary>
/// Класс-связка для отношения "многие-ко-многим".
/// </summary>
public class AppointmentService
{
    /// <summary>Идентификатор</summary>
    [Key]
    public int Id { get; protected internal set; }

    /// <summary>Ссылка на приём (внешний ключ)</summary>
    [Required]
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; protected internal set; }

    /// <summary>Навигационное свойство к приёму</summary>
    public virtual Appointment Appointment { get; protected internal set; }

    /// <summary>Ссылка на услугу (внешний ключ)</summary>
    [Required]
    [ForeignKey(nameof(Service))]
    public int ServiceId { get; protected internal set; }

    /// <summary>Навигационное свойство к услуге</summary>
    public virtual Service Service { get; protected internal set; }

    /// <summary>Количество оказанных услуг</summary>
    public int Quantity { get; protected internal set; }

    /// <summary>Стоимость использованных материалов</summary>
    public decimal MaterialsCost { get; protected internal set; }

    protected internal AppointmentService() { }

    public static AppointmentService Create(int appointmentId, int serviceId, int quantity, decimal materialsCost)
    {
        if (appointmentId <= 0) throw new ArgumentException("Не указан приём");
        if (serviceId <= 0) throw new ArgumentException("Не указана услуга");
        if (quantity <= 0) throw new ArgumentException("Количество должно быть больше нуля");
        if (materialsCost < 0) throw new ArgumentException("Стоимость материалов не может быть отрицательной");

        return new AppointmentService
        {
            AppointmentId = appointmentId,
            ServiceId = serviceId,
            Quantity = quantity,
            MaterialsCost = materialsCost
        };
    }

    public static AppointmentService Restore(int id, int appointmentId, int serviceId, int quantity, decimal materialsCost)
    {
        var item = Create(appointmentId, serviceId, quantity, materialsCost);
        item.Id = id;
        return item;
    }
}