using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public int IdHab { get; set; }
        public string Habilidade1 { get; set; }
        public int? IdTipoHab { get; set; }

        public virtual TipoDeHabilidade IdTipoHabNavigation { get; set; }
    }
}
