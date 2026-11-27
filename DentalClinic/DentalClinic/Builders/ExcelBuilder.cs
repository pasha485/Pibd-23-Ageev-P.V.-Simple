using System.Globalization;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using X = DocumentFormat.OpenXml.Spreadsheet;

namespace DentalClinic.Builders;

/// <summary>Создаёт однолистовой отчёт Excel в формате XLSX.</summary>
public sealed class ExcelBuilder
{
    private const uint HeadingStyle = 1;
    private const uint HeaderStyle = 2;
    private const uint TextCellStyle = 3;
    private const uint NumberCellStyle = 4;
    private const uint TotalTextStyle = 5;
    private const uint TotalNumberStyle = 6;
    private const int MaxColumns = 16_384;
    private const int MaxRows = 1_048_576;
    private readonly X.SheetData _sheetData = new();
    private readonly List<uint> _introRows = new();
    private readonly List<double> _columnWidths = new();
    private uint _rowCount;

    /// <summary>Создаёт пустой отчёт Excel.</summary>
    public ExcelBuilder() { }

    /// <summary>Добавляет выделенный жирным заголовок в отдельную строку.</summary>
    public void AddHeading(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        AppendIntroRow(text, HeadingStyle);
    }

    /// <summary>Добавляет текст в отдельную строку.</summary>
    public void AddText(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        AppendIntroRow(text, 0);
    }

    /// <summary>Добавляет таблицу с заголовками, данными и выделенной итоговой строкой.</summary>
    public void AddTable(IReadOnlyList<string> headers, IEnumerable<IReadOnlyList<object?>> rows,
        IReadOnlyList<object?> totals)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(rows);
        ArgumentNullException.ThrowIfNull(totals);
        if (headers.Count is 0 or > MaxColumns)
            throw new ArgumentException($"Таблица должна содержать от 1 до {MaxColumns} столбцов.", nameof(headers));
        if (totals.Count != headers.Count)
            throw new ArgumentException("Ширина итоговой строки должна совпадать с числом заголовков.", nameof(totals));
        EnsureRoom(2);

        var tableRows = new List<X.Row> { new(headers.Select(header => CreateCell(header, HeaderStyle))) };
        foreach (var row in rows)
        {
            if (row is null || row.Count != headers.Count)
                throw new ArgumentException("Ширина каждой строки должна совпадать с числом заголовков.", nameof(rows));
            EnsureRoom(tableRows.Count + 2);
            tableRows.Add(new X.Row(row.Select(value => CreateCell(value, TextCellStyle, NumberCellStyle))));
        }
        tableRows.Add(new X.Row(totals.Select(value => CreateCell(value, TotalTextStyle, TotalNumberStyle))));

        while (_columnWidths.Count < headers.Count)
            _columnWidths.Add(12);
        foreach (var row in tableRows)
        {
            int column = 0;
            foreach (var cell in row.Elements<X.Cell>())
            {
                _columnWidths[column] = Math.Max(_columnWidths[column], MeasureWidth(cell.InnerText));
                column++;
            }
            AppendRow(row);
        }
    }

    /// <summary>Сохраняет отчёт в файле XLSX по указанному пути.</summary>
    public void Save(string path)
    {
        using var package = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook);
        var workbookPart = package.AddWorkbookPart();
        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        var worksheet = new X.Worksheet();
        var widths = _columnWidths.Count > 0 ? _columnWidths : new List<double> { 48 };
        worksheet.Append(new X.Columns(widths.Select((width, index) => new X.Column
        {
            Min = (uint)(index + 1), Max = (uint)(index + 1), Width = width, CustomWidth = true
        })));
        var sheetData = (X.SheetData)_sheetData.CloneNode(true);
        worksheet.Append(sheetData);
        FormatIntroRows(worksheet, sheetData, widths);
        worksheetPart.Worksheet = worksheet;
        workbookPart.AddNewPart<WorkbookStylesPart>().Stylesheet = CreateStyles();
        workbookPart.Workbook = new X.Workbook(new X.Sheets(new X.Sheet
        {
            Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Отчёт"
        }));
    }

    private void AppendIntroRow(string text, uint style)
    {
        AppendRow(new X.Row(CreateCell(text.ReplaceLineEndings("\n"), style)));
        _introRows.Add(_rowCount);
    }

    private void FormatIntroRows(X.Worksheet worksheet, X.SheetData sheetData, IReadOnlyList<double> widths)
    {
        if (_introRows.Count == 0)
            return;

        var introIndices = _introRows.ToHashSet();
        double totalWidth = widths.Sum();
        foreach (var row in sheetData.Elements<X.Row>().Where(row => introIndices.Contains(row.RowIndex!.Value)))
        {
            var cell = row.GetFirstChild<X.Cell>()!;
            bool heading = cell.StyleIndex?.Value == HeadingStyle;
            double usableWidth = totalWidth / (heading ? 1.55 : 1.1);
            double estimatedLines = cell.InnerText.Split('\n')
                .Sum(line => Math.Max(1, Math.Ceiling((line.Length + 2) / usableWidth)));
            row.Height = Math.Min(409, estimatedLines * (heading ? 23 : 16));
            row.CustomHeight = true;
        }

        if (widths.Count < 2)
            return;
        var lastColumn = GetColumnName(widths.Count);
        worksheet.Append(new X.MergeCells(_introRows.Select(index =>
        {
            string row = index.ToString(CultureInfo.InvariantCulture);
            return new X.MergeCell { Reference = $"A{row}:{lastColumn}{row}" };
        })) { Count = (uint)_introRows.Count });
    }

    private static double MeasureWidth(string text) => Math.Clamp(
        text.ReplaceLineEndings("\n").Split('\n').Max(line => line.Length) * 1.15 + 3, 12, 48);

    private static string GetColumnName(int index)
    {
        var name = "";
        while (index > 0)
        {
            index--;
            name = (char)('A' + index % 26) + name;
            index /= 26;
        }
        return name;
    }

    private void AppendRow(X.Row row)
    {
        EnsureRoom(1);
        row.RowIndex = ++_rowCount;
        _sheetData.Append(row);
    }

    private void EnsureRoom(int count)
    {
        if (_rowCount + count > MaxRows)
            throw new InvalidOperationException($"Лист Excel не может содержать больше {MaxRows} строк.");
    }

    private static X.Cell CreateCell(object? value, uint textStyle, uint? numberStyle = null)
    {
        var cell = new X.Cell { StyleIndex = textStyle };
        switch (value)
        {
            case null:
                break;
            case bool flag:
                cell.DataType = X.CellValues.Boolean;
                cell.CellValue = new X.CellValue(flag ? "1" : "0");
                break;
            case byte or sbyte or short or ushort or int or uint or long or ulong or decimal:
            case float single when float.IsFinite(single):
            case double real when double.IsFinite(real):
                cell.StyleIndex = numberStyle ?? textStyle;
                cell.DataType = X.CellValues.Number;
                cell.CellValue = new X.CellValue(((IFormattable)value).ToString(null, CultureInfo.InvariantCulture));
                break;
            default:
                cell.DataType = X.CellValues.InlineString;
                cell.InlineString = new X.InlineString(new X.Text(Convert.ToString(value, CultureInfo.CurrentCulture) ?? "")
                {
                    Space = SpaceProcessingModeValues.Preserve
                });
                break;
        }
        return cell;
    }

    private static X.Stylesheet CreateStyles()
    {
        static X.Font Font(double size, bool bold = false)
        {
            var font = new X.Font(new X.FontSize { Val = size }, new X.FontName { Val = "Calibri" });
            if (bold)
                font.PrependChild(new X.Bold());
            return font;
        }

        static X.CellFormat Format(uint font, uint border, X.HorizontalAlignmentValues horizontal) => new(
            new X.Alignment { Horizontal = horizontal, Vertical = X.VerticalAlignmentValues.Center, WrapText = true })
        {
            FontId = font, BorderId = border, FillId = 0, NumberFormatId = 0, FormatId = 0,
            ApplyFont = true, ApplyBorder = border != 0, ApplyAlignment = true
        };

        return new X.Stylesheet(
            new X.Fonts(Font(11), Font(16, true), Font(11, true)) { Count = 3 },
            new X.Fills(
                new X.Fill(new X.PatternFill { PatternType = X.PatternValues.None }),
                new X.Fill(new X.PatternFill { PatternType = X.PatternValues.Gray125 })) { Count = 2 },
            new X.Borders(new X.Border(), new X.Border(
                new X.LeftBorder { Style = X.BorderStyleValues.Thin },
                new X.RightBorder { Style = X.BorderStyleValues.Thin },
                new X.TopBorder { Style = X.BorderStyleValues.Thin },
                new X.BottomBorder { Style = X.BorderStyleValues.Thin },
                new X.DiagonalBorder())) { Count = 2 },
            new X.CellStyleFormats(new X.CellFormat()) { Count = 1 },
            new X.CellFormats(
                Format(0, 0, X.HorizontalAlignmentValues.Left),
                Format(1, 0, X.HorizontalAlignmentValues.Left),
                Format(2, 1, X.HorizontalAlignmentValues.Center),
                Format(0, 1, X.HorizontalAlignmentValues.Left),
                Format(0, 1, X.HorizontalAlignmentValues.Right),
                Format(2, 1, X.HorizontalAlignmentValues.Left),
                Format(2, 1, X.HorizontalAlignmentValues.Right)) { Count = 7 },
            new X.CellStyles(new X.CellStyle { Name = "Normal", FormatId = 0, BuiltinId = 0 }) { Count = 1 });
    }
}
