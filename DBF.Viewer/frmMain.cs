using Simple.DBF;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBF.Viewer
{
    public partial class frmMain : Form
    {
        private string folder;

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
            var tables = Directory.GetFiles(folder, "*.dbf");

            foreach (var f in tables)
            {
                var fi = new FileInfo(f);

                var count = Reader.GetRowCount(fi.FullName);

                cboTables.Items.Add($"{fi.Name} [{count:N0} rows] ");
            }

        }

        private async void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTables.Enabled = false;

            var name = cboTables.Text;
            name = name.Substring(0, name.LastIndexOf('[')).Trim();

            var filePath = Path.Combine(folder, name);

            var progress = new Progress<int>();
            progress.ProgressChanged += Progress_ProgressChanged;
            var dt = await Task.Run(() => Reader.Load(filePath, progress));

            grdDados.DataSource = dt;
            progressBar1.Value = 0;
            atualizaStatus();

            cboTables.Enabled = true;
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
            progressBar1.Value = e;
        }

    }
}