using DentalClinic.Models;
using Unity;

namespace DentalClinic;

public static class IoCContainer
{
    public static IUnityContainer Configure()
    {
        var container = new UnityContainer();

        // Регистрируем интерфейсы. 
        // ВАЖНО: Здесь мы используем классы-заглушки (Stubs). 
        // Если студия подчеркивает их красным, значит ты не добавил папку Stubs в проект.
        container.RegisterType<IPatientRepository, Models.PatientRepositoryStub>();
        container.RegisterType<IDoctorRepository, Models.DoctorRepositoryStub>();
        container.RegisterType<IServiceRepository, Models.ServiceRepositoryStub>();
        container.RegisterType<IAppointmentRepository, Models.AppointmentRepositoryStub>();
        container.RegisterType<IAppointmentServiceRepository, Models.AppointmentServiceRepositoryStub>();

        return container;
    }
}