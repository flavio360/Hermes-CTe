using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_codigos_cidades_ibge : Entregas_cte_detalhe_expedidor
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Cidade_cod_ibge { get; set; }
        public string Uf { get; set; }        

    }
}
