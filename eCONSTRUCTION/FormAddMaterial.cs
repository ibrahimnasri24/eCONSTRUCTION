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
    public partial class FormAddMaterial : Form 
       
    {
        string imageFilePath;
        bool editMode = false;
        bool ExpirationDateExists = true;
        public FormAddMaterial()
        {
            InitializeComponent();
        }
        DataTable dt;
        int Materialid;
        public void EditMode(int MaterialID)
        {
            labelAddMaterial.Text = "Edit Material";

            editMode = true;
            Materialid = MaterialID;
            dt = FormMain.dl.GetData($"SELECT * FROM Materials WHERE MaterialID = {MaterialID}", "Material");
            DataRow dr = dt.Rows[0];
            textboxMaterialName.Text = dr["MaterialName"].ToString();
            textboxCost.Text = dr["CostPerUnit"].ToString();
            textboxUnit.Text = dr["Unit"].ToString();
            textboxField.Text = dr["Field"].ToString();
            textboxDescription.Text = dr["ExtraDetails"].ToString();
            datepickerDate.Value = DateTime.Parse(dr["ExpirationDate"].ToString());
            comboboxSupplier.SelectedItem = dr["SuppliersID"].ToString();
            comboboxCategory.SelectedItem = dr["Category"].ToString();

            if (dr["Image"] != DBNull.Value)
            {
                byte[] Img = (byte[])dr["Image"];
                if (Img != null)
                {
                    MemoryStream ms = new MemoryStream(Img);
                    pictureboxMaterial.Image = Image.FromStream(ms);
                }
            }
        }
        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 9];

            //Supplier Assertions
            if (textboxMaterialName.Text == "")
            { MessageBox.Show("Vehicle name is required"); return; }
            if (textboxCost.Text == "")
            { MessageBox.Show("Cost per hour is required"); return; }
            if (textboxField.Text == "")
            { MessageBox.Show("Field Name is required"); return; }
            if (textboxUnit.Text == "")
            { MessageBox.Show("Unit Name is required"); return; }
            if (comboboxCategory.SelectedIndex == -1)
            { MessageBox.Show("A Category Selection is Required Name is required"); return; }


            //Supplier Attributes
            parameters[0, 0] = "MaterialName"; parameters[1, 0] = textboxMaterialName.Text;
            parameters[0, 1] = "CostPerUnit"; parameters[1, 1] = double.Parse(textboxCost.Text);

            parameters[0, 2] = "SuppliersID"; parameters[1, 2] = comboboxSupplier.SelectedValue;

            if (textboxField.Text == "")
            { parameters[0, 3] = "Field"; parameters[1, 3] = DBNull.Value; }
            else { parameters[0, 3] = "Field"; parameters[1, 3] = textboxField.Text; }
            
            parameters[0, 4] = "Category"; parameters[1, 4] = comboboxCategory.SelectedItem.ToString();

            if (textboxField.Text == "")
            { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = DBNull.Value; }
            else { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = textboxDescription.Text; }

            if (imageFilePath == null)
            {
                parameters[0, 6] = "Image";
                MemoryStream ms = new MemoryStream();
                pictureboxMaterial.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
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
            if (!ExpirationDateExists)
            { parameters[0, 7] = "ExpirationDate"; parameters[1, 7] = DBNull.Value; }
            else { parameters[0, 7] = "ExpirationDate"; parameters[1, 7] = datepickerDate.Value; }


            parameters[0, 8] = "Unit"; parameters[1, 8] = textboxUnit.Text;
            

            if (!editMode)
                FormMain.dl.ExecuteActionCommand("addMaterial", parameters);

            else
            {
                object[,] parametersEdit = new object[2, 10];
                parametersEdit[0, 0] = "MaterialID"; parametersEdit[1, 0] = Materialid;
                for (int i = 0; i < 9; i++)
                {
                    parametersEdit[0, i + 1] = parameters[0, i];
                }
                for (int i = 0; i < 9; i++)
                {
                    parametersEdit[1, i + 1] = parameters[1, i];
                }
                FormMain.dl.ExecuteActionCommand("editMaterial", parameters);
            }

            this.Close();
        }

        private void FormAddMaterial_Load(object sender, EventArgs e)
        {
            dt = FormMain.dl.GetData("SELECT CompanyName, SuppliersID FROM Suppliers", "Suppliers");
            comboboxSupplier.DataSource = dt;
            comboboxSupplier.DisplayMember = "CompanyName";
            comboboxSupplier.ValueMember = "SuppliersID";
        }

        private void closeAddMachine_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonProjectAll_Click(object sender, EventArgs e)
        {
            if (!ExpirationDateExists)
            {
                ExpirationDateExists = true;
                buttonProjectAll.OnPressedState.FillColor = Color.FromArgb(255, 161, 10);
                buttonProjectAll.OnPressedState.ForeColor = Color.Black;
            }
            else
            {
                ExpirationDateExists = false;
                buttonProjectAll.OnPressedState.FillColor = Color.Transparent;
                buttonProjectAll.OnPressedState.ForeColor = Color.White;
            }
        }

        private void pictureboxMaterial_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg)|*.jpg|Image files(*.jpeg)|*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureboxMaterial.Image = Image.FromFile(ofd.FileName);
                    imageFilePath = ofd.FileName.ToString();
                }
            }
        }
    }
}
       
