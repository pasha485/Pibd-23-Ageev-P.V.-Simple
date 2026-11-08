using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для вывода списка врачей.
    /// </summary>
    public partial class DoctorListForm : Form
    {
        private readonly IDoctorRepository _repo;
        public DoctorListForm(IDoctorRepository repo) { InitializeComponent(); _repo = repo; RefreshGrid(); }

        private void RefreshGrid() { grid.DataSource = null; grid.DataSource = _repo.GetAll().ToList(); }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new DoctorEditForm();
            if (form.ShowDialog() == DialogResult.OK) { _repo.Add(form.Result); RefreshGrid(); }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Doctor selected) { MessageBox.Show("Выберите врача!"); return; }
            using var form = new DoctorEditForm(selected);
            if (form.ShowDialog() == DialogResult.OK) { _repo.Update(form.Result); RefreshGrid(); }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Doctor selected) { MessageBox.Show("Выберите врача!"); return; }
            _repo.Delete(selected.Id); RefreshGrid();
        }
    }
}