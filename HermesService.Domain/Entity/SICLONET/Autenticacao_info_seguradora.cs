using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.SICLONET
{
    public class Autenticacao_info_seguradora
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Codigo { get; set; }
        public string Ws_Endereco { get; set; }
        public string Observacao { get; set; }
        public string Ativo { get; set; }
    }
}
