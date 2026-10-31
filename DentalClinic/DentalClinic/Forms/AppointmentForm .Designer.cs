namespace DentalClinic.Forms
{
    partial class AppointmentForm
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
            cbPatient = new ComboBox();
            cbDoctor = new ComboBox();
            dtDate = new DateTimePicker();
            tbDiagnosis = new TextBox();
            chkPaid = new CheckBox();
            btnAdd = new Button();
            lblPatient = new Label();
            lblDoctor = new Label();
            lblDate = new Label();
            lblDiag = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();

            // 
            // grid (Таблица)
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(12, 12);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(760, 250);
            grid.TabIndex = 0;

            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(12, 285);
            lblPatient.Text = "Пациент:";

            // 
            // cbPatient (Выбор пациента)
            // 
            cbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPatient.Location = new Point(120, 282);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(250, 40);
            cbPatient.TabIndex = 1;

            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(12, 335);
            lblDoctor.Text = "Врач:";

            // 
            // cbDoctor (Выбор врача)
            // 
            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.Location = new Point(120, 332);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(250, 40);
            cbDoctor.TabIndex = 2;

            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 385);
            lblDate.Text = "Дата:";

            // 
            // dtDate (Дата приема)
            // 
            dtDate.Location = new Point(120, 382);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(250, 39);
            dtDate.TabIndex = 3;

            // 
            // lblDiag
            // 
            lblDiag.AutoSize = true;
            lblDiag.Location = new Point(12, 435);
            lblDiag.Text = "Диагноз:";

            // 
            // tbDiagnosis (Поле диагноза)
            // 
            tbDiagnosis.Location = new Point(120, 432);
            tbDiagnosis.Name = "tbDiagnosis";
            tbDiagnosis.Size = new Size(250, 39);
            tbDiagnosis.TabIndex = 4;

            // 
            // chkPaid (Галочка оплаты)
            // 
            chkPaid.AutoSize = true;
            chkPaid.Location = new Point(120, 485);
            chkPaid.Name = "chkPaid";
            chkPaid.Size = new Size(161, 36);
            chkPaid.Text = "Оплачено";
            chkPaid.TabIndex = 5;

            // 
            // btnAdd (Кнопка добавить)
            // 
            btnAdd.Location = new Point(400, 282);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 46);
            btnAdd.Text = "Добавить приём";
            btnAdd.Click += btnAdd_Click;

            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(btnAdd);
            Controls.Add(chkPaid);
            Controls.Add(tbDiagnosis);
            Controls.Add(lblDiag);
            Controls.Add(dtDate);
            Controls.Add(lblDate);
            Controls.Add(cbDoctor);
            Controls.Add(lblDoctor);
            Controls.Add(cbPatient);
            Controls.Add(lblPatient);
            Controls.Add(grid);
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Приёмы";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Объявление переменных для дизайнера
        private DataGridView grid;
        private ComboBox cbPatient;
        private ComboBox cbDoctor;
        private DateTimePicker dtDate;
        private TextBox tbDiagnosis;
        private CheckBox chkPaid;
        private Button btnAdd;
        private Label lblPatient;
        private Label lblDoctor;
        private Label lblDate;
        private Label lblDiag;
    }
}