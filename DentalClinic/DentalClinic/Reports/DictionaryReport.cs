using DentalClinic.Builders;
using DentalClinic.Enums;
using DentalClinic.Interfaces;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace DentalClinic.Reports;

/// <summary>
/// Выгрузка выбранных справочников стоматологической клиники в Word.
/// </summary>
public class DictionaryReport
{
    private static readonly CultureInfo ReportCulture = CultureInfo.GetCultureInfo("ru-RU");
    private readonly IPatientRepository _patRepo;
    private readonly IDoctorRepository _docRepo;
    private readonly IServiceRepository _srvRepo;
    private readonly ILogger<DictionaryReport> _logger;

    public DictionaryReport(IPatientRepository patRepo, IDoctorRepository docRepo, IServiceRepository srvRepo,
        ILogger<DictionaryReport> logger)
    {
        _patRepo = patRepo;
        _docRepo = docRepo;
        _srvRepo = srvRepo;
        _logger = logger;
    }

    /// <summary>
    /// Сохраняет один документ с отдельной таблицей для каждого выбранного справочника.
    /// </summary>
    public void Generate(string path, bool exportPatients, bool exportDoctors, bool exportServices)
    {
        try
        {
            _logger.LogInformation("Формирование справочников Word: пациенты {Patients}, врачи {Doctors}, услуги {Services}",
                exportPatients, exportDoctors, exportServices);

            if (!exportPatients && !exportDoctors && !exportServices)
                throw new ArgumentException("Выберите хотя бы один справочник.");

            var builder = new WordBuilder();
            builder.AddHeading("Справочники стоматологической клиники");
            builder.AddText("Дата выгрузки: " + DateTime.Today.ToString("dd.MM.yyyy"));

            if (exportPatients)
            {
                var rows = _patRepo.GetAll().OrderBy(p => p.Id).Select(p => new[]
                {
                    p.Id.ToString(), p.FullName, p.BirthDate.ToString("dd.MM.yyyy"), p.Phone, p.PolicyNumber
                });
                AddDictionary(builder, "Пациенты", ["ID", "ФИО", "Дата рождения", "Телефон", "Номер полиса"],
                    rows, [650, 3150, 1600, 1750, 1850]);
            }

            if (exportDoctors)
            {
                var rows = _docRepo.GetAll().OrderBy(d => d.Id).Select(d => new[]
                {
                    d.Id.ToString(), d.FullName, GetSpecializationName(d.Specialization), d.Rate.ToString("N2", ReportCulture)
                });
                AddDictionary(builder, "Врачи", ["ID", "ФИО", "Специализация", "Ставка"],
                    rows, [650, 3600, 3000, 1750]);
            }

            if (exportServices)
            {
                var rows = _srvRepo.GetAll().OrderBy(s => s.Id).Select(s => new[]
                {
                    s.Id.ToString(), s.Name, GetServiceTypeName(s.Type), s.Price.ToString("N2", ReportCulture)
                });
                AddDictionary(builder, "Услуги", ["ID", "Название", "Тип", "Цена"],
                    rows, [650, 3150, 3450, 1750]);
            }

            builder.Save(path);
            _logger.LogInformation("Справочники Word сохранены: {Path}", path);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка формирования справочников Word: {Path}", path);
            throw;
        }
    }

    /// <summary>
    /// Добавляет заголовок и таблицу справочника, в том числе если он пуст.
    /// </summary>
    private static void AddDictionary(WordBuilder builder, string title, string[] headers,
        IEnumerable<string[]> rows, int[] columnWidths)
    {
        builder.AddHeading(title);
        builder.AddTable(rows.Prepend(headers), columnWidths);
    }

    private static string GetSpecializationName(DoctorSpecialization specialization)
    {
        return specialization switch
        {
            DoctorSpecialization.Therapist => "Терапевт",
            DoctorSpecialization.Surgeon => "Хирург",
            DoctorSpecialization.Orthodontist => "Ортодонт",
            DoctorSpecialization.Prosthodontist => "Ортопед",
            _ => specialization.ToString()
        };
    }

    private static string GetServiceTypeName(ServiceType type)
    {
        if (type == ServiceType.None) return "Не указан";

        var names = new (ServiceType Type, string Name)[]
        {
            (ServiceType.Filling, "Пломбирование"),
            (ServiceType.Removal, "Удаление"),
            (ServiceType.Prosthetics, "Протезирование"),
            (ServiceType.Cleaning, "Чистка")
        };
        var matches = names.Where(item => type.HasFlag(item.Type)).Select(item => item.Name);
        const ServiceType knownTypes = ServiceType.Filling | ServiceType.Removal | ServiceType.Prosthetics | ServiceType.Cleaning;
        if ((type & ~knownTypes) != 0) return type.ToString();

        return string.Join(", ", matches);
    }
}
