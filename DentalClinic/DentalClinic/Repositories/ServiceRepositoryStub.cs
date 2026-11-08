using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Repositories;

/// <summary>
/// Заглушка репозитория услуг.
/// </summary>
public class ServiceRepositoryStub : IServiceRepository
{
    private readonly List<Service> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<Service> GetAll() => _items;

    public void Add(Service s)
    {
        _items.Add(Service.Restore(_nextId++, s.Name, s.Type, s.Price));
    }

    public void Update(Service s)
    {
        var i = _items.FindIndex(x => x.Id == s.Id);
        if (i >= 0) _items[i] = s;
    }

    public void Delete(int id) => _items.RemoveAll(x => x.Id == id);
}