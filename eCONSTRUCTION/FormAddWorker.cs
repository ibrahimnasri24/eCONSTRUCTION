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
    public partial class FormAddWorker : Form
    {
        string imageFilePath;
        bool datePickerWasUsed;
        bool editMode = false;
        int Workerid;
        DataTable dt;
        public void EditMode(int WorkerID)
        {
            labelAddWorker.Text = "Edit Worker";
            Workerid = WorkerID;
            editMode = true;
            dt = FormMain.dl.GetData($"SELECT * FROM Workers, Persons, Addresses WHERE Workers.PersonID = Persons.PersonID AND Persons.AdressID = Addresses.AdressID AND WorkerID = {WorkerID}", "WorkerToEdit");
            DataRow dr = dt.Rows[0];
            textboxWorkerFirstName.Text = dr["FirstName"].ToString();
            textboxWorkerMiddleName.Text = dr["MiddleName"].ToString();
            textboxWorkerLastName.Text = dr["LastName"].ToString();
            textboxWorkerPhoneNumber.Text = dr["PhoneNumber"].ToString();
            datepickerWorker.Value = DateTime.Parse(dr["DateOfBirth"].ToString());
            dropdownWorkerGender.SelectedItem = dr["Gender"].ToString();
            textboxWorkerEmail.Text = dr["Email"].ToString();
            comboboxWorkerWorkingField.SelectedItem = dr["Field"].ToString();
            comboboxWorkerTitle.SelectedItem = dr["Title"].ToString();
            textboxWorkerCompany.Text = dr["Company"].ToString();
            textboxWorkerOtherDetails.Text = dr["OtherDetails"].ToString();
            textboxCountry.Text = dr["Country"].ToString();
            textboxCity.Text = dr["City"].ToString();
            textboxStreet.Text = dr["Street"].ToString();
            textBoxBuilding.Text = dr["Building"].ToString();
            if(dr["Image"] != DBNull.Value)
            {
                byte[] Img = (byte[])dr["Image"];
                if (Img != null)
                {
                    MemoryStream ms = new MemoryStream(Img);
                    WorkerPictureBox.Image = Image.FromStream(ms);
                }
            }
        }
        public FormAddWorker()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panelAddWorker);
            datePickerWasUsed = false;
        }

        private void buttonAddWorker_Click_1(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 16];

           //Person Assertions
            if (textboxWorkerFirstName.Text == "")
            { MessageBox.Show("Worker first name is required"); return; }
            if (textboxWorkerLastName.Text == "")
            { MessageBox.Show("Worker last name is required"); return; }
            if (textboxWorkerPhoneNumber.Text == "")
            { MessageBox.Show("Phone number is required"); return; }
            if (dropdownWorkerGender.SelectedIndex == -1)
            { MessageBox.Show("Gender is required"); return; }
            //Worker Assertions
            if (comboboxWorkerTitle.SelectedIndex == -1)
            { MessageBox.Show("Worker Title is required"); return; }
            if (comboboxWorkerWorkingField.SelectedIndex == -1)
            { MessageBox.Show("A work field selection is required"); return; }
            //Address Assertions
            if (textboxCountry.Text == "")
            { MessageBox.Show("Country is required"); return; }
            if (textboxCity.Text == "")
            { MessageBox.Show("City is required"); return; }
            if (textboxStreet.Text == "")
            { MessageBox.Show("Streeet is required"); return; }

            //Person Attributes
            parameters[0, 0] = "FirstName"; parameters[1, 0] = textboxWorkerFirstName.Text;

            if (textboxWorkerMiddleName.Text == "")
            { parameters[0, 1] = "MiddleName"; parameters[1, 1] = DBNull.Value; }
            else { parameters[0, 1] = "MiddleName"; parameters[1, 1] = textboxWorkerMiddleName.Text; }

            parameters[0, 2] = "LastName"; parameters[1, 2] = textboxWorkerLastName.Text;

            parameters[0, 3] = "PhoneNumber"; parameters[1, 3] = textboxWorkerPhoneNumber.Text;

            if (textboxWorkerEmail.Text == "")
            { parameters[0, 4] = "Email"; parameters[1, 4] = DBNull.Value; }
            else { parameters[0, 4] = "Email"; parameters[1, 4] = textboxWorkerEmail.Text; }

            parameters[0, 5] = "Gender"; parameters[1, 5] = dropdownWorkerGender.SelectedItem.ToString();

            if (!datePickerWasUsed)
            { parameters[0, 6] = "DateOfBirth"; parameters[1, 6] = DBNull.Value; }
            else { parameters[0, 6] = "DateOfBirth"; parameters[1, 6] = datepickerWorker.Value; }

            if (textboxWorkerOtherDetails.Text == "")
            { parameters[0, 7] = "OtherDetails"; parameters[1, 7] = DBNull.Value; }
            else { parameters[0, 7] = "OtherDetails"; parameters[1, 7] = textboxWorkerOtherDetails.Text; }

            if (imageFilePath == null)
            { 
                parameters[0, 8] = "Image";
                MemoryStream ms = new MemoryStream();
                WorkerPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                parameters[1, 8] = ms.ToArray();
            }
            else {
                byte[] image = null;
                FileStream fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);
                parameters[0, 8] = "Image"; parameters[1, 8] = image; 
            }


            //Worker Attributes
            parameters[0, 9] = "Field"; parameters[1, 9] = comboboxWorkerWorkingField.SelectedItem.ToString();
            parameters[0, 10] = "Title"; parameters[1, 10] = comboboxWorkerTitle.SelectedItem.ToString();
            if (textboxWorkerCompany.Text == "")
            { parameters[0, 11] = "Company"; parameters[1, 11] = DBNull.Value; }
            else { parameters[0, 11] = "Company"; parameters[1, 11] = textboxWorkerCompany.Text; }

            //Address Attributes
            parameters[0, 12] = "Country"; parameters[1, 12] = textboxCountry.Text;
            parameters[0, 13] = "City"; parameters[1, 13] = textboxCity.Text;
            parameters[0, 14] = "Street"; parameters[1, 14] = textboxStreet.Text;
            if (textBoxBuilding.Text == "")
            { parameters[0, 15] = "Building"; parameters[1, 15] = DBNull.Value; }
            else { parameters[0, 15] = "Building"; parameters[1, 15] = textBoxBuilding.Text; }
            if(!editMode)
                FormMain.dl.ExecuteActionCommand("addWorkerWithPersonWithAddress", parameters);
            else
            {
                object[,] parametersEdit = new object[2, 17];
                parametersEdit[0, 0] = "WorkerID"; parametersEdit[1, 0] = Workerid;
                for(int i = 0; i < 16; i++)
                {
                    parametersEdit[0, i+1] = parameters[0, i];
                }
                for (int i = 0; i < 16; i++)
                {
                    parametersEdit[1, i + 1] = parameters[1, i];
                }
            }
            this.Close();
        }

        private void buttonimageAddWorkerClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WorkerPictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg)|*.jpg|Image files(*.jpeg)|*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    WorkerPictureBox.Image = Image.FromFile(ofd.FileName);
                    imageFilePath = ofd.FileName.ToString();
                }
            }
        }


        private void datepickerWorker_ValueChanged(object sender, EventArgs e)
        {
            datePickerWasUsed = true;
        }
    }
}