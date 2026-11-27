namespace DentalClinic.Forms
{
    partial class ServicesChartReportForm
    {
        private void InitializeComponent()
        {
            lblDate = new Label();
            dtDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 15);
            lblDate.Name = "lblDate";
            lblDate.Text = "Дата отчёта:";

            dtDate.Format = DateTimePickerFormat.Short;
            dtDate.Location = new Point(215, 12);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(237, 39);
            dtDate.TabIndex = 0;

            btnSave.Location = new Point(152, 70);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(307, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 46);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";

            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(464, 130);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtDate);
            Controls.Add(lblDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServicesChartReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Диаграмма услуг за день (PDF)";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblDate;
        private DateTimePicker dtDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
