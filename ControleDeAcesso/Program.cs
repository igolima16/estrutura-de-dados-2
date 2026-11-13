using System;
using System.Linq;

namespace ControleDeAcesso
{
    class Program
    {
        static Cadastro cadastro = new Cadastro();

        static void Main(string[] args)
        {
            cadastro.Download();

            int opcao = -1;
            do
            {
                Console.WriteLine("\n=== CONTROLE DE ACESSOS ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuário");
                Console.WriteLine("5. Consultar usuário");
                Console.WriteLine("6. Excluir usuário");
                Console.WriteLine("7. Conceder permissão de acesso ao usuário");
                Console.WriteLine("8. Revogar permissão de acesso ao usuário");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs de acesso");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                Console.WriteLine();
                switch (opcao)
                {
                    case 0:
                        cadastro.Upload();
                        Console.WriteLine("Dados salvos em 'dados.json'. Encerrando...");
                        break;
                    case 1: CadastrarAmbiente(); break;
                    case 2: ConsultarAmbiente(); break;
                    case 3: ExcluirAmbiente(); break;
                    case 4: CadastrarUsuario(); break;
                    case 5: ConsultarUsuario(); break;
                    case 6: ExcluirUsuario(); break;
                    case 7: GerenciarPermissao(true); break;
                    case 8: GerenciarPermissao(false); break;
                    case 9: RegistrarAcesso(); break;
                    case 10: ConsultarLogs(); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

            } while (opcao != 0);
        }

        static void CadastrarAmbiente()
        {
            Console.Write("ID do Ambiente: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (cadastro.PesquisarAmbiente(new Ambiente(id)) != null)
            {
                Console.WriteLine("Erro: Já existe um ambiente com esse ID.");
                return;
            }
            Console.Write("Nome do Ambiente: ");
            string nome = Console.ReadLine();
            cadastro.AdicionarAmbiente(new Ambiente(id, nome));
            Console.WriteLine("Ambiente cadastrado com sucesso!");
        }

        static void ConsultarAmbiente()
        {
            Console.Write("ID do Ambiente: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Ambiente amb = cadastro.PesquisarAmbiente(new Ambiente(id));
            Console.WriteLine(amb != null ? amb.ToString() : "Ambiente não encontrado.");
        }

        static void ExcluirAmbiente()
        {
            Console.Write("ID do Ambiente a excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            bool sucesso = cadastro.RemoverAmbiente(new Ambiente(id));
            Console.WriteLine(sucesso ? "Ambiente removido com sucesso!" : "Falha: Ambiente não encontrado.");
        }

        static void CadastrarUsuario()
        {
            Console.Write("ID do Usuário: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (cadastro.PesquisarUsuario(new Usuario(id)) != null)
            {
                Console.WriteLine("Erro: Já existe um usuário com esse ID.");
                return;
            }
            Console.Write("Nome do Usuário: ");
            string nome = Console.ReadLine();
            cadastro.AdicionarUsuario(new Usuario(id, nome));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        static void ConsultarUsuario()
        {
            Console.Write("ID do Usuário: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Usuario usr = cadastro.PesquisarUsuario(new Usuario(id));
            if (usr != null)
            {
                Console.WriteLine(usr);
                if (usr.Ambientes.Count > 0)
                {
                    Console.WriteLine("Ambientes permitidos:");
                    foreach (var a in usr.Ambientes)
                        Console.WriteLine($"  - [{a.Id}] {a.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        static void ExcluirUsuario()
        {
            Console.Write("ID do Usuário a excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            bool sucesso = cadastro.RemoverUsuario(new Usuario(id));
            Console.WriteLine(sucesso
                ? "Usuário removido com sucesso!"
                : "Falha ao remover: Usuário não encontrado ou ainda possui permissões ativas.");
        }

        static void GerenciarPermissao(bool conceder)
        {
            Console.Write("ID do Ambiente: ");
            if (!int.TryParse(Console.ReadLine(), out int idAmb)) return;
            Ambiente amb = cadastro.PesquisarAmbiente(new Ambiente(idAmb));

            Console.Write("ID do Usuário: ");
            if (!int.TryParse(Console.ReadLine(), out int idUsr)) return;
            Usuario usr = cadastro.PesquisarUsuario(new Usuario(idUsr));

            if (amb == null || usr == null)
            {
                Console.WriteLine("Erro: Ambiente ou Usuário não encontrado.");
                return;
            }

            if (conceder)
            {
                bool ok = usr.ConcederPermissao(amb);
                Console.WriteLine(ok ? "Permissão concedida com sucesso!" : "Usuário já possui permissão para este ambiente.");
            }
            else
            {
                bool ok = usr.RevogarPermissao(amb);
                Console.WriteLine(ok ? "Permissão revogada com sucesso!" : "Usuário não possuía permissão para este ambiente.");
            }
        }

        static void RegistrarAcesso()
        {
            Console.Write("ID do Ambiente: ");
            if (!int.TryParse(Console.ReadLine(), out int idAmb)) return;
            Ambiente amb = cadastro.PesquisarAmbiente(new Ambiente(idAmb));

            Console.Write("ID do Usuário: ");
            if (!int.TryParse(Console.ReadLine(), out int idUsr)) return;
            Usuario usr = cadastro.PesquisarUsuario(new Usuario(idUsr));

            if (amb == null || usr == null)
            {
                Console.WriteLine("Erro: Ambiente ou Usuário não encontrado.");
                return;
            }

            bool autorizado = usr.Ambientes.Contains(amb);
            amb.RegistrarLog(new Log(DateTime.Now, usr, autorizado));

            Console.WriteLine(autorizado ? "Acesso AUTORIZADO (Log registrado)." : "Acesso NEGADO (Tentativa registrada no log).");
        }

        static void ConsultarLogs()
        {
            Console.Write("ID do Ambiente: ");
            if (!int.TryParse(Console.ReadLine(), out int idAmb)) return;
            Ambiente amb = cadastro.PesquisarAmbiente(new Ambiente(idAmb));

            if (amb == null)
            {
                Console.WriteLine("Ambiente não encontrado.");
                return;
            }

            Console.WriteLine("Filtrar por: [1] Autorizados | [2] Negados | [3] Todos");
            Console.Write("Opção de filtro: ");
            if (!int.TryParse(Console.ReadLine(), out int filtro)) filtro = 3;

            var logsFiltrados = amb.Logs.Where(l =>
                filtro == 1 ? l.TipoAcesso == true :
                filtro == 2 ? l.TipoAcesso == false : true
            ).ToList();

            if (logsFiltrados.Count == 0)
            {
                Console.WriteLine("Nenhum log encontrado para o filtro selecionado.");
                return;
            }

            Console.WriteLine($"\n--- Logs do Ambiente: {amb.Nome} ---");
            foreach (var log in logsFiltrados)
            {
                Console.WriteLine(log);
            }
        }
    }
}