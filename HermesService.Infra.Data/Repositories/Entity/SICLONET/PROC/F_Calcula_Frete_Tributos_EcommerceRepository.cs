using Dapper;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET.PROC
{
    public class F_Calcula_Frete_Tributos_EcommerceRepository : RepositoryConnection, IF_Calcula_Frete_Tributos_EcommerceRepository
    {
        public F_Calcula_Frete_Tributos_Ecommerce CalculaExpressa(string codentregacli, string estado_origem, string estado_destino, string cod_ibge_destino, string cod_ibge_origem)
        {
            
            string proc = string.Format("select msg,valor_frete,valor_icms,taxa_icms,taxa_gris,valor_gris,valor_advalor,taxa_advalorem,preco_normal,erro,calcula_gris,valor_despacho  from f_calcula_frete_tributos_ecommerce ('{0}','{1}','{2}','{3}','{4}')",
                                            codentregacli, estado_origem, estado_destino, cod_ibge_destino, cod_ibge_origem);

            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

            var ret = SqlMapper.QueryFirst<F_Calcula_Frete_Tributos_Ecommerce>(Connection, proc);
            
            return ret;
        }
    }
}
