using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class  Entrega_cte_conifg_filiais_emissorasRepository : RepositoryConnection, IEntrega_cte_conifg_filiais_emissorasRepository
    {
        public Entrega_cte_conifg_filiais_emissoras ConsultaEmissoraAtiva(string cod_empresa)
        {
            string query = "SELECT " +
                                "A.id,A.cod_empresa,A.data_cadastro,A.ativo " +
                            "FROM " +
                                "entrega_cte_conifg_filiais_emissoras A " +
                            "INNER JOIN " +
                                "empresas B ON A.cod_empresa = B.codempresa " +
                            "WHERE " +
                                "A.ativo = TRUE AND " +
                                "A.cod_empresa = {0} ";

            query = string.Format(query, cod_empresa);



                if (cod_empresa == null)
                    throw new ArgumentNullException("ConsultaEmissoraAtiva");



                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);


 
                var ret = SqlMapper.QueryFirstOrDefault<Entrega_cte_conifg_filiais_emissoras>(Connection, query);

                return ret;
        }
    }
}
