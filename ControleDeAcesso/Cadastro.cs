using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ControleDeAcesso
{
    public class Cadastro
    {
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Ambiente> Ambientes { get; set; } = new List<Ambiente>();

        private const string ArquivoDados = "dados.json";

        public void AdicionarUsuario(Usuario usuario)
        {
            if (PesquisarUsuario(usuario) == null)
                Usuarios.Add(usuario);
        }

        public bool RemoverUsuario(Usuario usuario)
        {
            Usuario u = PesquisarUsuario(usuario);
            if (u != null && u.Ambientes.Count == 0)
                return Usuarios.Remove(u);
            return false;
        }

        public Usuario PesquisarUsuario(Usuario usuario)
        {
            return Usuarios.FirstOrDefault(u => u.Equals(usuario));
        }

        public void AdicionarAmbiente(Ambiente ambiente)
        {
            if (PesquisarAmbiente(ambiente) == null)
                Ambientes.Add(ambiente);
        }

        public bool RemoverAmbiente(Ambiente ambiente)
        {
            Ambiente a = PesquisarAmbiente(ambiente);
            if (a != null)
            {
                foreach (var u in Usuarios)
                    u.RevogarPermissao(a);
                return Ambientes.Remove(a);
            }
            return false;
        }

        public Ambiente PesquisarAmbiente(Ambiente ambiente)
        {
            return Ambientes.FirstOrDefault(a => a.Equals(ambiente));
        }

        public void Upload()
        {
            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                };
                string json = JsonSerializer.Serialize(this, opcoes);
                File.WriteAllText(ArquivoDados, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar dados: {ex.Message}");
            }
        }

        public void Download()
        {
            if (!File.Exists(ArquivoDados)) return;

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };
                string json = File.ReadAllText(ArquivoDados);
                var dados = JsonSerializer.Deserialize<Cadastro>(json, opcoes);

                if (dados != null)
                {
                    this.Usuarios = dados.Usuarios ?? new List<Usuario>();
                    this.Ambientes = dados.Ambientes ?? new List<Ambiente>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
            }
        }
    }
}