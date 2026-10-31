namespace DentalClinic.Forms
{
    partial class DoctorForm
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
            tbName = new TextBox();
            cbSpec = new ComboBox();
            numRate = new NumericUpDown();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            lblName = new Label();
            lblSpec = new Label();
            lblRate = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            SuspendLayout();
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(12, 12);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 82;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(760, 250);
            grid.TabIndex = 0;
            grid.CellClick += grid_CellClick;
            // 
            // tbName
            // 
            tbName.Location = new Point(209, 285);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 39);
            tbName.TabIndex = 1;
            // 
            // cbSpec
            // 
            cbSpec.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpec.Location = new Point(209, 335);
            cbSpec.Name = "cbSpec";
            cbSpec.Size = new Size(170, 40);
            cbSpec.TabIndex = 2;
            // 
            // numRate
            // 
            numRate.DecimalPlaces = 2;
            numRate.Location = new Point(209, 383);
            numRate.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numRate.Name = "numRate";
            numRate.Size = new Size(200, 39);
            numRate.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(477, 281);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(477, 331);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(477, 383);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 285);
            lblName.Name = "lblName";
            lblName.Size = new Size(72, 32);
            lblName.TabIndex = 6;
            lblName.Text = "ФИО:";
            // 
            // lblSpec
            // 
            lblSpec.AutoSize = true;
            lblSpec.Location = new Point(12, 335);
            lblSpec.Name = "lblSpec";
            lblSpec.Size = new Size(191, 32);
            lblSpec.TabIndex = 5;
            lblSpec.Text = "Специализация:";
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Location = new Point(12, 385);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(93, 32);
            lblRate.TabIndex = 4;
            lblRate.Text = "Ставка:";
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(numRate);
            Controls.Add(lblRate);
            Controls.Add(cbSpec);
            Controls.Add(lblSpec);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(grid);
            Name = "DoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Врачи";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView grid;
        private TextBox tbName;
        private ComboBox cbSpec;
        private NumericUpDown numRate;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Label lblName;
        private Label lblSpec;
        private Label lblRate;
    }
}