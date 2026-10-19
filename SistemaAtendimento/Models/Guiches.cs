using System.Collections.Generic;

namespace SistemaAtendimento.Models
{
    public class Guiches
    {
        private List<Guiche> listaGuiches;

        public List<Guiche> ListaGuiches { get { return listaGuiches; } }

        public Guiches()
        {
            listaGuiches = new List<Guiche>();
        }

        public void Adicionar(Guiche guiche)
        {
            listaGuiches.Add(guiche);
        }
    }
}
