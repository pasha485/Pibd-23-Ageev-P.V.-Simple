using DentalClinic.Data;
using DentalClinic.Interfaces;
using DentalClinic.Reports;
using DentalClinic.Repositories;
using Microsoft.Extensions.Logging;
using Serilog;
using Unity;
using Unity.Lifetime;

namespace DentalClinic;

public static class IoCContainer
{
    public static IUnityContainer Configure()
    {
        var container = new UnityContainer();

        // Создаем логгер для передачи в репозитории
        var loggerFactory = new LoggerFactory().AddSerilog();

        // Регистрируем логгер
        container.RegisterInstance<ILoggerFactory>(loggerFactory);
        container.RegisterType(typeof(ILogger<>), typeof(Logger<>), new TransientLifetimeManager());

        // Регистрируем DataContext и репозитории
        container.RegisterType<DataContext>();
        container.RegisterType<IPatientRepository, PatientRepositoryDb>();
        container.RegisterType<IDoctorRepository, DoctorRepositoryDb>();
        container.RegisterType<IServiceRepository, ServiceRepositoryDb>();
        container.RegisterType<IAppointmentRepository, AppointmentRepositoryDb>();
        container.RegisterType<IAppointmentServiceRepository, AppointmentServiceRepositoryDb>();

        // Регистрируем классы формирования отчётов
        container.RegisterType<DictionaryReport>();
        container.RegisterType<OperationsReport>();
        container.RegisterType<ServicesChartReport>();

        return container;
    }
}