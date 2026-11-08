using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Repositories;

/// <summary>
/// Заглушка репозитория услуг на приёме.
/// </summary>
public class AppointmentServiceRepositoryStub : IAppointmentServiceRepository
{
    private readonly List<AppointmentService> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<AppointmentService> GetByAppointmentId(int id) =>
        _items.Where(x => x.AppointmentId == id).ToList();

    public void Add(AppointmentService item)
    {
        _items.Add(AppointmentService.Restore(_nextId++, item.AppointmentId, item.ServiceId, item.Quantity, item.MaterialsCost));
    }

    public void Delete(int id) => _items.RemoveAll(x => x.Id == id);
}