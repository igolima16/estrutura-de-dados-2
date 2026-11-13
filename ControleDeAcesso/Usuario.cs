using System.Collections.Generic;

namespace ControleDeAcesso
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Ambiente> Ambientes { get; set; } = new List<Ambiente>();

        public Usuario() { }

        public Usuario(int id, string nome = "")
        {
            Id = id;
            Nome = nome;
            Ambientes = new List<Ambiente>();
        }

        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (ambiente == null || Ambientes.Contains(ambiente))
                return false;

            Ambientes.Add(ambiente);
            return true;
        }

        public bool RevogarPermissao(Ambiente ambiente)
        {
            if (ambiente == null)
                return false;

            return Ambientes.Remove(ambiente);
        }

        public override bool Equals(object obj)
        {
            return obj is Usuario outro && this.Id == outro.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"ID: {Id} | Usuário: {Nome} | Permissões ativas: {Ambientes.Count}";
    }
}