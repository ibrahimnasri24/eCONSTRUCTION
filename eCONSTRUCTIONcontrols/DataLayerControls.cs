using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace eCONSTRUCTIONcontrols
{
    public class DataLayerControls
    {
        string server_name;
        string database_name;
        SqlConnection con;
        public bool IsValid = false;
        public DataLayerControls(string ServerName, string DataBaseName)
        {
            server_name = ServerName;
            database_name = DataBaseName;
            VerifyConnection();
        }

        private void VerifyConnection()
        {
            con = new SqlConnection(@"Data Source=" + server_name + ";Initial Catalog=" + database_name + ";Integrated Security=True");
            try
            {
                con.Open();
                con.Close();
                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
        }
        public void SetServerName(string ServerName)
        {
            server_name = ServerName;
            VerifyConnection();
        }
        public string GetServerName()
        {
            return server_name;
        }
        public void SetDataBaseName(string DataBaseName)
        {
            database_name = DataBaseName;
            VerifyConnection();
        }
        public string GetDataBaseName()
        {
            return database_name;
        }

        public int ExecuteActionCommand(string CommandText)
        {
            int rep = 0;

            if ((IsValid) && (CommandText.Length > 0))
            {
                SqlCommand com = new SqlCommand(CommandText, con);
                con.Open();
                try
                {
                    rep = com.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
            }
            return rep;
        }
        public int ExecuteActionCommand(string CommandText, object[,] Parameters)
        {
            int rep = 0;

            if ((IsValid) && (CommandText.Length > 0))
            {
                SqlCommand com = new SqlCommand(CommandText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.Length / 2; i++)
                    com.Parameters.Add(new
                     SqlParameter
                    (Parameters[0, i].ToString(), Parameters[1, i]));
                con.Open();
                try
                {
                    rep = com.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
            }
            return rep;
        }
        public object GetValue(string SqlText)
        {
            if ((IsValid) && (SqlText.Length > 0))
            {
                object v = null;
                SqlCommand com = new SqlCommand(SqlText, con);
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }
        public object GetValue(string SqlText, object[,] Parameters)
        {
            if ((IsValid) && (SqlText.Length > 0))
            {
                object v = null;
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.Length / 2; i++)
                    com.Parameters.Add(new
                     SqlParameter
                    (Parameters[0, i].ToString(), Parameters[1, i]));
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }
        public DataTable GetData(string SqlText, string name)
        {
            DataTable dt = new DataTable();
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.Text;
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }
        public DataTable GetData(string SqlText, object[,] Parameters, string name)
        {
            DataTable dt = new DataTable();
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.Length / 2; i++)
                    com.Parameters.Add(new
                     SqlParameter
                    (Parameters[0, i].ToString(), Parameters[1, i]));
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }
        public AutoCompleteStringCollection GenerateAutoCompleteStringCollection(string SqlText, string name, string columnName)
        {
            AutoCompleteStringCollection result = new AutoCompleteStringCollection();
            DataTable dt = GetData(SqlText, name);
            if (dt.Columns.Count > 1)
                return new AutoCompleteStringCollection();
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(dr[columnName].ToString());
            }
            return result;
        }
        /*public int UpdateTable(string TableName, object[,] CulomnsToChange, string CulomnID, int ID)
        {
            int rep = 0, len = CulomnsToChange.GetLength(1);
            string UpdateCom = $@"UPDATE {TableName}
                                SET ";
            for(int i = 0; i < len; i++)
            {
                UpdateCom += $"{CulomnsToChange[0, i]} = '{CulomnsToChange[1, i]}', ";
            }
            UpdateCom += $"WHERE {CulomnID} = {ID}";
            System.Diagnostics.Debug.WriteLine(UpdateCom);
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(UpdateCom, con);
                con.Open();
                try
                {
                    rep = com.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
            }
            return rep;
        }*/
    }
}
