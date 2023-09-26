using Dapper;
using HermesService.Application.EntidadesDTO;
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
    public class FilaCTeRepository : RepositoryConnection, IFilaCTeRepository 
    {
        private string funcNextVal = "nextval('entregas_cte_erro_id_seq'::regclass)"; 

        public IEnumerable<Entregas> ConsultaPedidos(Entregas_cte_filiais_x_remetente clientes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entregas> ConsultaPedidosAsync(IEnumerable<Entregas_cte_filiais_x_remetente> clientes)
        {
            #region Query
            var query =
                       @"SELECT "+

                             "REMETENTE.id as id_remet, REMETENTE.cnpj_origem_coleta,REMETENTE.cep AS CepOrigemColeta,REMETENTE.endereco AS EnderecoOrigemColeta, " +
                             "REMETENTE.bairro AS BairroOrigemColeta, " +
                             "REMETENTE.cidade as CidadeOrigemColeta, REMETENTE.ie AS IE_OrigemColeta,REMETENTE.uf AS UfOrigemColeta,REMETENTE.cidade_cod_ibge AS Cidade_cod_ibgeOrigemColeta,CLI.cliente as NomeCLiente,   " +

                             "EMIT.cnpj  as Cnpj_Emit, EMIT.codmun AS Codmun_Emit, EMIT.razao_social AS Razao_social_Emit ,EMIT.estado AS Estado_Emit, " +
                             "EMIT.telefone_e_ddd AS Telefone_e_ddd_Emit,    EMIT.cep as Cep_Emit , EMIT.cidade  as Cidade_Emit, EMIT.codempresa as Codempresa_Emit, " +

                             "ENT.codcliente, ENT.codentregacli,  ENT.advalorem,  ENT.aliq_icms,  ENT.altura, " +
                             "ENT.largura, ENT.comprimento,  ENT.base_calc_icms,  ENT.basetxadvalorem,  ENT.chave_nfe_cliente,  " +
                             "ENT.cnpj  ,  ENT.incice_icms , ENT.cidade ,  ENT.bairro as Bairro_Dest ,  ENT.cidade as Cidade_Dest ,  ENT.celular ,  ENT.cep as Cep_Dest , " +
                             "ENT.cep_origem ,  ENT.clientecodigo ,   ENT.codentrega  ,  ENT.codmun ,  " +
                             "ENT.codsituacao ,  ENT.codsituacaoatual ,  ENT.codtipolista ,  ENT.codcidade,  ENT.cpf_cnpj ,  " +
                             "ENT.data_cadastro ,  ENT.destinatario ,  ENT.documento ,  ENT.endereco ,  ENT.estado ,  ENT.estado_ori ,  " +
                             "ENT.fantasia ,  ENT.insc_est ,  ENT.nrnota ,  ENT.numero_cte_cliente ,   ENT.peso ,  ENT.quantidade ,   " +
                             "ENT.serie ,  ENT.telefone ,  ENT.tipo_pessoa ,  ENT.valordeclarado ,  ENT.vlr_entrega ,  ENT.vlr_gris ,   " +
                             "ENT.vlr_icms ,  ENT.vlr_icms_retido ,  ENT.vlr_iss ,  ENT.vlr_total_frete  " +
                       "FROM " +
                       "	entregas_recepcao ENT_RECP " +
                       "INNER JOIN   " +
                       "    entregas ENT ON ENT.codentrega = ENT_RECP.codentrega " +
                       "LEFT JOIN " +
                       "	entregas_fila_cte FILA ON FILA.cod_entrega = ENT_RECP.codentrega " +
                       "LEFT JOIN " +
                       "	entregas_cte_erro ERRO ON ERRO.cod_entrega = ENT_RECP.codentrega  " +
                       "LEFT JOIN " +
                       "	entregas_cte_filiais_x_remetente REMETENTE ON REMETENTE.cod_cliente = ENT.codcliente " +
                       "LEFT JOIN " +
                       "	clientes CLI ON CLI.codcliente = REMETENTE.cod_cliente " +
                       "LEFT JOIN " +
                       "	empresas EMIT ON EMIT.codempresa = REMETENTE.cod_empresa " +
                       "WHERE " +
                           "ENT_RECP.codentrega IS NOT NULL AND " +
                           "ENT_RECP.data_recepcao >=  NOW() - interval '365 days' AND " +
                           "FILA.cod_entrega IS NULL AND " +
                           "(ERRO.erro IS FALSE OR ERRO.cod_entrega IS NULL )AND " +
                           "ENT.data_cadastro >=  NOW() - interval '6 days' AND " +
                           //"ENT.data_cadastro >=  NOW() - interval '365 days' AND " +
                           "REMETENTE.ativo = TRUE " +
                           "ORDER BY ENT_RECP.data_recepcao DESC";
            #endregion


                var objPedidos = SqlMapper.Query<Entregas>(Connection, query);                

                return objPedidos;
        }

        public void GravaFilaCTe(List<DadosCteDTO> dadosCtes)
        {
            string query = "";
            try
            {
                var parametros = new DynamicParameters();

                //#TODO testar o insert
                foreach (var item in dadosCtes)
                {
                    parametros.Add("AliqIcms", item.AliqIcms);
                }

                Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);

                var ret = SqlMapper.Query<Entregas_cte_erro>(Connection, query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Problema na execução da classe \"GravaFilaCTe\" msg: " + ex.Message);
            }
        }

    }
}
