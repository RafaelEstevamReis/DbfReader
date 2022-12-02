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
            this.lblTableInfo_General_File_LastWrite = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_File_CreatedAt = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_File_Size = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_File_Path = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_Header_Encoding = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_Header_LastUpdate = new System.Windows.Forms.Label();
            this.lblTableInfo_General_Header_Version = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_RowCount_Deleted = new System.Windows.Forms.Label();
            this.lblTableInfo_General_RowCount_Actual = new System.Windows.Forms.Label();
            this.lblTableInfo_General_RowCount_Reported = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTableInfo_Schema_CreateTable = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtTableInfo_Schema_CSharp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTableInfo_General_Header_FieldCount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.tabPage2.Controls.Add(this.lblTableInfo_General_Header_FieldCount);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_File_LastWrite);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_File_CreatedAt);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_File_Size);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_File_Path);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_Header_Encoding);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_Header_LastUpdate);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_Header_Version);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_RowCount_Deleted);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_RowCount_Actual);
            this.tabPage2.Controls.Add(this.lblTableInfo_General_RowCount_Reported);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
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
            // lblTableInfo_General_File_LastWrite
            // 
            this.lblTableInfo_General_File_LastWrite.AutoSize = true;
            this.lblTableInfo_General_File_LastWrite.Location = new System.Drawing.Point(79, 110);
            this.lblTableInfo_General_File_LastWrite.Name = "lblTableInfo_General_File_LastWrite";
            this.lblTableInfo_General_File_LastWrite.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_File_LastWrite.TabIndex = 31;
            this.lblTableInfo_General_File_LastWrite.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 15);
            this.label20.TabIndex = 30;
            this.label20.Text = "Last Write:";
            // 
            // lblTableInfo_General_File_CreatedAt
            // 
            this.lblTableInfo_General_File_CreatedAt.AutoSize = true;
            this.lblTableInfo_General_File_CreatedAt.Location = new System.Drawing.Point(79, 95);
            this.lblTableInfo_General_File_CreatedAt.Name = "lblTableInfo_General_File_CreatedAt";
            this.lblTableInfo_General_File_CreatedAt.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_File_CreatedAt.TabIndex = 29;
            this.lblTableInfo_General_File_CreatedAt.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 15);
            this.label18.TabIndex = 28;
            this.label18.Text = "Created At:";
            // 
            // lblTableInfo_General_File_Size
            // 
            this.lblTableInfo_General_File_Size.AutoSize = true;
            this.lblTableInfo_General_File_Size.Location = new System.Drawing.Point(79, 80);
            this.lblTableInfo_General_File_Size.Name = "lblTableInfo_General_File_Size";
            this.lblTableInfo_General_File_Size.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_File_Size.TabIndex = 27;
            this.lblTableInfo_General_File_Size.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "File Size:";
            // 
            // lblTableInfo_General_File_Path
            // 
            this.lblTableInfo_General_File_Path.Location = new System.Drawing.Point(64, 33);
            this.lblTableInfo_General_File_Path.Name = "lblTableInfo_General_File_Path";
            this.lblTableInfo_General_File_Path.Size = new System.Drawing.Size(302, 46);
            this.lblTableInfo_General_File_Path.TabIndex = 25;
            this.lblTableInfo_General_File_Path.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "File Path:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 15);
            this.label15.TabIndex = 23;
            this.label15.Text = "FILE DATA";
            // 
            // lblTableInfo_General_Header_Encoding
            // 
            this.lblTableInfo_General_Header_Encoding.AutoSize = true;
            this.lblTableInfo_General_Header_Encoding.Location = new System.Drawing.Point(476, 77);
            this.lblTableInfo_General_Header_Encoding.Name = "lblTableInfo_General_Header_Encoding";
            this.lblTableInfo_General_Header_Encoding.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_Header_Encoding.TabIndex = 22;
            this.lblTableInfo_General_Header_Encoding.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(382, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 15);
            this.label13.TabIndex = 21;
            this.label13.Text = "Load Encoding:";
            // 
            // lblTableInfo_General_Header_LastUpdate
            // 
            this.lblTableInfo_General_Header_LastUpdate.AutoSize = true;
            this.lblTableInfo_General_Header_LastUpdate.Location = new System.Drawing.Point(460, 47);
            this.lblTableInfo_General_Header_LastUpdate.Name = "lblTableInfo_General_Header_LastUpdate";
            this.lblTableInfo_General_Header_LastUpdate.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_Header_LastUpdate.TabIndex = 20;
            this.lblTableInfo_General_Header_LastUpdate.Text = "-";
            // 
            // lblTableInfo_General_Header_Version
            // 
            this.lblTableInfo_General_Header_Version.AutoSize = true;
            this.lblTableInfo_General_Header_Version.Location = new System.Drawing.Point(436, 33);
            this.lblTableInfo_General_Header_Version.Name = "lblTableInfo_General_Header_Version";
            this.lblTableInfo_General_Header_Version.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_Header_Version.TabIndex = 19;
            this.lblTableInfo_General_Header_Version.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(382, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Last Update:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Version:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "HEADER DATA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(576, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "TABLE ROWS";
            // 
            // lblTableInfo_General_RowCount_Deleted
            // 
            this.lblTableInfo_General_RowCount_Deleted.AutoSize = true;
            this.lblTableInfo_General_RowCount_Deleted.Location = new System.Drawing.Point(669, 47);
            this.lblTableInfo_General_RowCount_Deleted.Name = "lblTableInfo_General_RowCount_Deleted";
            this.lblTableInfo_General_RowCount_Deleted.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_RowCount_Deleted.TabIndex = 14;
            this.lblTableInfo_General_RowCount_Deleted.Text = "-";
            // 
            // lblTableInfo_General_RowCount_Actual
            // 
            this.lblTableInfo_General_RowCount_Actual.AutoSize = true;
            this.lblTableInfo_General_RowCount_Actual.Location = new System.Drawing.Point(669, 33);
            this.lblTableInfo_General_RowCount_Actual.Name = "lblTableInfo_General_RowCount_Actual";
            this.lblTableInfo_General_RowCount_Actual.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_RowCount_Actual.TabIndex = 13;
            this.lblTableInfo_General_RowCount_Actual.Text = "-";
            // 
            // lblTableInfo_General_RowCount_Reported
            // 
            this.lblTableInfo_General_RowCount_Reported.AutoSize = true;
            this.lblTableInfo_General_RowCount_Reported.Location = new System.Drawing.Point(493, 63);
            this.lblTableInfo_General_RowCount_Reported.Name = "lblTableInfo_General_RowCount_Reported";
            this.lblTableInfo_General_RowCount_Reported.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_RowCount_Reported.TabIndex = 12;
            this.lblTableInfo_General_RowCount_Reported.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(586, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Deleted Rows:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(586, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Row Count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Header Row Count:";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(4, 182);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(788, 262);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTableInfo_Schema_CreateTable);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 234);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "SQL";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTableInfo_Schema_CreateTable
            // 
            this.txtTableInfo_Schema_CreateTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableInfo_Schema_CreateTable.Location = new System.Drawing.Point(3, 3);
            this.txtTableInfo_Schema_CreateTable.Multiline = true;
            this.txtTableInfo_Schema_CreateTable.Name = "txtTableInfo_Schema_CreateTable";
            this.txtTableInfo_Schema_CreateTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTableInfo_Schema_CreateTable.Size = new System.Drawing.Size(774, 228);
            this.txtTableInfo_Schema_CreateTable.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtTableInfo_Schema_CSharp);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(780, 234);
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
            this.txtTableInfo_Schema_CSharp.Size = new System.Drawing.Size(774, 228);
            this.txtTableInfo_Schema_CSharp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 164);
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
            // lblTableInfo_General_Header_FieldCount
            // 
            this.lblTableInfo_General_Header_FieldCount.AutoSize = true;
            this.lblTableInfo_General_Header_FieldCount.Location = new System.Drawing.Point(454, 92);
            this.lblTableInfo_General_Header_FieldCount.Name = "lblTableInfo_General_Header_FieldCount";
            this.lblTableInfo_General_Header_FieldCount.Size = new System.Drawing.Size(12, 15);
            this.lblTableInfo_General_Header_FieldCount.TabIndex = 33;
            this.lblTableInfo_General_Header_FieldCount.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(382, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 15);
            this.label17.TabIndex = 32;
            this.label17.Text = "FieldCount:";
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
        private Label lblTableInfo_General_RowCount_Deleted;
        private Label lblTableInfo_General_RowCount_Actual;
        private Label lblTableInfo_General_RowCount_Reported;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label lblTableInfo_General_Header_LastUpdate;
        private Label lblTableInfo_General_Header_Version;
        private Label label11;
        private Label label10;
        private Label lblTableInfo_General_Header_Encoding;
        private Label label13;
        private Label lblTableInfo_General_File_Path;
        private Label label14;
        private Label label15;
        private Label lblTableInfo_General_File_LastWrite;
        private Label label20;
        private Label lblTableInfo_General_File_CreatedAt;
        private Label label18;
        private Label lblTableInfo_General_File_Size;
        private Label label16;
        private Label lblTableInfo_General_Header_FieldCount;
        private Label label17;
    }
}