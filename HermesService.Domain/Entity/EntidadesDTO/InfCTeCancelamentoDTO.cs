using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.EntidadesDTO
{
    public class InfCTeCancelamentoDTO
    {
        public string sCNPJEmitente { get; set; }
        public string sChaveCTe { get; set; }
        public string sJustificativa { get; set; }
        public string sNPrtolocoloAutorizacao { get; set; }
        public string sdescEvento { get; set; }
        public string sTPevento { get; set; }
        public string sNumeroSequenciaEvento { get; set; }
        public string sTpAmbiente { get; set; }
        public string sCOrgaoOrigem { get; set; }

        public InfCTeCancelamentoDTO()
        {
            sTPevento = "110111";
        }
    }
}
