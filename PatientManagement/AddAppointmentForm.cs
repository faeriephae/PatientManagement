using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PatientManagement.BusinessLayer;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientManagement.Data;
using PatientManagement.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PatientManagement
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Set datasources for combobox and autocomplete
                cbMedication.DataSource = TreatmentAccessLayer.GetMedicationList();
                tbSearch.AutoCompleteCustomSource.AddRange(TreatmentAccessLayer.GetPatientsArray());
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                new AddPatient().ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Check for empty fields
                string meds = cbMedication.SelectedItem.ToString();
                string date = dtpAppointment.Text;
                string patient = tbSearch.Text;

                if (patient != "" && date != "" && meds != "")
                {
                    //Split fullname
                    string[] name = tbSearch.Text.ToLower().Split(' ');

                    TreatmentDto dto = new()
                    {
                        Date = date,
                        Firstname = name[0],
                        Lastname = name[1],
                        Medication = cbMedication.SelectedItem == null ? "None" : meds,
                        Memo = tbMemo.Text,
                        PatientId = LoginAccessLayer.GetPersonId(name)
                    };

                    //MessageBox.Show($"Date: {dtpAppointment.Text} \n Patient: {name[0]} {name[1]} \n Memo: {tbMemo.Text} \n Meds: {cbMedication.SelectedItem.ToString()}");
                    
                    //Add appointment
                    if (TreatmentAccessLayer.AddAppointment(dto))
                    {
                        MessageBox.Show("Save successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else throw new Exception("Save failed.");
                }
                else MessageBox.Show("Please fill out all input fields.");
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }
    }
}
