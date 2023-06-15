using Dapper;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET.PROC
{
    public class F_Insere_Fila_CTeRepository : RepositoryConnection, IF_Insere_Fila_CTeRepository
    {
        public void Insere_Fila_CTe(List<F_Insere_Fila_CTe> pedido)
        {
            if (pedido==null)
            {
                throw new ArgumentNullException("Buffer_Fila_Cte");
            }
            #region Procedure
            
            //string proc = "select F_Insere_Fila_CTe("
            //                                    + " @Cod_entrega,"
            //                                    + " @Vlr_advalorem,"
            //                                    + " @Aliq_icms,"
            //                                    + " @Vlr_nfe,"
            //                                    + " @Vlr_frete_total,"
            //                                    + " @Vlr_frete,"
            //                                    + " @Vlr_gris,"
            //                                    + " @Vlr_icms,"
            //                                    + " @Cod_cliente,"
            //                                    + " @Cod_empresa,"
            //                                    + " @Id_filial_x_remetente,"
            //                                    + " @Cub_altura,"
            //                                    + " @cub_comprimento,"
            //                                    + " @Nfe_descricao_produto,"
            //                                    + " @Cub_largura,"
            //                                    + " @Cte_chave_anterior,"
            //                                    + " @Peso_arquivo,"
            //                                    + " @Peso_balanca,"
            //                                    + " @Cub_peso,"
            //                                    + " @Quantidade,"
            //                                    + " @Nfe_serie,"
            //                                    + " @Nfe_numero,"
            //                                    + " @Cte_modelo,"
            //                                    + " @Cte_chave,"
            //                                    + " @Cte_numero,"
            //                                    + " @Cte_tipo,"
            //                                    + " @Cfop,"
            //                                    + " @Cst,"
            //                                    + " @Cte_data_insert_fila,"
            //                                    + " @Cte_modal,"
            //                                    + " @Cte_status,"
            //                                    + " @Destinatario_endereco,"
            //                                    + " @Destinatario_bairro,"
            //                                    + " @Destinatario_cep,"
            //                                    + " @Destinatario_cidade,"
            //                                    + " @Destinatario_cidade_cod_ibge,"
            //                                    + " @Destinatario_cpf,"
            //                                    + " @Destinatario_nome,"
            //                                    + " @Destinatario_complemento,"
            //                                    + " @Destinatario_razao_social,"
            //                                    + " @Destinatario_telefone,"
            //                                    + " @Destinatario_tipo_pessoa,"
            //                                    + " @Cte_complementar_motivo,"
            //                                    + " @Cod_entrega_reprogramada,"
            //                                    + " @Nfe_chave,"
            //                                    + " @Destinatario_cnpj,"
            //                                    + " @Cte_cancelamento_motivo,"
            //                                    + " @Destinatario_uf,"
            //                                    + " @Emitente_cnpj,"
            //                                    + " @Emitente_cidade_cod_ibge,"
            //                                    + " @Emitente_nome,"
            //                                    + " @Emitente_complemento,"
            //                                    + " @Emitente_fantasia,"
            //                                    + " @Emitente_razaosocial ,"
            //                                    + " @Emitente_uf,"
            //                                    + " @Emitente_telefone ,"
            //                                    + " @Rntrc,"
            //                                    + " @Emitente_cep,"
            //                                    + " @Remetente_cnpj,"
            //                                    + " @Remetente_cidade_cod_ibge,"
            //                                    + " @Remetente_cpf_cnpj,"
            //                                    + " @Remetente_nome,"
            //                                    + " @Remetente_complemento,"
            //                                    + " @Remetente_fantasia,"
            //                                    + " @Remetente_razaosocial,"
            //                                    + " @Remetente_telefone,"
            //                                    + " @Remetente_uf"
            //                                    + " )";
            #endregion

            foreach (var propCTe in pedido)
            {
                //var parametros = new DynamicParameters();
                string proc = string.Format("select F_Insere_Fila_CTe('{0}',{1},{2},{3},{4},{5},{6},{7},{8},'{9}','{10}',{11},{12},'{13}',{14},'{15}',{16},{17},{18},'{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}'," +
                                                                     "'{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}')",
                        propCTe.Cod_entrega,
                        propCTe.Vlr_advalorem.ToString().Replace(",", "."),
                        propCTe.Aliq_icms.ToString().Replace(",", "."),
                        propCTe.Vlr_nfe.ToString().Replace(",","."),
                        propCTe.Vlr_frete_total.ToString().Replace(",", "."),
                        propCTe.Vlr_frete.ToString().Replace(",", "."),
                        propCTe.Vlr_gris.ToString().Replace(",", "."), 
                        propCTe.Vlr_icms.ToString().Replace(",", "."), 
                        propCTe.Cod_cliente,
                        propCTe.Cod_empresa,

                        propCTe.Id_filial_x_remetente.ToString(),
                        propCTe.Cub_altura.ToString().Replace(",", "."),
                        propCTe.Cub_comprimento.ToString().Replace(",", "."),
                        propCTe.Nfe_descricao_produto,
                        propCTe.Cub_largura.ToString().Replace(",", "."),
                        propCTe.Cte_chave_anterior,
                        propCTe.Peso_arquivo.ToString().Replace(",", "."),
                        propCTe.Peso_balanca.ToString().Replace(",", "."),
                        propCTe.Cub_peso.ToString().Replace(",", "."),
                        propCTe.Quantidade.ToString(),
                        propCTe.Nfe_serie,
                        propCTe.Nfe_numero,
                        propCTe.Cte_modelo,
                        propCTe.Cte_chave,
                        propCTe.Cte_numero,
                        propCTe.Cte_tipo,
                        propCTe.Cfop,
                        propCTe.Cst,
                        DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        propCTe.Cte_modal,
                        propCTe.Cte_status,
                        propCTe.Destinatario_endereco,
                        propCTe.Destinatario_bairro,
                        propCTe.Destinatario_cep,
                        propCTe.destinatario_cidade,
                        propCTe.destinatario_cidade_cod_ibge,
                        propCTe.destinatario_cpf,
                        propCTe.destinatario_nome,
                        propCTe.destinatario_complemento,
                        propCTe.destinatario_razao_social,
                        propCTe.destinatario_telefone,
                        propCTe.Destinatario_tipo_pessoa,
                        propCTe.Cte_complementar_motivo,
                        propCTe.Cod_entrega_reprogramada,
                        propCTe.Nfe_chave,
                        propCTe.Destinatario_cnpj,
                        propCTe.Cte_cancelamento_motivo,
                        propCTe.Destinatario_uf,
                        propCTe.Emitente_cnpj,
                        propCTe.Emitente_cidade_cod_ibge,
                        propCTe.Emitente_nome,
                        propCTe.Emitente_complemento,
                        propCTe.Emitente_fantasia,
                        propCTe.Emitente_razaosocial,
                        propCTe.Emitente_uf,
                        propCTe.Emitente_telefone,
                        propCTe.Rntrc,
                        propCTe.Emitente_cep,
                        propCTe.Remetente_cnpj,
                        propCTe.Remetente_cidade_cod_ibge,
                        propCTe.Remetente_cnpj,
                        propCTe.Remetente_nome,
                        propCTe.Remetente_complemento,
                        propCTe.Remetente_fantasia,
                        propCTe.Remetente_razaosocial,
                        propCTe.Remetente_telefone,
                        propCTe.Remetente_uf);                

                var ret = SqlMapper.QueryFirst<F_roteirizador_entregas>(Connection, proc);
            }
        }
    }
}
