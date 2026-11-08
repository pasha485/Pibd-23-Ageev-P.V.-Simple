using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для вывода списка услуг.
    /// </summary>
    public partial class ServiceListForm : Form
    {
        private readonly IServiceRepository _repo;

        public ServiceListForm(IServiceRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _repo.GetAll().ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new ServiceEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repo.Add(form.Result);
                RefreshGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Service selected)
            {
                MessageBox.Show("Выберите услугу!");
                return;
            }

            using var form = new ServiceEditForm(selected);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _repo.Update(form.Result);
                RefreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not Service selected)
            {
                MessageBox.Show("Выберите услугу!");
                return;
            }
            _repo.Delete(selected.Id);
            RefreshGrid();
        }
    }
}