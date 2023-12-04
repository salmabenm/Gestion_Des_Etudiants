using Gestion_Etudiants.Data;
using Gestion_Etudiants.View.Administration;
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

namespace Gestion_Etudiants.View.Login
{
    public partial class LoginPage : Form
    {

        
        public LoginPage()
        {
            InitializeComponent();
          
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string userType = GetUserType(username, password);

            if (!string.IsNullOrEmpty(userType))
            {
                if (userType.Equals("Administrateur", StringComparison.OrdinalIgnoreCase))
                {
                    administrationMenuStrip menuStrip = new administrationMenuStrip();
                    this.Hide();
                    menuStrip.ShowDialog();
                }
                else if (userType.Equals("Enseignant", StringComparison.OrdinalIgnoreCase))
                {
                    // TrimonoscopeForm trimonoscopeForm = new TrimonoscopeForm();
                    this.Hide();
                    //  trimonoscopeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Type d'utilisateur non reconnu. Accès refusé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                Application.Exit();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect. Accès refusé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserType(string username, string password)
        {
            string userType = string.Empty;

          
            string query = "SELECT type FROM [users] WHERE login = @username AND password = @password";

            using (SqlCommand command = new SqlCommand(query, Connections.connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userType = result.ToString();
                }
            }


            return userType;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
