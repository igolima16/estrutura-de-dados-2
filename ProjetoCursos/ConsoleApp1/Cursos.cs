using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Disciplina[] Disciplinas { get; private set; }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Disciplinas = new Disciplina[12];
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] == null)
                {
                    Disciplinas[i] = disciplina;
                    return true;
                }
            }
            return false; // Máximo de disciplinas atingido
        }

        public Disciplina PesquisarDisciplina(Disciplina disciplina)
        {
            foreach (var d in Disciplinas)
            {
                if (d != null && d.Id == disciplina.Id)
                    return d;
            }
            return null;
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
                {
                    // Regra: não pode remover se tiver alunos
                    foreach (var aluno in Disciplinas[i].Alunos)
                    {
                        if (aluno != null) return false;
                    }

                    Disciplinas[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
