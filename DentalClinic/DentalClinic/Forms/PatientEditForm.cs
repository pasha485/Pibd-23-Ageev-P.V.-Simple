using System;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для создания или редактирования записи пациента.
    /// </summary>
    public partial class PatientEditForm : Form
    {
        private readonly Patient _existing;

        /// <summary>
        /// Результат работы формы (сохраненный или измененный пациент).
        /// </summary>
        public Patient Result { get; private set; }

        /// <summary>
        /// Конструктор для создания нового пациента.
        /// </summary>
        public PatientEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для редактирования существующего пациента.
        /// </summary>
        public PatientEditForm(Patient patient) : this()
        {
            _existing = patient;
            tbName.Text = patient.FullName;
            tbPhone.Text = patient.Phone;
            tbPolicy.Text = patient.PolicyNumber;
            dtBirth.Value = patient.BirthDate;
        }

        /// <summary>
        /// Сохранение введенных данных.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Проверка на пустые поля на уровне интерфейса
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbPolicy.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Попытка сохранить (модель Patient сама проверит формат телефона, полиса и даты)
            try
            {
                Result = _existing == null
                    ? Patient.Create(tbName.Text, dtBirth.Value, tbPhone.Text, tbPolicy.Text)
                    : Patient.Restore(_existing.Id, tbName.Text, dtBirth.Value, tbPhone.Text, tbPolicy.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                // Если модель выбросила ошибку валидации (например, буквы в телефоне)
                MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // На случай других непредвиденных ошибок
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрытие формы без сохранения.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}