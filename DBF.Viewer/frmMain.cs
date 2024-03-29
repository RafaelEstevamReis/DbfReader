using Simple.DBF;
using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DBF.Viewer
{
    public partial class frmMain : Form
    {
        private string folder;
        private TreeNode nodeRecent;
        private TreeNode nodeEmpty;
        private TreeNode nodeTables;
        private TreeNode nodeError;
        //private Reader currentTable;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            btnChangePath_Click(null, e);
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            folder = dlg.SelectedPath;
            textBox1.Text = folder;

            cboTables.Items.Clear();

            trvTabelas.Nodes.Clear();
            nodeRecent = trvTabelas.Nodes.Add("Recent Tables");
            nodeEmpty = trvTabelas.Nodes.Add("Empty Tables");
            nodeTables = trvTabelas.Nodes.Add("Tables");
            nodeError = trvTabelas.Nodes.Add("Loading Error");

            var tables = Directory.GetFiles(folder, "*.dbf");
            var progress = new Progress<int>();
            progress.ProgressChanged += Progress_ProgressChanged;
            // get table information
            Database dt = Database.Load(folder, progress);
            foreach (var t in dt.Tables)
            {
                string name;
                if (t.LoadError == null)
                {
                    name = $"{t.Name} [{t.RowCount:N0} rows] ";

                    if (t.RowCount == 0) nodeEmpty.Nodes.Add(name);
                    else nodeTables.Nodes.Add(name);
                }
                else
                {
                    name = $"{t.Name} [ERROR] ";
                    nodeError.Nodes.Add(name);
                }

                cboTables.Items.Add(name);
            }

            progressBar1.Value = 0;
            lblDadosTabela.Text = "Complete";

            nodeEmpty.Text = $"Empty Tables ({nodeEmpty.Nodes.Count})";
            nodeTables.Text = $"Tables ({nodeTables.Nodes.Count})";
            nodeError.Text = $"Loading Error ({nodeError.Nodes.Count})";
        }
        private async void trvTabelas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;

            if (e.Node.Level != 1) return;

            var name = e.Node.Text;

            foreach (TreeNode n in nodeRecent.Nodes)
            {
                if (n.Text != name) continue;
                nodeRecent.Nodes.Remove(n);
                break;
            }
            nodeRecent.Nodes.Add(name);

            name = name.Substring(0, name.LastIndexOf('[')).Trim();
            await loadTableAsync(name);
        }
        private async void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = cboTables.Text;
            name = name.Substring(0, name.LastIndexOf('[')).Trim();
            await loadTableAsync(name);
        }
        private async Task loadTableAsync(string tableName)
        {
            lblDadosTabela.Text = "Loading...";
            cboTables.Enabled = false;
            trvTabelas.Enabled = false;

            grdDados.DataSource = null;
            grdDados.Rows.Clear();
            grdDados.Columns.Clear();

            var filePath = Path.Combine(folder, tableName);

            var progress = new Progress<int>();
            progress.ProgressChanged += Progress_ProgressChanged;

            try
            {
                var reader = await Task.Run(() => Reader.Open(filePath, progress));
                //currentTable = reader;
                grdDados.DataSource = reader.ToDataTable();
                progressBar1.Value = 0;
                atualizaStatus();

                var fi = new FileInfo(reader.FilePath);
                lblTableInfo_General_File_Path.Text = reader.FilePath;
                lblTableInfo_General_File_Size.Text = $"{sizeFormat(fi.Length)} ({fi.Length:N0}b)";
                lblTableInfo_General_File_CreatedAt.Text = fi.CreationTime.ToString("G");
                lblTableInfo_General_File_LastWrite.Text = fi.LastWriteTime.ToString("G");

                lblTableInfo_General_Header_Version.Text = $"{reader.HeaderVersion} (0x{(int)reader.HeaderVersion:X2})";
                lblTableInfo_General_Header_LastUpdate.Text = reader.HeaderLastUpdate.ToString("G");
                lblTableInfo_General_RowCount_Reported.Text = reader.HeaderRowCount.ToString("N0");
                lblTableInfo_General_Header_Encoding.Text = reader.HeaderEncoding.EncodingName;
                lblTableInfo_General_Header_FieldCount.Text = reader.Fields.Count.ToString();

                int deleted = reader.Records.Count(r => r.Deleted);
                lblTableInfo_General_RowCount_Actual.Text = (reader.RowCount - deleted).ToString("N0");
                lblTableInfo_General_RowCount_Deleted.Text = deleted.ToString("N0");

                txtTableInfo_Schema_CreateTable.Text = reader.ExportCreateTable(includeExample: true);
                txtTableInfo_Schema_CSharp.Text = reader.ExportModelClassTemplate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the table:\n" + ex.Message);
            }

            trvTabelas.Enabled = true;
            cboTables.Enabled = true;
            lblDadosTabela.Text = tableName;
        }
        private string sizeFormat(long bytes)
        {
            string unit = "";

            double dSize = bytes;
            if (dSize > 512)
            {
                dSize /= 1024;
                unit = "KiB";
            }

            if (dSize > 512)
            {
                dSize /= 1024;
                unit = "MiB";
            }

            if (dSize > 512)
            {
                dSize /= 1024;
                unit = "GiB";
            }

            return $"{dSize:N1} {unit}";
        }

        private void grdDados_SelectionChanged(object sender, EventArgs e)
        {
            atualizaStatus();
        }
        private void atualizaStatus()
        {
            int current;
            if (grdDados.SelectedCells.Count > 0)
            {
                current = grdDados.SelectedCells[0].RowIndex;
            }
            else
            {
                current = grdDados.FirstDisplayedScrollingRowIndex;
            }
            current += 1; // Starts at row 1

            lblDadosTabela.Text = $"{current:N0}/{grdDados.RowCount:N0}";
        }

        private void Progress_ProgressChanged(object sender, int e)
        {
            if (e > progressBar1.Maximum) e = progressBar1.Maximum;
            progressBar1.Value = e;
        }

        private async void btnTableInfo_Schema_Export_CSV_Click(object sender, EventArgs e)
        {
            if (grdDados.RowCount == 0)
            {
                MessageBox.Show("Selected table is empty");
                return;
            }

            var tskRows = Task.Run(convertCsv); // process while user select destination

            using var dlg = new SaveFileDialog();
            var fi = new FileInfo(lblTableInfo_General_File_Path.Text);
            dlg.FileName = $"{fi.Name}.csv";
            dlg.Filter = "Arquivo *.CSV|*.csv";

            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            string[] rows = await tskRows;
            
            File.WriteAllLines(dlg.FileName, rows);
            MessageBox.Show($"CSV saved at:\n{dlg.FileName}");
        }
        private string[] convertCsv()
        {
            var rows = convertRowsCsv(grdDados.Rows.Cast<DataGridViewRow>());
            rows = new string[] { convertHeaderCsv(grdDados) }
                   .Union(rows);
            return rows.ToArray();
        }
        private string convertHeaderCsv(DataGridView grid)
        {
            return string.Join(',', grdDados.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText));
        }
        private IEnumerable<string> convertRowsCsv(IEnumerable<DataGridViewRow> rows) 
            => rows.Select(r => convertRowCsv(r.Cells.Cast<DataGridViewCell>()));
        private string convertRowCsv(IEnumerable<DataGridViewCell> row) 
            => string.Join(',', row.Select(c => convertCellCsv(c.Value)));
        private string convertCellCsv(object value)
        {
            if (value is null) return "\"\"";
            var strVal = value.ToString();
            // escape
            if (strVal.Contains('"')) strVal = strVal.Replace("\"", "\"\"");

            return $"\"{strVal}\"";
        }
    }
}