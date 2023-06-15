using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC
{
    public interface IF_Calcula_Frete_Tributos_EcommerceRepository : IRepositoryConnection
    {
        F_Calcula_Frete_Tributos_Ecommerce CalculaExpressa(string codentregacli, string estado_origem, string estado_destino, string cod_ibge_destino, string cod_ibge_origem);
    }
}
