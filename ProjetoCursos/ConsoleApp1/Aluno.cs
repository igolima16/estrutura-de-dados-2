using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public bool PodeMatricular(Escola escola, Curso cursoDesejado)
        {
            int totalDisciplinas = 0;

            foreach (var curso in escola.Cursos)
            {
                if (curso == null) continue;

                bool matriculadoNesteCurso = false;

                foreach (var disc in curso.Disciplinas)
                {
                    if (disc == null) continue;

                    foreach (var a in disc.Alunos)
                    {
                        if (a != null && a.Id == this.Id)
                        {
                            matriculadoNesteCurso = true;
                            totalDisciplinas++;
                        }
                    }
                }

                // Se encontrou o aluno em um curso diferente do que ele está tentando se matricular
                if (matriculadoNesteCurso && curso.Id != cursoDesejado.Id)
                {
                    return false;
                }
            }

            // O aluno só pode se matricular se tiver menos de 6 disciplinas no total
            return totalDisciplinas < 6;
        }
    }
}
