using DentalClinic.Builders;
using DentalClinic.Interfaces;
using Microsoft.Extensions.Logging;

namespace DentalClinic.Reports;

/// <summary>
/// Отчёт Excel по приёмам и оказанным услугам в разрезе пациентов.
/// </summary>
public class OperationsReport
{
    private readonly IPatientRepository _patRepo;
    private readonly IAppointmentRepository _appRepo;
    private readonly IAppointmentServiceRepository _appSrvRepo;
    private readonly ILogger<OperationsReport> _logger;

    public OperationsReport(IPatientRepository patRepo, IAppointmentRepository appRepo,
        IAppointmentServiceRepository appSrvRepo, ILogger<OperationsReport> logger)
    {
        _patRepo = patRepo;
        _appRepo = appRepo;
        _appSrvRepo = appSrvRepo;
        _logger = logger;
    }

    /// <summary>
    /// Сохраняет сведения по пациентам за период, включая обе даты.
    /// </summary>
    public void Generate(string path, DateTime startDate, DateTime endDate)
    {
        try
        {
            startDate = startDate.Date;
            endDate = endDate.Date;
            _logger.LogInformation("Формирование операций Excel: с {StartDate:dd.MM.yyyy} по {EndDate:dd.MM.yyyy}",
                startDate, endDate);

            if (startDate > endDate)
                throw new ArgumentException("Дата начала не может быть позже даты окончания.");

            var appointments = _appRepo.GetAll()
                .Where(a => a.Date.Date >= startDate && a.Date.Date <= endDate)
                .ToList();
            var servicesByAppointment = _appSrvRepo.GetByAppointmentIds(appointments.Select(a => a.Id).ToArray())
                .ToLookup(s => s.AppointmentId);
            var patients = _patRepo.GetAll().ToDictionary(p => p.Id, p => p.FullName);

            var operations = appointments.GroupBy(a => a.PatientId)
                .Select(group =>
                {
                    var services = group.SelectMany(a => servicesByAppointment[a.Id]).ToList();
                    return new
                    {
                        PatientId = group.Key,
                        PatientName = patients.GetValueOrDefault(group.Key, "Неизвестный пациент"),
                        Appointments = group.Count(),
                        PaidAppointments = group.Count(a => a.IsPaid),
                        Services = services.Sum(s => (long)s.Quantity),
                        MaterialsCost = services.Sum(s => s.MaterialsCost)
                    };
                })
                .OrderBy(o => o.PatientName)
                .ThenBy(o => o.PatientId)
                .ToList();

            var builder = new ExcelBuilder();
            builder.AddHeading("Приёмы и услуги по пациентам");
            builder.AddText($"Период: {startDate:dd.MM.yyyy} — {endDate:dd.MM.yyyy} (включительно)");
            if (operations.Count == 0) builder.AddText("За указанный период приёмов не найдено.");

            var rows = operations.Select(o => new object?[]
            {
                o.PatientId, o.PatientName, o.Appointments, o.PaidAppointments, o.Services, o.MaterialsCost
            });
            builder.AddTable(["ID пациента", "Пациент", "Приёмы", "Оплаченные приёмы", "Оказано услуг, ед.", "Стоимость материалов"],
                rows, ["Итого", null, operations.Sum(o => o.Appointments), operations.Sum(o => o.PaidAppointments),
                    operations.Sum(o => o.Services), operations.Sum(o => o.MaterialsCost)]);

            builder.Save(path);
            _logger.LogInformation("Операции Excel сохранены: {Path}", path);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка формирования операций Excel: {Path}", path);
            throw;
        }
    }
}
