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


namespace eCONSTRUCTION
{
    public partial class FormAddMachine : Form
    {
        string imageFilePath;
        bool editMode = false; 
        public FormAddMachine()
        {
            InitializeComponent();
        }
        DataTable dt;
        int Machineid;
        public void EditMode(int MachineID)
        {
            //label.Text = "Edit Vehicle";

            editMode = true;
            Machineid = MachineID;
            dt = FormMain.dl.GetData($"SELECT * FROM Materials WHERE MachineID = {MachineID}", "Machine");
            DataRow dr = dt.Rows[0];
            TextBoxMachineName.Text = dr["VehicleName"].ToString();
            textboxCostPerHour.Text = dr["CostPerHour"].ToString();
            TextBoxGuideLink.Text = dr["GuideLink"].ToString();
            textboxMachineDescription.Text = dr["ExtraDetails"].ToString();
            TextBoxMachineField.Text = dr["Field"].ToString();

            comboboxSupplier.SelectedItem = dr["SuppliersID"].ToString();

            if (dr["Image"] != DBNull.Value)
            {
                byte[] Img = (byte[])dr["Image"];
                if (Img != null)
                {
                    MemoryStream ms = new MemoryStream(Img);
                    PictureBoxMachine.Image = Image.FromStream(ms);
                }
            }
        }
        private void buttonAddMachine_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 7];

            //Vehicle Assertions
            if (TextBoxMachineName.Text == "")
            { MessageBox.Show("Machine name is required"); return; }
            if (textboxCostPerHour.Text == "")
            { MessageBox.Show("Cost per hour is required"); return; }
            if (TextBoxMachineField.Text == "")
            { MessageBox.Show("Field Name is required"); return; }
            

            //Vehicle Attributes
            parameters[0, 0] = "MachineName"; parameters[1, 0] = TextBoxMachineName.Text;

            

            parameters[0, 1] = "CostPerHour"; parameters[1, 1] = textboxCostPerHour.Text;

            
            if (TextBoxGuideLink.Text == "")
            { parameters[0, 2] = "GuideLink"; parameters[1, 2] = DBNull.Value; }
            else { parameters[0, 2] = "GuideLink"; parameters[1, 2] = TextBoxGuideLink.Text; }

            parameters[0, 3] = "SuppliersID"; parameters[1, 3] = comboboxSupplier.SelectedValue;
            if (TextBoxMachineField.Text == "")
            { parameters[0, 4] = "Field"; parameters[1, 4] = DBNull.Value; }
            else { parameters[0, 4] = "Field"; parameters[1, 4] = TextBoxMachineField.Text; }
            if (TextBoxMachineField.Text == "")
            { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = DBNull.Value; }
            else { parameters[0, 5] = "ExtraDetails"; parameters[1, 5] = textboxMachineDescription.Text; }

            if (imageFilePath == null)
            {
                parameters[0, 6] = "Image";
                MemoryStream ms = new MemoryStream();
                PictureBoxMachine.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
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
                FormMain.dl.ExecuteActionCommand("addMachine", parameters);

            else
            {
                object[,] parametersEdit = new object[2, 8];
                parametersEdit[0, 0] = "MachineID"; parametersEdit[1, 0] = Machineid;
                for (int i = 0; i < 7; i++)
                {
                    parametersEdit[0, i + 1] = parameters[0, i];
                }
                for (int i = 0; i < 7; i++)
                {
                    parametersEdit[1, i + 1] = parameters[1, i];
                }
                FormMain.dl.ExecuteActionCommand("editMachine", parametersEdit);
            }
            this.Close();
        }
        private void closeAddMachine_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddMachine_Load(object sender, EventArgs e)
        {
            dt = FormMain.dl.GetData("SELECT CompanyName, SuppliersID FROM Suppliers", "Suppliers");
            comboboxSupplier.DataSource = dt;
            comboboxSupplier.DisplayMember = "CompanyName";
            comboboxSupplier.ValueMember = "SuppliersID";
        }

        private void PictureBoxMachine_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg)|*.jpg|Image files(*.jpeg)|*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PictureBoxMachine.Image = Image.FromFile(ofd.FileName);
                    imageFilePath = ofd.FileName.ToString();
                }
            }
        }
    }
}

