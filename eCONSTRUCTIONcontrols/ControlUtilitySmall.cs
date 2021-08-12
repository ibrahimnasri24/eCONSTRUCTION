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
    public partial class ControlUtilitySmall : UserControl
    {
        public string UtilityName { get; set; }
        public int ID { get; set; }
        public string Supplier { get; set; }
        public double CostPerUnit { get; set; }
        public string Unit { get; set; }
        public bool isMaterial { get; set; }
        public bool isMachine { get; set; }
        public int quantity{get;set;}
        public ControlUtilitySmall()
        {
            InitializeComponent();
        }

        private void ControlUtilitySmall_Load(object sender, EventArgs e)
        {
            quantity = 0;
            if (!isMaterial)
            {
                textboxQuantity.PlaceholderText = "Rent Duration";
                labelUnit.Text = "$/hour";
            }
            else
            {
                textboxQuantity.PlaceholderText = "Quantity";
                labelUnit.Text = Unit;
            }
            labelCostPerUnit.Text = CostPerUnit.ToString();
            labelUtilityName.Text = UtilityName;
            labelSupplier.Text = Supplier;
        }

        private void ControlUtilitySmall_DoubleClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void textboxQuantity_TextChange(object sender, EventArgs e)
        {
            try 
            {
                if(textboxQuantity.Text !="") 
                    quantity = int.Parse(textboxQuantity.Text);
                else
                {
                    quantity = 0;
                }
            }
            catch { MessageBox.Show("Quantity or hour number should be a number"); }
        }
    }
}
