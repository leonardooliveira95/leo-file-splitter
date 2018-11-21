namespace FileSplitter
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ttbNomeArquivo = new System.Windows.Forms.TextBox();
            this.ttbNumeroPartes = new System.Windows.Forms.TextBox();
            this.btnDividir = new System.Windows.Forms.Button();
            this.lblTempo = new System.Windows.Forms.Label();
            this.btnJuntar = new System.Windows.Forms.Button();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.lblNumeroPartes = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.pgbProgressoArquivo = new System.Windows.Forms.ProgressBar();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ttbNomeArquivo
            // 
            this.ttbNomeArquivo.Location = new System.Drawing.Point(12, 29);
            this.ttbNomeArquivo.Name = "ttbNomeArquivo";
            this.ttbNomeArquivo.Size = new System.Drawing.Size(401, 20);
            this.ttbNomeArquivo.TabIndex = 0;
            this.ttbNomeArquivo.Click += new System.EventHandler(this.ttbNomeArquivo_Click);
            // 
            // ttbNumeroPartes
            // 
            this.ttbNumeroPartes.Location = new System.Drawing.Point(12, 85);
            this.ttbNumeroPartes.Name = "ttbNumeroPartes";
            this.ttbNumeroPartes.Size = new System.Drawing.Size(91, 20);
            this.ttbNumeroPartes.TabIndex = 1;
            // 
            // btnDividir
            // 
            this.btnDividir.Location = new System.Drawing.Point(12, 124);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(75, 23);
            this.btnDividir.TabIndex = 2;
            this.btnDividir.Text = "Dividir";
            this.btnDividir.UseVisualStyleBackColor = true;
            this.btnDividir.Click += new System.EventHandler(this.btnDividir_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(9, 164);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(69, 13);
            this.lblTempo.TabIndex = 3;
            this.lblTempo.Text = "Tempo total: ";
            // 
            // btnJuntar
            // 
            this.btnJuntar.Location = new System.Drawing.Point(93, 124);
            this.btnJuntar.Name = "btnJuntar";
            this.btnJuntar.Size = new System.Drawing.Size(75, 23);
            this.btnJuntar.TabIndex = 4;
            this.btnJuntar.Text = "Juntar";
            this.btnJuntar.UseVisualStyleBackColor = true;
            this.btnJuntar.Click += new System.EventHandler(this.btnJuntar_Click);
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(9, 13);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(101, 13);
            this.lblCaminho.TabIndex = 5;
            this.lblCaminho.Text = "Caminho do arquivo";
            // 
            // lblNumeroPartes
            // 
            this.lblNumeroPartes.AutoSize = true;
            this.lblNumeroPartes.Location = new System.Drawing.Point(9, 69);
            this.lblNumeroPartes.Name = "lblNumeroPartes";
            this.lblNumeroPartes.Size = new System.Drawing.Size(91, 13);
            this.lblNumeroPartes.TabIndex = 6;
            this.lblNumeroPartes.Text = "Número de partes";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 193);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 7;
            // 
            // pgbProgressoArquivo
            // 
            this.pgbProgressoArquivo.Location = new System.Drawing.Point(12, 257);
            this.pgbProgressoArquivo.Name = "pgbProgressoArquivo";
            this.pgbProgressoArquivo.Size = new System.Drawing.Size(458, 23);
            this.pgbProgressoArquivo.TabIndex = 8;
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.Location = new System.Drawing.Point(12, 238);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(0, 13);
            this.lblProgresso.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 292);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.pgbProgressoArquivo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblNumeroPartes);
            this.Controls.Add(this.lblCaminho);
            this.Controls.Add(this.btnJuntar);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.btnDividir);
            this.Controls.Add(this.ttbNumeroPartes);
            this.Controls.Add(this.ttbNomeArquivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FileSplitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ttbNomeArquivo;
        private System.Windows.Forms.TextBox ttbNumeroPartes;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Button btnJuntar;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Label lblNumeroPartes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.ProgressBar pgbProgressoArquivo;
        private System.Windows.Forms.Label lblProgresso;
    }
}

