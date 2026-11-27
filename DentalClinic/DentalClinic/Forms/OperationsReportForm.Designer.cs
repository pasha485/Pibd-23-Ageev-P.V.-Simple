namespace DentalClinic.Forms
{
    partial class OperationsReportForm
    {
        private void InitializeComponent()
        {
            lblPeriod = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            dtStartDate = new DateTimePicker();
            dtEndDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            lblPeriod.AutoSize = true;
            lblPeriod.Location = new Point(12, 12);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Text = "Обе даты включаются в отчёт.";

            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(12, 60);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Text = "Дата начала:";

            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(12, 110);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Text = "Дата окончания:";

            dtStartDate.Format = DateTimePickerFormat.Short;
            dtStartDate.Location = new Point(240, 57);
            dtStartDate.Name = "dtStartDate";
            dtStartDate.Size = new Size(212, 39);
            dtStartDate.TabIndex = 0;

            dtEndDate.Format = DateTimePickerFormat.Short;
            dtEndDate.Location = new Point(240, 107);
            dtEndDate.Name = "dtEndDate";
            dtEndDate.Size = new Size(212, 39);
            dtEndDate.TabIndex = 1;

            btnSave.Location = new Point(152, 165);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 46);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(307, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 46);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";

            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(464, 225);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtEndDate);
            Controls.Add(dtStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblPeriod);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OperationsReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Операции за период (Excel)";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblPeriod;
        private Label lblStartDate;
        private Label lblEndDate;
        private DateTimePicker dtStartDate;
        private DateTimePicker dtEndDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
