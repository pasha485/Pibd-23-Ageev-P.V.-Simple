using System;
using System.Linq; // Обязательно для метода .All()

namespace DentalClinic.Models;

/// <summary>
/// Сущность "Пациент".
/// </summary>
public class Patient
{
    /// <summary>Идентификатор (первичный ключ)</summary>
    public int Id { get; private set; }

    /// <summary>ФИО пациента</summary>
    public string FullName { get; private set; } = string.Empty;

    /// <summary>Дата рождения</summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>Контактный телефон</summary>
    public string Phone { get; private set; } = string.Empty;

    /// <summary>Номер медицинского полиса</summary>
    public string PolicyNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Приватный конструктор (запрещает создание объекта без валидации).
    /// </summary>
    private Patient() { }

    /// <summary>
    /// Статический метод создания нового пациента (с проверками).
    /// </summary>
    public static Patient Create(string fullName, DateTime birthDate, string phone, string policyNumber)
    {
        // 1. Проверка ФИО на пустоту
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("ФИО не может быть пустым");

        // 2. Проверка телефона на пустоту и на наличие только цифр
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Телефон не может быть пустым");

        if (!phone.All(char.IsDigit))
            throw new ArgumentException("Телефон должен состоять только из цифр");

        // 3. Проверка полиса на пустоту, наличие только цифр и длину (обычно полис не короче 5 цифр)
        if (string.IsNullOrWhiteSpace(policyNumber))
            throw new ArgumentException("Полис не может быть пустым");

        if (!policyNumber.All(char.IsDigit))
            throw new ArgumentException("Номер полиса должен состоять только из цифр");

        if (policyNumber.Length < 5)
            throw new ArgumentException("Номер полиса слишком короткий (минимум 5 цифр)");

        // 4. Проверка даты рождения (нельзя родиться в будущем)
        if (birthDate > DateTime.Now)
            throw new ArgumentException("Дата рождения не может быть в будущем");

        return new Patient
        {
            FullName = fullName,
            BirthDate = birthDate,
            Phone = phone,
            PolicyNumber = policyNumber
        };
    }

    /// <summary>
    /// Восстановление пациента из БД (с присвоением Id).
    /// </summary>
    public static Patient Restore(int id, string fullName, DateTime birthDate, string phone, string policyNumber)
    {
        // Метод Restore вызывает Create, поэтому все проверки сработают и здесь.
        var p = Create(fullName, birthDate, phone, policyNumber);
        p.Id = id;
        return p;
    }
}