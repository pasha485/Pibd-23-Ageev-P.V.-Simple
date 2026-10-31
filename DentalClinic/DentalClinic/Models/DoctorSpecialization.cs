namespace DentalClinic.Models;

/// <summary>
/// Обычное перечисление. Определяет специализацию врача-стоматолога.
/// </summary>
public enum DoctorSpecialization
{
    /// <summary>Терапевт</summary>
    Therapist,

    /// <summary>Хирург</summary>
    Surgeon,

    /// <summary>Ортодонт</summary>
    Orthodontist,

    /// <summary>Ортопед (протезист)</summary>
    Prosthodontist
}