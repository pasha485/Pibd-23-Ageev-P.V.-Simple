using DentalClinic.Interfaces;
using DentalClinic.Repositories;
using Unity;

namespace DentalClinic;

/// <summary>
/// Статический класс для настройки IoC-контейнера.
/// </summary>
public static class IoCContainer
{
    public static IUnityContainer Configure()
    {
        var container = new UnityContainer();

        // Регистрация зависимостей (Интерфейсы -> Заглушки)
        container.RegisterType<IPatientRepository, PatientRepositoryStub>();
        container.RegisterType<IDoctorRepository, DoctorRepositoryStub>();
        container.RegisterType<IServiceRepository, ServiceRepositoryStub>();
        container.RegisterType<IAppointmentRepository, AppointmentRepositoryStub>();
        container.RegisterType<IAppointmentServiceRepository, AppointmentServiceRepositoryStub>();

        return container;
    }
}