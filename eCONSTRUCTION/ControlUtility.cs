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

    public partial class ControlUtility : UserControl
    {
        public string UtilityName { get; set; }
        public int ID { get; set; }
        public string Supplier { get; set; }
        public double CostPerUnit { get; set; }
        public string Unit { get; set; }
        public bool isMaterial { get; set; }
        public bool isMachine { get; set; }
        public byte[] Img { get; set; }
        public ControlUtility()
        {
            InitializeComponent();
        }

        private void ControlNeededItem_Load(object sender, EventArgs e)
        {
            if (!isMaterial)
            {
                labelUnit.Hide();
                labelforUnit.Hide();
                labelforCostPerUnit.Text = "Cost per Hour:";
            }
            else
            {
                labelUnit.Show();
                labelforUnit.Show();
                labelforCostPerUnit.Text = "Cost per unit:";
                labelUnit.Text = Unit;
            }
            labelCostPerUnit.Text = CostPerUnit.ToString();
            labelUtilityName.Text = UtilityName;
            labelSupplierName.Text = Supplier;
            if (Img != null)
            {
                MemoryStream ms = new MemoryStream(Img);
                pictureboxUtility.Image = Image.FromStream(ms);
            }
        }

        private void pictureboxWorker_Click(object sender, EventArgs e)
        {

        }
    }
}
