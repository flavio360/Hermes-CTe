using Dapper;
using HermesService.Domain.Entity.Averbacao;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Entity.SICLONET.PROC
{
    public class AverbacaoRepository : RepositoryConnection, IAverbacaoRepository
    {
        public string InsertAverbacao(CTeAverbacao dadosAverbacao)
        {
            string codigoErro = string.Empty;
            string numeroAverbacao = string.Empty;
            string cnpjSeguradora = string.Empty;
            string nomeSeguradora = string.Empty;
            string numApolice = string.Empty;
            string tpMov = string.Empty;
            string tpDDR = string.Empty;
            string valorAverbado = string.Empty;
            string ramoAverbado = string.Empty;
            bool averb = true;

            if (dadosAverbacao.Erros != null)
            {
                foreach (var erro in dadosAverbacao.Erros.Erro)
                {
                    codigoErro = erro.Codigo;
                    averb = false;
                    continue;
                }
            }

            foreach (var dadosSeguro in dadosAverbacao.Averbado.DadosSeguro)
            {
                numeroAverbacao = dadosSeguro.NumeroAverbacao;
                cnpjSeguradora = dadosSeguro.CNPJSeguradora;
                nomeSeguradora = dadosSeguro.NomeSeguradora;
                numApolice = dadosSeguro.NumApolice;
                tpMov = dadosSeguro.TpMov;
                tpDDR = dadosSeguro.TpDDR;
                valorAverbado = dadosSeguro.ValorAverbado;
                ramoAverbado = dadosSeguro.RamoAverbado;
            }

            string insertQuery = @"
                                    INSERT INTO Averbacao (
                                        id_averbacao,
                                        averbacao,
                                        data_envio_seguradora,
                                        cod_cliente,
                                        numero_doc,
                                        serie,
                                        filial,
                                        cnpj_cli,
                                        tp_doc,
                                        inf_adic,
                                        dh_averbacao,
                                        protocolo,
                                        numero_averbacao,
                                        cnpj_seguradora,
                                        num_apolice,
                                        tp_mov,
                                        tp_ddr,
                                        valor_averbado,
                                        ramo_averbado,
                                        codigo,
                                        descricao,
                                        cod_entrega,
                                        cod_erro
                                    ) VALUES (
                                        nextval('averbacao_id_averbacao_seq'::regclass),
                                        @Averbado,
                                        @DataEnvioSeguradora,
                                        @CodCliente,
                                        @Numero,
                                        @Serie,
                                        @Filial,
                                        @CNPJCli,
                                        @TpDoc,
                                        @InfAdic,
                                        @DhAverbacao,
                                        @Protocolo,
                                        @NumeroAverbacao,
                                        @CNPJSeguradora,
                                        @NomeSeguradora,
                                        @NumApolice,
                                        @TpMov,
                                        @TpDDR,
                                        @ValorAverbado,
                                        @RamoAverbado,
                                        @Codigo,
                                        @Descricao,
                                        @CodEntrega,
                                        @CodErro
                                    );";
            
            try
            {
                int rowsAffected = Connection.Execute(insertQuery, new
                {
                    //Averbado = dadosAverbacao.Processado,
                    Averbado = averb,
                    DataEnvioSeguradora = DateTime.Now,
                    CodCliente = Convert.ToInt32(dadosAverbacao.CodCliente),
                    Numero = dadosAverbacao.Numero ?? "",
                    Serie = dadosAverbacao.Serie ?? "",
                    Filial = dadosAverbacao.Filial ?? "",
                    CNPJCli = dadosAverbacao.CNPJCli ?? "",
                    TpDoc = dadosAverbacao.TpDoc ?? "",
                    InfAdic = dadosAverbacao.InfAdic ?? "",
                    DhAverbacao = Convert.ToDateTime(dadosAverbacao.Averbado.DhAverbacao),
                    Protocolo = dadosAverbacao.Averbado?.Protocolo ?? "",
                    NumeroAverbacao = numeroAverbacao ?? "",
                    CNPJSeguradora = cnpjSeguradora ?? "",
                    NomeSeguradora = nomeSeguradora ?? "",
                    NumApolice = numApolice ?? "",                    
                    TpMov = tpMov ?? "",
                    TpDDR = tpDDR ?? "",
                    ValorAverbado = decimal.TryParse(valorAverbado, out decimal valor) ? valor : 0,
                    RamoAverbado = ramoAverbado ?? "",
                    Codigo = dadosAverbacao.Infos?.Info?.Codigo ?? "",
                    Descricao = dadosAverbacao.Infos?.Info?.Descricao ?? "",
                    CodEntrega = dadosAverbacao.CodEntrega ?? "",
                    CodErro = codigoErro ?? ""
                });

                return rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteAverbacao(string cod_entrega = null, string numero_averbacao = null, string cod_cliente = null, string protocolo = null)
        {
            throw new NotImplementedException();
        }

        public CTeAverbacao SelectAverbacao(string cod_entrega = null, string numero_averbacao = null, string cod_cliente = null, string protocolo = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateAverbacao(CTeAverbacao dadosAverbacao)
        {
            throw new NotImplementedException();
        }
    }
}
