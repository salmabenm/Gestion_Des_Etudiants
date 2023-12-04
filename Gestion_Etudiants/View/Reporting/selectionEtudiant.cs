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

namespace Gestion_Etudiants.View.Reporting
{
    public partial class selectionEtudiant : Form
    {
        public selectionEtudiant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string cneValue = textBox1.Text.Trim();

                if (DoesCNEExist(cneValue))
                {
                    foreachStudent cne = new foreachStudent(cneValue);
                    cne.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La valeur CNE n'existe pas dans la table etudiant.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur pour le CNE.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DoesCNEExist(string cneValue)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-11MQR6U\\SQLEXPRESS;Initial Catalog=Gestion_Etudiant;Integrated Security=True");

            string query = "SELECT COUNT(*) FROM etudiants WHERE CNE = @CNE";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CNE", cneValue);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

    }
}
