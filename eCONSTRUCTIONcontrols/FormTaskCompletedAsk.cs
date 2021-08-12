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
    public partial class FormTaskCompletedAsk : Form
    {
        public int TaskID { get; set; }
        public FormTaskCompletedAsk()
        {
            InitializeComponent();
        }

        private void FormTaskCompletedAsk_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            FormTaskCompleted ftc = new FormTaskCompleted();
            ftc.TaskID = TaskID;
            ftc.ShowDialog();
            this.Close();
        }
    }
}
