using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class entregas_cte_erroRepository : RepositoryConnection, IEntregas_cte_erroRepository
    {
        private string funcNextVal = "nextval('entregas_cte_erro_id_seq'::regclass)";
        public void GravaRejeicaoSefaz(Entregas_cte_erro objErro)
        {
            throw new NotImplementedException();
        }
    }
}
