using Dapper;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET.PROC
{
    public class F_Roteirizador_EntregasRepository : RepositoryConnection, IF_Roteirizador_EntregasRepository
    {
        public F_roteirizador_entregas RoteirizaEntrega(string codEntregaCli, string cep, string codCliente,  string codproduto,  string estado, string codusuario=null, string codbase= null,string codservico= "''")
        {
            string proc = string.Format(@"SELECT d_codbase, d_base,d_nome_curto FROM  f_roteirizador_entregas ({0},{1},{2},{3},{4},{5},{6},{7})",
               "'"+ codEntregaCli + "'", "'" + cep + "'", codCliente, "null", "null", "'" + estado + "'", codusuario, "null") ;

            SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

            var ret = SqlMapper.QueryFirst<F_roteirizador_entregas>(Connection, proc);

            return ret;
        }





    }
}
