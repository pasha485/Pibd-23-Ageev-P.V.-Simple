using DentalClinic.Models;
using System;
using System.Windows.Forms;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Главная форма приложения (содержит меню навигации).
    /// </summary>
    public partial class MainForm : Form
    {
        // Поля для хранения внедренных зависимостей
        private readonly IPatientRepository _patRepo;
        private readonly IDoctorRepository _docRepo;
        private readonly IServiceRepository _srvRepo;
        private readonly IAppointmentRepository _appRepo;
        private readonly IAppointmentServiceRepository _appSrvRepo;

        /// <summary>
        /// Конструктор с внедрением зависимостей через IoC-контейнер.
        /// </summary>
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

        /// <summary>
        /// Открывает форму со списком пациентов.
        /// </summary>
        private void menuPatients_Click(object sender, EventArgs e)
        {
            using var form = new PatientListForm(_patRepo);
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает форму со списком врачей.
        /// </summary>
        private void menuDoctors_Click(object sender, EventArgs e)
        {
            using var form = new DoctorListForm(_docRepo);
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает форму со списком услуг.
        /// </summary>
        private void menuServices_Click(object sender, EventArgs e)
        {
            using var form = new ServiceListForm(_srvRepo);
            form.ShowDialog();
        }

        // --- ОТКРЫТИЕ ФОРМ (ОПЕРАЦИИ) ---

        /// <summary>
        /// Открывает форму со списком приёмов.
        /// </summary>
        private void menuAppointments_Click(object sender, EventArgs e)
        {
            using var form = new AppointmentListForm(_appRepo, _patRepo, _docRepo);
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает форму с услугами на приёме.
        /// </summary>
        private void menuAppointmentServices_Click(object sender, EventArgs e)
        {
            using var form = new AppointmentServiceListForm(_appRepo, _appSrvRepo, _srvRepo, _patRepo);
            form.ShowDialog();
        }
    }
}