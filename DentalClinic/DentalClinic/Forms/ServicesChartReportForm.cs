using System;
using System.Windows.Forms;
using DentalClinic.Reports;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма выбора даты для выгрузки диаграммы услуг в PDF.
    /// </summary>
    public partial class ServicesChartReportForm : Form
    {
        private readonly ServicesChartReport _report;

        /// <summary>
        /// Создаёт форму с переданным отчётом о распределении услуг.
        /// </summary>
        public ServicesChartReportForm(ServicesChartReport report)
        {
            InitializeComponent();
            _report = report;
        }

        /// <summary>
        /// Сохраняет диаграмму за выбранную календарную дату в файл PDF.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var date = dtDate.Value.Date;
            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "Документ PDF (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    AddExtension = true,
                    FileName = "Диаграмма услуг.pdf"
                };
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                _report.Generate(dialog.FileName, date);
                MessageBox.Show(this, "Отчёт успешно сохранён.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Не удалось сохранить отчёт: {ex.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
