namespace DentalClinic.Models;

/// <summary>
/// Класс-связка для отношения "многие-ко-многим".
/// Связывает Приём и Услугу.
/// </summary>
public class AppointmentService
{
    /// <summary>Идентификатор</summary>
    public int Id { get; private set; }

    /// <summary>Ссылка на приём (внешний ключ)</summary>
    public int AppointmentId { get; private set; }

    /// <summary>Ссылка на услугу (внешний ключ)</summary>
    public int ServiceId { get; private set; }

    /// <summary>Количество оказанных услуг</summary>
    public int Quantity { get; private set; }

    /// <summary>Стоимость использованных материалов</summary>
    public decimal MaterialsCost { get; private set; }

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private AppointmentService() { }

    /// <summary>
    /// Создание записи об оказанной услуге.
    /// </summary>
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

    /// <summary>
    /// Восстановление связи из БД.
    /// </summary>
    public static AppointmentService Restore(int id, int appointmentId, int serviceId, int quantity, decimal materialsCost)
    {
        var item = Create(appointmentId, serviceId, quantity, materialsCost);
        item.Id = id;
        return item;
    }
}