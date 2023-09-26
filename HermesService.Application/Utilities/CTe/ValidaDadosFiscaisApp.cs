using Hermes.BLL.Ferramentas;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.Utilities.CTe
{
    public class ValidaDadosFiscaisApp
    {
        public List<F_Insere_Fila_CTe> ValidarCamposFiscais(List<F_Insere_Fila_CTe> entregas)
        {            
            var count = entregas.Count;
            Tuple<bool, string> situacao;

            foreach (var item in entregas)
            {
                //while (count!=-0)
                //{


                situacao = ValidaDanfe(item.Nfe_chave, item.Vlr_nfe);
                if (situacao.Item1)
                {
                    item.Erro = true;
                    item.DescricaoErro = situacao.Item2;
                    continue;
                }
                situacao = null; 
                
                //#TODO Parametros passados na assinatura,.
                situacao = ValidaDadosRemetente(item.Remetente_nome, item.Remetente_cnpj , item.Remetente_cidade_cod_ibge,null,null,item.Remetente_razaosocial,item.Remetente_uf);
                if (situacao.Item1)
                {
                    item.Erro = true;
                    item.DescricaoErro = situacao.Item2;
                    continue;
                }
                situacao = null;

                situacao = ValidaDadosEmissor(item.Emitente_nome, item.Emitente_cnpj);
                if (situacao.Item1)
                {
                    item.Erro = true;
                    item.DescricaoErro = situacao.Item2;
                    continue;
                }
                situacao = null;
                

                if (item.Remetente_cidade_cod_ibge == item.destinatario_cidade_cod_ibge)
                {
                    //item.Erro = true;
                    item.Observacao = "Origem x destino mesma cidade, Nota fiscal de serviço";
                    item.Cte_status = "100";
                    item.Cte_tipo = "NFS";
                }

                if (item.Aliq_icms == 0 || item.Vlr_frete == 0 || item.Vlr_icms == 0 )
                {
                    item.Erro = true;

                    if (item.Aliq_icms == 0)
                    {
                        item.DescricaoErro = "Aliquota ICMS não esta cadastrado";
                    }
                    else if (item.Vlr_frete == 0)
                    {
                        item.DescricaoErro = "O frete não foi calculado, verificar as variáveis do calculo";
                    }
                    else if (item.Vlr_icms == 0)
                    {
                        item.DescricaoErro = "Valor ICMS não cadastrado";
                    }
                }
            }
            return entregas;
        }

        private Tuple<bool, string> ValidaDanfe(string danfe, decimal valor) 
        {
            bool erro = false;
            string msg = string.Empty;

            if (danfe==string.Empty)
            {
                erro = true;
                msg = "Chave DANFE não localizada.";
            }
            if (valor == 0)
            {
                erro = true;
                msg = msg + "|| Valor da Nota Fiscal não informado.";
            }
            return new Tuple<bool, string>(erro, msg);
        }

        private Tuple<bool, string> ValidaDadosEmissor(string nome, string cnpj)
        {
            bool erro = false;
            string msg = string.Empty;

            if (nome == string.Empty)
            {
                erro = true;
                msg = "Campo Nome do remetente vazio";
            }
            if (cnpj == string.Empty)
            {
                erro = true;
                msg = msg + "|| CEP do remetente vazio";
            }

            return new Tuple<bool, string>(erro, msg);
        }

        private Tuple<bool, string> ValidaDadosRemetente(string nome, string cnpj, string ibge, string endereco, string cidade, string razaosocial, string uf )
        {
            bool erro = false;
            string msg = string.Empty;

            var doc = new Validacoes();
            var ret = doc.ValidaCPF_CNPJ(cnpj);
            if (cnpj == string.Empty || cnpj == null)
            {
                erro = true;
                msg = "CNPJ do remetente vazio";
            }
            if (ret==false)
            {
                erro = true;
                msg = "CNPJ do remetente inválido";
            }
            if (ibge == string.Empty || ibge == null)
            {
                erro = true;
                msg = msg + "|| Código cidade IBGE do remetente não preenchido";
            }

            return new Tuple<bool, string>(erro, msg);
        }

    }
}
