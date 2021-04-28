using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TipoDeHabilidade
    {
        public TipoDeHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHab { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
