namespace DentalClinic.Forms
{
    partial class ServiceForm
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
            clbTypes = new CheckedListBox();
            numPrice = new NumericUpDown();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            lblName = new Label();
            lblTypes = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
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
            tbName.Location = new Point(143, 287);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 39);
            tbName.TabIndex = 1;
            // 
            // clbTypes
            // 
            clbTypes.CheckOnClick = true;
            clbTypes.Location = new Point(143, 332);
            clbTypes.Name = "clbTypes";
            clbTypes.Size = new Size(200, 112);
            clbTypes.TabIndex = 2;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(143, 465);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(200, 39);
            numPrice.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(400, 282);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 332);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(400, 382);
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
            lblName.Size = new Size(125, 32);
            lblName.TabIndex = 6;
            lblName.Text = "Название:";
            // 
            // lblTypes
            // 
            lblTypes.AutoSize = true;
            lblTypes.Location = new Point(12, 335);
            lblTypes.Name = "lblTypes";
            lblTypes.Size = new Size(77, 32);
            lblTypes.TabIndex = 5;
            lblTypes.Text = "Типы:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 465);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(76, 32);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Цена:";
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(clbTypes);
            Controls.Add(lblTypes);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(grid);
            Name = "ServiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Услуги";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Объявление элементов (чтобы дизайнер их видел)
        private DataGridView grid;
        private TextBox tbName;
        private CheckedListBox clbTypes;
        private NumericUpDown numPrice;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Label lblName;
        private Label lblTypes;
        private Label lblPrice;
    }
}