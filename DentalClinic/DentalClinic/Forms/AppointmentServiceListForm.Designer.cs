namespace DentalClinic.Forms
{
    partial class AppointmentServiceListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbAppointments = new ComboBox();
            gridServices = new DataGridView();
            btnAdd = new Button();
            lblApp = new Label();
            ((System.ComponentModel.ISupportInitialize)gridServices).BeginInit();
            SuspendLayout();

            lblApp.AutoSize = true;
            lblApp.Location = new Point(12, 15);
            lblApp.Text = "Выберите приём:";

            cbAppointments.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAppointments.Location = new Point(180, 12);
            cbAppointments.Name = "cbAppointments";
            cbAppointments.Size = new Size(500, 40);
            cbAppointments.SelectedIndexChanged += cbAppointments_SelectedIndexChanged;

            gridServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridServices.Location = new Point(12, 60);
            gridServices.Name = "gridServices";
            gridServices.ReadOnly = true;
            gridServices.AllowUserToAddRows = false;
            gridServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridServices.Size = new Size(760, 250);
            gridServices.TabIndex = 1;

            btnAdd.Location = new Point(12, 330);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 46);
            btnAdd.Text = "Добавить услугу";
            btnAdd.Click += btnAdd_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(btnAdd);
            Controls.Add(gridServices);
            Controls.Add(cbAppointments);
            Controls.Add(lblApp);
            Name = "AppointmentServiceListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Услуги на приёме";
            ((System.ComponentModel.ISupportInitialize)gridServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cbAppointments;
        private DataGridView gridServices;
        private Button btnAdd;
        private Label lblApp;
    }
}