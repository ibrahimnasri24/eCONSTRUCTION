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
using System.Diagnostics;

namespace eCONSTRUCTION
{
    public partial class FormAddVehicle : Form
    {
        bool editMode = false;
        string imageFilePath;
        public FormAddVehicle()
        {
            InitializeComponent();
        }
        
        DataTable dt ;
        int Vehicleid;
        public void EditMode(int VehicleID)
        {
            //label.Text = "Edit Vehicle";

            editMode = true;
            Vehicleid = VehicleID;
            dt = FormMain.dl.GetData($"SELECT * FROM Materials WHERE VehicleID = {VehicleID}", "Material");
            DataRow dr = dt.Rows[0];
            textboxVehicleName.Text = dr["VehicleName"].ToString();
            textboxCostPerHour.Text = dr["CostPerHour"].ToString();
            textboxGuideLink.Text = dr["GuideLink"].ToString();
            textboxDescription.Text = dr["ExtraDetails"].ToString();
            textboxField.Text = dr["Field"].ToString();

            comboboxSupplier.SelectedItem = dr["SuppliersID"].ToString();
            
            if (dr["Image"] != DBNull.Value)
            {
                byte[] Img = (byte[])dr["Image"];
                if (Img != null)
                {
                    MemoryStream ms = new MemoryStream(Img);
                    pictureboxVehicle.Image = Image.FromStream(ms);
                }
            }
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 7];

            //Person Assertions
            if (textboxVehicleName.Text == "")
            { MessageBox.Show("Vehicle name is required"); return; }
            if (textboxCostPerHour.Text == "")
            { MessageBox.Show("Cost per hour is required"); return; }
            if (textboxField.Text == "")
            { MessageBox.Show("Field Name is required"); return; }


            //Person Attributes
            parameters[0, 0] = "VehicleName"; parameters[1, 0] = textboxVehicleName.Text;



            parameters[0, 1] = "CostPerHour"; parameters[1, 1] = textboxCostPerHour.Text;


            if (textboxGuideLink.Text == "")
            { parameters[0, 2] = "GuideLink"; parameters[1, 2] = DBNull.Value; }
            else { parameters[0, 2] = "GuideLink"; parameters[1, 2] = textboxGuideLink.Text; }

            parameters[0, 3] = "SuppliersID"; parameters[1, 3] = comboboxSupplier.SelectedValue;
            if (textboxField.Text == "")
            { parameters[0, 4] = "Field"; parameters[1, 4] = DBNull.Value; }
            else { parameters[0, 4] = "Field"; parameters[1, 4] = textboxField.Text; }
            if (textboxField.Text == "")
            { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = DBNull.Value; }
            else { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = textboxDescription.Text; }

            if (imageFilePath == null)
            {
                parameters[0, 6] = "Image";
                MemoryStream ms = new MemoryStream();
                pictureboxVehicle.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                parameters[1, 6] = ms.ToArray();
            }
            else
            {
                byte[] image = null;
                FileStream fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);
                parameters[0, 6] = "Image"; parameters[1, 6] = image;
            }
            if (!editMode)
                FormMain.dl.ExecuteActionCommand("addVehicle", parameters);

            else
            {
                object[,] parametersEdit = new object[2, 8];
                parametersEdit[0, 0] = "VehicleID"; parametersEdit[1, 0] = Vehicleid;
                for (int i = 0; i < 7; i++)
                {
                    parametersEdit[0, i + 1] = parameters[0, i];
                }
                for (int i = 0; i < 7; i++)
                {
                    parametersEdit[1, i + 1] = parameters[1, i];
                }
                FormMain.dl.ExecuteActionCommand("editVehicle", parametersEdit);
            }
            this.Close();
        }
        

        private void formAddVehicle_Load(object sender, EventArgs e)
        {
            dt = FormMain.dl.GetData("SELECT CompanyName, SuppliersID FROM Suppliers", "Suppliers");
            comboboxSupplier.DataSource = dt;
            comboboxSupplier.DisplayMember = "CompanyName";
            comboboxSupplier.ValueMember = "SuppliersID";
        }

        private void pictureboxVehicle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg)|*.jpg|Image files(*.jpeg)|*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureboxVehicle.Image = Image.FromFile(ofd.FileName);
                    imageFilePath = ofd.FileName.ToString();
                }
            }
        }

        private void closeAddMachine_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    