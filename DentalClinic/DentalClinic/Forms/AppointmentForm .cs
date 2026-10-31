using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly IAppointmentRepository _repo;
        private readonly IPatientRepository _patRepo;
        private readonly IDoctorRepository _docRepo;

        public AppointmentForm(IAppointmentRepository repo, IPatientRepository patRepo, IDoctorRepository docRepo)
        {
            InitializeComponent();
            _repo = repo;
            _patRepo = patRepo;
            _docRepo = docRepo;

            // Загружаем пациентов и врачей в выпадающие списки
            cbPatient.DataSource = _patRepo.GetAll().ToList();
            cbPatient.DisplayMember = "FullName";

            cbDoctor.DataSource = _docRepo.GetAll().ToList();
            cbDoctor.DisplayMember = "FullName";

            RefreshGrid();
        }

        // Метод для обновления таблицы
        private void RefreshGrid()
        {
            // Создаем словари для быстрого поиска ФИО по Id
            var pats = _patRepo.GetAll().ToDictionary(p => p.Id, p => p.FullName);
            var docs = _docRepo.GetAll().ToDictionary(d => d.Id, d => d.FullName);

            // Формируем красивую таблицу (вместо Id показываем ФИО)
            var view = _repo.GetAll().Select(a => new {
                a.Id,
                Пациент = pats.GetValueOrDefault(a.PatientId, "?"),
                Врач = docs.GetValueOrDefault(a.DoctorId, "?"),
                a.Date,
                a.Diagnosis,
                Оплачено = a.IsPaid ? "Да" : "Нет"
            }).ToList();

            grid.DataSource = view;
        }

        // Обработчик кнопки "Добавить приём"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, выбраны ли пациент и врач
            if (cbPatient.SelectedItem is not Patient p || cbDoctor.SelectedItem is not Doctor d)
            {
                MessageBox.Show("Выберите пациента и врача!");
                return;
            }

            // Проверяем, введен ли диагноз
            if (string.IsNullOrWhiteSpace(tbDiagnosis.Text))
            {
                MessageBox.Show("Введите диагноз!");
                return;
            }

            try
            {
                // Создаем и добавляем новый прием
                _repo.Add(Appointment.Create(p.Id, d.Id, dtDate.Value, tbDiagnosis.Text, chkPaid.Checked));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}