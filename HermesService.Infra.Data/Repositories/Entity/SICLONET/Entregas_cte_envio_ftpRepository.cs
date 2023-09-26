using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public  class Entregas_cte_envio_ftpRepository : RepositoryConnection, IEntregas_cte_envio_ftpRepository
    {
        public void Update_entregas_cte_envio_ftp(string cod_entrega, string numero_cte, string xml)
        {
            string query = " update entregas_cte_envio_ftp set cte_xml = '{0}' where cod_entrega = '{1}' and cte_chave = '{2}' ;";

            try
            {
                query = string.Format(query, xml, cod_entrega, numero_cte);

                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                var ret = SqlMapper.Query<Entregas_cte_erro>(Connection, query);
            }
            catch (Exception ex)
            {
                throw new Exception ("Erro de execução na classe \"Update_entregas_cte_envio_ftp\" :" + ex.Message);
            }

        }



        public string Consulta_entregas_cte_envio_ftp(string cod_entrega, string numero_cte)
        {
            string query = "select a.cte_xml from entregas_cte_envio_ftp a where a.cod_entrega = '{0}' and a.cte_chave = '{1}' ; ";
            string ret = string.Empty;

            try
            {
                query = string.Format(query, cod_entrega, numero_cte);

                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                ret = SqlMapper.QueryFirstOrDefault<string>(Connection, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public void Grava_entregas_cte_envio_ftp(string xml, string id_ws, Entregas_cte_dados_gerados_detalhe objDetalhe)
        {
            #region Query
            string query = "INSERT INTO " +
                                "entregas_cte_envio_ftp(id,cnpj_cliente,cod_cliente,cte_chave,id_cliente_area_ftp,data_insert,data_envio,cte_xml,cod_entrega) " +
                            "VALUES " +
                                "({0},{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})";
            #endregion

            var parametros = new DynamicParameters();

            try
            {
                query = string.Format(query, 
                    "nextval('entregas_cte_envio_ftp_id_seq'::regclass)",
                    "'"+objDetalhe.Cnpj_origem_coleta +"'" ,
                    "'" + objDetalhe.Cod_cliente + "'",
                    "'" + objDetalhe.Cte_chave + "'",
                    "null",
                    "'" + Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "'",
                    "null",
                    "'" + xml + "'",
                    "'" + objDetalhe.Cod_entrega + "'"
                    );
                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                var ret = SqlMapper.Query<Entregas_cte_erro>(Connection, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Entregas_cte_envio_ftp> SelectPedidosAverbacao()
        {
            string query = @"
                            SELECT 
                                CTE_XML.cte_xml as sCte_xml ,
                                CTE_XML.cod_entrega as sCod_entrega,
                                CTE_XML.cod_cliente as sCod_cliente
                            FROM 
                                entregas_cte_envio_ftp CTE_XML
                            LEFT JOIN
                                entregas_cte_transmitido CTE_SITUACAO ON CTE_XML.cod_entrega = CTE_SITUACAO.cod_entrega
                            LEFT JOIN
                                averbacao AVER ON CTE_XML.cod_entrega = AVER.cod_entrega
                            WHERE
                                CTE_SITUACAO.cte_status = '100' AND
                                AVER.cod_entrega IS NULL AND
                                CTE_SITUACAO.cte_data_registro_ret_sefaz >=  NOW()- interval '90 days';";

            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

            var ret = SqlMapper.Query<Entregas_cte_envio_ftp>(Connection, query).ToList();

            return ret; 

        }
    }
}
