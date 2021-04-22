using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "A descrição precisa ser atribuida")]
        public string descricao { get; set; }

        // [Required(ErrorMessage = "Informe a data de lançamento do jogo")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }
        public int valor { get; set; }
        public int idEstudio { get; set; }
    }
}
