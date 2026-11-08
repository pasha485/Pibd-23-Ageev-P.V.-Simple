using DentalClinic.Models;

namespace DentalClinic.Interfaces;

/// <summary>
/// Интерфейс репозитория для врачей (CRUD).
/// </summary>
public interface IDoctorRepository
{
    IReadOnlyList<Doctor> GetAll();
    void Add(Doctor doctor);
    void Update(Doctor doctor);
    void Delete(int id);
}