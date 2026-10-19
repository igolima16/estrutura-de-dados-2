using System;

namespace SistemaAtendimento.Models
{
    public class Senha
    {
        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime dataAtend;
        private DateTime horaAtend;

        public Senha(int id)
        {
            this.id = id;
            this.dataGerac = DateTime.Now.Date;
            this.horaGerac = DateTime.Now;
        }

        public void Atender()
        {
            this.dataAtend = DateTime.Now.Date;
            this.horaAtend = DateTime.Now;
        }

        public string DadosParciais()
        {
            return $"{id:000} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss}";
        }

        public string DadosCompletos()
        {
            return $"{id:000} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss} - {dataAtend:dd/MM/yyyy} - {horaAtend:HH:mm:ss}";
        }
    }
}
