using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Empresas : Entregas_codigos_cidades_ibge
    {
        public string Codempresa_Emit { get; set; }
        public int Codgrupempresa_Emit { get; set; }
        public string Cnpj_Emit { get; set; }
        public string Razao_social_Emit { get; set; }
        public string Endereco_Emit { get; set; }
        public string Numero_Emit { get; set; }
        public string Complemento_Emit { get; set; }
        public string Bairro_Emit { get; set; }
        public string Cidade_Emit { get; set; }
        public string Codmun_Emit { get; set; }
        public string Estado_Emit { get; set; }
        public string Insc_est_Emit { get; set; }
        public string Insc_mun_Emit { get; set; }
        public string Cd_nome_Emit { get; set; }
        public string Cep_Emit { get; set; }
        public string Telefone_e_ddd_Emit { get; set; }
    }
}
