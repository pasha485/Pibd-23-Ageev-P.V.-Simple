using System;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для добавления услуги к конкретному приёму.
    /// </summary>
    public partial class AppointmentServiceAddForm : Form
    {
        private readonly int _appId;
        public AppointmentService Result { get; private set; }

        public AppointmentServiceAddForm(int appId, IServiceRepository srvRepo)
        {
            InitializeComponent();
            _appId = appId;

            cbServices.DataSource = srvRepo.GetAll().ToList();
            cbServices.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbServices.SelectedItem is not Service srv)
            {
                MessageBox.Show("Выберите услугу!");
                return;
            }

            try
            {
                Result = AppointmentService.Create(_appId, srv.Id, (int)numQty.Value, numCost.Value);
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