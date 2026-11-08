using System;
using System.Windows.Forms;
using DentalClinic.Enums;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для создания или редактирования записи врача.
    /// </summary>
    public partial class DoctorEditForm : Form
    {
        private readonly Doctor _existing;
        public Doctor Result { get; private set; }

        public DoctorEditForm()
        {
            InitializeComponent();

            var specializations = new[] {
                new { Value = DoctorSpecialization.Therapist, Text = "Терапевт" },
                new { Value = DoctorSpecialization.Surgeon, Text = "Хирург" },
                new { Value = DoctorSpecialization.Orthodontist, Text = "Ортодонт" },
                new { Value = DoctorSpecialization.Prosthodontist, Text = "Ортопед" }
            };
            cbSpec.DataSource = specializations;
            cbSpec.DisplayMember = "Text";
            cbSpec.ValueMember = "Value";
        }

        public DoctorEditForm(Doctor doctor) : this()
        {
            _existing = doctor;
            tbName.Text = doctor.FullName;
            cbSpec.SelectedValue = doctor.Specialization;
            numRate.Value = doctor.Rate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }

            try
            {
                Result = _existing == null
                    ? Doctor.Create(tbName.Text, (DoctorSpecialization)cbSpec.SelectedValue, numRate.Value)
                    : Doctor.Restore(_existing.Id, tbName.Text, (DoctorSpecialization)cbSpec.SelectedValue, numRate.Value);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}