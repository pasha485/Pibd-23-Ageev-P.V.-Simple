using DentalClinic.Interfaces;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для вывода списка пациентов.
    /// </summary>
    public partial class PatientListForm : Form
    {
        private readonly IPatientRepository _repo;

        public PatientListForm(IPatientRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            this.Shown += (s, e) => RefreshGrid();
        }

        /// <summary>
        /// Обновляет данные в таблице.
        /// </summary>
        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.AutoResizeColumns();
            grid.DataSource = _repo.GetAll().ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new PatientEditForm();
            if (form.ShowDialog() == DialogResult.OK) { _repo.Add(form.Result); RefreshGrid(); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Patient selected) { MessageBox.Show("Выберите пациента!"); return; }
            using var form = new PatientEditForm(selected);
            if (form.ShowDialog() == DialogResult.OK) { _repo.Update(form.Result); RefreshGrid(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Patient selected) { MessageBox.Show("Выберите пациента!"); return; }
            _repo.Delete(selected.Id); RefreshGrid();
        }
    }
}