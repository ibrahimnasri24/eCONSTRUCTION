using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eCONSTRUCTIONcontrols;

namespace eCONSTRUCTION
{
    public partial class ControlTaskDay : UserControl
    {
        public string TaskName { get; set; }
        public string Field { get; set; }
        public string Project { get; set; }
        public int TaskID { get; set; }
        public ControlTaskDay()
        {
            InitializeComponent();
        }

        private void ControlTaskDay_Load_1(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            labelTaskName.Text = TaskName;
            labelField.Text = Field;
            labelProject.Text = Project;
        }

        private void tableLayoutPanel1_DoubleClick_1(object sender, EventArgs e)
        {
            FormTaskCompleted ftc = new FormTaskCompleted();
            ftc.TaskID = TaskID;
            ftc.ShowDialog();
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddPayment fap = new FormAddPayment();
            fap.TaskID = TaskID;
            fap.ShowDialog();
        }
    }
}
