using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCONSTRUCTIONcontrols
{
    public partial class ControlWorkerSmall : UserControl
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Field { get; set; }
        bool hourly = true;
        public double Rate(out bool Hourly)
        {
            Hourly = hourly;
            if (textboxHourlyRate.Text == "")
                return -1;
            try
            {
                return double.Parse(textboxHourlyRate.Text);
            }
            catch
            {
                return -1;
            }
        }
        public int WorkerID { get; set; }
        bool firstClick = false;
        public void Clicked()
        {
            if (!firstClick)
            {
                firstClick = true;
                panel1.BackColor = Color.FromArgb(255, 161, 10);
            }
            else
            {
                panel1.BackColor = Color.FromArgb(66, 66, 76);
            }
        }

        public ControlWorkerSmall()
        {
            InitializeComponent();
        }

        private void ControlWorkerSmall_Load(object sender, EventArgs e)
        {
            labelName.Text = FirstName + " " + LastName;
            labelCompany.Text = Company;
            labelField.Text = Field;
        }

        private void ControlWorkerSmall_DoubleClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void buttonHourlyPerTask_Click_1(object sender, EventArgs e)
        {
            if (!hourly)
            {
                hourly = true;
                buttonHourlyPerTask.OnPressedState.FillColor = Color.FromArgb(255, 161, 10);
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.Black;
                textboxHourlyRate.PlaceholderText = "Hourly Rate";
            }
            else
            {
                hourly = false;
                buttonHourlyPerTask.OnPressedState.FillColor = Color.Transparent;
                buttonHourlyPerTask.OnPressedState.ForeColor = Color.White;
                textboxHourlyRate.PlaceholderText = "Task Rate";
            }
        }
    }
}
