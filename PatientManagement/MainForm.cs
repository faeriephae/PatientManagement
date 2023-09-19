using PatientManagement.BusinessLayer;
using System.Drawing.Text;

namespace PatientManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                labelDisplayName.Text = (LoginAccessLayer.IsLoggedIn) ? LoginAccessLayer.username : "Unknown User";
                dgvTreatment.DataSource = TreatmentAccessLayer.GetTreatmentList();
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvTreatment.DataSource = TreatmentAccessLayer.GetTreatmentList(tbSearch.Text);
        }

        private void dgvTreatment_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Column index 0 --> Patient Id 
                int patientId = (int)dgvTreatment.Rows[e.RowIndex].Cells[0].Value;
                dgvMedication.DataSource = TreatmentAccessLayer.GetMedicationList(patientId);
            }
            catch (Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }
        }

        //Open AddAppointment Modal
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                new AddAppointmentForm().ShowDialog();
            }
            catch(Exception ex)
            {
                ErrorHandling.ErrorMsg(ex);
            }

        }
    }
}