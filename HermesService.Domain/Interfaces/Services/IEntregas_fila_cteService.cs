using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IEntregas_fila_cteService
    {
        List<Entregas_fila_cte> SelectEntregas_Fila_Ctes();
        void DeleteEntregas_Fila_Ctes();
        void UpdateEntregas_Fila_Ctes(Entregas_cte_dados_gerados_detalhe objEntrega, dynamic retSefaz);
        void InsertEntregas_Fila_Ctes();
    }
}
