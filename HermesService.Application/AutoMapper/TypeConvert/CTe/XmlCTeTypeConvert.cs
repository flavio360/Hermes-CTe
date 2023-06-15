using AutoMapper;
using Hermes.BLL.Ferramentas;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.AutoMapper.TypeConvert.CTe
{
    public class XmlCTeTypeConvert : ITypeConverter<Entregas_cte_dados_gerados_detalhe, IdeDTO> , ITypeConverter<Entregas_cte_dados_gerados_detalhe, DestDTO>, 
                                     ITypeConverter<Entregas_cte_dados_gerados_detalhe, RemDTO> , ITypeConverter<Entregas_cte_dados_gerados_detalhe, ExpedDTO>,
                                     ITypeConverter<Entregas_cte_dados_gerados_detalhe, VPrestDTO>, ITypeConverter<Entregas_cte_dados_gerados_detalhe, EmitDTO>,
                                     ITypeConverter<Entregas_cte_dados_gerados_detalhe, ImpDTO>
    {
        private string versaoApp = "Hermes";

        #region PROPRIEDADE IDE XML CTE
        public IdeDTO Convert(Entregas_cte_dados_gerados_detalhe source, IdeDTO destination, ResolutionContext context)
        {

            TrataString trata = new TrataString();
            var tool = new CTeTools();
            destination = new IdeDTO();
            try
            {
                
                destination.CUF = tool.RetornaCodigoUF(source.Emitente_uf); 
                destination.CCT = source.Cte_chave.Substring(35,8);
                destination.CFOP = source.Cfop;
                destination.NatOp = "TRANSP ESTABELECIMENTO COMERCIAL";
                destination.Mod = "57";
                destination.Serie = "1";
                destination.Serie = source.Cte_chave.Substring(22,3);
                destination.NCT = source.Cte_numero;
                destination.DhEmi = null;
                destination.TpImp = "1";
                destination.TpEmis = "1";
                destination.CDV = source.Cte_chave.Substring(source.Cte_chave.Length - 1, 1);
                destination.TpAmb = null;
                destination.TpCTe = source.Cte_tipo;
                destination.ProcEmi = ((int)CTEEnums.AppEmissor.AppContribuente).ToString();
                destination.VerProc = versaoApp;
                destination.CMunEnv = source.Emitente_cidade_cod_ibge;
                destination.XMunEnv = trata.RemoveDiacriticas(source.Cidade_Emit);
                destination.UFEnv = source.Emitente_uf;
                destination.Modal = ((int)CTEEnums.Modal.Rodoviario).ToString();
                destination.TpServ = source.Cte_tipo;
                destination.CMunIni = source.Emitente_cidade_cod_ibge;
                destination.XMunIni = trata.RemoveDiacriticas(source.Cidade_Emit);
                destination.UFIni = source.Emitente_uf;
                destination.CMunFim = source.Destinatario_cidade_cod_ibge;
                destination.XMunFim = trata.RemoveDiacriticas(source.Destinatario_cidade);
                destination.UFFim = source.destinatario_estado;
                destination.Retira = ((int)CTEEnums.Retira.Nao).ToString();
                destination.IndIEToma = "TODO"; 

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PROPRIEDADE DEST XML CTE
        public DestDTO Convert(Entregas_cte_dados_gerados_detalhe source, DestDTO destination, ResolutionContext context)
        {
            TrataString trata = new TrataString();
            destination = new DestDTO();
            try
            {

                destination.Cpf = source.Destinatario_cpf;
                destination.IE = " ";
                destination.xNome = trata.RemoveDiacriticas(source.Destinatario_nome);
                destination.fone = source.Destinatario_telefone;
                destination.xLgr = trata.RemoveDiacriticas(source.Destinatario_endereco);
                destination.nro = " ";
                destination.xBairro = trata.RemoveDiacriticas(source.Destinatario_bairro);
                destination.cMun = source.Destinatario_cidade_cod_ibge;
                destination.xMun = trata.RemoveDiacriticas(source.Destinatario_cidade);
                destination.CEP = source.Destinatario_cep;
                destination.Uf = source.destinatario_estado;


                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region PROPRIEDADE "REM" XML CTE
        public RemDTO Convert(Entregas_cte_dados_gerados_detalhe source, RemDTO destination, ResolutionContext context)
        {
            destination = new RemDTO();
            TrataString trata = new TrataString();
            try
            {
                destination.UF = source.Remetente_uf;
                destination.CNPJ = source.Remetente_cnpj;
                destination.CEP = source.CepOrigemColeta;
                destination.cMun = source.Remetente_cidade_cod_ibge;
                destination.xBairro = trata.RemoveDiacriticas(source.BairroOrigemColeta);
                destination.xFant = trata.RemoveDiacriticas(source.Remetente_nome);
                destination.xLgr = trata.RemoveDiacriticas(source.Remetente_endereco);
                destination.IE = source.IE_OrigemColeta;
                destination.xNome = source.Remetente_nome;
                destination.fone = source.Remetente_telefone;
                destination.nro = "10";
                destination.xMun = trata.RemoveDiacriticas(source.CidadeOrigemColeta);

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PROPRIEDADE "EXPED" XML CTE
        public ExpedDTO Convert(Entregas_cte_dados_gerados_detalhe source, ExpedDTO destination, ResolutionContext context)
        {
            destination = new ExpedDTO();
            TrataString trata = new TrataString();
            try
            {
                destination.CNPJ = source.Expedidor_cnpj;
                destination.IE = source.Expedidor_IE;
                destination.xNome = trata.RemoveDiacriticas(source.Expedidor_fantasia);
                destination.xFant = trata.RemoveDiacriticas(source.Expedidor_fantasia);
                destination.xLgr = source.Expedidor_endereco;
                destination.nro = source.Expedidor_complemento;
                destination.xBairro = trata.RemoveDiacriticas(source.Expedidor_bairro);
                destination.cMun = source.Expedidor_cidade_cod_ibge;
                destination.xMun = trata.RemoveDiacriticas(source.Expedidor_cidade);
                destination.CEP = source.Expedidor_cep;
                destination.UF = source.Expedidor_uf;
                destination.fone = source.Expedidor_telefone;

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region PROPRIEDADE "EMIT" XML CTE
        public EmitDTO Convert(Entregas_cte_dados_gerados_detalhe source, EmitDTO destination, ResolutionContext context)
        {
            destination = new EmitDTO();
            TrataString trata = new TrataString();
            try
            {
                destination.CNPJ = source.Emitente_cnpj;
                destination.IE = source.Insc_est_Emit;
                destination.xNome = trata.RemoveDiacriticas(source.Emitente_nome);
                destination.xFant = trata.RemoveDiacriticas(source.Emitente_nome);
                destination.xLgr = trata.RemoveDiacriticas(source.Endereco_Emit);
                destination.nro = source.Numero_Emit;
                destination.xBairro = trata.RemoveDiacriticas(source.Bairro_Emit);
                destination.cMun = source.Emitente_cidade_cod_ibge;
                destination.xMun = trata.RemoveDiacriticas(source.Cidade_Emit);
                destination.CEP = source.Cep_Emit;
                destination.UF = source.Estado_Emit;
                destination.fone = source.Telefone_e_ddd_Emit;

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region PROPRIEDADE "VPREST" XML CTE
        public VPrestDTO Convert(Entregas_cte_dados_gerados_detalhe source, VPrestDTO destination, ResolutionContext context)
        {
            destination = new VPrestDTO();

            try
            {
                destination.VTPrest = source.Vlr_frete_total.ToString().Replace(",", ".");
                destination.VCompFrete = source.Vlr_frete.ToString().Replace(",", ".");
                destination.VRec  = source.Vlr_frete_total.ToString().Replace(",", ".");
                destination.VCompICMS = source.Vlr_icms.ToString().Replace(",", ".");

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region PROPRIEDADE "IMP" XML CTE
        public ImpDTO Convert(Entregas_cte_dados_gerados_detalhe source, ImpDTO destination, ResolutionContext context)
        {
            destination = new ImpDTO();

            try
            {
                destination.CST = source.Cst != null? source.Cst : "00";
                destination.VBC = source.Vlr_frete.ToString().Replace(",",".");
                destination.PICMS = source.Aliq_icms.ToString().Replace(",", ".");
                destination.VICMS = source.Vlr_icms.ToString().Replace(",", ".");

                return destination;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

    }
}
