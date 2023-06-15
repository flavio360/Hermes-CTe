using HermesService.Domain.Interfaces.Repositories.Entity.SEFAZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_cte_transmitido : ResponseSefaz
    {
        public string id { get; set; }
        public string cte_numero { get; set; }
        public string cte_status { get; set; }
        public string cod_entrega { get; set; }
        public string cte_hambiente_emissao { get; set; }
        public string cte_data_transmissao { get; set; }
        public string uf_sefaz { get; set; }
        public string cte_verAplic { get; set; }
        public string cte_recibo_sefaz { get; set; }
        public string cte_protocolo_sefaz { get; set; }
        public string cte_data_registro_ret_sefaz { get; set; }
        public string id_dados_gerados_detalhe { get; set; }
    }
}
