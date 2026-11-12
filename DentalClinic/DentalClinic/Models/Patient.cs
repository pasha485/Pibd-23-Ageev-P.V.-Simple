using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DentalClinic.Models;

/// <summary>
/// Сущность "Пациент".
/// </summary>
public class Patient
{
    /// <summary>Идентификатор (первичный ключ)</summary>
    [Key]
    public int Id { get; protected internal set; }

    /// <summary>ФИО пациента</summary>
    [Required]
    [MaxLength(100)]
    public string FullName { get; protected internal set; } = string.Empty;

    /// <summary>Дата рождения</summary>
    public DateTime BirthDate { get; protected internal set; }

    /// <summary>Контактный телефон</summary>
    [Required]
    [MaxLength(20)]
    public string Phone { get; protected internal set; } = string.Empty;

    /// <summary>Номер медицинского полиса</summary>
    [Required]
    [MaxLength(20)]
    public string PolicyNumber { get; protected internal set; } = string.Empty;

    /// <summary>
    /// Конструктор для Entity Framework.
    /// </summary>
    protected internal Patient() { }

    /// <summary>
    /// Статический метод создания нового пациента.
    /// </summary>
    public static Patient Create(string fullName, DateTime birthDate, string phone, string policyNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("ФИО не может быть пустым");
        if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Телефон не может быть пустым");
        if (!phone.All(char.IsDigit)) throw new ArgumentException("Телефон должен состоять только из цифр");
        if (string.IsNullOrWhiteSpace(policyNumber)) throw new ArgumentException("Полис не может быть пустым");
        if (!policyNumber.All(char.IsDigit) || policyNumber.Length < 5) throw new ArgumentException("Номер полиса введен некорректно");
        if (birthDate > DateTime.Now) throw new ArgumentException("Дата рождения не может быть в будущем");

        return new Patient
        {
            FullName = fullName,
            BirthDate = birthDate,
            Phone = phone,
            PolicyNumber = policyNumber
        };
    }

    /// <summary>
    /// Восстановление пациента из БД.
    /// </summary>
    public static Patient Restore(int id, string fullName, DateTime birthDate, string phone, string policyNumber)
    {
        var p = Create(fullName, birthDate, phone, policyNumber);
        p.Id = id;
        return p;
    }
}