namespace DentalClinic.Models;

/// <summary>
/// Сущность "Приём" (история лечения).
/// </summary>
public class Appointment
{
    /// <summary>Идентификатор</summary>
    public int Id { get; private set; }

    /// <summary>Ссылка на пациента (внешний ключ)</summary>
    public int PatientId { get; private set; }

    /// <summary>Ссылка на врача (внешний ключ)</summary>
    public int DoctorId { get; private set; }

    /// <summary>Дата и время приёма</summary>
    public DateTime Date { get; private set; }

    /// <summary>Поставленный диагноз</summary>
    public string Diagnosis { get; private set; } = string.Empty;

    /// <summary>Статус оплаты (true - оплачено)</summary>
    public bool IsPaid { get; private set; }

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private Appointment() { }

    /// <summary>
    /// Создание нового приёма.
    /// </summary>
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

    /// <summary>
    /// Восстановление приёма из БД.
    /// </summary>
    public static Appointment Restore(int id, int patientId, int doctorId, DateTime date, string diagnosis, bool isPaid)
    {
        var a = Create(patientId, doctorId, date, diagnosis, isPaid);
        a.Id = id;
        return a;
    }
}