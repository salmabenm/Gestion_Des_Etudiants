using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Etudiants.View.Reporting
{
    public partial class rpTousEtudiants : Form
    {
        public rpTousEtudiants()
        {
            InitializeComponent();
        }

        private void rpTousEtudiants_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crptStudentReport crpt = new crptStudentReport();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = crpt;
        }
    }
}
