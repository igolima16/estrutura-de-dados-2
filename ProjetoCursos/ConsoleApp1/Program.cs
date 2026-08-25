using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoCursos.Models
{
    class Program
    {
        static Escola minhaEscola = new Escola();

        static void Main(string[] args)
        {
            int opcao = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTÃO ESCOLAR ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina do curso");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");
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
                case 0: Console.WriteLine("Saindo..."); break;
                case 1: AdicionarCurso(); break;
                case 2: PesquisarCurso(); break;
                case 3: RemoverCurso(); break;
                case 4: AdicionarDisciplina(); break;
                case 5: PesquisarDisciplina(); break;
                case 6: RemoverDisciplina(); break;
                case 7: MatricularAluno(); break;
                case 8: RemoverAluno(); break;
                case 9: PesquisarAluno(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
            if (op != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void AdicionarCurso()
        {
            Console.Write("ID do Curso: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string desc = Console.ReadLine();

            if (minhaEscola.AdicionarCurso(new Curso(id, desc)))
                Console.WriteLine("Curso adicionado com sucesso!");
            else
                Console.WriteLine("Erro: Limite de 5 cursos atingido.");
        }

        static void PesquisarCurso()
        {
            Console.Write("ID do Curso: ");
            int id = int.Parse(Console.ReadLine());
            Curso enc = minhaEscola.PesquisarCurso(new Curso(id, ""));

            if (enc != null)
            {
                Console.WriteLine($"\nCurso: {enc.Descricao}");
                Console.WriteLine("Disciplinas:");
                bool temDisc = false;
                foreach (var d in enc.Disciplinas)
                {
                    if (d != null)
                    {
                        Console.WriteLine($"- [{d.Id}] {d.Descricao}");
                        temDisc = true;
                    }
                }
                if (!temDisc) Console.WriteLine("Nenhuma disciplina cadastrada.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void RemoverCurso()
        {
            Console.Write("ID do Curso para remover: ");
            int id = int.Parse(Console.ReadLine());

            if (minhaEscola.RemoverCurso(new Curso(id, "")))
                Console.WriteLine("Curso removido com sucesso!");
            else
                Console.WriteLine("Erro: Curso não encontrado ou possui disciplinas associadas.");
        }

        static void AdicionarDisciplina()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = minhaEscola.PesquisarCurso(new Curso(idCurso, ""));

            if (curso != null)
            {
                Console.Write("ID da Disciplina: ");
                int idDisc = int.Parse(Console.ReadLine());
                Console.Write("Descrição da Disciplina: ");
                string desc = Console.ReadLine();

                if (curso.AdicionarDisciplina(new Disciplina(idDisc, desc)))
                    Console.WriteLine("Disciplina adicionada com sucesso!");
                else
                    Console.WriteLine("Erro: Limite de 12 disciplinas atingido neste curso.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void PesquisarDisciplina()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = minhaEscola.PesquisarCurso(new Curso(idCurso, ""));

            if (curso != null)
            {
                Console.Write("ID da Disciplina: ");
                int idDisc = int.Parse(Console.ReadLine());
                Disciplina disc = curso.PesquisarDisciplina(new Disciplina(idDisc, ""));

                if (disc != null)
                {
                    Console.WriteLine($"\nDisciplina: {disc.Descricao}");
                    Console.WriteLine("Alunos matriculados:");
                    bool temAluno = false;
                    foreach (var a in disc.Alunos)
                    {
                        if (a != null)
                        {
                            Console.WriteLine($"- [{a.Id}] {a.Nome}");
                            temAluno = true;
                        }
                    }
                    if (!temAluno) Console.WriteLine("Nenhum aluno matriculado.");
                }
                else Console.WriteLine("Disciplina não encontrada.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void RemoverDisciplina()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = minhaEscola.PesquisarCurso(new Curso(idCurso, ""));

            if (curso != null)
            {
                Console.Write("ID da Disciplina: ");
                int idDisc = int.Parse(Console.ReadLine());

                if (curso.RemoverDisciplina(new Disciplina(idDisc, "")))
                    Console.WriteLine("Disciplina removida com sucesso!");
                else
                    Console.WriteLine("Erro: Disciplina não encontrada ou possui alunos matriculados.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void MatricularAluno()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = minhaEscola.PesquisarCurso(new Curso(idCurso, ""));

            if (curso != null)
            {
                Console.Write("ID da Disciplina: ");
                int idDisc = int.Parse(Console.ReadLine());
                Disciplina disc = curso.PesquisarDisciplina(new Disciplina(idDisc, ""));

                if (disc != null)
                {
                    Console.Write("ID do Aluno: ");
                    int idAluno = int.Parse(Console.ReadLine());
                    Console.Write("Nome do Aluno: ");
                    string nome = Console.ReadLine();

                    Aluno aluno = new Aluno(idAluno, nome);

                    if (aluno.PodeMatricular(minhaEscola, curso))
                    {
                        if (disc.MatricularAluno(aluno))
                            Console.WriteLine("Aluno matriculado com sucesso!");
                        else
                            Console.WriteLine("Erro: Disciplina cheia ou aluno já matriculado.");
                    }
                    else
                    {
                        Console.WriteLine("Erro: O aluno já atingiu o limite de 6 disciplinas ou está vinculado a outro curso.");
                    }
                }
                else Console.WriteLine("Disciplina não encontrada.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void RemoverAluno()
        {
            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = minhaEscola.PesquisarCurso(new Curso(idCurso, ""));

            if (curso != null)
            {
                Console.Write("ID da Disciplina: ");
                int idDisc = int.Parse(Console.ReadLine());
                Disciplina disc = curso.PesquisarDisciplina(new Disciplina(idDisc, ""));

                if (disc != null)
                {
                    Console.Write("ID do Aluno: ");
                    int idAluno = int.Parse(Console.ReadLine());

                    if (disc.DesmatricularAluno(new Aluno(idAluno, "")))
                        Console.WriteLine("Aluno desmatriculado com sucesso!");
                    else
                        Console.WriteLine("Erro: Aluno não encontrado nesta disciplina.");
                }
                else Console.WriteLine("Disciplina não encontrada.");
            }
            else Console.WriteLine("Curso não encontrado.");
        }

        static void PesquisarAluno()
        {
            Console.Write("Nome do Aluno para pesquisa (Exata): ");
            string nome = Console.ReadLine();
            bool encontrou = false;

            Console.WriteLine($"\nResultados para o aluno '{nome}':");

            foreach (var c in minhaEscola.Cursos)
            {
                if (c == null) continue;
                foreach (var d in c.Disciplinas)
                {
                    if (d == null) continue;
                    foreach (var a in d.Alunos)
                    {
                        if (a != null && a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"- Curso: {c.Descricao} | Disciplina: {d.Descricao}");
                            encontrou = true;
                        }
                    }
                }
            }

            if (!encontrou) Console.WriteLine("Aluno não encontrado em nenhuma disciplina.");
        }
    }
}
