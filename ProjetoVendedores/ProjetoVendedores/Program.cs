using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoVendedores.Models;

namespace ProjetoVendedores
{
    class Program
    {
        static Vendedores gerenciaVendedores = new Vendedores(10); // Regra (*): Máximo 10

        static void Main(string[] args)
        {
            int opcao = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE VENDAS ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    ExecutarOpcao(opcao);
                }

            } while (opcao != 0);
        }

        static void ExecutarOpcao(int op)
        {
            Console.Clear();
            switch (op)
            {
                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                case 1:
                    CadastrarVendedor();
                    break;
                case 2:
                    ConsultarVendedor();
                    break;
                case 3:
                    ExcluirVendedor();
                    break;
                case 4:
                    RegistrarVenda();
                    break;
                case 5:
                    ListarVendedores();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            if (op != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void CadastrarVendedor()
        {
            Console.WriteLine("--- CADASTRAR VENDEDOR ---");
            Console.Write("ID do Vendedor: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Percentual de Comissão (%): ");
            double perc = double.Parse(Console.ReadLine());

            Vendedor novo = new Vendedor(id, nome, perc);

            if (gerenciaVendedores.addVendedor(novo))
                Console.WriteLine("Vendedor cadastrado com sucesso!");
            else
                Console.WriteLine("Erro: Limite de vendedores atingido (Máximo 10).");
        }

        static void ConsultarVendedor()
        {
            Console.WriteLine("--- CONSULTAR VENDEDOR ---");
            Console.Write("Informe o ID do Vendedor: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id, "", 0); // Vendedor "fake" só para passar o ID na busca
            Vendedor encontrado = gerenciaVendedores.searchVendedor(busca);

            if (encontrado != null)
            {
                // Regra (**)
                Console.WriteLine($"\nID: {encontrado.Id}");
                Console.WriteLine($"Nome: {encontrado.Nome}");
                Console.WriteLine($"Total Vendas: {encontrado.valorVendas():C2}");
                Console.WriteLine($"Comissão Devida: {encontrado.valorComissao():C2}");

                Console.WriteLine("\n--- Vendas Diárias ---");
                bool teveVenda = false;
                for (int i = 0; i < encontrado.AsVendas.Length; i++)
                {
                    Venda v = encontrado.AsVendas[i];
                    if (v != null)
                    {
                        Console.WriteLine($"Dia {i + 1}: Valor Médio da Venda = {v.valorMedio():C2}");
                        teveVenda = true;
                    }
                }
                if (!teveVenda) Console.WriteLine("Nenhuma venda registrada para este vendedor.");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado.");
            }
        }

        static void ExcluirVendedor()
        {
            Console.WriteLine("--- EXCLUIR VENDEDOR ---");
            Console.Write("Informe o ID do Vendedor a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id, "", 0);
            Vendedor encontrado = gerenciaVendedores.searchVendedor(busca);

            if (encontrado != null)
            {
                // A validação de vendas > 0 ocorre dentro do método delVendedor no Model
                if (gerenciaVendedores.delVendedor(encontrado))
                    Console.WriteLine("Vendedor excluído com sucesso!");
                else
                    Console.WriteLine("Erro: Não é possível excluir o vendedor. Ele possui vendas registradas.");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado.");
            }
        }

        static void RegistrarVenda()
        {
            Console.WriteLine("--- REGISTRAR VENDA ---");
            Console.Write("Informe o ID do Vendedor: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id, "", 0);
            Vendedor encontrado = gerenciaVendedores.searchVendedor(busca);

            if (encontrado != null)
            {
                Console.Write("Informe o dia (1 a 31): ");
                int dia = int.Parse(Console.ReadLine());

                Console.Write("Quantidade de itens vendidos: ");
                int qtde = int.Parse(Console.ReadLine());

                Console.Write("Valor total da venda: ");
                double valor = double.Parse(Console.ReadLine());

                Venda novaVenda = new Venda(qtde, valor);
                encontrado.registrarVenda(dia, novaVenda);
                Console.WriteLine("Venda registrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado.");
            }
        }

        static void ListarVendedores()
        {
            Console.WriteLine("--- LISTA DE VENDEDORES ---");
            if (gerenciaVendedores.Qtde == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            // Regra (****)
            for (int i = 0; i < gerenciaVendedores.Qtde; i++)
            {
                Vendedor v = gerenciaVendedores.OsVendedores[i];
                Console.WriteLine($"ID: {v.Id} | Nome: {v.Nome} | Total Vendas: {v.valorVendas():C2} | Comissão: {v.valorComissao():C2}");
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"TOTAL DE VENDAS GERAL: {gerenciaVendedores.valorVendas():C2}");
            Console.WriteLine($"TOTAL DE COMISSÃO GERAL: {gerenciaVendedores.valorComissao():C2}");
        }
    }
}
