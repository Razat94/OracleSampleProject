using System;
using System.Collections; // For ArrayList
using System.Data; // For CommandType Property

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace getFormData.Models
{
    public class ODPInsertClass
    {
        public string FirstName { get; set; }
        public ArrayList sqlList { get; set; }

        public ODPInsertClass(){
            sqlList = new ArrayList();
        }

        public void insertINTOSQLLIST(string fname) {
            // Create a connection to Oracle			
            string conString = "User Id=bms;Password=abc;" +

            //How to connect to an Oracle DB with a DB alias.
            "Data Source=localhost:1521;";

            using (OracleConnection con = new OracleConnection(conString))
            {

                // Display Version Number
                // Console.WriteLine("Connected to Oracle " + con.ServerVersion); 

                string queryString = "addFirstName";
                OracleCommand cmd = new OracleCommand(queryString, con);
                cmd.BindByName = true;
                // cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                // add parameters to stored procedure
                cmd.Parameters.Add("firstname", fname);

                // Console.WriteLine(cmd.CommandText);

                con.Open();
                cmd.ExecuteNonQuery();
                //Execute the command and use DataReader to display the data
                // OracleDataReader reader = cmd.ExecuteReader();
                // while (reader.Read())
                // {
                //     sqlList.Add(reader.GetString(0));
                // }
                // reader.Dispose();
                con.Close();
            }
        } // end of insertINTOSQLLIST method function

    }
}
