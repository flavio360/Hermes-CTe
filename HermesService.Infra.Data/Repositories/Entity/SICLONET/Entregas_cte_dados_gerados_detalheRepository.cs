using Dapper;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET
{
    public class Entregas_cte_dados_gerados_detalheRepository : RepositoryConnection, IEntregas_cte_dados_gerados_detalheRepository
    {

        public List<Entregas_cte_dados_gerados_detalhe> RecuperaDadosProcessoGeraCTe(string cod_empresa)
        {
            string query =
            "SELECT " +
                "CTE_T.cte_status_atual, CTE_T.cte_hambiente_emissao,CTE_T.cte_protocolo_sefaz ,CTE_T.uf_sefaz, CTE_T.cte_recibo_sefaz , " +
                "EMP.bairro as Bairro_emit, EMP.cep as Cep_Emit, EMP.cidade as Cidade_Emit, EMP.endereco as Endereco_Emit, EMP.insc_est as Insc_est_Emit, EMP.numero as Numero_Emit, EMP.complemento,EMP.telefone_e_ddd, EMP.estado as Estado_Emit, " +
                "FIL.bairro as BairroOrigemColeta,FIL.cep as CepOrigemColeta,FIL.cnpj_origem_coleta,FIL.cidade as CidadeOrigemColeta,FIL.endereco as EnderecoOrigemColeta, FIL.ie  as IE_OrigemColeta, FIL.razao_social, FIL.endereco AS Remetente_endereco,  " +
                "ENT_DET.*, ENT_DET.destinatario_uf as destinatario_estado, " +
                "EMIT_DET.id,EMIT_DET.emitente_cnpj as Emitente_cnpj ,EMIT_DET.emitente_cidade_cod_ibge,EMIT_DET.emitente_nome,EMIT_DET.emitente_complemento,EMIT_DET.emitente_fantasia,EMIT_DET.emitente_razaosocial,EMIT_DET.emitente_uf,EMIT_DET.emitente_telefone,EMIT_DET.rntrc as Emitente_Rntrc,EMIT_DET.emitente_cep, " +
                "REM_DET.id,REM_DET.remetente_cnpj,REM_DET.remetente_cidade_cod_ibge,REM_DET.remetente_cpf_cnpj,REM_DET.remetente_nome,REM_DET.remetente_complemento,REM_DET.remetente_fantasia,REM_DET.remetente_razaosocial,REM_DET.remetente_telefone,REM_DET.remetente_uf,REM_DET.cod_cliente,REM_DET.cod_empresa, REM_DET.remetente_endereco, " +
                "EXP.expedidor_cnpj,EXP.expedidor_cidade_cod_ibge,EXP.expedidor_complemento,EXP.expedidor_fantasia,EXP.expedidor_razaosocial,EXP.expedidor_uf,EXP.expedidor_telefone,EXP.expedidor_cep,EXP.expedidor_endereco,EXP.expedidor_cidade,EXP.expedidor_bairro,EXP.expedidor_IE " +
            "FROM " +
                "entregas_fila_cte ENT_DET " +
            "LEFT JOIN " +
                "entregas_cte_detalhe_emitente EMIT_DET ON EMIT_DET.id =  ENT_DET.id_detalhe_emitente " +
            "LEFT JOIN " +
                "entregas_cte_detalhe_remetente REM_DET ON REM_DET.id = ENT_DET.id_detalhe_remetente " +
            "LEFT JOIN " +
                "Entregas_cte_filiais_x_remetente FIL ON FIL.cod_cliente = REM_DET.cod_cliente " +
            "LEFT JOIN " +
                "Empresas EMP ON EMP.cnpj = EMIT_DET.emitente_cnpj " +
            "LEFT JOIN " +
                "entregas_cte_detalhe_expedidor EXP ON EXP.cod_cliente = ENT_DET.cod_cliente " +
            "LEFT JOIN " +
                "entregas_cte_erro CTE_E ON CTE_E.cod_entrega = ENT_DET.cod_entrega " +
            "LEFT JOIN " +
                "entregas_cte_transmitido CTE_T ON CTE_T.cod_entrega = ENT_DET.cod_entrega " +
            " WHERE " +
                "(ENT_DET.cod_empresa = '2' AND " +
                "CTE_T.cte_recibo_sefaz IS NULL  AND " +
                "(CTE_E.erro IS NULL OR CTE_E.erro = FALSE) AND " +
                "CTE_T.cte_status_atual <> '100' or CTE_T.cte_status_atual is null AND " +
                "ENT_DET.cte_status = '1') " +
                "OR " +
                "(CTE_E.erro = FALSE AND " +
                "ENT_DET.cod_empresa = '2' AND " +
                "ENT_DET.cte_status = '1')";

            var parametros = new DynamicParameters();

            parametros.Add("@cod_empresa", Convert.ToInt32(cod_empresa));
            try
            {
                var ret = SqlMapper.Query<Entregas_cte_dados_gerados_detalhe>(Connection, query, parametros).AsList<Entregas_cte_dados_gerados_detalhe>();

                return SqlMapper.Query<Entregas_cte_dados_gerados_detalhe>(Connection, query, parametros).AsList<Entregas_cte_dados_gerados_detalhe>();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
