using System;
using System.Windows.Forms;
using DentalClinic.Reports;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма выбора справочников для выгрузки в Word.
    /// </summary>
    public partial class DictionaryReportForm : Form
    {
        private readonly DictionaryReport _report;

        /// <summary>
        /// Создаёт форму с переданным отчётом по справочникам.
        /// </summary>
        public DictionaryReportForm(DictionaryReport report)
        {
            InitializeComponent();
            _report = report;
        }

        /// <summary>
        /// Проверяет выбор справочников и сохраняет отчёт в файл Word.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var exportPatients = chkPatients.Checked;
            var exportDoctors = chkDoctors.Checked;
            var exportServices = chkServices.Checked;
            if (!exportPatients && !exportDoctors && !exportServices)
            {
                MessageBox.Show(this, "Выберите хотя бы один справочник.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "Документ Word (*.docx)|*.docx",
                    DefaultExt = "docx",
                    AddExtension = true,
                    FileName = "Справочники.docx"
                };
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                _report.Generate(dialog.FileName, exportPatients, exportDoctors, exportServices);
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
