using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Cte_endereco_web_serviceRepository : RepositoryConnection, ICte_endereco_web_serviceRepository
    {
        public List<cte_endereco_web_service> ConsultaDadosWSSefaz()
        {
            string query =
                        "select "+                        
                            "cte_ws.id, "+
                            "cte_ws.desc_servico, " +
                            "cte_ws.url, " +
                            "cte_ws.uf, " +
                            "cte_ws.ambiente, " +
                            "a1.numero_serie " +
                        "from " +
                            "cte_endereco_web_service cte_ws  " +
                        "inner join " +
                            "dados_certificado_A1 a1 on cte_ws.id_certificado = a1.id ";

            try
            {
                var objWS = SqlMapper.Query<cte_endereco_web_service>(Connection, query).AsList<cte_endereco_web_service>();

                return objWS;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetType().FullName.ToString() + " , classe \"ConsultaDadosWSSefaz\", msg:" + ex.Message);
            }
        }
    }
}
