using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для вывода списка приёмов.
    /// </summary>
    public partial class AppointmentListForm : Form
    {
        private readonly IAppointmentRepository _repo;
        private readonly IPatientRepository _patRepo;
        private readonly IDoctorRepository _docRepo;

        public AppointmentListForm(IAppointmentRepository repo, IPatientRepository patRepo, IDoctorRepository docRepo)
        {
            InitializeComponent();
            _repo = repo;
            _patRepo = patRepo;
            _docRepo = docRepo;
            this.Shown += (s, e) => RefreshGrid();
        }

        private void RefreshGrid()
        {
            var pats = _patRepo.GetAll().ToDictionary(p => p.Id, p => p.FullName);
            var docs = _docRepo.GetAll().ToDictionary(d => d.Id, d => d.FullName);

            var view = _repo.GetAll().Select(a => new {
                a.Id,
                Пациент = pats.GetValueOrDefault(a.PatientId, "?"),
                Врач = docs.GetValueOrDefault(a.DoctorId, "?"),
                a.Date,
                a.Diagnosis,
                Оплачено = a.IsPaid ? "Да" : "Нет"
            }).ToList();

            grid.DataSource = null;
            grid.AutoResizeColumns();
            grid.DataSource = view;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AppointmentAddForm(_patRepo, _docRepo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repo.Add(form.Result);
                RefreshGrid();
            }
        }
    }
}