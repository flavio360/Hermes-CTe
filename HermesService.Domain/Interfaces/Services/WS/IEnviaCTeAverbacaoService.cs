using HermesService.Domain.Entity.Averbacao;
using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services.WS
{
    public interface IEnviaCTeAverbacaoService
    {
        CTeAverbacao RequestAverbacao(string token, string Cte_xml ,string URLWS, string codCliente, string codEntrega, Autenticacao_info_seguradora dadosToken);
    }
}
