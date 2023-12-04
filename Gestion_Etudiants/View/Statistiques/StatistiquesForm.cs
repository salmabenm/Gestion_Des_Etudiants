using Gestion_Etudiants.Data;
using Gestion_Etudiants.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_Etudiants.View.Statistiques
{
    public partial class StatistiquesForm : Form
    {
        public StatistiquesForm()
        {
            InitializeComponent();
            fillChart();
        }
        private void fillChart()
        {
            FilieresData data = new FilieresData();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();


            ChartArea chartArea = chart1.ChartAreas.Add("MainChartArea");
            Series series = chart1.Series.Add("Nombre Etudiant");
            series.ChartType = SeriesChartType.Column; // Assuming a column chart

            chartArea.AxisX.Title = "Filiere";
            chartArea.AxisY.Title = "Nombre d'etudiants";


            List<FiliereModel> filieres = data.getAllFilieresWithCountOfStudent();
            int totalStudents = (int)filieres.Sum(f => f.NombreEtudiant);


            foreach (FiliereModel f in filieres)
            {
                double percentage = (double)f.NombreEtudiant / totalStudents * 100.0;
                int index = chart1.Series["Nombre Etudiant"].Points.AddXY(f.Nom, f.NombreEtudiant);
                chart1.Series["Nombre Etudiant"].Points[index].Label = $"{percentage:0.00}%";


            }
            chart1.Titles.Add("Repartition des etudiants par filiere");
            chart1.Dock = DockStyle.Fill;

        }
    }
}
