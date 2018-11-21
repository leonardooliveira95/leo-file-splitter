using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSplitter
{
    public partial class Form1 : Form
    {
        private string caminhoArquivo;
        private int numeroPartes;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDividir_Click(object sender, EventArgs e)
        {
            LerParametros();

            if (!ValidarArquivo())
            {
                return;
            }

            pgbProgressoArquivo.Maximum = 100;
            pgbProgressoArquivo.Step = 1;

            var progress = new Progress<int>(v =>
            {
                pgbProgressoArquivo.Value = v;
                lblProgresso.Text = "Processando parte " + (v * numeroPartes / 100) + " de " + numeroPartes;
            });

            AlterarInterface(false);
            lblStatus.Text = "";
            lblTempo.Text = "";

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Task task = FileSplitterLib.FileSplitter.DividirArquivo(caminhoArquivo, numeroPartes, progress);

            await task;

            watch.Stop();

            lblTempo.Text = "Tempo total: " + ((double)watch.ElapsedMilliseconds / 1000) + "s";
            lblStatus.Text = "Operação completada";
            lblStatus.ForeColor = Color.DarkGreen;

            AlterarInterface(true);
        }

        private async void btnJuntar_Click(object sender, EventArgs e)
        {
            caminhoArquivo = ttbNomeArquivo.Text;

            if (!ValidarArquivo())
            {
                return;
            }

            numeroPartes = GetNumeroPartes();

            pgbProgressoArquivo.Maximum = 100;
            pgbProgressoArquivo.Step = 1;

            var progress = new Progress<int>(v =>
            {
                pgbProgressoArquivo.Value = v;
                lblProgresso.Text = "Processando parte " + (v * numeroPartes / 100) + " de " + numeroPartes;
            });

            AlterarInterface(false);
            lblStatus.Text = "";
            lblTempo.Text = "";

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Task task = FileSplitterLib.FileSplitter.JuntarArquivo(caminhoArquivo, progress);

            await task;

            watch.Stop();

            lblTempo.Text = "Tempo total: " + ((double)watch.ElapsedMilliseconds / 1000) + "s";
            lblStatus.Text = "Operação completada";
            lblStatus.ForeColor = Color.DarkGreen;

            AlterarInterface(true);
        }

        private void LerParametros()
        {
            caminhoArquivo = ttbNomeArquivo.Text;
            numeroPartes = int.Parse(ttbNumeroPartes.Text);
        }

        private void ttbNomeArquivo_Click(object sender, EventArgs e)
        {
            DialogResult fd = ofdArquivo.ShowDialog();

            if (fd == DialogResult.OK)
            {
                ttbNomeArquivo.Text = ofdArquivo.FileName;
            }
        }

        private void AlterarInterface(bool habilitado)
        {
            btnDividir.Enabled = habilitado;
            btnJuntar.Enabled = habilitado;
            ttbNomeArquivo.Enabled = habilitado;
            ttbNumeroPartes.Enabled = habilitado;
        }

        private bool ValidarArquivo()
        {
            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("O caminho de arquivo informado não existe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(File.GetAttributes(caminhoArquivo) == FileAttributes.Directory)
            {
                MessageBox.Show("O caminho informado é um diretório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int GetNumeroPartes()
        {
            DirectoryInfo di = Directory.GetParent(caminhoArquivo);
            List<FileInfo> arqs = di.GetFiles().ToList();
            FileInfo arq = new FileInfo(caminhoArquivo);
            string subStr = arq.Name.Substring(0, arq.Name.LastIndexOf('.'));
            List<FileInfo> res = arqs.FindAll(x => x.Name.Contains(subStr));

            return res.Count;

        }
    }
}
