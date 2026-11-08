using DentalClinic.Models;

namespace DentalClinic.Interfaces;

/// <summary>
/// Интерфейс репозитория для услуг на приёме.
/// </summary>
public interface IAppointmentServiceRepository
{
    IReadOnlyList<AppointmentService> GetByAppointmentId(int appointmentId);
    void Add(AppointmentService item);
    void Delete(int id);
}