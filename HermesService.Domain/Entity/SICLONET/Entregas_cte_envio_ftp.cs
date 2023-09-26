using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_cte_envio_ftp
    {
        public string sCNPJ_cliente { get; set; }
        public string sCod_cliente { get; set; }
        public string sCte_chave { get; set; }
        public string sId_cliente { get; set; }
        public string sData_insert { get; set; }
        public string sData_envio { get; set; }
        public string sCte_xml { get; set; }
        public string sCod_entrega { get; set; }
    }
}
