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

        private void btnDividir_Click(object sender, EventArgs e)
        {
            LerParametros();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            FileSplitterLib.FileSplitter.DividirArquivo(caminhoArquivo, numeroPartes);

            watch.Stop();
            lblTempo.Text = "Tempo total: " + ((double)watch.ElapsedMilliseconds / 1000) + "s";
            lblStatus.Text = "Operação completada";
            lblStatus.ForeColor = Color.DarkGreen;
        }
        
        private void btnJuntar_Click(object sender, EventArgs e)
        {
            LerParametros();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            FileSplitterLib.FileSplitter.JuntarArquivo(caminhoArquivo);

            watch.Stop();
            lblTempo.Text = "Tempo total: " + ((double)watch.ElapsedMilliseconds / 1000) + "s";
            lblStatus.Text = "Operação completada";
            lblStatus.ForeColor = Color.DarkGreen;
        }

        private void LerParametros()
        {
            caminhoArquivo = ttbNomeArquivo.Text;
            numeroPartes = int.Parse(ttbNumeroPartes.Text);
        }

        private void ttbNomeArquivo_Click(object sender, EventArgs e)
        {
            DialogResult fd = ofdArquivo.ShowDialog();

            if(fd == DialogResult.OK)
            {
                ttbNomeArquivo.Text = ofdArquivo.FileName;
            }
        }
    }
}
