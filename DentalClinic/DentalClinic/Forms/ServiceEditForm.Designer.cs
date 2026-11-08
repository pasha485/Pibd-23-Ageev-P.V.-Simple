namespace DentalClinic.Forms
{
    partial class ServiceEditForm
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
            clbTypes = new CheckedListBox();
            numPrice = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            lblTypes = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();

            lblName.AutoSize = true;
            lblName.Location = new Point(12, 15);
            lblName.Text = "Название:";

            tbName.Location = new Point(120, 12);
            tbName.Name = "tbName";
            tbName.Size = new Size(250, 39);

            lblTypes.AutoSize = true;
            lblTypes.Location = new Point(12, 65);
            lblTypes.Text = "Типы услуг:";

            clbTypes.CheckOnClick = true;
            clbTypes.Location = new Point(120, 62);
            clbTypes.Name = "clbTypes";
            clbTypes.Size = new Size(250, 112);

            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 195);
            lblPrice.Text = "Цена:";

            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(120, 192);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(250, 39);

            btnSave.Location = new Point(120, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 46);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            btnCancel.Location = new Point(250, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 46);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 320);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(clbTypes);
            Controls.Add(lblTypes);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Name = "ServiceEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Услуга";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox tbName;
        private CheckedListBox clbTypes;
        private NumericUpDown numPrice;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private Label lblTypes;
        private Label lblPrice;
    }
}