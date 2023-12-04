using Gestion_Etudiants.Data;
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

namespace Gestion_Etudiants.View.Filiere
{
    public partial class FilierePage : Form
    {

        private DataTable filiereTable;

        public FilierePage()
        {
            InitializeComponent();

            LoadFiliereData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadFiliereData()
        {
           

            string query = "SELECT filiereId, nom FROM [filieres]";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, Connections.connection))
            {
                filiereTable = new DataTable();
                adapter.Fill(filiereTable);
                dataGridView1.DataSource = filiereTable;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomFiliere = textBox1.Text;

             

            string query = "INSERT INTO [filieres] (nom) VALUES (@Nom)";
            using (SqlCommand command = new SqlCommand(query, Connections.connection))
            {
                command.Parameters.AddWithValue("Nom", nomFiliere);
                command.ExecuteNonQuery();
            }


           
            LoadFiliereData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int filiereId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["filiereId"].Value);


                string newNomFiliere = Microsoft.VisualBasic.Interaction.InputBox("Enter the new filiere name:", "Modify Filiere", dataGridView1.Rows[selectedRowIndex].Cells["Nom"].Value.ToString());

                if (!string.IsNullOrWhiteSpace(newNomFiliere))
                {

                    
                    string query = "UPDATE [filieres] SET Nom = @Nom WHERE filiereId = @filiereId";
                    using (SqlCommand command = new SqlCommand(query, Connections.connection))
                    {
                        command.Parameters.AddWithValue("@Nom", newNomFiliere);
                        command.Parameters.AddWithValue("@filiereId", filiereId);
                        command.ExecuteNonQuery();
                    }
                    
                    LoadFiliereData();
                }
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int filiereId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["filiereId"].Value);
                int FiliereId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["FiliereId"].Value);

                string query = "DELETE FROM [filieres] WHERE filiereId = @filiereId";
                using (SqlCommand command = new SqlCommand(query, Connections.connection))
                {
                    command.Parameters.AddWithValue("@filiereId", filiereId);
                    command.ExecuteNonQuery();
                }

                string quer = "DELETE FROM [etudiants] WHERE FiliereId = @FiliereId";
                using (SqlCommand command = new SqlCommand(quer, Connections.connection))
                {
                    command.Parameters.AddWithValue("@FiliereId", FiliereId);
                    command.ExecuteNonQuery();
                }
                LoadFiliereData();
                ClearTextBoxes();
            }
        }

        private void FilierePage_Load(object sender, EventArgs e)
        {

        }
    }
}
