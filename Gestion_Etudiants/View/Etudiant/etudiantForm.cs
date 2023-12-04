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
using Gestion_Etudiants.Models;

namespace Gestion_Etudiants.View.Etudiant
{
    public partial class etudiantForm : Form
    {
        private List<Models.Etudiant> students_data;
        private List<Models.FiliereModel> filieres_data;

        public etudiantForm()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStudentsList();
            DisplaySelectedStudentDetails();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedStudentDetails();
        }


        private void etudiantForm_Load(object sender, EventArgs e)
        {
            students_data = getAllStudentData();

            foreach (var i in students_data)
            {
                search_student.Items.Add(i.CNE);
            }

            filieres_data = getAllFiliere();
            foreach (var i in filieres_data)
            {
                filiere_cmb_2.Items.Add(i.Nom);
            }
        }



        private void UpdateStudentsList()
        {
            string selectedFiliere = filiere_cmb_2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFiliere))
            {
                // Filter the list of students based on the selected filiere
                students_data = getAllStudentData().Where(student => student.FiliereName == selectedFiliere).ToList();

                // Update the search_student ComboBox with the filtered list
                search_student.Items.Clear();
                foreach (var student in students_data)
                {
                    search_student.Items.Add(student.CNE);
                }
            }
        }

        private void DisplaySelectedStudentDetails()
        {
            string selectedCNE = search_student.SelectedItem?.ToString();

            Models.Etudiant selectedStudent = students_data.FirstOrDefault(student => student.CNE == selectedCNE);

            if (selectedStudent != null)
            {
                date_naiss_cmb.Items.Clear();
                filiere_cmb.Items.Clear();
                nom_txt.Text = selectedStudent.Nom;
                prenom_txt.Text = selectedStudent.Prenom;
                adress_txt.Text = selectedStudent.Addresse;
                tel_txt.Text = selectedStudent.Phone;
                filiere_cmb.Text = selectedStudent.FiliereName;
                adress_txt.Text = selectedStudent.Addresse;
                if (selectedStudent.Sexe.Equals("F"))
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                filiere_cmb.Items.Add(selectedStudent.Filiere);
                date_naiss_cmb.Items.Add(selectedStudent.DateNaissance);
                cne_txt.Text = selectedStudent.CNE;
            }
        }

        public List<Models.Etudiant> getAllStudentData()
        {
            List<Models.Etudiant> st_data = new List<Models.Etudiant>();
            DataClasses1DataContext data = new DataClasses1DataContext();

            var query = from e in data.etudiants
                        join f in data.filieres on e.FiliereId equals f.filiereId
                        select new Models.Etudiant
                        {
                            CNE = e.CNE,
                            Nom = e.Nom,
                            Prenom = e.Prenom,
                            Addresse = e.Addresse,
                            Phone = e.Phone,
                            Sexe = e.Sexe,
                            DateNaissance = e.DateNaissance.ToString(),
                            FiliereName = f.Nom
                        };

            List<Models.Etudiant> etudiants = query.ToList();
            st_data = etudiants;

            return st_data;
        }

        public List<Models.FiliereModel> getAllFiliere()
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

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dv = gestion_EtudiantDataSet.etudiants.DefaultView;
            dv.Sort = "Nom ASC";
            DataTable sortedTable = gestion_EtudiantDataSet.etudiants.Clone();

            foreach (DataRowView rowView in dv)
            {
                DataRow newRow = sortedTable.NewRow();
                newRow.ItemArray = rowView.Row.ItemArray;
                sortedTable.Rows.Add(newRow);
            }

            dataGridView1.DataSource = sortedTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataView dv = gestion_EtudiantDataSet.etudiants.DefaultView;
            dv.Sort = "Nom DESC";
            DataTable sortedTable = gestion_EtudiantDataSet.etudiants.Clone();

            foreach (DataRowView rowView in dv)
            {
                DataRow newRow = sortedTable.NewRow();
                newRow.ItemArray = rowView.Row.ItemArray;
                sortedTable.Rows.Add(newRow);
            }

            dataGridView1.DataSource = sortedTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedFiliere = filiere_cmb_2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFiliere))
            {
                int selectedFiliereId = filieres_data.FirstOrDefault(f => f.Nom == selectedFiliere)?.Id ?? -1;

                this.etudiantsTableAdapter.FillBy(this.gestion_EtudiantDataSet.etudiants, selectedFiliereId);
            }
            else
            {

                this.etudiantsTableAdapter.Fill(this.gestion_EtudiantDataSet.etudiants);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fichiers Excel|.xlsx;.xls";
                openFileDialog.Title = "Sélectionnez le fichier Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    DataTable dataTable = ReadExcelData(filePath);

                    if (dataTable != null)
                    {

                        if (IsValidDataTableStructure(dataTable))
                        {
                            InsertDataIntoDatabase(dataTable);

                            this.etudiantsTableAdapter.Fill(this.gestion_EtudiantDataSet.etudiants);
                            MessageBox.Show("Importation réussie !");
                        }
                        else
                        {
                            MessageBox.Show("La structure du fichier Excel est incorrecte. Vérifiez les colonnes.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la lecture du fichier Excel.");
                    }
                }
            }

        }
        private DataTable ReadExcelData(string filePath)
        {
            /*try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); 

                    
                    DataTable dataTable = worksheet.ToDataTable();

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la lecture du fichier Excel : {ex.Message}");
                return null;
            }*/
            return null;
        }
        private bool IsValidDataTableStructure(DataTable dataTable)
        {
            return dataTable.Columns.Contains("CNE") && dataTable.Columns.Contains("Nom") && dataTable.Columns.Contains("Prenom") && dataTable.Columns.Contains("Sexe") && dataTable.Columns.Contains("DateNaissance") && dataTable.Columns.Contains("Addresse") && dataTable.Columns.Contains("Phone") && dataTable.Columns.Contains("Filiere");
        }

        private void InsertDataIntoDatabase(DataTable dataTable)
        {
            try
            {
                using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string cne = row["CNE"].ToString();
                        string nom = row["Nom"].ToString();
                        string prenom = row["Prenom"].ToString();
                        string sexe = row["Sexe"].ToString();
                        string dateNaissance = row["DateNaissance"].ToString();
                        string addresse = row["Addresse"].ToString();
                        string phone = row["Phone"].ToString();
                        string filiereNom = row["Filiere"].ToString();

                        int filiereId = filieres_data.FirstOrDefault(f => f.Nom == filiereNom)?.Id ?? -1;

                        if (filiereId != -1)
                        {

                            Models.Etudiant newEtudiant = new Models.Etudiant();
                            newEtudiant.Nom = nom;
                            newEtudiant.Addresse = addresse;
                            newEtudiant.Phone = phone;
                            newEtudiant.CNE = cne;
                            newEtudiant.Prenom = prenom;
                            newEtudiant.DateNaissance = dateNaissance;
                            newEtudiant.Sexe = sexe;
                            newEtudiant.FiliereName = filiereNom;


                            // TODO :Insert the new Etudiant object into the database

                        }
                        else
                        {
                            MessageBox.Show($"Filiere '{filiereNom}' not found. Skipping this entry.");
                        }
                    }

                    dataContext.SubmitChanges();
                }

                MessageBox.Show("Importation réussie !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'insertion dans la base de données : {ex.Message}");
            }
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            AjouterEtudiant formAjout = new AjouterEtudiant();
            formAjout.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Models.Etudiant updatedStudent = new Models.Etudiant
            { 
                Nom = nom_txt.Text,
                Prenom = prenom_txt.Text,
                Sexe = radioButton1.Checked ? "H" : "F",
                Addresse = adress_txt.Text,
                Phone = tel_txt.Text,
            };
            updateStudentInDB(cne_txt.Text, updatedStudent);
        }
        private void updateStudentInDB(string cne ,  Models.Etudiant updatedStudent)
        {
            try
            {
                string updateQuery = "UPDATE etudiants " +
                             "SET Nom = @Nom, Prenom = @Prenom, Sexe = @Sexe, " +
                             " Addresse = @Addresse, " +
                             "Phone = @Phone " +
                             "WHERE CNE = @CNE";
                using (SqlCommand command = new SqlCommand(updateQuery, Data.Connections.connection))
                {
                    command.Parameters.AddWithValue("@CNE", cne);
                    command.Parameters.AddWithValue("@Nom", updatedStudent.Nom);
                    command.Parameters.AddWithValue("@Prenom", updatedStudent.Prenom);
                    command.Parameters.AddWithValue("@Sexe", updatedStudent.Sexe);
                    command.Parameters.AddWithValue("@Addresse", updatedStudent.Addresse);
                    command.Parameters.AddWithValue("@Phone", updatedStudent.Phone);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Étudiant mis à jour avec succès dans la base de données");
                RefreshUI();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour de l'étudiant dans la base de données: {ex.Message}");
            }
        }
        private void RefreshUI()
        {
            search_student.Items.Clear();
            students_data = getAllStudentData();

            foreach (var i in students_data)
            {
                search_student.Items.Add(i.CNE);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Assuming you have a student CNE to delete
            string cneToDelete = cne_txt.Text;

            if (!string.IsNullOrEmpty(cneToDelete))
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer cet étudiant?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    deleteStudentFromDB(cneToDelete);
                    // Optionally, refresh the UI or perform other actions after the delete
                    RefreshUI(); // Example: Call a method to refresh the UI
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer le CNE de l'étudiant que vous souhaitez supprimer.");
            }
        }

        private void deleteStudentFromDB(string cneToDelete)
        {
            try
            {
                string deleteQuery = "DELETE FROM etudiants WHERE CNE = @CNE";

                using (SqlCommand command = new SqlCommand(deleteQuery, Data.Connections.connection))
                {
                    command.Parameters.AddWithValue("@CNE", cneToDelete);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Étudiant supprimé avec succès de la base de données");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'étudiant de la base de données: {ex.Message}");
            }
        }
    }
}