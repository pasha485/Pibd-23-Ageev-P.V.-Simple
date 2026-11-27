using DentalClinic.Builders;
using DentalClinic.Interfaces;
using Microsoft.Extensions.Logging;

namespace DentalClinic.Reports;

/// <summary>
/// Отчёт PDF с распределением оказанных услуг за день.
/// </summary>
public class ServicesChartReport
{
    private readonly IAppointmentRepository _appRepo;
    private readonly IAppointmentServiceRepository _appSrvRepo;
    private readonly IServiceRepository _srvRepo;
    private readonly ILogger<ServicesChartReport> _logger;

    public ServicesChartReport(IAppointmentRepository appRepo, IAppointmentServiceRepository appSrvRepo,
        IServiceRepository srvRepo, ILogger<ServicesChartReport> logger)
    {
        _appRepo = appRepo;
        _appSrvRepo = appSrvRepo;
        _srvRepo = srvRepo;
        _logger = logger;
    }

    /// <summary>
    /// Сохраняет круговую диаграмму по количеству оказанных услуг каждого наименования.
    /// </summary>
    public void Generate(string path, DateTime date)
    {
        try
        {
            date = date.Date;
            _logger.LogInformation("Формирование диаграммы услуг PDF за {Date:dd.MM.yyyy}", date);

            var appointmentIds = _appRepo.GetAll()
                .Where(a => a.Date.Date == date)
                .Select(a => a.Id)
                .ToArray();
            var quantities = _appSrvRepo.GetByAppointmentIds(appointmentIds)
                .Where(s => s.Quantity > 0)
                .GroupBy(s => s.ServiceId)
                .Select(group => new { ServiceId = group.Key, Quantity = group.Sum(s => s.Quantity) })
                .OrderByDescending(s => s.Quantity)
                .ThenBy(s => s.ServiceId)
                .ToList();

            var builder = new PdfBuilder();
            builder.AddHeading("Распределение оказанных услуг");
            builder.AddText($"Дата приёма: {date:dd.MM.yyyy}");
            if (quantities.Count == 0)
            {
                builder.AddText("За выбранную дату оказанных услуг не найдено.");
            }
            else
            {
                var names = _srvRepo.GetAll().ToDictionary(s => s.Id, s => s.Name);
                var chartValues = quantities.ToDictionary(
                    s => $"{names.GetValueOrDefault(s.ServiceId, "Неизвестная услуга")} (ID: {s.ServiceId})",
                    s => s.Quantity);
                builder.AddText($"Всего оказано услуг: {chartValues.Values.Sum(q => (long)q)} ед.");
                builder.AddPieChart(chartValues);
            }

            builder.Save(path);
            _logger.LogInformation("Диаграмма услуг PDF сохранена: {Path}", path);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка формирования диаграммы услуг PDF: {Path}", path);
            throw;
        }
    }
}
