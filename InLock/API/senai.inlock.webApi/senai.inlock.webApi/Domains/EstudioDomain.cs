using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "O estudio deve ser informado!")]
        public string nomeEstudio { get; set; }
    }
}
