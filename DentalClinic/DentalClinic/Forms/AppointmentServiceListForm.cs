using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для вывода списка услуг, оказанных на конкретном приёме.
    /// </summary>
    public partial class AppointmentServiceListForm : Form
    {
        private readonly IAppointmentRepository _appRepo;
        private readonly IAppointmentServiceRepository _repo;
        private readonly IServiceRepository _srvRepo;
        private readonly IPatientRepository _patRepo;

        public AppointmentServiceListForm(IAppointmentRepository appRepo, IAppointmentServiceRepository repo, IServiceRepository srvRepo, IPatientRepository patRepo)
        {
            InitializeComponent();
            _appRepo = appRepo;
            _repo = repo;
            _srvRepo = srvRepo;
            _patRepo = patRepo;
            LoadAppointments();
            this.Shown += (s, e) => RefreshGrid();
        }

        /// <summary>
        /// Загружает список приемов в верхний ComboBox.
        /// </summary>
        private void LoadAppointments()
        {
            var pats = _patRepo.GetAll().ToDictionary(p => p.Id, p => p.FullName);
            cbAppointments.DataSource = _appRepo.GetAll().Select(a => new {
                a.Id,
                Display = $"Приём #{a.Id} от {a.Date:d} ({pats.GetValueOrDefault(a.PatientId, "?")})"
            }).ToList();
            cbAppointments.DisplayMember = "Display";
            cbAppointments.ValueMember = "Id";
        }

        private void cbAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        /// <summary>
        /// Обновляет таблицу с услугами для выбранного приёма.
        /// </summary>
        private void RefreshGrid()
        {
            if (cbAppointments.SelectedValue is not int appId) return;

            var services = _srvRepo.GetAll().ToDictionary(s => s.Id, s => s.Name);
            var list = _repo.GetByAppointmentId(appId).Select(x => new {
                x.Id,
                Услуга = services.GetValueOrDefault(x.ServiceId, "?"),
                x.Quantity,
                Материалы = x.MaterialsCost
            }).ToList();

            gridServices.DataSource = null;
            gridServices.AutoResizeColumns();
            gridServices.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbAppointments.SelectedValue is not int appId)
            {
                MessageBox.Show("Сначала выберите приём!");
                return;
            }

            using var form = new AppointmentServiceAddForm(appId, _srvRepo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repo.Add(form.Result);
                RefreshGrid();
            }
        }
    }
}