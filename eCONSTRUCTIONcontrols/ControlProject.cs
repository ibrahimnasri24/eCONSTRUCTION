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
    public partial class ControlProject : UserControl
    {
        DateTime Default = new DateTime();
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime InitiationDate {get;  set;}
        public DateTime TerminationDate { get; set; }
        public DateTime DueDate { get; set; }

        public string ProjectType { get; set; }

        public string Description { get; set; }
        public int SiteID { get; set; }

        public string Phase { get; set; }
        public string Arch { get; set; }
        public string CivilEng { get; set; }
        public string ElecEng { get; set; }
        public int TasksProgress { get; set; }
        public int PendingOrders { get; set; }

        public ControlProject()
        {
            InitializeComponent();
        }

        private void ProjectControl_Load(object sender, EventArgs e)
        {
            labelProjectName.Text = ProjectName;
            labelProjectID.Text = ProjectID.ToString();
            labelPhase.Text = Phase;
            if (DueDate == Default)
                labelDueDate.Text = "N/A";
            else
                labelDueDate.Text = DueDate.ToString().Substring(0,10);
        }

        private void ControlProject_Click(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(66, 66, 76);
        }

        private void progressPendingOrders_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }
    }
}
