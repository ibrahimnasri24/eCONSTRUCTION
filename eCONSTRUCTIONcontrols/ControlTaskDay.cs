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
    public partial class ControlTaskDay : UserControl
    {
        public string TaskName {get;set;}
        public string Field { get; set; }
        public string Project { get; set; }
        public int TaskID { get; set; }
        public ControlTaskDay()
        {
            InitializeComponent();
        }

        private void controlTaskDay_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            labelTaskName.Text = TaskName;
            labelField.Text = Field;
            labelProject.Text = Project;
        }

        private void labelTaskName_Click(object sender, EventArgs e)
        {
            
        }

        private void controlTaskDay_DoubleClick(object sender, EventArgs e)
        {
        }

        private void labelProject_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            FormTaskCompleted ftc = new FormTaskCompleted();
            ftc.TaskID = TaskID;
            ftc.ShowDialog();
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            eCONSTRUCTION.FormAddPayment fap = new eCONSTRUCTION.FormAddPayment();
            fap.TaskID = TaskID;
            fap.ShowDialog();
        }
    }
}
