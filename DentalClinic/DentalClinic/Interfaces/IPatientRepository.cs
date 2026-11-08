using DentalClinic.Models;

namespace DentalClinic.Interfaces;

/// <summary>
/// Интерфейс репозитория для пациентов (CRUD).
/// </summary>
public interface IPatientRepository
{
    IReadOnlyList<Patient> GetAll();
    void Add(Patient patient);
    void Update(Patient patient);
    void Delete(int id);
}