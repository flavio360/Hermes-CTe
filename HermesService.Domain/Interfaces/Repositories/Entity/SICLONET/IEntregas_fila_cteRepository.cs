using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntregas_fila_cteRepository : IRepositoryConnection
    {
        List<Entregas_fila_cte> SelectEntregas_Fila_Ctes();
        void DeleteEntregas_Fila_Ctes();
        void UpdateEntregas_Fila_Ctes(Entregas_cte_dados_gerados_detalhe objEntrega);
        void InsertEntregas_Fila_Ctes();
    }
}
