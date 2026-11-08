namespace DentalClinic.Forms
{
    partial class AppointmentListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grid = new DataGridView();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(12, 12);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(760, 350);
            grid.TabIndex = 0;

            btnAdd.Location = new Point(12, 380);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 46);
            btnAdd.Text = "Добавить приём";
            btnAdd.Click += btnAdd_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(grid);
            Name = "AppointmentListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список приёмов";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        private DataGridView grid;
        private Button btnAdd;
    }
}