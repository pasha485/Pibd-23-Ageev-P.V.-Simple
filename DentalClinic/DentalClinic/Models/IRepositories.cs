namespace DentalClinic.Models;

/// <summary>
/// Интерфейс репозитория для пациентов (CRUD).
/// </summary>
public interface IPatientRepository
{
    IReadOnlyList<Patient> GetAll();   // Получить всех
    void Add(Patient patient);         // Добавить
    void Update(Patient patient);      // Обновить
    void Delete(int id);               // Удалить
}

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

/// <summary>
/// Интерфейс репозитория для приёмов (без редактирования).
/// </summary>
public interface IAppointmentRepository
{
    IReadOnlyList<Appointment> GetAll();
    void Add(Appointment appointment);
}

/// <summary>
/// Интерфейс репозитория для услуг на приёме (связь).
/// </summary>
public interface IAppointmentServiceRepository
{
    IReadOnlyList<AppointmentService> GetByAppointmentId(int appointmentId); // Получить по ID приёма
    void Add(AppointmentService item);
    void Delete(int id);
}