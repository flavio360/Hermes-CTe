using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_cte_detalhe_remetente : Entregas_cte_filiais_x_remetente
    {
        public string Remetente_cnpj { get; set; }
        public string Remetente_cidade_cod_ibge { get; set; }
        public string Remetente_cpf_cnpj { get; set; }
        public string Remetente_nome { get; set; }
        public string Remetente_complemento { get; set; }
        public string Remetente_fantasia { get; set; }
        public string Remetente_razaosocial { get; set; }
        public string Remetente_telefone { get; set; }
        public string Remetente_uf { get; set; }
        public string Remetente_cod_uf { get; set; }
        public string Remetente_endereco { get; set; }

    }
}
