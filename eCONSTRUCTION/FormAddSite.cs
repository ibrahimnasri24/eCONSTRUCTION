using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCONSTRUCTION
{
    public partial class FormAddSite : Form
    {
        public static int SiteID;
        public FormAddSite()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textboxSiteName.Text == "")
            { MessageBox.Show("Site Name field is required"); return; }

            if (textboxCountry.Text == "")
            { MessageBox.Show("Country field is required"); return; }

            if (textboxCity.Text == "")
            { MessageBox.Show("City field is required"); return; }

            if (textboxStreet.Text == "")
            { MessageBox.Show("Street field is required"); return; }

            if(textboxArea.Text == "")
            { MessageBox.Show("Area is required"); return; }

            if (textboxPricePerMeter.Text == "") 
            { MessageBox.Show("Area per meter is required"); return; }

            int area; float pricepermeter;

            try { area = int.Parse(textboxArea.Text); }
            catch { MessageBox.Show("Area should be an Integer"); return; }

            try { pricepermeter = float.Parse(textboxPricePerMeter.Text); }
            catch { MessageBox.Show("Price should be a Decimal number"); return; }

            object[,] parameters = new object[2, 8];
            parameters[0, 0] = "SiteName";              parameters[1, 0] = textboxSiteName.Text;
            parameters[0, 1] = "Area";                  parameters[1, 1] = area;
            parameters[0, 2] = "PricePerMeterSquared";  parameters[1, 2] = pricepermeter;
            parameters[0, 3] = "Country";               parameters[1, 3] = textboxCountry.Text;
            parameters[0, 4] = "City";                  parameters[1, 4] = textboxCity.Text;
            parameters[0, 5] = "Street";                parameters[1, 5] = textboxStreet.Text;

            if (textboxLatitude.Text == "")
            { parameters[0, 6] = "Latitude";            parameters[1, 6] = DBNull.Value; }
            else 
            { parameters[0, 6] = "Latitude";            parameters[1, 6] = textboxLatitude.Text; }

            if (textboxLongitude.Text == "") 
            { parameters[0, 7] = "Longitude";           parameters[1, 7] = DBNull.Value; }
            else 
            { parameters[0, 7] = "Longitude";           parameters[1, 7] = textboxLongitude.Text; }

            try
            {
                SiteID = int.Parse(FormMain.dl.GetValue("addSiteAddress", parameters).ToString());
            }
            catch
            {
                MessageBox.Show("The Site Name is a duplicate of another one");
                return;
            }
            FormMain.formProjAdd.LoadComboBoxSiteSelect(SiteID);
            this.Close();
        }
    }
}
