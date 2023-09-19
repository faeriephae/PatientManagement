namespace PatientManagement
{
    partial class AddAppointmentForm
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
            labelPatient = new Label();
            tbSearch = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            labelDate = new Label();
            labelMemo = new Label();
            dtpAppointment = new DateTimePicker();
            tbMemo = new TextBox();
            labelMedication = new Label();
            dgvMedication = new DataGridView();
            cbMedication = new ComboBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedication).BeginInit();
            SuspendLayout();
            // 
            // labelPatient
            // 
            labelPatient.AutoSize = true;
            labelPatient.Location = new Point(92, 39);
            labelPatient.Name = "labelPatient";
            labelPatient.Size = new Size(47, 15);
            labelPatient.TabIndex = 0;
            labelPatient.Text = "Patient:";
            // 
            // tbSearch
            // 
            tbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbSearch.Location = new Point(95, 57);
            tbSearch.Margin = new Padding(3, 2, 3, 2);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "search patients...";
            tbSearch.Size = new Size(291, 23);
            tbSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(392, 57);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(25, 25);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "o";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(423, 57);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(66, 25);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(92, 99);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(34, 15);
            labelDate.TabIndex = 8;
            labelDate.Text = "Date:";
            // 
            // labelMemo
            // 
            labelMemo.AutoSize = true;
            labelMemo.Location = new Point(92, 193);
            labelMemo.Name = "labelMemo";
            labelMemo.Size = new Size(45, 15);
            labelMemo.TabIndex = 9;
            labelMemo.Text = "Memo:";
            // 
            // dtpAppointment
            // 
            dtpAppointment.Location = new Point(95, 117);
            dtpAppointment.MinDate = new DateTime(1999, 1, 1, 0, 0, 0, 0);
            dtpAppointment.Name = "dtpAppointment";
            dtpAppointment.Size = new Size(214, 23);
            dtpAppointment.TabIndex = 11;
            // 
            // tbMemo
            // 
            tbMemo.Location = new Point(95, 211);
            tbMemo.Multiline = true;
            tbMemo.Name = "tbMemo";
            tbMemo.Size = new Size(394, 167);
            tbMemo.TabIndex = 12;
            // 
            // labelMedication
            // 
            labelMedication.AutoSize = true;
            labelMedication.Location = new Point(567, 193);
            labelMedication.Name = "labelMedication";
            labelMedication.Size = new Size(70, 15);
            labelMedication.TabIndex = 14;
            labelMedication.Text = "Medication:";
            // 
            // dgvMedication
            // 
            dgvMedication.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedication.Location = new Point(567, 240);
            dgvMedication.Name = "dgvMedication";
            dgvMedication.RowTemplate.Height = 25;
            dgvMedication.Size = new Size(121, 138);
            dgvMedication.TabIndex = 15;
            // 
            // cbMedication
            // 
            cbMedication.FormattingEnabled = true;
            cbMedication.Location = new Point(567, 211);
            cbMedication.Name = "cbMedication";
            cbMedication.Size = new Size(121, 23);
            cbMedication.TabIndex = 16;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(95, 394);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 33);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(cbMedication);
            Controls.Add(dgvMedication);
            Controls.Add(labelMedication);
            Controls.Add(tbMemo);
            Controls.Add(dtpAppointment);
            Controls.Add(labelMemo);
            Controls.Add(labelDate);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(tbSearch);
            Controls.Add(labelPatient);
            Name = "AddAppointmentForm";
            Text = "AddTreatmentForm";
            Load += AddAppointmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedication).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label labelPatient;
        public TextBox tbSearch;
        public Button btnSearch;
        public Button btnAdd;
        public Label labelDate;
        public Label labelMemo;
        public TextBox tbMemo;
        public DateTimePicker dtpAppointment;
        public Label labelMedication;
        public DataGridView dgvMedication;
        public ComboBox cbMedication;
        public Button btnSave;
    }
}