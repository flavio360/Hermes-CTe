using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Hermes.BLL.Ferramentas;
using HermesService.Application.EntidadesDTO;
using HermesService.Application.Utilities.CTe;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;

namespace HermesService.Application.AutoMapper.TypeConvert.CTe
{
    public class CTeTypeConverter : ITypeConverter<IEnumerable<Entregas>, List<F_Insere_Fila_CTe>>
    {
        public List<F_Insere_Fila_CTe> Convert(IEnumerable<Entregas> source, List<F_Insere_Fila_CTe> destination, ResolutionContext context)
        {
            var tratar = new TrataString();
            var tpCTe = new DefinirTipoCTe();
            
            try
            {
                if (source == null)
                    return null;

                destination = new List<F_Insere_Fila_CTe>();

                foreach (var item in source)
                {
                    destination.Add(new F_Insere_Fila_CTe()
                    {
                        //Id_fila = item.Id,
                        Cod_entrega_cliente = item.Codentregacli,
                        Vlr_advalorem = item.Advalorem,
                        Cod_entrega = item.Codentrega,
                        Aliq_icms = item.Aliq_icms==0 ? 0.00M : item.Aliq_icms,
                        Vlr_nfe = item.Vlr_entrega,
                        Vlr_frete = 0.00M,
                        Vlr_frete_total = item.Vlr_total_frete,
                        Vlr_gris = item.Vlr_gris,
                        Vlr_icms = item.Vlr_icms == 0 ? 0.00M : item.Vlr_icms,
                        Cod_cliente = item.Codcliente,
                        Cod_empresa = item.Codempresa_Emit==null?"null": item.Codempresa_Emit,

                        Id_filial_x_remetente = '0',
                        Cub_altura = item.Altura == 0 ? 0.00M : item.Altura,
                        Cub_comprimento = item.Comprimento == 0 ? 0.00M : item.Comprimento,
                        Nfe_descricao_produto = item.Descricao==null?"null": tratar.RemoveDiacriticas(item.Descricao),
                        Cub_largura = item.Largura == 0 ? 0.00M : item.Largura,
                        Cte_chave_anterior = item.Numero_cte_cliente==null?"null": item.Numero_cte_cliente,
                        Peso_arquivo = item.Peso,
                        Peso_balanca = item.Peso_balanca,
                        Cub_peso = item.Peso_cubado,
                        Quantidade = item.Quantidade.ToString(),
                        Nfe_serie = item.Serie != null ? item.Serie : "N/D",
                        Nfe_numero = item.Nrnota!=null? item.Nrnota: "N/D",
                        Cte_modelo = "N/D",
                        Cte_chave = null,
                        Cte_numero = null,
                        Cte_tipo = null,
                        Cfop = string.Empty,
                        Cst = "00",
                        Cte_data_insert_fila = "null",
                        Cte_modal = null,
                        Cte_status = "null",                        
                        Destinatario_endereco = tratar.RemoveDiacriticas(item.Endereco),
                        Destinatario_bairro = tratar.RemoveDiacriticas(item.Bairro_Dest),
                        Destinatario_cep = tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Cep_Dest)),
                        destinatario_cidade = tratar.RemoveDiacriticas(item.Cidade),
                        destinatario_cidade_cod_ibge = null,
                        destinatario_cpf = tratar.RemoveFormatacao(item.Cpf_cnpj),
                        destinatario_nome = tratar.RemoveDiacriticas(item.Destinatario),
                        destinatario_complemento = item.Complemento_Dest!=""? tratar.RemoveDiacriticas(item.Complemento_Dest):"null",
                        destinatario_razao_social = "null",
                        destinatario_telefone = item.Telefone==string.Empty?"null":tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Telefone)),
                        Destinatario_tipo_pessoa = item.Cpf_cnpj.Length==14?"J":"F",
                        Destinatario_uf= tratar.RemoveEspacos(item.Estado),
                        Cte_cancelamento_motivo = "null",
                        Cod_entrega_reprogramada = item.Ar_reprogramada != null ? item.Ar_reprogramada : "null",
                        Nfe_chave = tratar.RemoveEspacos(item.Chave_nfe_cliente != null ? item.Chave_nfe_cliente :"null"),
                        Destinatario_cnpj = tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Cpf_cnpj)),
                        Cte_complementar_motivo = "null",
                        Observacao = tratar.RemoveDiacriticas(item.Observacao),

                        Emitente_cnpj = tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Cnpj_Emit)),
                        Emitente_cidade_cod_ibge = item.Codmun_Emit,
                        Emitente_nome = item.Razao_social_Emit,
                        Emitente_complemento = "null",
                        Emitente_fantasia = tratar.RemoveDiacriticas(item.Razao_social_Emit),
                        Emitente_razaosocial = tratar.RemoveDiacriticas(item.Razao_social_Emit),
                        Emitente_uf = item.Estado_Emit,
                        Emitente_telefone = item.Telefone_e_ddd_Emit!=null? tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Telefone_e_ddd_Emit)):"null",
                        Emitente_cep = tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Cep_Emit)),

                        Rntrc = "null",
                        
                        Remetente_cnpj = tratar.RemoveEspacos(tratar.RemoveFormatacao(item.Cnpj_origem_coleta)),
                        Remetente_cidade_cod_ibge = item.Cidade_cod_ibgeOrigemColeta != null ? tratar.RemoveEspacos(item.Cidade_cod_ibgeOrigemColeta) :"null",
                        Remetente_nome = tratar.RemoveDiacriticas(item.NomeCLiente),
                        Remetente_complemento = "null",
                        Remetente_fantasia = tratar.RemoveDiacriticas(item.NomeCLiente),
                        Remetente_razaosocial = tratar.RemoveDiacriticas(item.NomeCLiente),
                        Remetente_telefone = "null",
                        Remetente_uf = tratar.RemoveEspacos(item.UfOrigemColeta),
                        Remetente_endereco = item.EnderecoOrigemColeta,
                        Erro = item.Problema!=null?true:false,
                        DescricaoErro = tratar.RemoveDiacriticas(item.Problema)!=null? tratar.RemoveDiacriticas(item.Problema):"null",

                        
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return destination;
        }
    }
}
