using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public string CapVida { get; set; }
        public string CapMana { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }
        public int? IdClasse { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
