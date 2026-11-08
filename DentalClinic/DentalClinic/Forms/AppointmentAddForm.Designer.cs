namespace DentalClinic.Forms
{
    partial class AppointmentAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbPatient = new ComboBox();
            cbDoctor = new ComboBox();
            dtDate = new DateTimePicker();
            tbDiagnosis = new TextBox();
            chkPaid = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblPatient = new Label();
            lblDoctor = new Label();
            lblDate = new Label();
            lblDiag = new Label();
            SuspendLayout();

            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(12, 15);
            lblPatient.Text = "Пациент:";

            cbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPatient.Location = new Point(120, 12);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(250, 40);

            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(12, 65);
            lblDoctor.Text = "Врач:";

            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.Location = new Point(120, 62);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(250, 40);

            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 115);
            lblDate.Text = "Дата:";

            dtDate.Location = new Point(120, 112);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(250, 39);

            lblDiag.AutoSize = true;
            lblDiag.Location = new Point(12, 165);
            lblDiag.Text = "Диагноз:";

            tbDiagnosis.Location = new Point(120, 162);
            tbDiagnosis.Name = "tbDiagnosis";
            tbDiagnosis.Size = new Size(250, 39);

            chkPaid.AutoSize = true;
            chkPaid.Location = new Point(120, 215);
            chkPaid.Name = "chkPaid";
            chkPaid.Text = "Оплачено";

            btnSave.Location = new Point(120, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 46);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.Location = new Point(250, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 46);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 340);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkPaid);
            Controls.Add(tbDiagnosis);
            Controls.Add(lblDiag);
            Controls.Add(dtDate);
            Controls.Add(lblDate);
            Controls.Add(cbDoctor);
            Controls.Add(lblDoctor);
            Controls.Add(cbPatient);
            Controls.Add(lblPatient);
            Name = "AppointmentAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новый приём";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cbPatient;
        private ComboBox cbDoctor;
        private DateTimePicker dtDate;
        private TextBox tbDiagnosis;
        private CheckBox chkPaid;
        private Button btnSave;
        private Button btnCancel;
        private Label lblPatient;
        private Label lblDoctor;
        private Label lblDate;
        private Label lblDiag;
    }
}