using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using eCONSTRUCTIONcontrols;

namespace eCONSTRUCTION
{
    public partial class FormChooseUtility : Form
    {
        DataTable dt = new DataTable();
        ControlUtility cu;
        ControlUtilitySmall cusmall;
        public int TaskID { get; set; }
        string searchword;
        public FormChooseUtility()
        {
            InitializeComponent();
        }

        public void RefreshUtilities()
        {
            searchword = textboxUtilitySearch.Text;
            dt = FormMain.dl.GetData($"SELECT * FROM Materials WHERE MaterialName LIKE '%{searchword}%'", "Materials");
            flowLayoutMaterials.Controls.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                ControlUtility cUtility = new ControlUtility();
                cUtility.isMaterial = true;
                cUtility.UtilityName = dr["MaterialName"].ToString();
                cUtility.CostPerUnit = double.Parse(dr["CostPerUnit"].ToString());
                cUtility.ID = int.Parse(dr["MaterialID"].ToString());
                cUtility.Unit = dr["Unit"].ToString();
                cUtility.Supplier = (FormMain.dl.GetValue($"SELECT CompanyName From Suppliers WHERE SuppliersID = {int.Parse(dr["SuppliersID"].ToString())}")).ToString();
                cUtility.Img = (byte[])dr["Image"];
                flowLayoutMaterials.Controls.Add(cUtility);

                cUtility.DoubleClick += CUtility_DoubleClick;
            }
            dt = FormMain.dl.GetData($"SELECT * FROM Machinery WHERE MachineName LIKE '%{searchword}%'", "Machines");
            flowLayoutMachinery.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ControlUtility cUtility = new ControlUtility();
                cUtility.isMaterial = false;
                cUtility.isMachine = true;
                cUtility.UtilityName = dr["MachineName"].ToString();
                cUtility.CostPerUnit = double.Parse(dr["CostPerHour"].ToString());
                cUtility.ID = int.Parse(dr["MachineID"].ToString());
                cUtility.Supplier = (FormMain.dl.GetValue($"SELECT CompanyName From Suppliers WHERE SuppliersID = {int.Parse(dr["SuppliersID"].ToString())}")).ToString();
                cUtility.Img = (byte[])dr["Image"];
                flowLayoutMachinery.Controls.Add(cUtility);

                cUtility.DoubleClick += CUtility_DoubleClick;
            }
            dt = FormMain.dl.GetData($"SELECT * FROM Vehicles WHERE VehicleName LIKE '%{searchword}%'", "Vehicles");
            flowLayoutVehicles.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ControlUtility cUtility = new ControlUtility();
                cUtility.isMaterial = false;
                cUtility.isMachine = false;
                cUtility.UtilityName = dr["VehicleName"].ToString();
                cUtility.CostPerUnit = double.Parse(dr["CostPerHour"].ToString());
                cUtility.ID = int.Parse(dr["VehicleID"].ToString());
                cUtility.Supplier = (FormMain.dl.GetValue($"SELECT CompanyName From Suppliers WHERE SuppliersID = {int.Parse(dr["SuppliersID"].ToString())}")).ToString();
                cUtility.Img = (byte[])dr["Image"];
                flowLayoutVehicles.Controls.Add(cUtility);

                cUtility.DoubleClick += CUtility_DoubleClick;
            }
        }

        private void CUtility_DoubleClick(object sender, EventArgs e)
        {
            cu = (ControlUtility)sender;
            ControlUtilitySmall cus = new ControlUtilitySmall();
            cus.UtilityName = cu.UtilityName;
            cus.isMaterial = cu.isMaterial;
            cus.ID = cu.ID;
            cus.Supplier = cu.Supplier;
            cus.CostPerUnit = cu.CostPerUnit;
            cus.Unit = cu.Unit;
            cus.isMachine = cu.isMachine;

            flowLayoutChosenItems.Controls.Add(cus);
        }

        private void CUtility_MouseDown(object sender, MouseEventArgs e)
        {
            cu = (ControlUtility)sender;
            Bitmap bitmap = new Bitmap(cu.Width, cu.Height);
            cu.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            this.DoDragDrop(cu.Name, DragDropEffects.Move);
        }
        private void flowLayoutChosemItems_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Hi there");
            for (int i = 1; i < flowLayoutChosenItems.Controls.Count; i++)
            {
                cusmall = (ControlUtilitySmall)flowLayoutChosenItems.Controls[i];
                if (cu.ID == cusmall.ID)
                {
                    flowLayoutChosenItems.BorderStyle = BorderStyle.None;
                    return;
                }
            }
            ControlUtilitySmall cus = new ControlUtilitySmall();
            cus.UtilityName = cu.UtilityName;
            cus.isMaterial = cu.isMaterial;
            cus.ID = cu.ID;
            cus.CostPerUnit = cu.CostPerUnit;
            cus.Unit = cu.Unit;

            flowLayoutChosenItems.Controls.Add(cus);

            flowLayoutChosenItems.AutoScrollPosition = new Point(cus.Left, cus.Right);

            flowLayoutChosenItems.BorderStyle = BorderStyle.None;
        }

        public bool AddUtilitiesChosenToDB()
        {
            object[,] parameters = new object[2, 3];
            if (flowLayoutChosenItems.Controls.Count == 1) return false;
            string id,storedprocedure,duration;
            for (int i = 1; i < flowLayoutChosenItems.Controls.Count; i++)
            {
                cusmall = (ControlUtilitySmall)flowLayoutChosenItems.Controls[i];

                if(cusmall.isMaterial && !cusmall.isMachine)
                {
                    id = "MaterialID";
                    storedprocedure = "addMaterialOrdered";
                    duration = "Quantity";
                }
                else
                {
                    if (cusmall.isMachine)
                    {
                        id = "MachineID";
                        storedprocedure = "addMachineOrdered";
                        duration = "DurationOfRent";
                    }
                    else
                    {
                        id = "VehicleID";
                        storedprocedure = "addVehicleOrdered";
                        duration = "DurationOfRent";
                    }
                }
                Debug.WriteLine($"{id} {duration} {storedprocedure}");
                parameters[0, 0] = id; parameters[1, 0] = cusmall.ID;
                parameters[0, 1] = "TaskID"; parameters[1, 1] = TaskID;
                parameters[0, 2] = duration; parameters[1, 2] = cusmall.quantity;
                Debug.WriteLine($"\ntaskid:{TaskID}\n");
                FormMain.dl.ExecuteActionCommand(storedprocedure, parameters);
            }
            return true;
        }

        private void FormCooseNeededItems_Load(object sender, EventArgs e)
        {
            RefreshUtilities();
            flowLayoutChosenItems.Controls.Clear();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddUtilities_Click(object sender, EventArgs e)
        {
            FormAddVehicle fav = new FormAddVehicle();
            fav.ShowDialog();
            RefreshUtilities();
        }

        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            FormAddMaterial fad = new FormAddMaterial();
            fad.ShowDialog();
            RefreshUtilities();
        }

        private void buttonAddMachine_Click(object sender, EventArgs e)
        {
            FormAddMachine fam = new FormAddMachine();
            fam.ShowDialog();
            RefreshUtilities();
        }

        private void flowLayoutChosemItems_DragOver(object sender, DragEventArgs e)
        {
            flowLayoutChosenItems.BorderStyle = BorderStyle.FixedSingle;
        }

        private void flowLayoutChosemItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void flowLayoutChosemItems_DragLeave(object sender, EventArgs e)
        {
            flowLayoutChosenItems.BorderStyle = BorderStyle.None;
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            foreach(ControlUtilitySmall cus in flowLayoutChosenItems.Controls)
            {
                if(cus.quantity == 0) { MessageBox.Show("You need to enter a quantity or rent duration");return; }
            }
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            RefreshUtilities();
        }
    }
}
