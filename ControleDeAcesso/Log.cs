using System;

namespace ControleDeAcesso
{
    public class Log
    {
        public DateTime DtAcesso { get; set; }
        public Usuario Usuario { get; set; }
        public bool TipoAcesso { get; set; } // true = Autorizado, false = Negado

        public Log() { }

        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            DtAcesso = dtAcesso;
            Usuario = usuario;
            TipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string status = TipoAcesso ? "AUTORIZADO" : "NEGADO";
            string nomeUsr = Usuario != null ? $"{Usuario.Id} - {Usuario.Nome}" : "Desconhecido";
            return $"[{DtAcesso:dd/MM/yyyy HH:mm:ss}] Usuário: {nomeUsr} | Status: {status}";
        }
    }
}