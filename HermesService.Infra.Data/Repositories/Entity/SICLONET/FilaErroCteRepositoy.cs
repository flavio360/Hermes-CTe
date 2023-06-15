using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class FilaErroCteRepositoy : RepositoryConnection, IFilaErroCteRepository
    {
        private string funcNextVal = "nextval('entregas_cte_erro_id_seq'::regclass)";

        public void GravaFilaErroCte(List<Entregas_cte_erro> entregas_Cte_Erros)
        {
            #region Query
            string query = "INSERT INTO " +
                                  "entregas_cte_erro( cod_entrega, cod_cte_id, observacao_erro, data_inclusao, data_correcao, usuario_correcao) " +
                           " VALUES " +
                                  "(@cod_entrega,@cod_cte_id,@observacao_erro, @data_inclusao, @data_correcao, @usuario_correcao)";
            #endregion  
            var parametros = new DynamicParameters();

           
            foreach (var item in entregas_Cte_Erros)
            {
               // parametros.Add("id", funcNextVal);
                parametros.Add("cod_entrega", item.Cod_entrega);
                parametros.Add("cod_cte_id", Convert.ToInt32( item.Cod_cte_id));
                parametros.Add("observacao_erro", item.Observacao_erro);
                parametros.Add("data_inclusao", item.Data_inclusao);
                parametros.Add("data_correcao", null);
                parametros.Add("usuario_correcao", item.Usuario_correcao);
            }

            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

            var ret = SqlMapper.Query<Entregas_cte_erro>(Connection, query, parametros);
        }

        public void GravaErroCte(string cod_entrega, string observacao_erro, string cod_cte_id = null)
        {
            #region Query
            string query = string.Format("INSERT INTO " +
                                                "entregas_cte_erro(id, cod_entrega, cod_cte_id, observacao_erro, data_inclusao, data_correcao, usuario_correcao) " +
                                         " VALUES " +
                                                "({0},@cod_entrega,@cod_cte_id,@observacao_erro, @data_inclusao, @data_correcao, @usuario_correcao)", funcNextVal);
            #endregion

            var parametros = new DynamicParameters();

            parametros.Add("cod_entrega", cod_entrega);
            parametros.Add("cod_cte_id", cod_cte_id);
            parametros.Add("observacao_erro", observacao_erro);
            parametros.Add("data_inclusao", DateTime.Now);
            parametros.Add("data_correcao", null);
            parametros.Add("usuario_correcao", null);

            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

            var ret = SqlMapper.Query<Entregas_cte_erro>(Connection, query, parametros);
        }

        public void F_processa_erro_cte(string data_processado, string cod_entrega, string status_cte)
        {
             try
             {
                 string proc = string.Format("select f_processa_erro_cte ({0},{1},{2},{3})", data_processado, cod_entrega, status_cte);

                 SqlMapper.QueryFirst(Connection, proc);
             }
             catch (Exception)
             {
                 throw;
             }
            
        }
    }
}
