using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Repositories;

/// <summary>
/// Заглушка репозитория пациентов (хранит данные в памяти).
/// </summary>
public class PatientRepositoryStub : IPatientRepository
{
    private readonly List<Patient> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<Patient> GetAll() => _items;

    public void Add(Patient p)
    {
        _items.Add(Patient.Restore(_nextId++, p.FullName, p.BirthDate, p.Phone, p.PolicyNumber));
    }

    public void Update(Patient p)
    {
        var i = _items.FindIndex(x => x.Id == p.Id);
        if (i >= 0) _items[i] = p;
    }

    public void Delete(int id) => _items.RemoveAll(x => x.Id == id);
}