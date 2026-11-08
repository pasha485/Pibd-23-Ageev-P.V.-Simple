namespace DentalClinic.Forms
{
    partial class DoctorEditForm
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
            cbSpec = new ComboBox();
            numRate = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblSpec = new Label();
            lblRate = new Label();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            SuspendLayout();

            lblName.AutoSize = true;
            lblName.Location = new Point(12, 15);
            lblName.Text = "ФИО:";

            tbName.Location = new Point(120, 12);
            tbName.Name = "tbName";
            tbName.Size = new Size(250, 39);

            lblSpec.AutoSize = true;
            lblSpec.Location = new Point(12, 65);
            lblSpec.Text = "Специализация:";

            cbSpec.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpec.Location = new Point(150, 62);
            cbSpec.Name = "cbSpec";
            cbSpec.Size = new Size(220, 40);

            lblRate.AutoSize = true;
            lblRate.Location = new Point(12, 115);
            lblRate.Text = "Ставка:";

            numRate.DecimalPlaces = 2;
            numRate.Location = new Point(120, 112);
            numRate.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numRate.Name = "numRate";
            numRate.Size = new Size(250, 39);

            btnSave.Location = new Point(120, 170);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 46);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.Location = new Point(250, 170);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 46);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 250);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numRate);
            Controls.Add(lblRate);
            Controls.Add(cbSpec);
            Controls.Add(lblSpec);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Name = "DoctorEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Врач";
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox tbName;
        private ComboBox cbSpec;
        private NumericUpDown numRate;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private Label lblSpec;
        private Label lblRate;
    }
}