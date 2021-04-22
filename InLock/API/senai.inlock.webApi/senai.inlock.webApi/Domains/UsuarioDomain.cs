using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo de senha precisa dde no maximo 20 caracteres!")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }


    }
}
