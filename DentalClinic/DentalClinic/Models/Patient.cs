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
        // Защита от null и пустых строк
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("ФИО не может быть пустым");
        if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Телефон не может быть пустым");
        if (string.IsNullOrWhiteSpace(policyNumber)) throw new ArgumentException("Полис не может быть пустым");

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
        var p = Create(fullName, birthDate, phone, policyNumber);
        p.Id = id;
        return p;
    }
}