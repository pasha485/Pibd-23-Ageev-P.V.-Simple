using System.Globalization;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DentalClinic.Builders;

/// <summary>Создаёт отчёт Word в формате DOCX.</summary>
public sealed class WordBuilder
{
    private readonly Body _body = new();

    /// <summary>Создаёт пустой отчёт Word.</summary>
    public WordBuilder() { }

    /// <summary>Добавляет выделенный жирным заголовок.</summary>
    public void AddHeading(string text)
    {
        var paragraph = CreateParagraph(text, bold: true);
        paragraph.PrependChild(new ParagraphProperties(new KeepNext(), new OutlineLevel { Val = 0 }));
        paragraph.GetFirstChild<Run>()!.RunProperties!.Append(new FontSize { Val = "32" });
        _body.Append(paragraph);
    }

    /// <summary>Добавляет абзац текста.</summary>
    public void AddText(string text) => _body.Append(CreateParagraph(text));

    /// <summary>Добавляет таблицу с заголовком в первой строке и ширинами столбцов в твипах.</summary>
    public void AddTable(IEnumerable<IReadOnlyList<string>> rows, IReadOnlyList<int> columnWidths)
    {
        ArgumentNullException.ThrowIfNull(rows);
        ArgumentNullException.ThrowIfNull(columnWidths);
        if (columnWidths.Count == 0 || columnWidths.Any(width => width <= 0))
            throw new ArgumentException("Ширина каждого столбца должна быть положительной.", nameof(columnWidths));

        var materializedRows = rows.ToList();
        if (materializedRows.Count == 0)
            return;
        if (materializedRows.Any(row => row is null || row.Count != columnWidths.Count))
            throw new ArgumentException("Число ячеек каждой строки должно совпадать с числом столбцов.", nameof(rows));

        var table = new Table(
            new TableProperties(
                new TableWidth
                {
                    Type = TableWidthUnitValues.Dxa,
                    Width = columnWidths.Sum().ToString(CultureInfo.InvariantCulture)
                },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 4 },
                    new LeftBorder { Val = BorderValues.Single, Size = 4 },
                    new BottomBorder { Val = BorderValues.Single, Size = 4 },
                    new RightBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }),
                new TableLayout { Type = TableLayoutValues.Fixed }),
            new TableGrid(columnWidths.Select(width => new GridColumn
            {
                Width = width.ToString(CultureInfo.InvariantCulture)
            })));

        TableRow CreateRow(IReadOnlyList<string> values, bool isHeader)
        {
            var row = new TableRow(values.Select((value, index) => new TableCell(
                new TableCellProperties(new TableCellWidth
                {
                    Type = TableWidthUnitValues.Dxa,
                    Width = columnWidths[index].ToString(CultureInfo.InvariantCulture)
                }),
                CreateParagraph(value, bold: isHeader))));
            if (isHeader)
                row.PrependChild(new TableRowProperties(new TableHeader()));
            return row;
        }

        table.Append(CreateRow(materializedRows.First(), isHeader: true));
        table.Append(materializedRows.Skip(1).Select(row => CreateRow(row, isHeader: false)));
        _body.Append(table);
    }

    /// <summary>Сохраняет отчёт в файле DOCX по указанному пути.</summary>
    public void Save(string path)
    {
        using var package = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);
        package.AddMainDocumentPart().Document = new Document((Body)_body.CloneNode(true));
    }

    private static Paragraph CreateParagraph(string text, bool bold = false)
    {
        ArgumentNullException.ThrowIfNull(text);
        var run = new Run();
        if (bold)
            run.RunProperties = new RunProperties(new Bold());
        var lines = text.ReplaceLineEndings("\n").Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (i != 0)
                run.Append(new Break());
            run.Append(new Text(lines[i]) { Space = SpaceProcessingModeValues.Preserve });
        }
        return new Paragraph(run);
    }
}
