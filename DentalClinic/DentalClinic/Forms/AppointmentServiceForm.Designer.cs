namespace DentalClinic.Forms
{
    partial class AppointmentServiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbAppointments = new ComboBox();
            gridServices = new DataGridView();
            cbServices = new ComboBox();
            numQty = new NumericUpDown();
            numCost = new NumericUpDown();
            btnAdd = new Button();
            lblApp = new Label();
            lblService = new Label();
            lblQty = new Label();
            lblCost = new Label();
            ((System.ComponentModel.ISupportInitialize)gridServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            SuspendLayout();
            // 
            // cbAppointments
            // 
            cbAppointments.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAppointments.Location = new Point(225, 15);
            cbAppointments.Name = "cbAppointments";
            cbAppointments.Size = new Size(500, 40);
            cbAppointments.TabIndex = 0;
            cbAppointments.SelectedIndexChanged += cbAppointments_SelectedIndexChanged;
            // 
            // gridServices
            // 
            gridServices.AllowUserToAddRows = false;
            gridServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridServices.Location = new Point(12, 60);
            gridServices.Name = "gridServices";
            gridServices.ReadOnly = true;
            gridServices.RowHeadersWidth = 82;
            gridServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridServices.Size = new Size(760, 250);
            gridServices.TabIndex = 1;
            // 
            // cbServices
            // 
            cbServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cbServices.Location = new Point(90, 332);
            cbServices.Name = "cbServices";
            cbServices.Size = new Size(250, 40);
            cbServices.TabIndex = 2;
            // 
            // numQty
            // 
            numQty.Location = new Point(440, 332);
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(100, 39);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numCost
            // 
            numCost.DecimalPlaces = 2;
            numCost.Location = new Point(150, 382);
            numCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(190, 39);
            numCost.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(600, 332);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 46);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // lblApp
            // 
            lblApp.AutoSize = true;
            lblApp.Location = new Point(12, 15);
            lblApp.Name = "lblApp";
            lblApp.Size = new Size(207, 32);
            lblApp.TabIndex = 8;
            lblApp.Text = "Выберите приём:";
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(12, 335);
            lblService.Name = "lblService";
            lblService.Size = new Size(90, 32);
            lblService.TabIndex = 7;
            lblService.Text = "Услуга:";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(360, 335);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(97, 32);
            lblQty.TabIndex = 6;
            lblQty.Text = "Кол-во:";
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(12, 385);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(146, 32);
            lblCost.TabIndex = 5;
            lblCost.Text = "Материалы:";
            // 
            // AppointmentServiceForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(numCost);
            Controls.Add(lblCost);
            Controls.Add(numQty);
            Controls.Add(lblQty);
            Controls.Add(cbServices);
            Controls.Add(lblService);
            Controls.Add(gridServices);
            Controls.Add(cbAppointments);
            Controls.Add(lblApp);
            Name = "AppointmentServiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Услуги на приёме";
            ((System.ComponentModel.ISupportInitialize)gridServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Объявления элементов
        private ComboBox cbAppointments;
        private DataGridView gridServices;
        private ComboBox cbServices;
        private NumericUpDown numQty;
        private NumericUpDown numCost;
        private Button btnAdd;
        private Label lblApp;
        private Label lblService;
        private Label lblQty;
        private Label lblCost;
    }
}