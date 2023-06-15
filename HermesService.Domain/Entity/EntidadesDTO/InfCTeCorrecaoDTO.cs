using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.EntidadesDTO
{
    public class InfCTeCorrecaoDTO : InfCTeCancelamentoDTO
    {
        public string XCondUso { get; set; }
        public string Status_cte_sefaz { get; set; }
    }
}
