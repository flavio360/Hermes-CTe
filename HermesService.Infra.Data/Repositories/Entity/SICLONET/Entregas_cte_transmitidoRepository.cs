using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Entregas_cte_transmitidoRepository : RepositoryConnection, IEntregas_cte_transmitidoRepository
    {
        #region Grava o response da sefaz quando é feito o primeiro envio
        public void RecordResponse(dynamic xmlResponse)
        {
            #region Query
            string query = "INSERT INTO " +
                                "entregas_cte_transmitido(cte_numero,cte_status,cod_entrega,cte_hambiente_emissao,cte_data_transmissao,uf_sefaz,cte_verAplic,cte_recibo_sefaz,cte_protocolo_sefaz,cte_data_registro_ret_sefaz,id_dados_gerados_detalhe,cte_status_atual) " +
                            "VALUES " +
                                "(@cte_numero,@cte_status,@cod_entrega,@cte_hambiente_emissao,@cte_data_transmissao,@uf_sefaz,@cte_verAplic,@cte_recibo_sefaz,@cte_protocolo_sefaz,@cte_data_registro_ret_sefaz,@id_dados_gerados_detalhe,@cte_status_atual)";
            #endregion

            var parametros = new DynamicParameters();

            try
            {
                var dataSefaz = Convert.ToDateTime(xmlResponse.cte_data_registro_ret_sefaz);

                parametros.Add("cte_numero", xmlResponse.cte_numero);
                parametros.Add("@cte_status", xmlResponse.cte_status);
                parametros.Add("@cte_hambiente_emissao", xmlResponse.cte_hambiente_emissao);
                parametros.Add("@cod_entrega", xmlResponse.cod_entrega);
                parametros.Add("@cte_data_transmissao", dataSefaz);
                parametros.Add("@uf_sefaz", xmlResponse.uf_sefaz);
                parametros.Add("@cte_verAplic", xmlResponse.cte_verAplic);
                parametros.Add("@cte_recibo_sefaz", xmlResponse.cte_recibo_sefaz);
                parametros.Add("@cte_protocolo_sefaz", xmlResponse.cte_protocolo_sefaz);
                parametros.Add("@cte_data_registro_ret_sefaz", dataSefaz);
                parametros.Add("@id_dados_gerados_detalhe", xmlResponse.id_dados_gerados_detalhe);
                parametros.Add("@cte_status_atual", xmlResponse.cte_status);


                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                var ret = SqlMapper.Query(Connection, query, parametros);
            }

            catch (Exception  ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Atualiza a informação do status do CTe.
        public void UpdateCte(dynamic xmlResponse)
        {
            #region Query
            string queryFinaliza = string.Empty;
            string query = "UPDATE " +
                                "entregas_cte_transmitido " +
                            "SET " +
                                "cte_status = '{0}', " +
                                "cte_data_registro_ret_sefaz = '{1}', " +
                                "cte_protocolo_sefaz = '{2}', " +
                                "cte_veraplic = '{3}', " +
                                "cte_status_atual = '{4}' " +
                            "WHERE " +
                                "cte_recibo_sefaz = '{5}' and " +
                                "cod_entrega = '{6}';";

            if (xmlResponse.cte_status == "100")
            {
                queryFinaliza = "UPDATE " +
                    "entregas_cte_transmitido " +
                        "SET " +
                    "cte_status_atual = '" + xmlResponse.cte_status + "' " +
                        "WHERE " +
                    "cod_entrega = '" + xmlResponse.cod_entrega + "';"; 
            }
            #endregion

            try
            {

                query = string.Format(query, 
                                        xmlResponse.cte_status,
                                        //xmlResponse.cte_data_registro_ret_sefaz != null ? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") : xmlResponse.cte_data_registro_ret_sefaz,
                                        xmlResponse.cte_data_registro_ret_sefaz =       string.IsNullOrEmpty(xmlResponse.cte_data_registro_ret_sefaz)
                                        ? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                                        : xmlResponse.cte_data_registro_ret_sefaz,

                                        xmlResponse.cte_protocolo_sefaz == null ? "null":xmlResponse.cte_protocolo_sefaz,
                                        xmlResponse.cte_verAplic,
                                        xmlResponse.cte_status,
                                        xmlResponse.cte_recibo_sefaz,
                                        xmlResponse.cod_entrega
                                        );

                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);
                var ret = SqlMapper.Query(Connection, query);

                if (xmlResponse.cte_status == "100")
                {
                    SqlMapper.Query(Connection, queryFinaliza);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Retorna lista de todos CTe pendentes de consulta na Sefaz
        public IEnumerable<Entregas_cte_transmitido> SelectEntregas_cte_transmitido()
        {
            #region Query
            string query = "SELECT " +
                                "id,cte_numero,cte_status,cod_entrega,cte_hambiente_emissao,cte_data_transmissao,uf_sefaz,cte_veraplic,cte_recibo_sefaz,cte_protocolo_sefaz,cte_data_registro_ret_sefaz,id_dados_gerados_detalhe " +
                            "FROM " +
                                "entregas_cte_transmitido " +
                            "WHERE " +
                                "cte_status IN ('103','104')" +
                            "ORDER BY uf_sefaz";
            #endregion

            try
            {
                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                var ret = SqlMapper.Query<Entregas_cte_transmitido>(Connection, query);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        #endregion


        #region Consulta unitária do status de processamento de um CTe. 
        public Entregas_cte_transmitido SelectEntregas_cte_transmitido(string cod_entrega)
        {
            var ret = new Entregas_cte_transmitido();

            return ret;
        }
        #endregion
    }
}
