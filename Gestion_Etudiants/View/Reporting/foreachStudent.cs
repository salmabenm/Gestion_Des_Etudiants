using Gestion_Etudiants.View.Reporting.StudentDataSetTableAdapters;
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
using Gestion_Etudiants.View.Reporting.StudentDataSetTableAdapters;

namespace Gestion_Etudiants.View.Reporting
{
    public partial class foreachStudent : Form
    {
        private string numIdentity;
        public foreachStudent(string cmd)
        {
            InitializeComponent();
            this.numIdentity = cmd;
        }

        private void foreachStudent_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-11MQR6U\\SQLEXPRESS; Initial Catalog = Gestion_Etudiant; Integrated Security = true");
            StudentDataSet ds = new StudentDataSet();
            studentTableAdapter da = new studentTableAdapter();
            crptForEach cr = new crptForEach();
            da.Fill(ds.student);
            cr.SetDataSource(ds);
            crystalReportViewer1.SelectionFormula = "{student.CNE}='" + numIdentity + "'";


            crystalReportViewer1.ReportSource = cr;
        }
    }
}
