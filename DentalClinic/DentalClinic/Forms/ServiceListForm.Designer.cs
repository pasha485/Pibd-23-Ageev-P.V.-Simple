namespace DentalClinic.Forms
{
    partial class ServiceListForm
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
            btnEdit = new Button();
            btnDelete = new Button();
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
            btnAdd.Size = new Size(150, 46);
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(180, 380);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 46);
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(350, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;

            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(grid);
            Name = "ServiceListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список услуг";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        private DataGridView grid;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}