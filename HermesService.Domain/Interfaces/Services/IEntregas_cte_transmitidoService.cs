using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IEntregas_cte_transmitidoService
    {
        void TreatRecordResponseRecepcao(string xmlResponse, Entregas_cte_dados_gerados_detalhe dadosPedido);
        void TreatRecordResponseRetRecepcao(Entregas_cte_transmitido xmlResponse);
        IEnumerable<Entregas_cte_transmitido> SelectEntregas_cte_transmitido();

    }
}
