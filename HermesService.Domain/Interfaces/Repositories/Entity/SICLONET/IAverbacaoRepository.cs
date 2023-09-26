using HermesService.Domain.Entity.Averbacao;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IAverbacaoRepository : IRepositoryConnection
    {
        CTeAverbacao SelectAverbacao(string cod_entrega=null, string numero_averbacao=null, string cod_cliente = null, string protocolo = null);
        string UpdateAverbacao(CTeAverbacao dadosAverbacao);
        string InsertAverbacao(CTeAverbacao dadosAverbacao);
        string DeleteAverbacao(string cod_entrega = null, string numero_averbacao = null, string cod_cliente = null, string protocolo = null);
    }
}
