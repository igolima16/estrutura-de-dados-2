namespace SistemaAtendimento
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnChamar = new System.Windows.Forms.Button();
            this.listBoxSenhas = new System.Windows.Forms.ListBox();
            this.listBoxAtendimentos = new System.Windows.Forms.ListBox();
            this.txtGuiche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            this.btnGerar.Location = new System.Drawing.Point(20, 20);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(100, 30);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar Senha";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            
            this.btnAdicionar.Location = new System.Drawing.Point(130, 20);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(120, 30);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar Guichê";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            
            this.txtGuiche.Location = new System.Drawing.Point(260, 25);
            this.txtGuiche.Name = "txtGuiche";
            this.txtGuiche.Size = new System.Drawing.Size(50, 23);
            this.txtGuiche.TabIndex = 2;
            
            this.btnChamar.Location = new System.Drawing.Point(320, 20);
            this.btnChamar.Name = "btnChamar";
            this.btnChamar.Size = new System.Drawing.Size(100, 30);
            this.btnChamar.TabIndex = 3;
            this.btnChamar.Text = "Chamar Senha";
            this.btnChamar.UseVisualStyleBackColor = true;
            this.btnChamar.Click += new System.EventHandler(this.btnChamar_Click);
            
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Guichê:";
            
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fila de Espera:";
            
            this.listBoxSenhas.FormattingEnabled = true;
            this.listBoxSenhas.ItemHeight = 15;
            this.listBoxSenhas.Location = new System.Drawing.Point(20, 80);
            this.listBoxSenhas.Name = "listBoxSenhas";
            this.listBoxSenhas.Size = new System.Drawing.Size(200, 200);
            this.listBoxSenhas.TabIndex = 6;
            
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Histórico Atendimentos:";
            
            this.listBoxAtendimentos.FormattingEnabled = true;
            this.listBoxAtendimentos.ItemHeight = 15;
            this.listBoxAtendimentos.Location = new System.Drawing.Point(260, 80);
            this.listBoxAtendimentos.Name = "listBoxAtendimentos";
            this.listBoxAtendimentos.Size = new System.Drawing.Size(350, 200);
            this.listBoxAtendimentos.TabIndex = 8;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 310);
            this.Controls.Add(this.listBoxAtendimentos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxSenhas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGuiche);
            this.Controls.Add(this.btnChamar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnGerar);
            this.Name = "Form1";
            this.Text = "Sistema de Atendimento";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnChamar;
        private System.Windows.Forms.ListBox listBoxSenhas;
        private System.Windows.Forms.ListBox listBoxAtendimentos;
        private System.Windows.Forms.TextBox txtGuiche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
