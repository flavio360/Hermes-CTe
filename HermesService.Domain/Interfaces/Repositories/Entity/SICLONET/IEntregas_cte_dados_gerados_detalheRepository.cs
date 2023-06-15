using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntregas_cte_dados_gerados_detalheRepository : IRepositoryConnection
    {
       List<Entregas_cte_dados_gerados_detalhe> RecuperaDadosProcessoGeraCTe(string cod_empresa);
    }
}
