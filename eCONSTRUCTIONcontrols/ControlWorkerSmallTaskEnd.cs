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

namespace eCONSTRUCTIONcontrols
{
    public partial class ControlWorkerSmallTaskEnd : UserControl
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Field { get; set; }
        public double HourlyRate { get; set; }
        public double TaskRate { get; set; }
        public int HourseWorked { get; set; }

        bool hourly = true;
        public int WorkerID { get; set; }
        public ControlWorkerSmallTaskEnd()
        {
            InitializeComponent();
        }

        public bool RefreshValues()
        {
            if (hourly)
            {
                try { HourlyRate = double.Parse(textboxHourlyRate.Text); }
                catch { MessageBox.Show($"Worker {FirstName} {LastName} doesn't have an hourly rate assigned"); return false; }
                try { HourseWorked = int.Parse(textboxHoursWorked.Text); }
                catch { MessageBox.Show($"Worker {FirstName} {LastName} doesn't have a number of worked hours assigned"); return false; }
               
            }
            else
            {
                try { TaskRate = double.Parse(textboxHourlyRate.Text); }
                catch { MessageBox.Show($"Worker {FirstName} {LastName} doesn't have a task rate assigned"); return false; }
                
            }
            return true;
        }

        private void buttonHourlyPerTask_Click(object sender, EventArgs e)
        {
            if (!hourly)
            {
                hourly = true;
                buttonHourlyPerTask.OnPressedState.FillColor = Color.FromArgb(255, 161, 10);
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.Black;
                textboxHourlyRate.PlaceholderText = "Hourly Rate";
                textboxHoursWorked.Show();
            }
            else
            {
                hourly = false;
                buttonHourlyPerTask.OnPressedState.FillColor = Color.Transparent;
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.White;
                textboxHourlyRate.PlaceholderText = "Task Rate";
                textboxHoursWorked.Hide();
            }
        }

        private void ControlWorkerSmallTaskEnd_Load(object sender, EventArgs e)
        {
            labelName.Text = FirstName + " " + LastName;
            labelCompany.Text = Company;
            labelField.Text = Field;
            textboxHoursWorked.Text = HourseWorked.ToString();
            if (HourseWorked == -1) textboxHoursWorked.Text = "";

            if(HourlyRate == -1)
            {
                hourly = false;
                //Debug.WriteLine($"HourlyRate:{HourlyRate} HoursWorked:{HourseWorked} TaskRate:{TaskRate}");

                buttonHourlyPerTask.OnPressedState.FillColor = Color.Transparent;
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.White;

                textboxHourlyRate.PlaceholderText = "Task Rate";
                textboxHourlyRate.Text = TaskRate.ToString();
                if (TaskRate == -1) textboxHourlyRate.Text = "";
                textboxHoursWorked.Hide();
            }
            else
            {
                hourly = true;
                //Debug.WriteLine($"HourlyRate:{HourlyRate} HoursWorked:{HourseWorked} TaskRate:{TaskRate}");

                buttonHourlyPerTask.OnPressedState.FillColor = Color.FromArgb(255, 161, 10);
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.Black;
                textboxHourlyRate.PlaceholderText = "Hourly Rate";
                textboxHourlyRate.Text = HourlyRate.ToString();
                if (HourlyRate == -1) textboxHourlyRate.Text = "";
                textboxHoursWorked.Show();
            }
        }
    }
}
