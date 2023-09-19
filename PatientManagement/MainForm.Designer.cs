namespace PatientManagement
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelCurrentUser = new Label();
            labelDisplayName = new Label();
            dgvTreatment = new DataGridView();
            tbSearch = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnSearch = new Button();
            dgvMedication = new DataGridView();
            label1 = new Label();
            labelMedication = new Label();
            btnAddAppointment = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTreatment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedication).BeginInit();
            SuspendLayout();
            // 
            // labelCurrentUser
            // 
            labelCurrentUser.AutoSize = true;
            labelCurrentUser.Location = new Point(42, 29);
            labelCurrentUser.Name = "labelCurrentUser";
            labelCurrentUser.Size = new Size(75, 15);
            labelCurrentUser.TabIndex = 0;
            labelCurrentUser.Text = "Current user:";
            // 
            // labelDisplayName
            // 
            labelDisplayName.AutoSize = true;
            labelDisplayName.Location = new Point(130, 29);
            labelDisplayName.Name = "labelDisplayName";
            labelDisplayName.Size = new Size(0, 15);
            labelDisplayName.TabIndex = 1;
            // 
            // dgvTreatment
            // 
            dgvTreatment.AllowUserToDeleteRows = false;
            dgvTreatment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTreatment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTreatment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTreatment.Location = new Point(45, 129);
            dgvTreatment.Margin = new Padding(3, 2, 3, 2);
            dgvTreatment.MultiSelect = false;
            dgvTreatment.Name = "dgvTreatment";
            dgvTreatment.RowHeadersWidth = 51;
            dgvTreatment.RowTemplate.Height = 29;
            dgvTreatment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatment.Size = new Size(453, 266);
            dgvTreatment.TabIndex = 2;
            dgvTreatment.RowEnter += dgvTreatment_RowEnter;
            // 
            // tbSearch
            // 
            tbSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbSearch.Location = new Point(45, 58);
            tbSearch.Margin = new Padding(3, 2, 3, 2);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "search...";
            tbSearch.Size = new Size(291, 23);
            tbSearch.TabIndex = 3;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(340, 58);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 25);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "o";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvMedication
            // 
            dgvMedication.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedication.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMedication.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedication.Location = new Point(535, 129);
            dgvMedication.Margin = new Padding(3, 2, 3, 2);
            dgvMedication.Name = "dgvMedication";
            dgvMedication.RowHeadersWidth = 51;
            dgvMedication.RowTemplate.Height = 29;
            dgvMedication.Size = new Size(219, 266);
            dgvMedication.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 112);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 6;
            label1.Text = "Appointments:";
            // 
            // labelMedication
            // 
            labelMedication.AutoSize = true;
            labelMedication.Location = new Point(535, 112);
            labelMedication.Name = "labelMedication";
            labelMedication.Size = new Size(70, 15);
            labelMedication.TabIndex = 7;
            labelMedication.Text = "Medication:";
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Location = new Point(407, 100);
            btnAddAppointment.Margin = new Padding(3, 2, 3, 2);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(91, 25);
            btnAddAppointment.TabIndex = 8;
            btnAddAppointment.Text = "Add Appointment...";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddAppointment);
            Controls.Add(labelMedication);
            Controls.Add(label1);
            Controls.Add(dgvMedication);
            Controls.Add(btnSearch);
            Controls.Add(tbSearch);
            Controls.Add(dgvTreatment);
            Controls.Add(labelDisplayName);
            Controls.Add(labelCurrentUser);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTreatment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedication).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCurrentUser;
        public Label labelDisplayName;
        public TextBox tbSearch;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        public Button btnSearch;
        public DataGridView dgvTreatment;
        private Button button1;
        public DataGridView dgvMedication;
        private Label label1;
        private Label labelMedication;
        public Button btnAddAppointment;
    }
}