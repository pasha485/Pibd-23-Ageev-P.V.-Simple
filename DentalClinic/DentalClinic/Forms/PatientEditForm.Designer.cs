namespace DentalClinic.Forms
{
    partial class PatientEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tbName = new TextBox();
            tbPhone = new TextBox();
            tbPolicy = new TextBox();
            dtBirth = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblPhone = new Label();
            lblPolicy = new Label();
            lblBirth = new Label();
            SuspendLayout();

            lblName.AutoSize = true; lblName.Location = new Point(12, 15); lblName.Text = "ФИО:";
            tbName.Location = new Point(120, 12); tbName.Name = "tbName"; tbName.Size = new Size(250, 39);

            lblPhone.AutoSize = true; lblPhone.Location = new Point(12, 65); lblPhone.Text = "Телефон:";
            tbPhone.Location = new Point(120, 62); tbPhone.Name = "tbPhone"; tbPhone.Size = new Size(250, 39);

            lblPolicy.AutoSize = true; lblPolicy.Location = new Point(12, 115); lblPolicy.Text = "Полис:";
            tbPolicy.Location = new Point(120, 112); tbPolicy.Name = "tbPolicy"; tbPolicy.Size = new Size(250, 39);

            lblBirth.AutoSize = true; lblBirth.Location = new Point(12, 165); lblBirth.Text = "Дата рожд.:";
            dtBirth.Location = new Point(120, 162); dtBirth.Name = "dtBirth"; dtBirth.Size = new Size(250, 39);

            btnSave.Location = new Point(120, 220); btnSave.Name = "btnSave"; btnSave.Size = new Size(120, 46);
            btnSave.Text = "Сохранить"; btnSave.Click += btnSave_Click;

            btnCancel.Location = new Point(250, 220); btnCancel.Name = "btnCancel"; btnCancel.Size = new Size(120, 46);
            btnCancel.Text = "Отмена"; btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(btnCancel); Controls.Add(btnSave);
            Controls.Add(dtBirth); Controls.Add(lblBirth);
            Controls.Add(tbPolicy); Controls.Add(lblPolicy);
            Controls.Add(tbPhone); Controls.Add(lblPhone);
            Controls.Add(tbName); Controls.Add(lblName);
            Name = "PatientEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование пациента";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox tbName;
        private TextBox tbPhone;
        private TextBox tbPolicy;
        private DateTimePicker dtBirth;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private Label lblPhone;
        private Label lblPolicy;
        private Label lblBirth;
    }
}