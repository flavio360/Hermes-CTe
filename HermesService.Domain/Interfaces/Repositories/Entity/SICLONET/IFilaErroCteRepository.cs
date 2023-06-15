using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IFilaErroCteRepository : IRepositoryConnection
    {   
        void GravaFilaErroCte(List<Entregas_cte_erro> entregas_Cte_Erros);
        void GravaErroCte(string cod_entrega, string observacao_erro, string cod_cte_id = null);

        void F_processa_erro_cte(string data_processado, string cod_entrega, string status_cte);
    }
}
