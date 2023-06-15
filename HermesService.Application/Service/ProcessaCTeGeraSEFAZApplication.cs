using Hermes.BLL.Ferramentas;
using HermesService.Application.AutoMapper;
using HermesService.Application.EntidadesDTO;
using HermesService.Application.Interfaces;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static HermesService.Application.AutoMapper.MapperFactory;



namespace HermesService.Application.Service
{
    public class ProcessaCTeGeraSEFAZApplication : IProcessaCTeGeraSEFAZApplication 
    {
        #region interfaces e Construtores
        
        private readonly IRecuperaFiliaisEmissorasAtivasSerivce _RecuperaFiliaisEmissorasAtivasSerivce;
        private readonly IProcessaCTeGeraSEFAZService _ProcessaCTeGeraSEFAZService;
        private readonly IGeraXMLCTeService _GeraXMLCTeService;
        private readonly IMontaXMLCTeService _MontaXMLCTeService;
        private readonly ICommunicationSefazService _CommunicationSefazService;
        private readonly ICte_endereco_web_serviceService _Cte_endereco_web_service;
        private readonly IEntregas_cte_transmitidoService _Entregas_cte_transmitido;
        List<cte_endereco_web_service> objWS = null;
        X509Certificate2 certif = null;
        string execProd = string.Empty;

        public ProcessaCTeGeraSEFAZApplication
        (
            IRecuperaFiliaisEmissorasAtivasSerivce RecuperaFiliaisEmissorasAtivasSerivce,
            IProcessaCTeGeraSEFAZService ProcessaCTeGeraSEFAZService,
            IGeraXMLCTeService GeraXMLCTeService,
            IMontaXMLCTeService MontaXMLCTeService,
            ICommunicationSefazService CommunicationSefazService,
            ICte_endereco_web_serviceService Cte_endereco_web_service,
            IEntregas_cte_transmitidoService Entregas_cte_transmitido
            
        )
        {
            _RecuperaFiliaisEmissorasAtivasSerivce = RecuperaFiliaisEmissorasAtivasSerivce;
            _ProcessaCTeGeraSEFAZService = ProcessaCTeGeraSEFAZService;
            _GeraXMLCTeService = GeraXMLCTeService;
            _MontaXMLCTeService = MontaXMLCTeService;
            _CommunicationSefazService = CommunicationSefazService;
            _Cte_endereco_web_service = Cte_endereco_web_service;
            _Entregas_cte_transmitido = Entregas_cte_transmitido;
        }
        #endregion

        public void InstanciaFiliaisEmissoras(string cod_empresa)
        {
            var emissora =  _RecuperaFiliaisEmissorasAtivasSerivce.RecuperaFiliaisEmissorasAtivas(cod_empresa);

            if (emissora.ativo == true)
            {
                string xmlEnvio = string.Empty;
                var objEmit = new EmitDTO();
                var objRem = new RemDTO();
                var objExped = new ExpedDTO();
                var objDest = new DestDTO();
                var objVPrest = new VPrestDTO();
                var objImp = new ImpDTO();
                var objIde = new IdeDTO();
                var coduf = new CTeTools();

                MapperFactory.CarregaMapper(Processo.XMLCTE);

                var ret = _ProcessaCTeGeraSEFAZService.DadosProcessoGeraCTe(cod_empresa);


                if (ret.Count > 0)
                { 
                    foreach (var itemXML in ret)
                    {   
                        var store = CertificadoDigital.ObterX509Store(OpenFlags.ReadOnly);
                        var objCompleto = itemXML;

                        itemXML.Remetente_cod_uf = coduf.RetornaCodigoUF(itemXML.Emitente_uf);

                        //if (itemXML.StatusSefaz != null && itemXML.StatusSefaz != "103")
                        //{
                        //    itemXML.Cte_tipo = "5";
                        //}

                        if (itemXML.Cte_tipo == "0")
                        {
                            objIde = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, IdeDTO>(itemXML);
                            objEmit    = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, EmitDTO>(itemXML);
                            objRem     = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, RemDTO>(itemXML);
                            objExped   = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, ExpedDTO>(itemXML);
                            objDest    = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, DestDTO>(itemXML);
                            objVPrest  = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, VPrestDTO>(itemXML);
                            objImp     = MapperFactory.Mapper?.Map<Entregas_cte_dados_gerados_detalhe, ImpDTO>(itemXML); 
                        }

                        #region Em status de debug força operar em Homologação
                        if (System.Diagnostics.Debugger.IsAttached)
                        {                             
                            execProd = ((int)CTEEnums.Ambiente.homologacacao).ToString();
                            string homologacao = "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                            objIde.TpAmb = execProd;
                            objRem.xNome = homologacao;
                            objExped.xNome = homologacao;
                            objDest.xNome = homologacao;
                            objEmit.xNome = homologacao;
                        }
                        else
                        {
                            execProd = ((int)CTEEnums.Ambiente.producao).ToString();
                            objIde.TpAmb = execProd;
                        }
                        #endregion

                        #region Popula dados do WS Sefaz
                        if (objWS == null)
                        {
                            objWS = _Cte_endereco_web_service.ConsultaDadosWSSefaz();
                        }

                        var ser = objWS.Find(x => x.ambiente.Equals(objIde.TpAmb) && x.uf.Equals(itemXML.Emitente_uf) && x.desc_servico.Equals(CTEEnums.FUNCAO.CTeRecepcao.ToString()));

                        string serial = ser.numero_serie.ToString();
                        string urlSEFAZ = ser.url;

                        #endregion

                        foreach (var item in store.Certificates)
                        {
                            if (item.SerialNumber != null && item.SerialNumber.ToUpper().Equals(serial.ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                            {
                                certif = item;
                            }
                        }

                        #region Disntingue se CTe emissão,  cancelamento, carta de correção . 




                        switch (itemXML.Cte_tipo)
                        {
                            case "0": //Emissão  
                                xmlEnvio = _GeraXMLCTeService.GeraXMLCTe(objExped, objDest, objRem, objIde, objImp, objEmit, objVPrest, itemXML, certif);
                                break;
                            case "1": //Complementar 
                                xmlEnvio = _GeraXMLCTeService.GeraXMLCTe(objExped, objDest, objRem, objIde, objImp, objEmit, objVPrest, itemXML, certif);
                                break;
                            case "2": //Anulacao 
                                break;
                            case "3": //Substituicao 
                                break;
                            case "4": //cancelamento

                                var objCan = new InfCTeCancelamentoDTO();

                                objCan.sCOrgaoOrigem =  coduf.RetornaCodigoUF(itemXML.Emitente_uf);
                                objCan.sChaveCTe =      itemXML.Cte_chave;
                                objCan.sCNPJEmitente =  itemXML.Emitente_cnpj;
                                objCan.sdescEvento = CTEEnums.TipoCTe.Cancelamento.ToString();
                                objCan.sJustificativa = itemXML.Cte_cancelamento_motivo;
                                objCan.sNPrtolocoloAutorizacao = itemXML.Cte_recibo_sefaz;
                                objCan.sNumeroSequenciaEvento = "";
                                objCan.sTpAmbiente = itemXML.Cte_hambiente_emissao;
                                //objCan.sTPevento="";                                

                                xmlEnvio = _GeraXMLCTeService.GeraXMLCancelamento(objCan, certif);
                                break;

                            case "5": // Correção
                                var objCorrecao = new InfCTeCorrecaoDTO();
                                objCorrecao.sChaveCTe = itemXML.Cte_chave;
                                objCorrecao.Status_cte_sefaz = itemXML.StatusSefaz;

                                objCorrecao.sCOrgaoOrigem = coduf.RetornaCodigoUF(itemXML.Emitente_uf);
                                objCorrecao.sChaveCTe = itemXML.Cte_chave;
                                objCorrecao.sCNPJEmitente = itemXML.Emitente_cnpj;
                                objCorrecao.sdescEvento = CTEEnums.TipoCTe.Cancelamento.ToString();
                                objCorrecao.sJustificativa = string.Empty;
                                objCorrecao.sNPrtolocoloAutorizacao = itemXML.Cte_recibo_sefaz;
                                objCorrecao.sNumeroSequenciaEvento = string.Empty;
                                objCorrecao.sTpAmbiente = itemXML.Cte_hambiente_emissao;

                                xmlEnvio = _GeraXMLCTeService.GeraXMLCorrecao(objCorrecao, objCompleto, certif);

                                break;
                        } 
                        #endregion
                        try
                        {
                            var retr = _CommunicationSefazService.RequestReception(xmlEnvio, urlSEFAZ, certif);

                            if (retr != string.Empty)
                            {
                                _Entregas_cte_transmitido.TreatRecordResponseRecepcao(retr, itemXML);
                                //WriteFile.WriteXMLCTe(xmlEnvio, itemXML.Cte_chave); 
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }                        
                    }
                }
                else
                {
                    //log inf que não há cte para emiter nesse momento. 
                }
            }
            else
            {
                //log inf que a empresa emissora não esta ativa.
            }
        }



    }
}
