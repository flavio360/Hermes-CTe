using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntregas_cte_transmitidoRepository :   IRepositoryConnection
    {
        void RecordResponse(dynamic xmlResponse);
        void UpdateCte(dynamic xmlResponse);
        IEnumerable<Entregas_cte_transmitido> SelectEntregas_cte_transmitido();
        Entregas_cte_transmitido SelectEntregas_cte_transmitido(string cod_entrega);


    }
}
