using Gestion_Etudiants.View.Filiere;
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

namespace Gestion_Etudiants.View.Etudiant
{
    public partial class AjouterEtudiant : Form
    {
        private List<Models.FiliereModel> fl_data;
        Models.FiliereModel selectedFiliere;
        string selectedName;
        public AjouterEtudiant()
        {
            InitializeComponent();
        }

        private void AjouterModifierEtudiant_Load(object sender, EventArgs e)
        {
            fl_data = getAllFiliere();
            foreach(var i in fl_data)
            {
                filiere_cmb.Items.Add(i.Nom);
            }
        }
        private List<Models.FiliereModel> getAllFiliere()
        {
            List<Models.FiliereModel> fl_data = new List<Models.FiliereModel>();
            DataClasses1DataContext data = new DataClasses1DataContext();

            var query = from f in data.filieres
                        select new Models.FiliereModel
                        (
                            f.filiereId,
                            f.Nom
                        );

            fl_data = query.ToList();
            return fl_data;
        }

        private void filiere_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedName = filiere_cmb.SelectedItem?.ToString();
            selectedFiliere = fl_data.FirstOrDefault(filiere => filiere.Nom == selectedName);
        }

        public bool checkStudentAvailability(string CNE)
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            var query = from etudiant in dataContext.etudiants where etudiant.CNE == CNE select etudiant;
            if (query.Any())
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void InsertStudentData(AjouterEtudiant form)
        {
            selectedName = filiere_cmb.SelectedItem?.ToString();
            string cne = cne_txt.Text;
            string sexe = radioButton1.Checked ? "H" : "F";

            if (checkStudentAvailability(cne))
            {
                if (selectedFiliere != null) // Check if selectedFiliere is not null
                {
                    Models.Etudiant newStudent = new Models.Etudiant
                    (
                         cne,
                         nom_txt.Text,
                         prenom_txt.Text,
                        "",
                        sexe,
                         date_txt.Text,
                         adress_txt.Text,
                         tel_txt.Text,
                        selectedFiliere.Id
                    );
                    addStudentToDB(newStudent);
                    form.Hide();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une filière valide.");
                }
            }
            else
            {
                MessageBox.Show("Erreur étudiant déjà inscrit dans la base de données");
            }
        }
        public void addStudentToDB(Models.Etudiant student)
            {
            try
            {
                {

                    string insertQuery = "INSERT INTO etudiants (CNE, Nom, Prenom, Sexe, DateNaissance, Addresse, Phone, FiliereId) " +
                     "VALUES (@CNE, @Nom, @Prenom, @Sexe, @DateNaissance, @Addresse, @Phone, @Filiere)";

                    using (SqlCommand command = new SqlCommand(insertQuery, Data.Connections.connection))
                    {
                        // Use parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@CNE", student.CNE);
                        command.Parameters.AddWithValue("@Nom", student.Nom);
                        command.Parameters.AddWithValue("@Prenom", student.Prenom);
                        command.Parameters.AddWithValue("@Sexe", student.Sexe);
                        command.Parameters.AddWithValue("@DateNaissance", student.DateNaissance);
                        command.Parameters.AddWithValue("@Addresse", student.Addresse);
                        command.Parameters.AddWithValue("@Phone", student.Phone);
                        command.Parameters.AddWithValue("@Filiere", student.Filiere);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Étudiant ajouté avec succès à la base de données");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'étudiant à la base de données: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertStudentData(this) ;
        }
    }
}

