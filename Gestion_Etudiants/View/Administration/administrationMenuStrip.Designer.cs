namespace Gestion_Etudiants.View.Administration
{
    partial class administrationMenuStrip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filièreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etudiantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tousLesÉtudiantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chaqueÉtudiantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trombinoscopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filièreToolStripMenuItem,
            this.etudiantToolStripMenuItem,
            this.statistiqueToolStripMenuItem,
            this.reportingToolStripMenuItem,
            this.trombinoscopeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filièreToolStripMenuItem
            // 
            this.filièreToolStripMenuItem.Name = "filièreToolStripMenuItem";
            this.filièreToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.filièreToolStripMenuItem.Text = "Filière";
            this.filièreToolStripMenuItem.Click += new System.EventHandler(this.filièreToolStripMenuItem_Click);
            // 
            // etudiantToolStripMenuItem
            // 
            this.etudiantToolStripMenuItem.Name = "etudiantToolStripMenuItem";
            this.etudiantToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.etudiantToolStripMenuItem.Text = "Etudiant";
            this.etudiantToolStripMenuItem.Click += new System.EventHandler(this.etudiantToolStripMenuItem_Click);
            // 
            // statistiqueToolStripMenuItem
            // 
            this.statistiqueToolStripMenuItem.Name = "statistiqueToolStripMenuItem";
            this.statistiqueToolStripMenuItem.Size = new System.Drawing.Size(110, 29);
            this.statistiqueToolStripMenuItem.Text = "Statistique";
            this.statistiqueToolStripMenuItem.Click += new System.EventHandler(this.statistiqueToolStripMenuItem_Click);
            // 
            // reportingToolStripMenuItem
            // 
            this.reportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tousLesÉtudiantsToolStripMenuItem,
            this.chaqueÉtudiantToolStripMenuItem});
            this.reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            this.reportingToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.reportingToolStripMenuItem.Text = "Reporting";
            this.reportingToolStripMenuItem.Click += new System.EventHandler(this.reportingToolStripMenuItem_Click);
            // 
            // tousLesÉtudiantsToolStripMenuItem
            // 
            this.tousLesÉtudiantsToolStripMenuItem.Name = "tousLesÉtudiantsToolStripMenuItem";
            this.tousLesÉtudiantsToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.tousLesÉtudiantsToolStripMenuItem.Text = "Tous les étudiants";
            this.tousLesÉtudiantsToolStripMenuItem.Click += new System.EventHandler(this.tousLesÉtudiantsToolStripMenuItem_Click);
            // 
            // chaqueÉtudiantToolStripMenuItem
            // 
            this.chaqueÉtudiantToolStripMenuItem.Name = "chaqueÉtudiantToolStripMenuItem";
            this.chaqueÉtudiantToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.chaqueÉtudiantToolStripMenuItem.Text = "Chaque étudiant";
            this.chaqueÉtudiantToolStripMenuItem.Click += new System.EventHandler(this.chaqueÉtudiantToolStripMenuItem_Click);
            // 
            // trombinoscopeToolStripMenuItem
            // 
            this.trombinoscopeToolStripMenuItem.Name = "trombinoscopeToolStripMenuItem";
            this.trombinoscopeToolStripMenuItem.Size = new System.Drawing.Size(151, 29);
            this.trombinoscopeToolStripMenuItem.Text = "Trombinoscope";
            this.trombinoscopeToolStripMenuItem.Click += new System.EventHandler(this.trombinoscopeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 646);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // administrationMenuStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "administrationMenuStrip";
            this.Text = "administrationMenuStrip";
            this.Load += new System.EventHandler(this.administrationMenuStrip_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filièreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etudiantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tousLesÉtudiantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chaqueÉtudiantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trombinoscopeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}