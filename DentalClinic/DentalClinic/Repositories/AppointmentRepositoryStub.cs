using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Repositories;

/// <summary>
/// Заглушка репозитория приёмов.
/// </summary>
public class AppointmentRepositoryStub : IAppointmentRepository
{
    private readonly List<Appointment> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<Appointment> GetAll() => _items;

    public void Add(Appointment a)
    {
        _items.Add(Appointment.Restore(_nextId++, a.PatientId, a.DoctorId, a.Date, a.Diagnosis, a.IsPaid));
    }
}