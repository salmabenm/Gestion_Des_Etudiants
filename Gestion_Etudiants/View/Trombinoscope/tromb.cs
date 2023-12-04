using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gestion_Etudiants.Data;
using Gestion_Etudiants.Models;
using Gestion_Etudiants.View.Etudiant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Etudiants.View.Trombinoscope
{
    public partial class tromb : Form
    {
        private List<Models.FiliereModel> filieres_data;
        private List<Models.Etudiant> etudiants = new List<Models.Etudiant>();
        public tromb()
        {
            InitializeComponent();
            fetchAllFilieres();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = combobox1.SelectedItem.ToString();
            FiliereModel f =  filieres_data.SingleOrDefault(fi=>fi.Nom==selectedItem);
            getAllStudentsInFiliere(f);
            PrintToExcelFile();
        }

        public void getAllStudentsInFiliere(FiliereModel f)
        {
            

            etudiants.Clear();
            String query = $"SELECT * from etudiants where filiereId={f.Id}";
            using (SqlCommand commande = new SqlCommand(query, Data.Connections.connection))
            {
                using (SqlDataReader data = commande.ExecuteReader())
                {
                    while (data.Read())
                    {

                        Models.Etudiant e = new Models.Etudiant(
                            data[0].ToString(),
                            data[1].ToString(),
                            data[2].ToString(),
                            data[3].ToString(),
                            data[4].ToString(),
                            data[5].ToString(),
                            data[6].ToString(),
                            data[7].ToString(),
                            (int)data[8]
                        );
                        
                        etudiants.Add(e);

                    }
                }
            }



        }


        public void PrintToExcelFile()
        {

            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(programDirectory).FullName).FullName).FullName;
            string imagesFolderPath = Path.Combine(parentDirectory, "Images");



            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save Excel File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Etudiants");

                    // Add headers
                    var headers = new List<string> { "CNE", "Nom", "Prenom" ,"Email","Photo" };
                    for (int i = 0; i < headers.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = headers[i];
                    }

                    // Add data
                    for (int i = 0; i < etudiants.Count; i++)
                    {
                        var etudiant = etudiants[i];
                        worksheet.Cell(i + 2, 1).Value = etudiant.CNE;
                        worksheet.Cell(i + 2, 2).Value = etudiant.Nom;
                        worksheet.Cell(i + 2, 3).Value = etudiant.Prenom;
                        worksheet.Cell(i + 2, 4).Value = etudiant.Email;



                        string imagePath = Path.Combine(imagesFolderPath, $"{etudiant.CNE}.jpg");


                        if (File.Exists(imagePath))
                        {
                            var image = worksheet.AddPicture(imagePath);

                            int targetRow = i+2;
                            int targetColumn = 5;

                            image.MoveTo(worksheet.Cell(targetRow, targetColumn));

                            image.Width =(int) worksheet.Column(targetColumn).Width+1;
                            image.Height =(int) worksheet.Row(targetRow).Height+1;
                        }


                    }

                    

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Excel file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void fetchAllFilieres()
        {
            filieres_data = getAllFiliere();
            foreach (var i in filieres_data)
            {
                combobox1.Items.Add(i.Nom);
            }
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
    }
}
