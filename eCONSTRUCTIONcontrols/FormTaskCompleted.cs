using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

namespace eCONSTRUCTIONcontrols
{
    public partial class FormTaskCompleted : Form
    {
        public int TaskID { get; set; }
        DataLayerControls dlc = new DataLayerControls(@".\SQLEXPRESS", "eCONSTRUCT");
        public FormTaskCompleted()
        {
            InitializeComponent();
        }

        private int CheckControlWorkerTaskEnd(ControlWorkerSmallTaskEnd cworker)
        {
            Debug.WriteLine($"Checking  HourlyRate:{cworker.HourlyRate} HoursWorked:{cworker.HourseWorked} TaskRate:{cworker.TaskRate}");
            if (cworker.TaskRate == -1)
            {
                if(cworker.HourlyRate == -1)
                {
                    return -1;
                }
                else
                {
                    if (cworker.HourseWorked == -1 || cworker.HourseWorked == 0)
                        return -1;
                    return 0;
                }
            }
            return 1;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 5];
            int check;
            foreach (ControlWorkerSmallTaskEnd cworker in flowLayoutWorkersOnTask.Controls)
            {
                if (!cworker.RefreshValues()) return;

                Debug.WriteLine($"HourlyRate:{cworker.HourlyRate} HoursWorked:{cworker.HourseWorked} TaskRate:{cworker.TaskRate}");
                check = CheckControlWorkerTaskEnd(cworker);
                Debug.WriteLine($"HourlyRate:{cworker.HourlyRate} HoursWorked:{cworker.HourseWorked} TaskRate:{cworker.TaskRate}");

                if (check == -1) { MessageBox.Show("One of the workers doesn't have a cost assigned"); return; }
                    parameters[0, 0] = "WorkerID";      parameters[1, 0] = cworker.WorkerID;
                    parameters[0, 1] = "TaskID";        parameters[1, 1] = TaskID;
                if (check == 0)
                {
                    parameters[0, 2] = "HourlyRate";    parameters[1, 2] = cworker.HourlyRate;
                    parameters[0, 3] = "HoursWorked";   parameters[1, 3] = cworker.HourseWorked;
                    parameters[0, 4] = "TaskRate";      parameters[1, 4] = DBNull.Value;
                }
                else
                {
                    parameters[0, 2] = "HourlyRate";    parameters[1, 2] = DBNull.Value;
                    parameters[0, 3] = "HoursWorked";   parameters[1, 3] = DBNull.Value;
                    parameters[0, 4] = "TaskRate";      parameters[1, 4] = cworker.TaskRate;
                }
                for(int i = 0; i < 5; i++)
                {
                    Debug.WriteLine($"{parameters[0, i]} - {parameters[1, i]}\n");
                }
                dlc.ExecuteActionCommand("editWorkforce", parameters);
            }
            dlc.ExecuteActionCommand($@"UPDATE Tasks 
                                        SET TerminationDate = '{datepickerTerminationDate.Value.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo)}'
                                        WHERE TaskID = {TaskID}");
            this.Close();
        }

        private void FormTaskCompleted_Load(object sender, EventArgs e)
        {
            DataLayerControls dl = new DataLayerControls(@".\SQLEXPRESS", "eCONSTRUCT");
            DataTable dt, dtworker;
            dt = dl.GetData($"SELECT WorkerID FROM Workforce WHERE TaskID = {TaskID}", "WorkerIDsOnTask");
            int WorkerID;
            foreach (DataRow dr1 in dt.Rows)
            {
                WorkerID = int.Parse(dr1["WorkerID"].ToString());
                eCONSTRUCTIONcontrols.ControlWorkerSmallTaskEnd cwste = new eCONSTRUCTIONcontrols.ControlWorkerSmallTaskEnd();
                dtworker = dl.GetData($"SELECT * FROM Workers, Persons, Workforce Where Workers.WorkerID = Workforce.WorkerID AND Workers.PersonID = Persons.PersonID AND Workers.WorkerID = {WorkerID} AND Workforce.TaskID = {TaskID}", "Worker");
                DataRow dr = dtworker.Rows[0];
                cwste.FirstName = dr["FirstName"].ToString();
                cwste.LastName = dr["LastName"].ToString();
                cwste.Company = dr["Company"].ToString();
                cwste.Field = dr["Field"].ToString();

                if (dr["HourlyRate"] == DBNull.Value)
                {
                    cwste.HourseWorked = -1;
                    cwste.HourlyRate = -1;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"{dr["HoursWorked"]}");
                    if (dr["HoursWorked"] == DBNull.Value)
                    {
                        cwste.HourseWorked = -1;
                    }
                    else
                    {
                        cwste.HourseWorked = int.Parse(dr["HoursWorked"].ToString());
                    }
                    System.Diagnostics.Debug.WriteLine($"{dr["HourlyRate"]}");
                    cwste.HourlyRate = double.Parse(dr["HourlyRate"].ToString());
                }
                if (dr["TaskRate"] == DBNull.Value)
                {
                    cwste.TaskRate = -1;
                }
                else
                {
                    cwste.TaskRate = double.Parse(dr["TaskRate"].ToString());
                }
                cwste.WorkerID = WorkerID;
                flowLayoutWorkersOnTask.Controls.Add(cwste);
            }
        }

        private void buttonimageAddWorkerClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            eCONSTRUCTION.FormAddPayment fap = new eCONSTRUCTION.FormAddPayment();
            fap.TaskID = TaskID;
            fap.ShowDialog();
        }
    }
}
