using DentalClinic.Models;

namespace DentalClinic.Interfaces;

/// <summary>
/// Интерфейс репозитория для приёмов.
/// </summary>
public interface IAppointmentRepository
{
    IReadOnlyList<Appointment> GetAll();
    void Add(Appointment appointment);
}