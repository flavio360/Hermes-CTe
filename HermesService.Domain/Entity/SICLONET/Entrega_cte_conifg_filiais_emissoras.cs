using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entrega_cte_conifg_filiais_emissoras
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string data_cadastro { get; set; }

        [Required]
        [StringLength(50)]
        public string cod_empresa { get; set; }

        [Required]        
        public bool ativo { get; set; }
    }
}
