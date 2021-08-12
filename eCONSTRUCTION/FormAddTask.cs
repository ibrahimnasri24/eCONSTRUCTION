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
    public partial class FormAddTask : Form
    {
        DataTable dt;
        public static string TaskField;
        FormChooseWorker frmChooseWorker;
        FormChooseUtility fcni;
        public static bool workeradd = false;
        public static bool utilitiesAdd = false;
        bool editMode;
        int taskID, taskid;

        public FormAddTask()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
        }

        public void EditMode(int TaskID)
        {
            labelAddTask.Text = "Edit Task";
            editMode = true;
            taskID = TaskID;
            dt = FormMain.dl.GetData($"SELECT * FROM Tasks WHERE TaskID = {TaskID}", "TaskToEdit");
            DataRow dr = dt.Rows[0];
            textboxTaskName.Text = dr["TaskName"].ToString();
            comboboxField.SelectedItem = dr["Field"].ToString();
            comboboxPhaseName.SelectedItem = int.Parse(dr["PhaseID"].ToString());
            textboxTaskEstimatedDuration.Text = dr["EstimatedDuration"].ToString();
            datepickerTaskInitiationDate.Value = DateTime.Parse(dr["DateOfBirth"].ToString());
            textboxTaskDescription.Text = dr["Description"].ToString();

        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 7];
            if (textboxTaskName.Text == "")
            { MessageBox.Show("Task name is required"); return; }
            else { parameters[0, 2] = "TaskName"; parameters[1, 2] = textboxTaskName.Text; }

            if (textboxTaskDescription.Text == "")
            { parameters[0, 0] = "Description"; parameters[1, 0] = DBNull.Value; }
            else { parameters[0, 0] = "Description"; parameters[1, 0] = textboxTaskDescription.Text; }

            if (comboboxField.SelectedIndex == -1)
            { MessageBox.Show("Task field is required"); return; }
            else { parameters[0, 1] = "Field"; parameters[1, 1] = comboboxField.SelectedItem.ToString();
                TaskField = comboboxField.SelectedItem.ToString();
            }

            if (datepickerTaskInitiationDate.Value == new DateTime())
            { parameters[0, 3] = "InitiationDate"; parameters[1, 3] = DBNull.Value; }
            else { parameters[0, 3] = "InitiationDate"; parameters[1, 3] = datepickerTaskInitiationDate.Value; }

            if (textboxTaskEstimatedDuration.Text == "")
            { MessageBox.Show("Estimated Duration is required"); return; }

            int estimatedDuration;
            try { estimatedDuration = int.Parse(textboxTaskEstimatedDuration.Text); }
            catch { MessageBox.Show("Estimated Duration should be an Integer"); return; }
            parameters[0, 4] = "EstimatedDuration"; parameters[1, 4] = estimatedDuration;

            if (comboboxPhaseName.SelectedIndex == -1)
            { MessageBox.Show("A phaese selection is required"); return; }
            parameters[0, 5] = "PhaseID"; parameters[1, 5] = comboboxPhaseName.SelectedValue;

            if (FormMain.selectedProjectID == 0)
            { MessageBox.Show("You must have a project selected"); return; }
            parameters[0, 6] = "ProjectID"; parameters[1, 6] = FormMain.selectedProjectID;


            if (workeradd)
            {
                taskid = int.Parse(FormMain.dl.GetValue("addTask", parameters).ToString());
                frmChooseWorker.TaskID = taskid;
                if (frmChooseWorker.AddWorkersChosenToDB())
                    frmChooseWorker.Close();
                else
                { MessageBox.Show("You need add at least one worker"); return; }
            }
            else
            {
                MessageBox.Show("You need add at least one worker"); return;
            }
            if (utilitiesAdd)
            {
                fcni.TaskID = taskid;
                if (fcni.AddUtilitiesChosenToDB())
                    fcni.Close();
            }
            this.Close();
        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {
            dt = FormMain.dl.GetData("SELECT PhaseName, PhaseID FROM Phases", "Phases");
            comboboxPhaseName.DataSource = dt;
            comboboxPhaseName.DisplayMember = "PhaseName";
            comboboxPhaseName.ValueMember = "PhaseID";

            /*object[,] parameters = new object[2, 1];
            parameters[0, 0] = "Field"; parameters[1, 0] = "Electrical";
            dt = FormMain.dl.GetData("FindWorkersInField", parameters,"Workers");
            comboboxWorkerSearch.DataSource = dt;
            comboboxWorkerSearch.DisplayMember = "Name";
            comboboxWorkerSearch.ValueMember = "PersonID";*/
        }

        /*private void comboboxTaskType_SelectedValueChanged(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 1];
            parameters[0, 0] = "Field"; parameters[1, 0] = comboboxField.SelectedItem.ToString();
            dt = FormMain.dl.GetData("FindWorkersInField", parameters, "Workers");
            comboboxWorkerSearch.DataSource = dt;
            comboboxWorkerSearch.DisplayMember = "Name";
            comboboxWorkerSearch.ValueMember = "PersonID";
        }*/

        private void closeAddTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChooseResponsibleWorkers_Click(object sender, EventArgs e)
        {
            workeradd = true;
            frmChooseWorker = new FormChooseWorker();
            frmChooseWorker.ShowDialog();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            utilitiesAdd = true;
            fcni = new FormChooseUtility();
            fcni.ShowDialog();
        }
    }
}
