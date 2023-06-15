using Dapper;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Entregas_codigos_cidades_ibgeRepository : RepositoryConnection, IEntregas_codigos_cidades_ibgeRepository
    {
        public string ObeterCodigoIBGE(string cidade, string uf)
        {
            string query = string.Format("select cidade_cod_ibge from entregas_codigos_cidades_ibge where uf = '{0}' and cidade = '{1}';", uf, cidade);


                var codIBGE = SqlMapper.QueryFirstOrDefault<string>(Connection, query);

                return codIBGE;

        }
    }
}
