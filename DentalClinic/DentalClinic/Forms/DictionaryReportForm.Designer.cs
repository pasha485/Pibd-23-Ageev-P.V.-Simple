namespace DentalClinic.Forms
{
    partial class DictionaryReportForm
    {
        private void InitializeComponent()
        {
            lblDictionaries = new Label();
            chkPatients = new CheckBox();
            chkDoctors = new CheckBox();
            chkServices = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            lblDictionaries.AutoSize = true;
            lblDictionaries.Location = new Point(12, 12);
            lblDictionaries.Name = "lblDictionaries";
            lblDictionaries.Text = "Выберите справочники для выгрузки:";

            chkPatients.AutoSize = true;
            chkPatients.Location = new Point(12, 55);
            chkPatients.Name = "chkPatients";
            chkPatients.TabIndex = 0;
            chkPatients.Text = "Пациенты";

            chkDoctors.AutoSize = true;
            chkDoctors.Location = new Point(12, 100);
            chkDoctors.Name = "chkDoctors";
            chkDoctors.TabIndex = 1;
            chkDoctors.Text = "Врачи";

            chkServices.AutoSize = true;
            chkServices.Location = new Point(12, 145);
            chkServices.Name = "chkServices";
            chkServices.TabIndex = 2;
            chkServices.Text = "Услуги";

            btnSave.Location = new Point(152, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 46);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(307, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 46);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";

            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(464, 260);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkServices);
            Controls.Add(chkDoctors);
            Controls.Add(chkPatients);
            Controls.Add(lblDictionaries);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DictionaryReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справочники (Word)";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDictionaries;
        private CheckBox chkPatients;
        private CheckBox chkDoctors;
        private CheckBox chkServices;
        private Button btnSave;
        private Button btnCancel;
    }
}
