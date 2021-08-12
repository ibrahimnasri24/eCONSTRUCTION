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
    public partial class FormAddSupplier : Form
    {
        public FormMain formmain { get; set; }
        public FormAddSupplier()
        {
            InitializeComponent();
        }

        private void FormAddSupplier_Load(object sender, EventArgs e)
        {

        }
        bool editMode = false;

        DataTable dt;
        int Suppliersid;
        public void EditMode(int SuppliersID)
        {
            labelAddSupplier.Text = "Edit Supplier";

            editMode = true;
            Suppliersid = SuppliersID;
            dt = FormMain.dl.GetData($"SELECT * FROM Suppliers WHERE SuppliersID = {SuppliersID}", "Supplier");
            DataRow dr = dt.Rows[0];
            textboxCompanyName.Text = dr["CompanyName"].ToString();
            textboxcontactname.Text = dr["ContactName"].ToString();
            textboxcontacttitle.Text = dr["ContactTitle"].ToString();
            textboxsupplierfax.Text = dr["Fax"].ToString();
            textboxphone.Text = dr["Phone"].ToString();
            textboxwebsite.Text = dr["Website"].ToString();

        }

        private void closeAddTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddSupplier_Click_1(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 6];


            if (textboxCompanyName.Text == "")
            { MessageBox.Show("Company name is required"); return; }
            if (textboxcontactname.Text == "")
            { MessageBox.Show("Contact Name is required"); return; }
            if (textboxphone.Text == "")
            { MessageBox.Show("Phone Number is required"); return; }



            parameters[0, 0] = "CompanyName"; parameters[1, 0] = textboxCompanyName.Text;
            parameters[0, 1] = "ContactName"; parameters[1, 1] = textboxcontactname.Text;
            parameters[0, 2] = "Phone"; parameters[1, 2] = textboxphone.Text;
            if (textboxcontacttitle.Text == "")
            { parameters[0, 3] = "ContactTitle"; parameters[1, 3] = DBNull.Value; }
            else { parameters[0, 3] = "ContactTitle"; parameters[1, 3] = textboxcontacttitle.Text; }
            if (textboxsupplierfax.Text == "")
            { parameters[0, 5] = "Fax"; parameters[1, 5] = DBNull.Value; }
            else { parameters[0, 5] = "Fax"; parameters[1, 5] = textboxsupplierfax.Text; }
            if (textboxwebsite.Text == "")
            { parameters[0, 4] = "Website"; parameters[1, 4] = DBNull.Value; }
            else { parameters[0, 4] = "Website"; parameters[1, 4] = textboxwebsite.Text; }



            if (!editMode)
            {
                FormMain.dl.ExecuteActionCommand("addSupplier", parameters);
            }
            else
            {
                object[,] parametersEdit = new object[2, 7];
                parametersEdit[0, 0] = "SuppliersID"; parametersEdit[1, 0] = Suppliersid;
                for (int i = 0; i < 6; i++)
                {
                    parametersEdit[0, i + 1] = parameters[0, i];
                }
                for (int i = 0; i < 6; i++)
                {
                    parametersEdit[1, i + 1] = parameters[1, i];
                }
                FormMain.dl.ExecuteActionCommand("editSupplier", parametersEdit);
            }
            formmain.RefreshSuppliers();

            this.Close();
        }
    }
}
