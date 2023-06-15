using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    
    public partial class Entregas_cte_filiais_x_remetente : Empresas
    {
        public int Id_remet { get;  set; }
        public string Cod_empresa { get; set; }
        public string Cnpj_origem_coleta { get; set; }
        public string CepOrigemColeta { get; set; }
        public string EnderecoOrigemColeta { get; set; }
        public string BairroOrigemColeta { get; set; }
        public string CidadeOrigemColeta { get; set; }
        public int Cod_cliente { get; set; }
        public string IE_OrigemColeta { get; set; }
        public string UfOrigemColeta { get; set; }
        public string Cidade_cod_ibgeOrigemColeta { get; set; }
        public int Id_clientes_area_ftp { get; set; }
        public string Data_cadastro_ { get; set; }
        public bool Ativo { get; set; }
        public string CNPJ_Emissor { get; set; }
        public string NomeCLiente { get; set; }
    }
}
