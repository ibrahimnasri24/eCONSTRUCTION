using eCONSTRUCTIONcontrols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace eCONSTRUCTION
{
    public partial class FormMain : Form
    {
        public static FormAddProject formProjAdd;
        ControlProject pControl;
        public static int selectedProjectID;
        public static DataLayer dl = new DataLayer(@".\SQLEXPRESS", "eCONSTRUCT");
        bool selectAllProjects = true;
        DataTable dt;
        DateTime Default = new DateTime();
        public FormMain()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panelTopBar);
        }
        private void ShowHideTaskBarControls(bool show)
        {
            if (show)
            {
                combobooxTitle.Show();
                comboboxField.Show();
                comboboxProject.Show();
                textboxWorkerSearch.Show();
                buttonProjectAll.Show();
                buttonWorkerSearch.Show();
            }
            else
            {
                combobooxTitle.Hide();
                comboboxField.Hide();
                comboboxProject.Hide();
                textboxWorkerSearch.Hide();
                buttonProjectAll.Hide();
                buttonWorkerSearch.Hide();
            }
        }
        private void formMain_Load(object sender, EventArgs e)
        {
            dt = FormMain.dl.GetData("SELECT ProjectName, ProjectID FROM Projects", "Projects");
            comboboxProject.DataSource = dt;
            comboboxProject.DisplayMember = "ProjectName";
            comboboxProject.ValueMember = "ProjectID";
            comboboxField.SelectedItem = "All";
            combobooxTitle.SelectedItem = "All";
            ShowHideTaskBarControls(false);
            RefreshProjects();
            RefreshWorkers(true);
            RefreshTaskSchedule(DateTime.Now, true);
            RefreshSuppliers();
        }

        private void RefreshWorkers(bool atLoad)
        {
            if (panelIndicator.Location.Y != buttonWorkers.Location.Y && !atLoad) return;
            string nameSearch, fieldSelect, titleSelect;
            if (textboxWorkerSearch.Text == null)
            {
                nameSearch = "";
            }
            else
            {
                nameSearch = textboxWorkerSearch.Text;
            }
            if(comboboxField.SelectedIndex == -1)
            {
                fieldSelect = "";
            }
            else
            {
                if (comboboxField.SelectedItem.ToString() == "All")
                    fieldSelect = "";
                else
                    fieldSelect = comboboxField.SelectedItem.ToString();
            }
            if (combobooxTitle.SelectedIndex == -1)
            {
                titleSelect = "";
            }
            else
            {
                if (combobooxTitle.SelectedItem.ToString() == "All")
                    titleSelect = "";
                else
                    titleSelect = combobooxTitle.SelectedItem.ToString();
            }
            string query = $@"   SELECT Image, CONCAT(FirstName, ' ', LastName) AS txtName, WorkerID, Company, PhoneNumber, Email, Field, Title
                                FROM Persons, Workers
                                WHERE Persons.PersonID = Workers.PersonID
                                AND (
                                FirstName LIKE '%{nameSearch}%'
                                OR MiddleName LIKE '%{nameSearch}%'
                                OR LastName LIKE '%{nameSearch}%'
                                OR Company LIKE '%{nameSearch}%')
                                AND Field LIKE '%{fieldSelect}%'
                                AND Title LIKE '%{titleSelect}%'
                                ";
            if(!selectAllProjects & comboboxProject.SelectedIndex != -1)
            {
                DataRowView drv = comboboxProject.SelectedItem as DataRowView;
                query += $@" AND WorkerID IN
	                        (SELECT WorkerID
	                        FROM Workforce
	                        WHERE TaskID IN(SELECT TaskID
					                        FROM Tasks 
					                        WHERE ProjectID = {drv["ProjectID"]}))";
            }
            dt = dl.GetData(query, "Workers");
            dataGridViewWorkers.DataSource = dt;
        }
        private int RefreshProjects()
        {
            flowLayoutProjects.Controls.Clear();
            int i = 0;
            dt = dl.GetData("SELECT * FROM Projects", "Projects");
            foreach (DataRow dr in dt.Rows)
            {
                ControlProject pc = new ControlProject();
                pc.ProjectID = int.Parse(dr["ProjectID"].ToString());
                pc.ProjectName = dr["ProjectName"].ToString();
                pc.Description = dr["Description"].ToString();
                pc.InitiationDate = DateTime.Parse(dr["InitiationDate"].ToString());
                try
                {
                    pc.TerminationDate = DateTime.Parse(dr["TerminationDate"].ToString());
                }
                catch
                {
                    pc.TerminationDate = Default;
                }
                try
                {
                    pc.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                }
                catch
                {
                    pc.DueDate = Default;
                }
                pc.ProjectType = dr["ProjectType"].ToString();
                pc.Phase = "Design";
                pc.Arch = "Aya Nasri";
                pc.CivilEng = "Akram Nasri";
                pc.ElecEng = "Ibrahim Nasri";
                pc.TasksProgress = 3;
                pc.TasksProgress = 79;

                flowLayoutProjects.Controls.Add(pc);
                pc.Click += Pc_Click;
                i++;
            }
            labelProjectsResultCount.Text = i.ToString() + " Projects";
            return i;
        }

        private int[] TaskDateVisualize(DateTime date1,DateTime date2, DateTime initiationDate, int EstimatedDuration)
        {
            int[] arr = new int[2];
            int span, start;
            DateTime estimatedTerminationDate = initiationDate.Date.AddDays(EstimatedDuration - 1);
            if(initiationDate.Date <= date1.Date)
            {
                start = 0;
            }
            else
            {
                start = (initiationDate.Date - date1.Date).Days;
            }
            if (estimatedTerminationDate.Date == initiationDate.Date)
            {
                span = 1;
            }
            else
            {
                if(estimatedTerminationDate.Date <= date2.Date)
                {
                    span = (estimatedTerminationDate.Date - ((initiationDate.Date > date1.Date) ? initiationDate.Date : date1.Date)).Days + 1;
                }
                else
                {
                    span = (date2.Date - ((initiationDate.Date > date1.Date) ? initiationDate.Date : date1.Date)).Days + 1;
                }
            }
            arr[0] = start; arr[1] = span;
            return arr;
        }
        public static void TaskEnd(int TaskID)
        {

        }
        private void RefreshTaskSchedule(DateTime date1, bool atLoad)
        {
            if (panelIndicator.Location.Y != buttonTasks.Location.Y && !atLoad) return;
            tableLayoutPanelTaskSchedule.Controls.Clear();
            for (int i = 0; i < tableLayoutPanelTaskSchedule.ColumnCount; i++)
            {
                Label labelDayOfWeek = new Label();
                labelDayOfWeek.BackColor = Color.Transparent;
                labelDayOfWeek.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                labelDayOfWeek.AutoSize = false;
                labelDayOfWeek.ForeColor = Color.White;
                labelDayOfWeek.TextAlign = ContentAlignment.MiddleCenter;
                labelDayOfWeek.Dock = DockStyle.Fill;
                labelDayOfWeek.Text = date1.AddDays(i).DayOfWeek.ToString();
                tableLayoutPanelTaskSchedule.Controls.Add(labelDayOfWeek, i, 0);

                Label labelDate = new Label();
                labelDate.BackColor = Color.Transparent;
                labelDate.Font = new Font("Century Gothic", 8);
                labelDate.AutoSize = false;
                labelDate.ForeColor = Color.White;
                labelDate.TextAlign = ContentAlignment.MiddleCenter;
                labelDate.Dock = DockStyle.Fill;
                labelDate.Text = date1.AddDays(i).ToShortDateString();
                tableLayoutPanelTaskSchedule.Controls.Add(labelDate, i, 1);

                Panel panel1 = new Panel();
                panel1.BackColor = Color.FromArgb(48, 48, 58);
                panel1.Dock = DockStyle.Fill;
                tableLayoutPanelTaskSchedule.Controls.Add(panel1, i, 2);
            }

            DateTime date2 = date1.Date.AddDays(tableLayoutPanelTaskSchedule.ColumnCount - 1);

            object[,] parameters = new object[2, 4];
            parameters[0, 0] = "Date1"; parameters[1, 0] = date1.Date;
            parameters[0, 1] = "Date2"; parameters[1, 1] = date2.Date;

            DataRowView drv = comboboxProject.SelectedItem as DataRowView;
            int ProjectID = 0;
            if (!selectAllProjects) ProjectID = int.Parse(drv["ProjectID"].ToString());
            parameters[0, 2] = "ProjectID"; parameters[1, 2] = ProjectID;


            parameters[0, 3] = "Field"; parameters[1, 3] = comboboxField.SelectedItem.ToString();
            dt = dl.GetData("findTasksBetweenTwoDates", parameters, "TasksBetweenTwoDates");

            int[] arr = new int[2];
            int j = 3;
            foreach (DataRow dr in dt.Rows)
            {
                ControlTaskDay ctd = new ControlTaskDay();
                if (dr["TerminationDate"] == DBNull.Value)
                {
                    ctd.TaskName = dr["TaskName"].ToString();
                    ctd.Field = dr["Field"].ToString();
                    ctd.TaskID = int.Parse(dr["TaskID"].ToString());
                    ctd.Project = dl.GetValue($"SELECT ProjectName FROM Projects WHERE ProjectID = {int.Parse(dr["ProjectID"].ToString())}").ToString();

                    arr = TaskDateVisualize(date1, date2, (DateTime)dr["InitiationDate"], int.Parse(dr["EstimatedDuration"].ToString()));

                    tableLayoutPanelTaskSchedule.Controls.Add(ctd, arr[0], j);
                    tableLayoutPanelTaskSchedule.SetColumnSpan(ctd, arr[1]);

                    j += 2;
                }
            }
        }
        public void RefreshSuppliers()
        {
            string nameSearch;
            if (textboxWorkerSearch.Text == null)
            {
                nameSearch = "";
            }
            else
            {
                nameSearch = textboxWorkerSearch.Text;
            }
            string query = $@"   SELECT * FROM Suppliers  WHERE 
                            CompanyName LIKE '%{nameSearch}%' ";
            dt = dl.GetData(query, "Suppliers");
            dataGridViewSuppliers.DataSource = dt;
        }

        private void RefreshPayments()
        {
            string query1 = $@"SELECT Image, CONCAT(FirstName, ' ', LastName) AS txtName, Workers.WorkerID, Tasks.TaskID, TaskName, AmountPaid, PaymentDate
                            FROM Persons, Workers, Tasks, Payments, Workforce
                            WHERE Persons.PersonID = Workers.PersonID
                            AND Tasks.TaskID = Payments.TaskID
                            AND Workers.WorkerID = Payments.WorkerID
                            AND Workforce.TaskID  = Tasks.TaskID
                            AND Workforce.WorkerID  = Workers.WorkerID
                            AND TerminationDate IS NOT NULL
                            ORDER BY Persons.FirstName";

            string query2 = $@"SELECT HourlyRate , HoursWorked , TaskRate
                            FROM Persons, Workers, Tasks, Payments, Workforce
                            WHERE Persons.PersonID = Workers.PersonID
                            AND Tasks.TaskID = Payments.TaskID
                            AND Workers.WorkerID = Payments.WorkerID
                            AND Workforce.TaskID  = Tasks.TaskID
                            AND Workforce.WorkerID  = Workers.WorkerID
                            AND TerminationDate IS NOT NULL
                            ORDER BY Persons.FirstName";

            dt = dl.GetData(query1, "nnn");
            DataTable dt2 = dl.GetData(query2, "nn");
            dt.Columns.Add("AmountDue");
            int i = 0;
            foreach(DataRow dr in dt.Rows)
            {
                DataRow dr2 = dt2.Rows[i];
                if(dr2["TaskRate"] == DBNull.Value)
                {
                    dr["AmountDue"] = double.Parse(dr2["HourlyRate"].ToString()) * int.Parse(dr2["HoursWorked"].ToString());
                }
                else
                {
                    dr["AmountDue"] = dr2["TaskRate"];
                }
                i++;
            }
            dataGridViewPayments.DataSource = dt;
        }

        private void IndicatorLocationChange(int y)
        {
            Point p = new Point(0, y);
            panelIndicator.Location = p;
        }
        private void Pc_Click(object sender, EventArgs e)
        {
            pControl = (ControlProject)sender;
            if (pControl.TerminationDate == Default)
                labelTerminationDate.Text = "Project still in progress";
            else
                labelTerminationDate.Text = pControl.TerminationDate.Date.ToString();
            labelInitiationDate.Text = pControl.InitiationDate.ToString().Substring(0, 10);
            labelProjectType.Text = pControl.ProjectType;
            labelDescription.Text = pControl.Description;
            selectedProjectID = pControl.ProjectID;
            labelProjectSelect.Text = pControl.ProjectName;
        }
        private void buttonProjects_Click(object sender, EventArgs e)
        {
            pagesMain.SetPage(tabProjects);
            IndicatorLocationChange(buttonProjects.Location.Y);
        }
        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void buttonWorkers_Click(object sender, EventArgs e)
        {
            ShowHideTaskBarControls(true);
            pagesMain.SetPage(tabWorkers);
            IndicatorLocationChange(buttonWorkers.Location.Y);
        }

        private void buttonTasks_Click(object sender, EventArgs e)
        {
            ShowHideTaskBarControls(false);
            comboboxProject.Show();
            comboboxField.Show();
            buttonProjectAll.Show();
            pagesMain.SetPage(tabTasks);
            IndicatorLocationChange(buttonTasks.Location.Y);
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            RefreshProjects();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            formProjAdd = new FormAddProject();
            formProjAdd.ShowDialog();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            FormAddTask formtaskAdd = new FormAddTask();
            formtaskAdd.ShowDialog();
        }

        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            FormAddWorker f = new FormAddWorker();
            f.ShowDialog();
        }

        private void buttonWorkerSearch_Click(object sender, EventArgs e)
        {
            RefreshWorkers(false);
            RefreshSuppliers();
        }
        private void buttonCost_Click(object sender, EventArgs e)
        {
            RefreshPayments();
            pagesMain.SetPage(tabPayments);
            ShowHideTaskBarControls(false);
            IndicatorLocationChange(buttonPayments.Location.Y);
        }

        private void comboboxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkers(false);
            RefreshTaskSchedule(datepickerDay.Value, false);
        }

        private void comboboxProject_Click(object sender, EventArgs e)
        {
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (!selectAllProjects)
            {
                selectAllProjects = true;
                buttonProjectAll.OnPressedState.FillColor = Color.FromArgb(255, 161, 10);
                buttonProjectAll.OnPressedState.ForeColor = Color.Black;
            }
            else
            {
                selectAllProjects = false;
                buttonProjectAll.OnPressedState.FillColor = Color.Transparent;
                buttonProjectAll.OnPressedState.ForeColor = Color.White;
            }
            RefreshWorkers(false);
            RefreshTaskSchedule(datepickerDay.Value, false);
        }

        private void comboboxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkers(false);
            RefreshTaskSchedule(datepickerDay.Value, false);
        }

        private void combobooxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkers(false);
        }

        private void datepickerDay_ValueChanged(object sender, EventArgs e)
        {
            RefreshTaskSchedule(datepickerDay.Value, false);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            datepickerDay.Value = datepickerDay.Value.AddDays(1);
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            datepickerDay.Value = datepickerDay.Value.AddDays(-1);
        }

        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            FormAddWorker f = new FormAddWorker();
            int SelectedWorkerID = int.Parse(dataGridViewWorkers.SelectedRows[0].Cells["WorkerID"].FormattedValue.ToString());
            f.EditMode(SelectedWorkerID);
            f.ShowDialog();
        }

        private void buttonUtilities_Click(object sender, EventArgs e)
        {
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            pagesMain.SetPage(tabSuppliers);
            ShowHideTaskBarControls(false);
            textboxWorkerSearch.Show();
            buttonWorkerSearch.Show();
            IndicatorLocationChange(buttonSuppliers.Location.Y);
            RefreshSuppliers();
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddSupplier f = new FormAddSupplier();
            f.formmain = this;
            f.ShowDialog();
        }

        private void buttonEditSupplier_Click(object sender, EventArgs e)
        {
            FormAddSupplier f = new FormAddSupplier();
            int SelectedSuppliersID = int.Parse(dataGridViewSuppliers.SelectedRows[0].Cells["SuppliersID"].FormattedValue.ToString());
            f.EditMode(SelectedSuppliersID);
            f.formmain = this;
            f.ShowDialog();
        }

        private void buttonDeleteSupplier_Click(object sender, EventArgs e)
        {
            int SelectedSupplierID = int.Parse(dataGridViewSuppliers.SelectedRows[0].Cells["SuppliersID"].FormattedValue.ToString());

            dl.ExecuteActionCommand($@" DELETE FROM Machinery WHERE SuppliersID = {SelectedSupplierID}
                                        DELETE FROM Materials WHERE SuppliersID = {SelectedSupplierID}
                                        DELETE FROM Vehicles WHERE SuppliersID = {SelectedSupplierID}
                                        DELETE FROM Suppliers WHERE SuppliersID = {SelectedSupplierID}");
            RefreshSuppliers();
        }
    }
}