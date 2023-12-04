using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_Etudiants.Data
{
    public class Connections
    {
        private string strConn = "Data Source=DESKTOP-11MQR6U\\SQLEXPRESS;Initial Catalog=Gestion_Etudiant;Integrated Security=True";
        public static SqlConnection connection;

        public SqlConnection GetConnection()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = strConn;
                connection.Open();
                MessageBox.Show($"Connected To DB");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Not Connect To DB {e.Message}");
            }

            return connection;
        }

        
        public Connections()
        {
            GetConnection();
        }
    }
}
