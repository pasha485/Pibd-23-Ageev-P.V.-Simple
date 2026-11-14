using DentalClinic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models;

/// <summary>
/// Сущность "Врач".
/// </summary>
public class Doctor
{
    /// <summary>Идентификатор</summary>
    [Key]
    public int Id { get; protected internal set; }

    /// <summary>ФИО врача</summary>
    [Required]
    [MaxLength(100)]
    public string FullName { get; protected internal set; } = string.Empty;

    /// <summary>Специализация</summary>
    [Required]
    public DoctorSpecialization Specialization { get; protected internal set; }

    /// <summary>Ставка (оклад)</summary>
    public decimal Rate { get; protected internal set; }

    protected internal Doctor() { }

    public static Doctor Create(string fullName, DoctorSpecialization specialization, decimal rate)
    {
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("ФИО не может быть пустым");
        if (rate < 0) throw new ArgumentException("Ставка не может быть отрицательной");

        return new Doctor
        {
            FullName = fullName,
            Specialization = specialization,
            Rate = rate
        };
    }

    public static Doctor Restore(int id, string fullName, DoctorSpecialization specialization, decimal rate)
    {
        var d = Create(fullName, specialization, rate);
        d.Id = id;
        return d;
    }
}