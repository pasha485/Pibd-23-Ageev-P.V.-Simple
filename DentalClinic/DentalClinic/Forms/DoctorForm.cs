using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    public partial class DoctorForm : Form
    {
        private readonly IDoctorRepository _repo;
        private Doctor _selected;

        public DoctorForm(IDoctorRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            cbSpec.DataSource = Enum.GetValues(typeof(DoctorSpecialization));
            RefreshGrid();
        }

        // 1. Метод для таблицы
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is Doctor d)
            {
                _selected = d;
                tbName.Text = d.FullName;
                cbSpec.SelectedItem = d.Specialization;
                numRate.Value = d.Rate;
            }
        }

        // 2. Метод для кнопки "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            try
            {
                _repo.Add(Doctor.Create(tbName.Text, (DoctorSpecialization)cbSpec.SelectedItem, numRate.Value));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 3. Метод для кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите врача из таблицы!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            try
            {
                _repo.Update(Doctor.Restore(_selected.Id, tbName.Text, (DoctorSpecialization)cbSpec.SelectedItem, numRate.Value));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 4. Метод для кнопки "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите врача!");
                return;
            }
            _repo.Delete(_selected.Id);
            RefreshGrid();
        }

        // Вспомогательный метод для обновления таблицы
        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _repo.GetAll().ToList();
            _selected = null;
            tbName.Clear();
        }
    }
}