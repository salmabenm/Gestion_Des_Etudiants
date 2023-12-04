using Gestion_Etudiants.Data;
using Gestion_Etudiants.View.Filiere;
using Gestion_Etudiants.View.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Gestion_Etudiants.View.Statistiques;
using Gestion_Etudiants.View.Etudiant;

namespace Gestion_Etudiants.View.Administration
{
    public partial class administrationMenuStrip : Form
    {
       
        public administrationMenuStrip()
        {
            InitializeComponent();
            
        }

        public void SwitchForms(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }


        private void tousLesÉtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpTousEtudiants studentsForm = new rpTousEtudiants();
            studentsForm.ShowDialog();
        }

        private void chaqueÉtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionEtudiant studentsForm = new selectionEtudiant();
            studentsForm.ShowDialog();
        }

        private void statistiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchForms(new StatistiquesForm());

        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchForms(new etudiantForm());
            

        }

        private void filièreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchForms(new FilierePage());
        }

        private void trombinoscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trombinoscope.tromb t = new Trombinoscope.tromb();
            t.ShowDialog();
        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void administrationMenuStrip_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
