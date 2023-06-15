using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class cte_endereco_web_service : Dados_certificado_A1
    {
        public string id { get; set; }
        public string desc_servico { get; set; }
        public string url { get; set; }
        public string uf { get; set; }
        public string ambiente { get; set; }
        public string id_certificado { get; set; }
    }
}
