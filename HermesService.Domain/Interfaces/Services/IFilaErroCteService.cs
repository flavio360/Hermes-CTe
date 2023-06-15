using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IFilaErroCteService
    {
        void GravaFilaErroCte(List<Entregas_cte_erro> entregas_Cte_Erros);
        void GravaErroCte(string cod_entrega,string observacao_erro, string cod_cte_id =null);
        void F_processa_erro_cte(string data_processado, string cod_entrega, string status_cte );
    }
}
