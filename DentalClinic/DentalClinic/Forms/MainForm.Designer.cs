namespace DentalClinic.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            menuDictionaries = new ToolStripMenuItem();
            menuPatients = new ToolStripMenuItem();
            menuDoctors = new ToolStripMenuItem();
            menuServices = new ToolStripMenuItem();
            menuOperations = new ToolStripMenuItem();
            menuAppointments = new ToolStripMenuItem();
            menuAppointmentServices = new ToolStripMenuItem();
            menuReports = new ToolStripMenuItem();
            menuDictionaryReport = new ToolStripMenuItem();
            menuOperationsReport = new ToolStripMenuItem();
            menuServicesChartReport = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();

            // 
            // menuStrip (Главное меню)
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuDictionaries, menuOperations, menuReports });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 40);
            menuStrip.TabIndex = 0;

            // 
            // menuDictionaries (Справочники)
            // 
            menuDictionaries.DropDownItems.AddRange(new ToolStripItem[] { menuPatients, menuDoctors, menuServices });
            menuDictionaries.Name = "menuDictionaries";
            menuDictionaries.Text = "Справочники";

            // 
            // menuPatients
            // 
            menuPatients.Name = "menuPatients";
            menuPatients.Text = "Пациенты";
            menuPatients.Click += menuPatients_Click;

            // 
            // menuDoctors
            // 
            menuDoctors.Name = "menuDoctors";
            menuDoctors.Text = "Врачи";
            menuDoctors.Click += menuDoctors_Click;

            // 
            // menuServices
            // 
            menuServices.Name = "menuServices";
            menuServices.Text = "Услуги";
            menuServices.Click += menuServices_Click;

            // 
            // menuOperations (Операции)
            // 
            menuOperations.DropDownItems.AddRange(new ToolStripItem[] { menuAppointments, menuAppointmentServices });
            menuOperations.Name = "menuOperations";
            menuOperations.Text = "Операции";

            // 
            // menuAppointments
            // 
            menuAppointments.Name = "menuAppointments";
            menuAppointments.Text = "Приёмы";
            menuAppointments.Click += menuAppointments_Click;

            // 
            // menuAppointmentServices
            // 
            menuAppointmentServices.Name = "menuAppointmentServices";
            menuAppointmentServices.Text = "Услуги на приёме";
            menuAppointmentServices.Click += menuAppointmentServices_Click;

            // 
            // menuReports (Отчеты)
            // 
            menuReports.DropDownItems.AddRange(new ToolStripItem[] { menuDictionaryReport, menuOperationsReport, menuServicesChartReport });
            menuReports.Name = "menuReports";
            menuReports.Text = "Отчеты";

            //
            // menuDictionaryReport
            //
            menuDictionaryReport.Name = "menuDictionaryReport";
            menuDictionaryReport.Text = "Справочники (Word)";
            menuDictionaryReport.Click += menuDictionaryReport_Click;

            //
            // menuOperationsReport
            //
            menuOperationsReport.Name = "menuOperationsReport";
            menuOperationsReport.Text = "Операции за период (Excel)";
            menuOperationsReport.Click += menuOperationsReport_Click;

            //
            // menuServicesChartReport
            //
            menuServicesChartReport.Name = "menuServicesChartReport";
            menuServicesChartReport.Text = "Диаграмма услуг за день (PDF)";
            menuServicesChartReport.Click += menuServicesChartReport_Click;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Стоматологическая клиника";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // Объявления элементов
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuDictionaries;
        private ToolStripMenuItem menuPatients;
        private ToolStripMenuItem menuDoctors;
        private ToolStripMenuItem menuServices;
        private ToolStripMenuItem menuOperations;
        private ToolStripMenuItem menuAppointments;
        private ToolStripMenuItem menuAppointmentServices;
        private ToolStripMenuItem menuReports;
        private ToolStripMenuItem menuDictionaryReport;
        private ToolStripMenuItem menuOperationsReport;
        private ToolStripMenuItem menuServicesChartReport;
    }
}