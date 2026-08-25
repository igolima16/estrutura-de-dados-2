using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendedores.Models
{
    public class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        public Venda[] AsVendas { get => asVendas; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31]; // Posições de 0 a 30 (dias 1 a 31)
        }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31)
            {
                asVendas[dia - 1] = venda;
            }
        }

        public double valorVendas()
        {
            double total = 0;
            foreach (var venda in asVendas)
            {
                if (venda != null)
                {
                    total += venda.Valor;
                }
            }
            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100.0);
        }
    }
}