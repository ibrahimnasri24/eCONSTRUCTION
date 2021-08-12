using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace eCONSTRUCTION
{
    public partial class FormChooseWorker : Form
    {
        DataTable dt;
        eCONSTRUCTIONcontrols.ControlWorker workerControl;
        eCONSTRUCTIONcontrols.ControlWorkerSmall workerControlSmall;
        //Stack<eCONSTRUCTIONcontrols.ControlWorkerSmall> wcsStack = new Stack<eCONSTRUCTIONcontrols.ControlWorkerSmall>();
        //eCONSTRUCTIONcontrols.ControlWorkerSmall[] wcsArr = new eCONSTRUCTIONcontrols.ControlWorkerSmall[50];
        public int TaskID { get; set; }
        public FormChooseWorker()
        {
            InitializeComponent();
        }

        public int RefreshSourceWorkerControls(string field, string searchKeyWord)
        {
            if (field == "All") field = "";
            int i = 0;
            if (field == "")
            {
                if (searchKeyWord == "")
                {
                    dt = FormMain.dl.GetData("SELECT * FROM Workers, Persons WHERE Workers.PersonID = Persons.PersonID ORDER BY FirstName", "Workers");
                }
                else
                {
                    dt = FormMain.dl.GetData("SELECT * FROM Workers, Persons WHERE Workers.PersonID = Persons.PersonID AND CONCAT(FirstName, MiddleName, LastName) LIKE '%" + searchKeyWord + "%' ORDER BY FirstName", "Workers");
                }
            }
            else
            {
                if (searchKeyWord == "")
                {
                    dt = FormMain.dl.GetData("SELECT * FROM Workers, Persons WHERE Workers.PersonID = Persons.PersonID AND Field = '" + field + "' ORDER BY FirstName", "Workers");
                }
                else
                {
                    dt = FormMain.dl.GetData("SELECT * FROM Workers, Persons WHERE Workers.PersonID = Persons.PersonID AND Field = '" + field + "'" + " AND CONCAT(FirstName, MiddleName, LastName) LIKE '%" + searchKeyWord + "%' ORDER BY FirstName", "Workers");
                }
            }
            flowLayoutWorkerSource.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                eCONSTRUCTIONcontrols.ControlWorker wc = new eCONSTRUCTIONcontrols.ControlWorker();
                wc.FirstName = dr["FirstName"].ToString();
                wc.LastName = dr["LastName"].ToString();
                wc.Company = dr["Company"].ToString();
                wc.Field = dr["Field"].ToString();
                wc.Title = dr["Title"].ToString();
                wc.WorkerID = int.Parse(dr["WorkerID"].ToString()) ;
                wc.Img = (byte[])dr["Image"];
                flowLayoutWorkerSource.Controls.Add(wc);
                i++;
                wc.MouseDown += wc_MouseDown;
            }
            return i;
        }

        private void wc_MouseDown(object sender, MouseEventArgs e)
        {
            workerControl = (eCONSTRUCTIONcontrols.ControlWorker)sender;
            Bitmap bitmap = new Bitmap(workerControl.Width, workerControl.Height);
            workerControl.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            this.DoDragDrop(workerControl.Name, DragDropEffects.Move);
        }

        private void FormChooseWorker_Load(object sender, EventArgs e)
        {
            RefreshSourceWorkerControls("", "");
        }

        private void closeAddTask_Click(object sender, EventArgs e)
        {
            FormAddTask.workeradd = false;
            this.Close();
        }

        private void comboboxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search, field;
            try { search = textboxWorkerSearch.Text; }
            catch { search = ""; }
            if (comboboxField.SelectedItem == null) field = "";
            else field = comboboxField.SelectedItem.ToString();
            RefreshSourceWorkerControls(field, search);
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string search,field;
            try { search = textboxWorkerSearch.Text; }
            catch { search = ""; }
            if (comboboxField.SelectedItem == null) field = "";
            else field = comboboxField.SelectedItem.ToString();
            RefreshSourceWorkerControls(field, search);
        }

        private void flowLayoutWorkersChosen_DragDrop(object sender, DragEventArgs e)
        {
            for (int i = 1; i < flowLayoutWorkersChosen.Controls.Count; i++)
            {
                workerControlSmall = (eCONSTRUCTIONcontrols.ControlWorkerSmall)flowLayoutWorkersChosen.Controls[i];
                if (workerControl.WorkerID == workerControlSmall.WorkerID)
                {
                    flowLayoutWorkersChosen.BorderStyle = BorderStyle.None;
                    return;
                }
            }
            eCONSTRUCTIONcontrols.ControlWorkerSmall wcs = new eCONSTRUCTIONcontrols.ControlWorkerSmall();
            wcs.FirstName = workerControl.FirstName;
            wcs.LastName = workerControl.LastName;
            wcs.Company = workerControl.Company;
            wcs.Field = workerControl.Field;
            wcs.WorkerID = workerControl.WorkerID;

            flowLayoutWorkersChosen.Controls.Add(wcs);

            flowLayoutWorkersChosen.AutoScrollPosition = new Point(wcs.Left, wcs.Right);

            flowLayoutWorkersChosen.BorderStyle = BorderStyle.None;
        }

        public bool AddWorkersChosenToDB()
        {
            object[,] parameters = new object[2,4];
            if (flowLayoutWorkersChosen.Controls.Count == 1) return false;
            for(int i = 1; i < flowLayoutWorkersChosen.Controls.Count; i++)
            {
                workerControlSmall = (eCONSTRUCTIONcontrols.ControlWorkerSmall)flowLayoutWorkersChosen.Controls[i];
                parameters[0, 0] = "WorkerID";          parameters[1, 0] = workerControlSmall.WorkerID;
                parameters[0, 1] = "TaskID";            parameters[1, 1] = TaskID;
                bool hourly;
                double Rate = workerControlSmall.Rate(out hourly);
                if(Rate == -1)
                {
                    if (hourly)
                    {
                        parameters[0, 2] = "HourlyRate"; parameters[1, 2] = DBNull.Value;
                        parameters[0, 3] = "TaskRate";   parameters[1, 3] = DBNull.Value;
                    }
                    else
                    {
                        parameters[0, 2] = "HourlyRate"; parameters[1, 2] = DBNull.Value;
                        parameters[0, 3] = "TaskRate"; parameters[1, 3] = DBNull.Value;
                    }
                }
                else
                {
                    if (hourly)
                    {
                        parameters[0, 2] = "HourlyRate"; parameters[1, 2] = Rate;
                        parameters[0, 3] = "TaskRate"; parameters[1, 3] = DBNull.Value;
                    }
                    else
                    {
                        parameters[0, 2] = "HourlyRate"; parameters[1, 2] = DBNull.Value;
                        parameters[0, 3] = "TaskRate"; parameters[1, 3] = Rate;
                    }
                }
                System.Diagnostics.Debug.WriteLine($"{workerControlSmall.WorkerID} {Rate} {hourly}");
                FormMain.dl.ExecuteActionCommand("addWorkforce", parameters);
            }
            return true;
        }

        private void flowLayoutWorkersChosen_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowLayoutWorkersChosen_DragOver(object sender, DragEventArgs e)
        {
            flowLayoutWorkersChosen.BorderStyle = BorderStyle.FixedSingle;
        }

        private void flowLayoutWorkersChosen_DragLeave(object sender, EventArgs e)
        {
            flowLayoutWorkersChosen.BorderStyle = BorderStyle.None;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(flowLayoutWorkersChosen.Controls.Count);
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
