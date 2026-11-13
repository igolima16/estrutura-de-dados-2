using System.Collections.Generic;

namespace ControleDeAcesso
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Queue<Log> Logs { get; set; } = new Queue<Log>();

        public Ambiente() { }

        public Ambiente(int id, string nome = "")
        {
            Id = id;
            Nome = nome;
            Logs = new Queue<Log>();
        }

        public void RegistrarLog(Log log)
        {
            if (Logs.Count >= 100)
            {
                Logs.Dequeue();
            }
            Logs.Enqueue(log);
        }

        public override bool Equals(object obj)
        {
            return obj is Ambiente outro && this.Id == outro.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"ID: {Id} | Ambiente: {Nome} | Total de Logs: {Logs.Count}";
    }
}