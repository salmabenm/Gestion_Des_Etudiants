using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Etudiants.View.Trombinoscope
{
    public partial class tromb : Form
    {
        public tromb()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assuming you have a SqlConnection named "connection"
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-11MQR6U\\SQLEXPRESS;Initial Catalog=Gestion_Etudiant;Integrated Security=True"))
            {
                connection.Open();

                // Replace "YourTableName" with your actual table name
                string query = "SELECT NomFROM filieres";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        comboBox1.Items.Clear();

                        // Check if there are rows in the result set
                        if (reader.HasRows)
                        {
                            // Iterate through the rows and add each filière name to the ComboBox
                            while (reader.Read())
                            {
                                string nomFiliere = reader["Nom"].ToString();
                                comboBox1.Items.Add(nomFiliere);
                            }
                        }
                    }
                }
            }
        }

    }
}
