using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace eCONSTRUCTIONcontrols
{
    public partial class ControlWorker : UserControl
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Field { get; set; }
        public string Title { get; set; }
        public int WorkerID { get; set; }
        public byte[] Img{ get; set; }

        public ControlWorker()
        {
            InitializeComponent();
        }

        private void ControlWorker_Load(object sender, EventArgs e)
        {
            labelName.Text = FirstName + " " + LastName;
            labelCompany.Text = Company;
            labelField.Text = Field;
            labelTitle.Text = Title;
            
            if(Img != null)
            {
                MemoryStream ms = new MemoryStream(Img);
                pictureboxWorker.Image = Image.FromStream(ms);
            }
        }
    }
}
