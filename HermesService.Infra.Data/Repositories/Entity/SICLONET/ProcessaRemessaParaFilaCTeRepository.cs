using Dapper;
using HermesService.Domain.Context;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class ProcessaRemessaParaFilaCTeRepository : RepositoryConnection, IProcessaRemessaParaFilaCTeRepository
    {
        public string ObeterUltimoCTeNumeroCliente(string Codcliente)
        {
            string ncte = string.Empty;
            #region Query
            string sql = string.Format(
                                        "SELECT " +
                                            "A.cte_numero " +
                                        "FROM " +
                                            "entregas_fila_cte A " +
                                        "WHERE " +
                                            "A.cod_cliente = {0} " +
                                        "ORDER BY " +
                                            "A.cte_numero DESC " + 
                                        "LIMIT " +
                                            "1;", Codcliente, Codcliente);
            #endregion

            var retorno = SqlMapper.Query<string>(Connection, sql).AsList();

            foreach (var item in retorno)
            {
                ncte = item.ToString();
            }            

            return ncte;
        }

        public IEnumerable<Entregas_cte_filiais_x_remetente> ObterClientesHabilitadosCTe()
        {
            #region Query
            var sql = "SELECT " +
                            "FILIAL.id " +
                            ",FILIAL.cod_empresa " +
                            ",FILIAL.cnpj_origem_coleta " +
                            ",FILIAL.cep " +
                            ",FILIAL.endereco " +
                            ",FILIAL.bairro " +
                            ",FILIAL.cidade " +
                            ",FILIAL.cod_cliente " +
                            ",FILIAL.ie " +
                            ",FILIAL.uf " +
                            ",FILIAL.cidade_cod_ibge " +
                            ",FILIAL.id_clientes_area_ftp " +
                            ",FILIAL.data_cadastro " +
                            ",FILIAL.razao_social " +
                            ",FILIAL.cod_pais " +
                        "FROM " +
                            "clientes_produtos CLIP " +
                        "INNER JOIN " +
                            "clientes CLI ON CLIP.codcliente = CLI.codcliente " +
                        "LEFT JOIN " +
                            "entregas_cte_filiais_x_remetente FILIAL ON cli.codcliente = FILIAL.cod_cliente " +
                        "WHERE " +
                            "produto_externo = 'ECOMMERCE' AND " +
                            "FILIAL.cod_cliente IS NOT NULL AND " +
                            "CLI.ativo = TRUE AND " +
                            "FILIAL.ativo = TRUE; ";
            #endregion

            var retorno = SqlMapper.Query<Entregas_cte_filiais_x_remetente>(Connection, sql);

            return retorno;
        
        }

        public IEnumerable<Entregas_cte_filiais_x_remetente> ObterClientesHabilitadosCTeAsync()
        {
            throw new NotImplementedException();
        }


    }
}
