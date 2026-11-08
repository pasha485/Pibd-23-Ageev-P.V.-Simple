using System;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для добавления нового приёма (без редактирования).
    /// </summary>
    public partial class AppointmentAddForm : Form
    {
        public Appointment Result { get; private set; }

        public AppointmentAddForm(IPatientRepository patRepo, IDoctorRepository docRepo)
        {
            InitializeComponent();

            cbPatient.DataSource = patRepo.GetAll().ToList();
            cbPatient.DisplayMember = "FullName";

            cbDoctor.DataSource = docRepo.GetAll().ToList();
            cbDoctor.DisplayMember = "FullName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPatient.SelectedItem is not Patient p || cbDoctor.SelectedItem is not Doctor d || string.IsNullOrWhiteSpace(tbDiagnosis.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                Result = Appointment.Create(p.Id, d.Id, dtDate.Value, tbDiagnosis.Text, chkPaid.Checked);
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