namespace DentalClinic.Models;

/// <summary>
/// Сущность "Врач".
/// </summary>
public class Doctor
{
    /// <summary>Идентификатор</summary>
    public int Id { get; private set; }

    /// <summary>ФИО врача</summary>
    public string FullName { get; private set; } = string.Empty;

    /// <summary>Специализация</summary>
    public DoctorSpecialization Specialization { get; private set; }

    /// <summary>Ставка (оклад)</summary>
    public decimal Rate { get; private set; }

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private Doctor() { }

    /// <summary>
    /// Создание нового врача.
    /// </summary>
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

    /// <summary>
    /// Восстановление врача из БД.
    /// </summary>
    public static Doctor Restore(int id, string fullName, DoctorSpecialization specialization, decimal rate)
    {
        var d = Create(fullName, specialization, rate);
        d.Id = id;
        return d;
    }
}