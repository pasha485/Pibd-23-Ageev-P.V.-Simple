using System;
using System.Windows.Forms;
using DentalClinic.Enums;
using DentalClinic.Models;
using DentalClinic.Interfaces;

namespace DentalClinic.Forms
{
    /// <summary>
    /// Форма для создания или редактирования услуги.
    /// </summary>
    public partial class ServiceEditForm : Form
    {
        private readonly Service _existing;
        public Service Result { get; private set; }

        public ServiceEditForm()
        {
            InitializeComponent();
            foreach (var val in Enum.GetValues<ServiceType>())
            {
                if (val != ServiceType.None)
                    clbTypes.Items.Add(val);
            }
        }

        public ServiceEditForm(Service service) : this()
        {
            _existing = service;
            tbName.Text = service.Name;
            numPrice.Value = service.Price;
            for (int i = 0; i < clbTypes.Items.Count; i++)
            {
                clbTypes.SetItemChecked(i, service.Type.HasFlag((ServiceType)clbTypes.Items[i]!));
            }
        }

        /// <summary>
        /// Собирает выбранные галочки в одно флаговое значение.
        /// </summary>
        private ServiceType GetSelectedType()
        {
            ServiceType t = ServiceType.None;
            foreach (var item in clbTypes.CheckedItems)
                t |= (ServiceType)item!;
            return t;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || GetSelectedType() == ServiceType.None)
            {
                MessageBox.Show("Заполните все поля и выберите тип!");
                return;
            }

            try
            {
                Result = _existing == null
                    ? Service.Create(tbName.Text, GetSelectedType(), numPrice.Value)
                    : Service.Restore(_existing.Id, tbName.Text, GetSelectedType(), numPrice.Value);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}