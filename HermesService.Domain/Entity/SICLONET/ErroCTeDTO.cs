using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HermesService.Application.EntidadesDTO
{
    public class ErroCTeDTO
    {
        public bool Erro { get; set; }
        public DateTime DataErro { get; set; }

        [StringLength(maximumLength:300)]
        public string DescricaoErro  { get; set; }

        [StringLength(maximumLength: 300)]
        public string Observacao { get; set; }
    }
}
