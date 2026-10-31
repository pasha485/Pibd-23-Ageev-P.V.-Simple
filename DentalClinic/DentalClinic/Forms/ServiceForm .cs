using System;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Models;

namespace DentalClinic.Forms
{
    public partial class ServiceForm : Form
    {
        private readonly IServiceRepository _repo;
        private Service _selected;

        public ServiceForm(IServiceRepository repo)
        {
            InitializeComponent();
            _repo = repo;

            // Заполняем CheckedListBox значениями флагового перечисления
            foreach (var val in Enum.GetValues<ServiceType>())
            {
                if (val != ServiceType.None)
                    clbTypes.Items.Add(val);
            }

            RefreshGrid();
        }

        // 1. Метод для таблицы
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is Service s)
            {
                _selected = s;
                tbName.Text = s.Name;
                numPrice.Value = s.Price;

                // Расставляем галочки
                for (int i = 0; i < clbTypes.Items.Count; i++)
                {
                    clbTypes.SetItemChecked(i, s.Type.HasFlag((ServiceType)clbTypes.Items[i]!));
                }
            }
        }

        // 2. Метод для кнопки "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || GetSelectedType() == ServiceType.None)
            {
                MessageBox.Show("Заполните название и выберите хотя бы один тип!");
                return;
            }

            try
            {
                _repo.Add(Service.Create(tbName.Text, GetSelectedType(), numPrice.Value));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 3. Метод для кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите услугу из таблицы!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text) || GetSelectedType() == ServiceType.None)
            {
                MessageBox.Show("Заполните название и выберите хотя бы один тип!");
                return;
            }

            try
            {
                _repo.Update(Service.Restore(_selected.Id, tbName.Text, GetSelectedType(), numPrice.Value));
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 4. Метод для кнопки "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Выберите услугу!");
                return;
            }
            _repo.Delete(_selected.Id);
            RefreshGrid();
        }

        // Вспомогательный метод (собирает галочки в одно значение)
        private ServiceType GetSelectedType()
        {
            ServiceType t = ServiceType.None;
            foreach (var item in clbTypes.CheckedItems)
            {
                // Приводим к типу ServiceType безопасно
                t |= (ServiceType)item;
            }
            return t;
        }

        // Вспомогательный метод (обновляет таблицу)
        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _repo.GetAll().ToList();
            _selected = null;
            tbName.Clear();

            for (int i = 0; i < clbTypes.Items.Count; i++)
                clbTypes.SetItemChecked(i, false);
        }
    }
}