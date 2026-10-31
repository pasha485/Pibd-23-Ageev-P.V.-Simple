namespace DentalClinic.Models;

/// <summary>
/// Заглушка репозитория пациентов (хранит данные в памяти).
/// </summary>
public class PatientRepositoryStub : IPatientRepository
{
    private readonly List<Patient> _items = new(); // Хранилище
    private int _nextId = 1;                       // Счетчик для Id

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