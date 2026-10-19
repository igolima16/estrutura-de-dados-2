using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAtendimento.Models;

namespace SistemaAtendimento
{
    public partial class Form1 : Form
    {
        private Senhas senhas;
        private Guiches guiches;

        public Form1()
        {
            InitializeComponent();
            senhas = new Senhas();
            guiches = new Guiches();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            senhas.Gerar();
            AtualizarListaSenhas();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int novoId = guiches.ListaGuiches.Count + 1;
            guiches.Adicionar(new Guiche(novoId));
            MessageBox.Show($"Guichê {novoId} adicionado com sucesso!", "Guichê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuiche.Text, out int idGuiche))
            {
                Guiche guicheSelecionado = guiches.ListaGuiches.FirstOrDefault(g => g.Id == idGuiche);

                if (guicheSelecionado != null)
                {
                    bool sucesso = guicheSelecionado.Chamar(senhas.FilaSenhas);

                    if (sucesso)
                    {
                        AtualizarListaSenhas();
                        AtualizarListaAtendimentos(guicheSelecionado);
                    }
                    else
                    {
                        MessageBox.Show("Não há senhas na fila de espera.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Guichê não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe um número de guichê válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarListaSenhas()
        {
            listBoxSenhas.Items.Clear();
            foreach (Senha s in senhas.FilaSenhas)
            {
                listBoxSenhas.Items.Add(s.DadosParciais());
            }
        }

        private void AtualizarListaAtendimentos(Guiche guiche)
        {
            listBoxAtendimentos.Items.Clear();
            foreach (Senha s in guiche.Atendimentos)
            {
                listBoxAtendimentos.Items.Add(s.DadosCompletos());
            }
        }
    }
}
