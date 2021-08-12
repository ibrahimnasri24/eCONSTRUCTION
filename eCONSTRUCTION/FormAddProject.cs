using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCONSTRUCTION
{
    public partial class FormAddProject : Form
    {
        bool datePickerDueDateWasUsed, datePickerInitiationDateWasUsed;
        public bool newSiteAdded = false;

        public void LoadComboBoxSiteSelect(int i)
        {
            DataTable dt = FormMain.dl.GetData("SELECT SiteName, SiteID FROM Sites", "Sites");
            comboboxSearchSites.DataSource = dt;
            comboboxSearchSites.DisplayMember = "SiteName";
            comboboxSearchSites.ValueMember = "SiteID";
            if (i == 0) return;
            comboboxSearchSites.SelectedValue = i;
        }
        public FormAddProject()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            datePickerDueDateWasUsed = false;
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLinkSite_Click(object sender, EventArgs e)
        {
            FormAddSite SiteAddForm = new FormAddSite();
            SiteAddForm.ShowDialog();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 7];
            if(textboxProjectName.Text == "")
            { MessageBox.Show("Project name is required"); return; }
            else { parameters[0, 0] = "ProjectName";        parameters[1, 0] = textboxProjectName.Text; }

            if (!datePickerInitiationDateWasUsed)
            { MessageBox.Show("Project Initiation Date is required"); return; }
            else {  parameters[0, 1] = "InitiationDate";    parameters[1, 1] = datePickerInitiationDate.Value; }

                    parameters[0, 2] = "TerminationDate";   parameters[1, 2] = DBNull.Value;

            if (!datePickerDueDateWasUsed)
            {      parameters[0, 3] = "DueDate";            parameters[1, 3] = DBNull.Value; }
            else { parameters[0, 3] = "DueDate";            parameters[1, 3] = datepickerDueDate.Value; }

            if(comboboxProjectType.SelectedIndex == -1)
            { MessageBox.Show("Project type is required"); return; }
            else { parameters[0, 4] = "ProjectType";        parameters[1, 4] = comboboxProjectType.SelectedItem.ToString(); }

            if(textboxProjectDescription.Text =="")
            { MessageBox.Show("A project description is required"); return; }
            else { parameters[0, 5] = "Description";        parameters[1, 5] = textboxProjectDescription.Text; }

            if (FormAddSite.SiteID == 0)
            {
                if (comboboxSearchSites.SelectedIndex == -1)
                { 
                    MessageBox.Show("A site selection is required");
                    return; 
                }
                    parameters[0, 6] = "SiteID";            parameters[1, 6] = comboboxSearchSites.SelectedValue;
            }
            else
            {
                    parameters[0, 6] = "SiteID";            parameters[1, 6] = FormAddSite.SiteID;
            }

            FormMain.dl.ExecuteActionCommand("addProject", parameters);
            this.Close();
        }

        private void formProjectAdd_Load(object sender, EventArgs e)
        {
            LoadComboBoxSiteSelect(0);
        }

        private void datepickerDueDate_ValueChanged(object sender, EventArgs e)
        {
            datePickerDueDateWasUsed = true;
        }

        private void datePickerInitiationDate_ValueChanged(object sender, EventArgs e)
        {
            datePickerInitiationDateWasUsed = true;
        }

        private void comboboxSearchSites_Click(object sender, EventArgs e)
        {

        }
    }
}
