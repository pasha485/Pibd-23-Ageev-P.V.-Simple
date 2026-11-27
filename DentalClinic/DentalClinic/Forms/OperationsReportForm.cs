using System;
using System.Windows.Forms;
using DentalClinic.Reports;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма выбора периода для выгрузки операций в Excel.
    /// </summary>
    public partial class OperationsReportForm : Form
    {
        private readonly OperationsReport _report;

        /// <summary>
        /// Создаёт форму с переданным отчётом по операциям.
        /// </summary>
        public OperationsReportForm(OperationsReport report)
        {
            InitializeComponent();
            _report = report;
        }

        /// <summary>
        /// Проверяет диапазон календарных дат и сохраняет отчёт в файл Excel.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var startDate = dtStartDate.Value.Date;
            var endDate = dtEndDate.Value.Date;
            if (startDate > endDate)
            {
                MessageBox.Show(this, "Дата начала не может быть позже даты окончания.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "Книга Excel (*.xlsx)|*.xlsx",
                    DefaultExt = "xlsx",
                    AddExtension = true,
                    FileName = "Операции.xlsx"
                };
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                _report.Generate(dialog.FileName, startDate, endDate);
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
