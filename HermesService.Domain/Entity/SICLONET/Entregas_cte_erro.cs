using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_cte_erro
    {
        public int? Id { get; set; }
        public string Cod_entrega { get; set; }
        public string Cod_cte_id { get; set; }
        public string Observacao_erro { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime? Data_correcao { get; set; }
        public string Usuario_correcao { get; set; }
    }
}
