using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface ICte_endereco_web_serviceRepository : IRepositoryConnection
    {
        List<cte_endereco_web_service> ConsultaDadosWSSefaz();
    }
}
