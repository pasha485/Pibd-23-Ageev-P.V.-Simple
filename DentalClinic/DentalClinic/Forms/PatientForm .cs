using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    public partial class PatientForm : Form
    {
        private readonly IPatientRepository _repo;
        private Patient? _selected;

        public PatientForm(IPatientRepository repo)
        {
            // Теперь мы вызываем InitializeComponent, 
            // так как элементы создаются в Designer.cs
            InitializeComponent();

            _repo = repo;
            RefreshGrid();
        }

        /// <summary>
        /// Обновление таблицы
        /// </summary>
        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _repo.GetAll().ToList();
            _selected = null;
            tbName.Clear();
            tbPhone.Clear();
            tbPolicy.Clear();
        }

        /// <summary>
        /// Клик по строке таблицы
        /// </summary>
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is Patient p)
            {
                _selected = p;
                tbName.Text = p.FullName;
                tbPhone.Text = p.Phone;
                tbPolicy.Text = p.PolicyNumber;
                dtBirth.Value = p.BirthDate;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbPolicy.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                _repo.Add(Patient.Create(tbName.Text, dtBirth.Value, tbPhone.Text, tbPolicy.Text));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите запись из таблицы!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbPolicy.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                _repo.Update(Patient.Restore(_selected.Id, tbName.Text, dtBirth.Value, tbPhone.Text, tbPolicy.Text));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            _repo.Delete(_selected.Id);
            RefreshGrid();
        }

    }
}