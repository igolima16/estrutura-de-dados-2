using System.Collections.Generic;

namespace SistemaAtendimento.Models
{
    public class Guiche
    {
        private int id;
        private Queue<Senha> atendimentos;

        public int Id { get { return id; } }
        public Queue<Senha> Atendimentos { get { return atendimentos; } }

        public Guiche()
        {
            this.id = 0;
            this.atendimentos = new Queue<Senha>();
        }

        public Guiche(int id)
        {
            this.id = id;
            this.atendimentos = new Queue<Senha>();
        }

        public bool Chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count > 0)
            {
                Senha senhaAtual = filaSenhas.Dequeue();
                senhaAtual.Atender();
                atendimentos.Enqueue(senhaAtual);
                return true;
            }
            return false;
        }
    }
}
