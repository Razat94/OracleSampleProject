using System;
using System.Collections; // For ArrayList
using System.Collections.Generic; // For using Dictionary.
using System.Data; // For CommandType Property

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace dispayData.Models
{
    public class ODPSelectClass
    {
        public ArrayList sqlList { get; set; }

        // public Dictionary<string> sqlDictionary { get; set; }

        public ODPSelectClass(){
            sqlList = new ArrayList();
           // sqlDictionary = new Dictionary<string, float>();
        }

        public void getSQLLIST() {
            // Create a connection to Oracle			
            string conString = "User Id=bms;Password=abc;" +
            "Data Source=localhost:1521;";

            using (OracleConnection con = new OracleConnection(conString))
            {

                // Display Version Number
                // Console.WriteLine("Connected to Oracle " + con.ServerVersion); 

                string queryString = "SELECT FIRST_NAME FROM employees";
                OracleCommand cmd = new OracleCommand(queryString, con);
                cmd.BindByName = true;
                cmd.CommandType = CommandType.Text;

                // Connect with the database, and select the data.
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Console.WriteLine(Convert.ToDouble (reader.GetFloat(0)));
                    // Console.WriteLine(reader.GetFloat(0));
                    sqlList.Add(reader.GetString(0));
                    // sqlDictionary.Add( reader.GetString(0), reader.GetFloat(0)  );
                }
                reader.Dispose();
                con.Close();
            }
        } // end of getSQLLIST method function
    }
}