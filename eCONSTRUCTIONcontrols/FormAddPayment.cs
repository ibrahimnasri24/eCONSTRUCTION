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
    public partial class FormAddPayment : Form
    {
        eCONSTRUCTIONcontrols.DataLayerControls dl = new eCONSTRUCTIONcontrols.DataLayerControls(@".\SQLEXPRESS", "eCONSTRUCT");
        public int TaskID { get; set; }
        public FormAddPayment()
        {
            InitializeComponent();
        }

        private void closeAddTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddPayment_Load(object sender, EventArgs e)
        {
            DataTable dt = dl.GetData($@"SELECT Image, CONCAT(FirstName, ' ', LastName) AS txtName, Workers.WorkerID
                                                FROM Persons, Workers, Workforce
                                                WHERE Persons.PersonID = Workers.PersonID
                                                AND Workforce.TaskID = {TaskID}
                                                AND Workforce.WorkerID = Workers.WorkerID", "Workers");
            dataGridViewWorkers.DataSource = dt;
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            object[,] parameters = new object[2, 4];
            parameters[0, 0] = "TaskID";            parameters[1, 0] = TaskID;
            parameters[0, 1] = "WorkerID";          parameters[1, 1] = int.Parse(dataGridViewWorkers.SelectedRows[0].Cells["WorkerID"].FormattedValue.ToString());
            parameters[0, 2] = "AmountPaid";        parameters[1, 2] = double.Parse(textboxPaymentAmount.Text);
            parameters[0, 3] = "PaymentDate";       parameters[1, 3] = datepickerPaymentDate.Value;

            dl.ExecuteActionCommand("addPayment", parameters);
            this.Close();
        }

        private void dataGridViewWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
