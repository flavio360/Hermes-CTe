using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service.Base;
using HermesService.Domain.Utilities;
using HermesService.Domain.Utilities.Certificado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace HermesService.Domain.Service
{
    public class GeraXMLCTeService : BaseService, IGeraXMLCTeService
    {
        #region construtores e interfaces
        List<cte_endereco_web_service> objWS = null;
        private readonly IMontaXMLCTeService _MontaXMLCTe;
        private readonly ICommunicationSefazService _CommunicationSefaz;
        private readonly IEntregas_cte_envio_ftpService _Entregas_cte_envio_ftp;
        private readonly IEntregas_cte_erroRepository _Entregas_cte_erro;
        private readonly ICte_endereco_web_serviceService _Cte_endereco_web_service;
        protected string versaoCTe = "3.00";
        private string xmls = "http://www.portalfiscal.inf.br/cte";
        private string codigo_UF = string.Empty;
        private string vrs = string.Empty;
        private string tpEvento = "110111"; //código correção


        Entregas_cte_transmitido cteResponseSefaz = new Entregas_cte_transmitido();
        
        string execProd = string.Empty;
        X509Certificate2 certif = null;
        string xmlFinal = string.Empty;
        string soap = string.Empty;

        public GeraXMLCTeService
        (
            IEntityRepository repo,
            IMontaXMLCTeService MontaXMLCTe,
            ICommunicationSefazService CommunicationSefaz,
            IEntregas_cte_erroRepository Entregas_cte_erro,
            IEntregas_cte_envio_ftpService Entregas_cte_envio_ftp,
            ICte_endereco_web_serviceService Cte_endereco_web_service
        ) : base(repo)
        {
            _MontaXMLCTe = MontaXMLCTe;
            _CommunicationSefaz = CommunicationSefaz;
            _Entregas_cte_envio_ftp = Entregas_cte_envio_ftp;
            _Entregas_cte_erro = Entregas_cte_erro;
            _Cte_endereco_web_service = Cte_endereco_web_service;            
        }
        #endregion

        #region CTE EMISSÃO NORMAL
        public string GeraXMLCTe(ExpedDTO objExped, DestDTO objDest, RemDTO objRem, IdeDTO objIde, ImpDTO objImp, EmitDTO objEmit, VPrestDTO objVPrest, Entregas_cte_dados_gerados_detalhe objDetalhe, X509Certificate2 cert)
        {
            string cteComplementar = string.Empty;
            #region Popula dados do WS Sefaz
            if (objWS ==null)
            {
                objWS = _Cte_endereco_web_service.ConsultaDadosWSSefaz();
            }

            var ser = objWS.Find(x => x.ambiente.Equals(objIde.TpAmb) && x.uf.Equals(objEmit.UF) && x.desc_servico.Equals(CTEEnums.FUNCAO.CTeRecepcao.ToString()));

            string serial = ser.numero_serie.ToString();
            string urlSEFAZ = ser.url;

            #endregion
            try
            {
                #region Validação para tratamento de produtos importados
                if (objRem.UF == "EX")
                {
                    //codição para tratar origem Exterior
                }
                #endregion

                #region Faz unificação de todos elementos que compõe o XML do CTe

                var propIde = _MontaXMLCTe.FormataTagIde(objIde);
                var propEmit = _MontaXMLCTe.FormataTagEmit(objEmit);
                var propDest = _MontaXMLCTe.FormataTagDest(objDest);
                var propExped = _MontaXMLCTe.FormataTagExped(objExped);
                var propRem = _MontaXMLCTe.FormataTagRem(objRem);
                var propImp = _MontaXMLCTe.FormataTagImp(objImp);
                var propVPrest = _MontaXMLCTe.FormataTagVPrest(objVPrest);
                var propInfCTeNorm = _MontaXMLCTe.FormataTagInfCTeNorm(objDetalhe);
                var propGerais = _MontaXMLCTe.FormataTagXMLCondicional(objDetalhe);

                var tpCTe = ((int)(CTEEnums.TipoCTe.Complementar)).ToString();
                if (objDetalhe.Cte_tipo == tpCTe)
                {
                    cteComplementar = _MontaXMLCTe.
                }

                var xml = _MontaXMLCTe.FormataXMLFinal(propGerais.Item2, propGerais.Item1, propInfCTeNorm, propDest, propExped, propRem, propIde, propImp, propEmit, propVPrest, objDetalhe, propGerais);
                #endregion

                #region Carrega certificado e adiciona assinatura do mesmo no XML criado na etapa anterior

                var store = CertificadoDigital.ObterX509Store(OpenFlags.ReadOnly);
                
                foreach (var item in store.Certificates)
                {
                    if (item.SerialNumber != null && item.SerialNumber.ToUpper().Equals(serial.ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        certif = item;

                        var documento = new XmlDocument { PreserveWhitespace = true };

                        string certBase = certif.SignatureAlgorithm.FriendlyName;

                        var ass = new AssinaturaDigital();

                        string item1 = StringTolls.RemoveEspacoTagsXML(xml.Item1);
                        string item2 = StringTolls.RemoveEspacoTagsXML(xml.Item2);
                        //https://www.sefaz.rs.gov.br/Dfe/ValidadorXml/ValidaXml validar a string do "xmlFinal" nesta página. 
                        xmlFinal = ass.SignatureCTe(certif, objDetalhe.Cte_chave, item1, item2);

                        codigo_UF = objDetalhe.Remetente_cod_uf;
                        vrs = versaoCTe;
                        
                        soap = "" +
                                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                "<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">" +
                                "<soap12:Header>" +
                                "<cteCabecMsg xmlns=\"http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao\">" +
                                "<cUF>" + codigo_UF + "</cUF>" +
                                "<versaoDados>" + versaoCTe + "</versaoDados>" +
                                "</cteCabecMsg>" + 
                                "</soap12:Header>" +
                                "<soap12:Body>" +
                                "<cteDadosMsg xmlns=\"http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao\">" +
                                "<enviCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"3.00\">" +
                                "<idLote>" + objDetalhe.Cod_entrega + "</idLote>" + //Identificação do lote (número de controle de responsabilidade do emitente)

                                xmlFinal +

                                "</enviCTe>" +
                                "</cteDadosMsg>" +
                                "</soap12:Body>" +
                                "</soap12:Envelope>" +
                                "";

                        //soap = soap.Replace(Environment.NewLine, string.Empty);

                        soap = StringTolls.RemoveEspacoTagsXML(soap).ToString();

                        break;
                    }
                }
                //WriteFile.WriteXMLCTe(soap, objDetalhe.Cte_chave);
                #endregion

                #region SOAP Comunica com SEFAZ e faz tratativa do response

                #region Grava xml do CTe para atualização posteror quando autorizado.

                //select* from entregas_cte_envio_ftp;
                xmlFinal = xmlFinal.Replace(" xmlns=\"http://www.portalfiscal.inf.br/cte\"","");

                string xmlFormat = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                    "<cteProc xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"3.00\"> " +
                                        "#replace#" +
                                        "<protCTe versao=\"3.00\">" +
                                            "<infProt Id=\"CTe{0}\">" +
                                                "<tpAmb>{1}</tpAmb>" +
                                                "<verAplic>{2}</verAplic>" +
                                                "<chCTe>{3}</chCTe>" +
                                                "<dhRecbto>{4}</dhRecbto>" +
                                                "<nProt>{5}</nProt>" +
                                                "<digVal>{6}</digVal>" +
                                                "<cStat>{7}</cStat>" +
                                                "<xMotivo>{8}</xMotivo>" +
                                            "</infProt>" +
                                        "</protCTe>" +
                                    "</cteProc>";

                xmlFormat = xmlFormat.Replace("#replace#", xmlFinal);

                if (objDetalhe.Cte_status_atual != null)
                {
                    _Entregas_cte_envio_ftp.Update_entregas_cte_envio_ftp(objDetalhe.Cod_entrega, objDetalhe.Cte_chave, xmlFormat);
                }
                else
                {
                    _Entregas_cte_envio_ftp.Grava_entregas_cte_envio_ftp(xmlFormat, null, objDetalhe);
                }  

                #endregion

                return soap;                

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
        #endregion


        #region CTE CANCELAMENTO 
        public string GeraXMLCancelamento(InfCTeCancelamentoDTO ObjCancelamento, X509Certificate2 cert)
        {
          string sEstruturaXml =  "<?xml version=\"1.0\" encoding=\"UTF-8\"?> " +
                      "<eventoCTe  = \"http://www.portalfiscal.inf.br/cte\" versao =\"3.0\"> " +
                           "< infEvento Id =\"ID11011112345678901234567890123456789012345678\"> " +
                                "<cOrgao> XX </cOrgao> " +
                                "<tpAmb> 1 </tpAmb> " +
                                "<CNPJ> 01234567890123 </CNPJ> " +
                                "<chCTe> 01234567890123456789012345678901234567890123 </chCTe> " +
                                "<dhEvento> 2023 - 05 - 23T12: 00:00 - 03:00 </dhEvento> " +
                                         " <tpEvento > 110111 </tpEvento>" +
                                         " <nSeqEvento> 1 </nSeqEvento> " +
                                          "<verEvento> 3.00 </verEvento> " +
                                         " <detEvento versao= \"3.00\"  " +
                                               "<descEvento> Cancelamento </descEvento > " +
                                               "<nProt> 012345678901234 </nProt > " +
                                               "<xJust> Justificativa do cancelamento do CT - e.</xJust> " +
                                            " </detEvento> " +
                                         " </infEvento> " +
                                        "  <ignature xmlns = \"http://www.w3.org/2000/09/xmldsig#\" > " +
                              "  < !--Assinatura digital do evento de cancelamento-- >" +
                           " </Signature > " +
                       " </eventoCTe > " ;

            var ass = new AssinaturaDigital();

            return ass.GlobalSignatureCTe(cert, sEstruturaXml);
        }
        #endregion


        #region CTE CORREÇÃO
        public string GeraXMLCorrecao(InfCTeCorrecaoDTO ObjCorrecao, Entregas_cte_dados_gerados_detalhe objPedido, X509Certificate2 cert)
        {
            #region propriedades do método
            string sXCorrecao = string.Empty;
            string sEstruturaXml =
                                    "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" +
                                    "<eventoCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"4.00\">" +
                                       "<infEvento Id=\"ID{0}\">" + //CHAVE CTE
                                          "<cOrgao>{1}</cOrgao>" + //UF 
                                          "<tpAmb>{2}</tpAmb>" +  //AMBIENTE EMISSÃO
                                          "<CNPJ>{3}</CNPJ>" + //CNPJ EMISSOR
                                          "<chCTe>{4}</chCTe>" + //CHAVE CTE
                                          "<dhEvento>{5}</dhEvento>" +
                                          "<tpEvento>110111</tpEvento>" + // VALOR PADRÃO
                                          "<nSeqEvento>{6}</nSeqEvento>" +
                                          "<verEvento>1.00</verEvento>" +
                                          "<detEvento versaoEvento=\"1.00\">" +
                                             "<descEvento>Carta de Correção</descEvento>" +
                                             "<xCorrecao>{7}</xCorrecao>" + // INDICATIVO DO QUE SERÁ CORRIGIDO
                                             "<xCondUso>{8}</xCondUso>" + //TEXTO USO LIVRE
                                       "</detEvento>" +
                                       "</infEvento>" +
                                       "<Signature xmlns=\"http://www.w3.org/2000/09/xmldsig# \">"+
                                       "</Signature>" +
                                    "</eventoCTe>";
            #endregion 

            sEstruturaXml = sEstruturaXml.Replace("xmldsig# ", "xmldsig#");

            switch (ObjCorrecao.Status_cte_sefaz)
            {
                case "676":
                    //criar campo na ba se que vai gravar a mensagem de correção;
                    sXCorrecao = "Correção do CFOP de 6108 para 5353";
                    break;
            }


            sEstruturaXml = string.Format(sEstruturaXml,
                                      ObjCorrecao.sChaveCTe,
                                      ObjCorrecao.sCOrgaoOrigem,
                                      ObjCorrecao.sTpAmbiente,
                                      ObjCorrecao.sCNPJEmitente,
                                      ObjCorrecao.sChaveCTe,
                                      Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm")),
                                      "3",
                                      sXCorrecao,
                                      sXCorrecao
                );

            var ass = new AssinaturaDigital();

            return ass.GlobalSignatureCTe(cert, sEstruturaXml);

        }

        #endregion
    }
}
