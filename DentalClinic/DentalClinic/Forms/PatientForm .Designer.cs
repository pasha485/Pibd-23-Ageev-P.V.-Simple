namespace DentalClinic.Forms
{
    partial class PatientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grid = new DataGridView();
            tbName = new TextBox();
            tbPhone = new TextBox();
            tbPolicy = new TextBox();
            dtBirth = new DateTimePicker();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            lblName = new Label();
            lblPhone = new Label();
            lblPolicy = new Label();
            lblBirth = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
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
            tbName.Location = new Point(120, 282);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 39);
            tbName.TabIndex = 1;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(120, 332);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(200, 39);
            tbPhone.TabIndex = 2;
            // 
            // tbPolicy
            // 
            tbPolicy.Location = new Point(120, 382);
            tbPolicy.Name = "tbPolicy";
            tbPolicy.Size = new Size(200, 39);
            tbPolicy.TabIndex = 3;
            // 
            // dtBirth
            // 
            dtBirth.Location = new Point(189, 432);
            dtBirth.Name = "dtBirth";
            dtBirth.Size = new Size(200, 39);
            dtBirth.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(400, 282);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 332);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(400, 382);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 285);
            lblName.Name = "lblName";
            lblName.Size = new Size(72, 32);
            lblName.TabIndex = 11;
            lblName.Text = "ФИО:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 335);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(115, 32);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Телефон:";
            // 
            // lblPolicy
            // 
            lblPolicy.AutoSize = true;
            lblPolicy.Location = new Point(12, 385);
            lblPolicy.Name = "lblPolicy";
            lblPolicy.Size = new Size(88, 32);
            lblPolicy.TabIndex = 9;
            lblPolicy.Text = "Полис:";
            // 
            // lblBirth
            // 
            lblBirth.AutoSize = true;
            lblBirth.Location = new Point(12, 435);
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(189, 32);
            lblBirth.TabIndex = 8;
            lblBirth.Text = "Дата рождения:";
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 569);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(dtBirth);
            Controls.Add(lblBirth);
            Controls.Add(tbPolicy);
            Controls.Add(lblPolicy);
            Controls.Add(tbPhone);
            Controls.Add(lblPhone);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(grid);
            Name = "PatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пациенты";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grid;
        private TextBox tbName;
        private TextBox tbPhone;
        private TextBox tbPolicy;
        private DateTimePicker dtBirth;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Label lblName;
        private Label lblPhone;
        private Label lblPolicy;
        private Label lblBirth;
    }
}