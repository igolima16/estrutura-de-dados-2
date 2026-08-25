using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Models
{
    public class Escola
    {
        public Curso[] Cursos { get; private set; }

        public Escola()
        {
            Cursos = new Curso[5];
        }

        public bool AdicionarCurso(Curso curso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] == null)
                {
                    Cursos[i] = curso;
                    return true;
                }
            }
            return false; // Máximo de cursos atingido
        }

        public Curso PesquisarCurso(Curso curso)
        {
            foreach (var c in Cursos)
            {
                if (c != null && c.Id == curso.Id)
                    return c;
            }
            return null;
        }

        public bool RemoverCurso(Curso curso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == curso.Id)
                {
                    // Regra: não pode remover se tiver disciplinas associadas
                    foreach (var disc in Cursos[i].Disciplinas)
                    {
                        if (disc != null) return false;
                    }

                    Cursos[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
