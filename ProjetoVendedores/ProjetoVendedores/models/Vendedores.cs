using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendedores.Models
{
    public class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max = 10)
        {
            this.max = max;
            this.osVendedores = new Vendedor[this.max];
            this.qtde = 0;
        }

        public int Qtde { get => qtde; }
        public Vendedor[] OsVendedores { get => osVendedores; }

        public bool addVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                osVendedores[qtde] = v;
                qtde++;
                return true;
            }
            return false;
        }

        public bool delVendedor(Vendedor v)
        {
            int index = -1;
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == v.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                // Regra (***): O vendedor só pode ser excluído se não tiver vendas
                if (osVendedores[index].valorVendas() > 0)
                {
                    return false;
                }

                // Desloca o array para tapar o "buraco" do vendedor removido
                for (int i = index; i < qtde - 1; i++)
                {
                    osVendedores[i] = osVendedores[i + 1];
                }
                osVendedores[qtde - 1] = null; // Limpa a última posição
                qtde--;
                return true;
            }
            return false;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == v.Id)
                {
                    return osVendedores[i];
                }
            }
            return null;
        }

        public double valorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorVendas();
            }
            return total;
        }

        public double valorComissao()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorComissao();
            }
            return total;
        }
    }
}