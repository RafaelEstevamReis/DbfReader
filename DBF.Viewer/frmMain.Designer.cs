using System.Windows.Forms;

namespace DBF.Viewer
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.grdDados = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblDadosTabela = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChangePath = new System.Windows.Forms.Button();
            this.trvTabelas = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableInfo_Schema_CreateTable = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtTableInfo_Schema_CSharp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tables:";
            // 
            // cboTables
            // 
            this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point(561, 5);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(233, 23);
            this.cboTables.TabIndex = 1;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            // 
            // grdDados
            // 
            this.grdDados.AllowUserToAddRows = false;
            this.grdDados.AllowUserToDeleteRows = false;
            this.grdDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDados.Location = new System.Drawing.Point(3, 3);
            this.grdDados.Name = "grdDados";
            this.grdDados.ReadOnly = true;
            this.grdDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDados.Size = new System.Drawing.Size(789, 441);
            this.grdDados.TabIndex = 2;
            this.grdDados.SelectionChanged += new System.EventHandler(this.grdDados_SelectionChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(133, 509);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(924, 16);
            this.progressBar1.TabIndex = 3;
            // 
            // lblDadosTabela
            // 
            this.lblDadosTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDadosTabela.Location = new System.Drawing.Point(2, 510);
            this.lblDadosTabela.Name = "lblDadosTabela";
            this.lblDadosTabela.Size = new System.Drawing.Size(125, 15);
            this.lblDadosTabela.TabIndex = 4;
            this.lblDadosTabela.Text = "0/0";
            this.lblDadosTabela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Location:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(405, 23);
            this.textBox1.TabIndex = 6;
            // 
            // btnChangePath
            // 
            this.btnChangePath.Location = new System.Drawing.Point(475, 5);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Size = new System.Drawing.Size(36, 23);
            this.btnChangePath.TabIndex = 7;
            this.btnChangePath.Text = "...";
            this.btnChangePath.UseVisualStyleBackColor = true;
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
            // 
            // trvTabelas
            // 
            this.trvTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvTabelas.Location = new System.Drawing.Point(2, 33);
            this.trvTabelas.Name = "trvTabelas";
            this.trvTabelas.Size = new System.Drawing.Size(251, 476);
            this.trvTabelas.TabIndex = 8;
            this.trvTabelas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvTabelas_NodeMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(259, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(803, 475);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdDados);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(795, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(795, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Table Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "SCHEMA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "GENERAL";
            // 
            // txtTableInfo_Schema_CreateTable
            // 
            this.txtTableInfo_Schema_CreateTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableInfo_Schema_CreateTable.Location = new System.Drawing.Point(3, 3);
            this.txtTableInfo_Schema_CreateTable.Multiline = true;
            this.txtTableInfo_Schema_CreateTable.Name = "txtTableInfo_Schema_CreateTable";
            this.txtTableInfo_Schema_CreateTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTableInfo_Schema_CreateTable.Size = new System.Drawing.Size(774, 242);
            this.txtTableInfo_Schema_CreateTable.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(4, 168);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(788, 276);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTableInfo_Schema_CreateTable);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 248);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "SQL";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtTableInfo_Schema_CSharp);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(780, 248);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "C#";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtTableInfo_Schema_CSharp
            // 
            this.txtTableInfo_Schema_CSharp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableInfo_Schema_CSharp.Location = new System.Drawing.Point(3, 3);
            this.txtTableInfo_Schema_CSharp.Multiline = true;
            this.txtTableInfo_Schema_CSharp.Name = "txtTableInfo_Schema_CSharp";
            this.txtTableInfo_Schema_CSharp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTableInfo_Schema_CSharp.Size = new System.Drawing.Size(774, 242);
            this.txtTableInfo_Schema_CSharp.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 526);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.trvTabelas);
            this.Controls.Add(this.btnChangePath);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDadosTabela);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "DBF Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cboTables;
        private DataGridView grdDados;
        private ProgressBar progressBar1;
        private Label lblDadosTabela;
        private Label label2;
        private TextBox textBox1;
        private Button btnChangePath;
        private TreeView trvTabelas;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtTableInfo_Schema_CreateTable;
        private Label label4;
        private Label label3;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox txtTableInfo_Schema_CSharp;
    }
}