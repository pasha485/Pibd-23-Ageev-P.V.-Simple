namespace DentalClinic.Forms
{
    partial class AppointmentServiceAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbServices = new ComboBox();
            numQty = new NumericUpDown();
            numCost = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblService = new Label();
            lblQty = new Label();
            lblCost = new Label();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            SuspendLayout();

            lblService.AutoSize = true;
            lblService.Location = new Point(12, 15);
            lblService.Text = "Услуга:";

            cbServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cbServices.Location = new Point(120, 12);
            cbServices.Name = "cbServices";
            cbServices.Size = new Size(250, 40);

            lblQty.AutoSize = true;
            lblQty.Location = new Point(12, 65);
            lblQty.Text = "Количество:";

            numQty.Location = new Point(120, 62);
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(250, 39);
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            lblCost.AutoSize = true;
            lblCost.Location = new Point(12, 115);
            lblCost.Text = "Материалы:";

            numCost.DecimalPlaces = 2;
            numCost.Location = new Point(120, 112);
            numCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(250, 39);

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
            Controls.Add(numCost);
            Controls.Add(lblCost);
            Controls.Add(numQty);
            Controls.Add(lblQty);
            Controls.Add(cbServices);
            Controls.Add(lblService);
            Name = "AppointmentServiceAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить услугу";
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cbServices;
        private NumericUpDown numQty;
        private NumericUpDown numCost;
        private Button btnSave;
        private Button btnCancel;
        private Label lblService;
        private Label lblQty;
        private Label lblCost;
    }
}