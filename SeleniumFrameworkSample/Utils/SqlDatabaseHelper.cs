using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SeleniumFrameworkV2Sample.Utils
{
    public class SqlDatabaseHelper
    {
        //Gets from the config file
        //private string connectionString = "Data Source=hgtestdb1;Initial Catalog=HealthGradesWeb;User ID=webuser;Password=dog.bone;";
        private string connectionString = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public Dictionary<string, string>[] ExecuteSelectQuery(string selectQuery)
        {
            int rowCount = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    SqlCommand myCommand = new SqlCommand(selectQuery, myConnection);
                    myConnection.Open();

                    SqlDataReader reader = myCommand.ExecuteReader();
                    while (reader.Read()) { rowCount++;}
                    reader.Close();
                    myConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    var columnNames = new List<string>();

                    SqlCommand myCommand = new SqlCommand(selectQuery, myConnection);
                    myConnection.Open();

                    SqlDataReader reader = myCommand.ExecuteReader();
                    Console.WriteLine("Provided query executed successfully: "+selectQuery);
                    //Get column names
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }

                    //get cell values
                    Dictionary < string, string>[] result = new Dictionary<string, string>[rowCount];
                    int cell = 0;
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
                        for(int i = 0; i<columnNames.Count; i++)
                        {
                            row.Add(columnNames[i], reader[columnNames[i]].ToString());
                        }
                        result[cell] = row;
                        cell++;
                    }
                    myConnection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string ExecuteUpdateOrDeleteQuery(string query)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    var numOfRowsAffected = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    return "Query executed successfully. (" + numOfRowsAffected + " row(s) affected). Query: "+query;
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
              
           }
        }

    }
}
