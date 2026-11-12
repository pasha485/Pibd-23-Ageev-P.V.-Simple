using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models;

/// <summary>
/// Сущность "Приём" (история лечения).
/// </summary>
public class Appointment
{
    /// <summary>Идентификатор</summary>
    [Key]
    public int Id { get; protected internal set; }

    /// <summary>Ссылка на пациента (внешний ключ)</summary>
    [Required]
    [ForeignKey(nameof(Patient))] // Атрибут связи
    public int PatientId { get; protected internal set; }

    /// <summary>Навигационное свойство к пациенту</summary>
    public virtual Patient Patient { get; protected internal set; }

    /// <summary>Ссылка на врача (внешний ключ)</summary>
    [Required]
    [ForeignKey(nameof(Doctor))] // Атрибут связи
    public int DoctorId { get; protected internal set; }

    /// <summary>Навигационное свойство к врачу</summary>
    public virtual Doctor Doctor { get; protected internal set; }

    /// <summary>Дата и время приёма</summary>
    [Column("AppointmentDate")] // Атрибут переименования колонки в БД
    public DateTime Date { get; protected internal set; }

    /// <summary>Поставленный диагноз</summary>
    [Required]
    [MaxLength(250)]
    public string Diagnosis { get; protected internal set; } = string.Empty;

    /// <summary>Статус оплаты (true - оплачено)</summary>
    public bool IsPaid { get; protected internal set; }

    protected internal Appointment() { }

    public static Appointment Create(int patientId, int doctorId, DateTime date, string diagnosis, bool isPaid)
    {
        if (patientId <= 0) throw new ArgumentException("Не указан пациент");
        if (doctorId <= 0) throw new ArgumentException("Не указан врач");
        if (string.IsNullOrWhiteSpace(diagnosis)) throw new ArgumentException("Диагноз не может быть пустым");

        return new Appointment
        {
            PatientId = patientId,
            DoctorId = doctorId,
            Date = date,
            Diagnosis = diagnosis,
            IsPaid = isPaid
        };
    }

    public static Appointment Restore(int id, int patientId, int doctorId, DateTime date, string diagnosis, bool isPaid)
    {
        var a = Create(patientId, doctorId, date, diagnosis, isPaid);
        a.Id = id;
        return a;
    }
}