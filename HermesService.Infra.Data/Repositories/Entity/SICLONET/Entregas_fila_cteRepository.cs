using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Entregas_fila_cteRepository : RepositoryConnection, IEntregas_fila_cteRepository
    {
        string query = string.Empty;
        public void DeleteEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public void InsertEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public List<Entregas_fila_cte> SelectEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntregas_Fila_Ctes( Entregas_cte_dados_gerados_detalhe objEntrega, dynamic retSefaz)
        {
            query = "update entregas_fila_cte set cte_status = {0} where cod_entrega = {1}";

            query = string.Format(query, objEntrega.Cte_status = "'2'", "'" + objEntrega.Cod_entrega +"'");

            SqlMapper.Query<Entregas>(Connection, query); 
        }
    }
}
