using DentalClinic.Models;
using System;
using System.Windows.Forms;

namespace DentalClinic.Forms
{
    public partial class MainForm : Form
    {
        private readonly IPatientRepository _patRepo;
        private readonly IDoctorRepository _docRepo;
        private readonly IServiceRepository _srvRepo;
        private readonly IAppointmentRepository _appRepo;
        private readonly IAppointmentServiceRepository _appSrvRepo;

        // Внедрение зависимостей
        public MainForm(IPatientRepository patRepo, IDoctorRepository docRepo, IServiceRepository srvRepo,
            IAppointmentRepository appRepo, IAppointmentServiceRepository appSrvRepo)
        {
            InitializeComponent();
            _patRepo = patRepo;
            _docRepo = docRepo;
            _srvRepo = srvRepo;
            _appRepo = appRepo;
            _appSrvRepo = appSrvRepo;
        }

        // Открытие форм
        private void menuPatients_Click(object sender, EventArgs e) => new PatientForm(_patRepo).ShowDialog();

        private void menuDoctors_Click(object sender, EventArgs e) => new DoctorForm(_docRepo).ShowDialog();

        private void menuServices_Click(object sender, EventArgs e) => new ServiceForm(_srvRepo).ShowDialog();

        private void menuAppointments_Click(object sender, EventArgs e) => new AppointmentForm(_appRepo, _patRepo, _docRepo).ShowDialog();

        private void menuAppointmentServices_Click(object sender, EventArgs e) => new AppointmentServiceForm(_appRepo, _appSrvRepo, _srvRepo, _patRepo).ShowDialog();
    }
}