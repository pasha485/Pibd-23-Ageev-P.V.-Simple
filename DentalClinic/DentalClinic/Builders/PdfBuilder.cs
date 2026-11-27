using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;

namespace DentalClinic.Builders;

/// <summary>Создаёт отчёт PDF с текстом и круговыми диаграммами.</summary>
public sealed class PdfBuilder
{
    // Версия GDI использует установленную в Windows Arial; PDFsharp встраивает подмножества глифов.
    private const string FontName = "Arial";
    private readonly Document _document = new();
    private readonly Section _section;

    /// <summary>Создаёт пустой отчёт с поддержкой кириллицы.</summary>
    public PdfBuilder()
    {
        var normal = _document.Styles[StyleNames.Normal]!;
        normal.Font.Name = FontName;
        normal.Font.Size = 11;
        normal.ParagraphFormat.SpaceAfter = Unit.FromPoint(6);

        var heading = _document.Styles[StyleNames.Heading1]!;
        heading.Font.Name = FontName;
        heading.Font.Size = 16;
        heading.Font.Bold = true;
        heading.ParagraphFormat.KeepWithNext = true;
        _section = _document.AddSection();
        _section.PageSetup.PageFormat = PageFormat.A4;
        _section.PageSetup.LeftMargin = Unit.FromCentimeter(2);
        _section.PageSetup.RightMargin = Unit.FromCentimeter(2);
    }

    /// <summary>Добавляет выделенный жирным заголовок.</summary>
    public void AddHeading(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _section.AddParagraph(text, StyleNames.Heading1);
    }

    /// <summary>Добавляет абзац текста.</summary>
    public void AddText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        _section.AddParagraph(text);
    }

    /// <summary>Добавляет круговую диаграмму с процентными подписями и легендой категорий.</summary>
    public void AddPieChart(IReadOnlyDictionary<string, int> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        var entries = values.ToArray();
        if (entries.Any(entry => entry.Value < 0))
            throw new ArgumentException("Значения круговой диаграммы не могут быть отрицательными.", nameof(values));
        if (entries.Length == 0 || entries.All(entry => entry.Value == 0))
        {
            AddText("Нет данных для диаграммы.");
            return;
        }

        var chart = _section.AddChart(ChartType.Pie2D);
        chart.Width = Unit.FromCentimeter(17);
        chart.Height = Unit.FromCentimeter(10);
        chart.Format.Font.Name = FontName;
        chart.Format.Font.Size = 10;
        chart.HasDataLabel = true;
        chart.DataLabel.Type = DataLabelType.Percent;
        chart.DataLabel.Position = DataLabelPosition.Center;
        chart.DataLabel.Format = "0.#";
        chart.DataLabel.Font.Name = FontName;
        chart.DataLabel.Font.Size = 10;

        var legend = chart.RightArea.AddLegend();
        legend.Format.Font.Name = FontName;
        legend.Format.Font.Size = 10;
        var categories = chart.XValues.AddXSeries();
        var series = chart.SeriesCollection.AddSeries();
        foreach (var (label, value) in entries)
        {
            categories.Add(label);
            series.Add(value);
        }
    }

    /// <summary>Сохраняет отчёт в файле PDF по указанному пути.</summary>
    public void Save(string path)
    {
        var renderer = new PdfDocumentRenderer { Document = _document.Clone(), Language = "ru-RU" };
        renderer.RenderDocument();
        using var pdf = renderer.PdfDocument;
        renderer.Save(path);
    }
}
