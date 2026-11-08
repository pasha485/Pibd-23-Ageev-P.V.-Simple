namespace DentalClinic.Enums;

/// <summary>
/// Флаговое перечисление. Позволяет комбинировать типы услуг (например, пломба + чистка).
/// Значения кратны степеням двойки: 1, 2, 4, 8.
/// </summary>
[Flags]
public enum ServiceType
{
    /// <summary>Нет услуги</summary>
    None = 0,

    /// <summary>Установка пломбы</summary>
    Filling = 1,

    /// <summary>Удаление зуба</summary>
    Removal = 2,

    /// <summary>Протезирование</summary>
    Prosthetics = 4,

    /// <summary>Профессиональная чистка</summary>
    Cleaning = 8
}