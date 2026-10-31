using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    public partial class AppointmentServiceForm : Form
    {
        private readonly IAppointmentRepository _appRepo;
        private readonly IAppointmentServiceRepository _repo;
        private readonly IServiceRepository _srvRepo;
        private readonly IPatientRepository _patRepo;

        public AppointmentServiceForm(IAppointmentRepository appRepo, IAppointmentServiceRepository repo,
            IServiceRepository srvRepo, IPatientRepository patRepo)
        {
            InitializeComponent();
            _appRepo = appRepo;
            _repo = repo;
            _srvRepo = srvRepo;
            _patRepo = patRepo;

            // Заполняем ComboBox доступными услугами
            cbServices.DataSource = _srvRepo.GetAll().ToList();
            cbServices.DisplayMember = "Name";

            // Загружаем список приемов
            LoadAppointments();
        }

        // Загрузка приемов в выпадающий список
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

        // Событие: при смене приема в ComboBox обновляем таблицу снизу
        private void cbAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // Обновление таблицы с услугами для выбранного приема
        private void RefreshGrid()
        {
            // Если ничего не выбрано - выходим
            if (cbAppointments.SelectedValue is not int appId) return;

            var services = _srvRepo.GetAll().ToDictionary(s => s.Id, s => s.Name);

            // Берем услуги только для выбранного приема
            var list = _repo.GetByAppointmentId(appId).Select(x => new {
                x.Id,
                Услуга = services.GetValueOrDefault(x.ServiceId, "?"),
                x.Quantity,
                Материалы = x.MaterialsCost
            }).ToList();

            gridServices.DataSource = null;
            gridServices.DataSource = list;
        }

        // Обработчик кнопки "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли прием и услуга
            if (cbAppointments.SelectedValue is not int appId || cbServices.SelectedItem is not Service srv)
            {
                MessageBox.Show("Выберите приём и услугу!");
                return;
            }

            try
            {
                // Создаем связь и добавляем в репозиторий
                _repo.Add(AppointmentService.Create(appId, srv.Id, (int)numQty.Value, numCost.Value));
                RefreshGrid(); // Обновляем таблицу
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}