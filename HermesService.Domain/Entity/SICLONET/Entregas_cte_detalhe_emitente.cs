using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_cte_detalhe_emitente : Entregas_cte_detalhe_remetente
    {
        public string Emitente_cnpj { get; set; }
        public string Emitente_cidade_cod_ibge { get; set; }
        public string Emitente_nome  { get; set; }
        public string Emitente_complemento { get; set; }
        public string Emitente_fantasia { get; set; }
        public string Emitente_razaosocial { get; set; }
        public string Emitente_uf { get; set; }
        public string Emitente_telefone { get; set; }
        public string Emitente_Rntrc { get; set; }
}
}
