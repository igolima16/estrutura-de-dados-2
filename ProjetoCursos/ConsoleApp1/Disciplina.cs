using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Aluno[] Alunos { get; private set; }

        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Alunos = new Aluno[15];
        }

        public bool MatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < Alunos.Length; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
                    return false; // Já matriculado

                if (Alunos[i] == null)
                {
                    Alunos[i] = aluno;
                    return true;
                }
            }
            return false; // Turma cheia
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < Alunos.Length; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
                {
                    Alunos[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
