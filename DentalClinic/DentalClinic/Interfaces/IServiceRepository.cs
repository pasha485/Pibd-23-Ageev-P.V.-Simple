using DentalClinic.Models;

namespace DentalClinic.Interfaces;

/// <summary>
/// Интерфейс репозитория для услуг (CRUD).
/// </summary>
public interface IServiceRepository
{
    IReadOnlyList<Service> GetAll();
    void Add(Service service);
    void Update(Service service);
    void Delete(int id);
}