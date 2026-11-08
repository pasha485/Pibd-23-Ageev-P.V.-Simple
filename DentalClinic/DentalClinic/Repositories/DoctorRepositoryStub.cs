using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Repositories;

/// <summary>
/// Заглушка репозитория врачей.
/// </summary>
public class DoctorRepositoryStub : IDoctorRepository
{
    private readonly List<Doctor> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<Doctor> GetAll() => _items;

    public void Add(Doctor d)
    {
        _items.Add(Doctor.Restore(_nextId++, d.FullName, d.Specialization, d.Rate));
    }

    public void Update(Doctor d)
    {
        var i = _items.FindIndex(x => x.Id == d.Id);
        if (i >= 0) _items[i] = d;
    }

    public void Delete(int id) => _items.RemoveAll(x => x.Id == id);
}