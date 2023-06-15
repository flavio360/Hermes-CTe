using HermesService.Application.Interfaces;
using HermesService.Application.Utilities;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service;
using HermesService.Domain.Service.WS.Sefaz;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace HermesService.Application.Service
{
    public class ProcessaConsultaCTeSefazApplication : IProcessaConsultaCTeSefazApplication
    {
        #region Construtores
        private readonly IEntregas_cte_transmitidoService _Entregas_cte_transmitidoService;
        private readonly ICte_endereco_web_serviceService _ICte_endereco_web_serviceService;
        private readonly ICommunicationSefazService _CommunicationSefazService;
        private readonly IObterCertificadoService _IObterCertificadoService;
        private readonly IFilaErroCteService _FilaErroCteService;
        private readonly IEntregas_cte_envio_ftpService _Entregas_cte_envio_ftp;
        public ProcessaConsultaCTeSefazApplication
        (
            IEntregas_cte_transmitidoService Entregas_cte_transmitidoService,
            ICte_endereco_web_serviceService  Cte_endereco_web_serviceService,
            ICommunicationSefazService CommunicationSefazService,
            IObterCertificadoService ObterCertificadoService,
            IFilaErroCteService FilaErroCteService,
            IEntregas_cte_envio_ftpService Entregas_cte_envio_ftpService
        )
        {
            _Entregas_cte_transmitidoService = Entregas_cte_transmitidoService;
            _ICte_endereco_web_serviceService = Cte_endereco_web_serviceService;
            _CommunicationSefazService = CommunicationSefazService;
            _IObterCertificadoService = ObterCertificadoService;
            _FilaErroCteService = FilaErroCteService;
            _Entregas_cte_envio_ftp = Entregas_cte_envio_ftpService;
        }
        #endregion
        public string ConsultaStatusCTeSefaz()
        {
            string retSefaz = string.Empty;
            try
            {
                var listWS = _ICte_endereco_web_serviceService.ConsultaDadosWSSefaz();
                
                var monta = new MontaXMLCTeService();
                var retObj = _Entregas_cte_transmitidoService.SelectEntregas_cte_transmitido();

                if (retObj != null)
                {
                    foreach (var item in retObj)
                    {
                        var objWS = listWS.Find(x => x.ambiente.Equals(item.cte_hambiente_emissao) && x.uf.Equals(item.uf_sefaz) && x.desc_servico.Equals(CTEEnums.FUNCAO.CTeRetRecepcao.ToString()));

                        var xmlConsulta = monta.MontaXMLCteRetRecepcao(item.cte_hambiente_emissao, item.cte_recibo_sefaz);

                        var certificado = _IObterCertificadoService.Retx509Certificate2(CertificadoDigital.ObterX509Store(OpenFlags.ReadOnly), objWS.numero_serie, objWS.ambiente);

                        retSefaz = _CommunicationSefazService.ResquestStatus(xmlConsulta, certificado, objWS.url);

                        var objResponse = ResponseSefaz.StringXML_X_ObjRetRecpcao(retSefaz);

                        if (objResponse.cte_status.Equals(((int)CTEEnums.STATUS_SEFAZ.Autorizado).ToString()))
                        {
                            string xml_autorizado = _Entregas_cte_envio_ftp.Consulta_entregas_cte_envio_ftp(item.cod_entrega, objResponse.chCTe);

                            xml_autorizado = string.Format(xml_autorizado,
                                                            objResponse.cte_protocolo_sefaz,
                                                            objResponse.cte_hambiente_emissao,
                                                            objResponse.cte_verAplic,
                                                            objResponse.chCTe,
                                                            objResponse.cte_data_registro_ret_sefaz,
                                                            objResponse.cte_protocolo_sefaz,
                                                            objResponse.digVal,
                                                            objResponse.cte_status,
                                                            objResponse.xMotivo
                                                            );

                            _Entregas_cte_envio_ftp.Update_entregas_cte_envio_ftp(item.cod_entrega, objResponse.chCTe, xml_autorizado);
                        }
                        else
                        {
                            _FilaErroCteService.GravaErroCte(item.cod_entrega, objResponse.cte_status, null);
                        }

                        objResponse.cod_entrega = item.cod_entrega;
                        objResponse.cte_status = ((int)CTEEnums.STATUS_CTE_IL.Enviado).ToString();

                        _Entregas_cte_transmitidoService.TreatRecordResponseRetRecepcao(objResponse);
                    }
                }                
            }            
            catch (Exception ex)
            {
                WriteFile.WriteWSCTeLog(CTEEnums.FUNCAO.CTeConsulta.ToString(),null, "msg: "+ ex.Message);
            }
            return retSefaz;
        }
        #region Implementacão para conuslta simplificada, não usar!
        /*public string ConsultaStatusCTeSefazOLD()
        {
            //string urlConsulta = " https://homologacao.nfe.fazenda.sp.gov.br/cteWEB/services/cteRetRecepcao.asmx"; //SC
            string urlConsulta = "https://homologacao.nfe.fazenda.sp.gov.br/cteWEB/services/cteRetRecepcao.asmx"; //SP
            //string urlConsulta = "https://hcte.fazenda.mg.gov.br/cte/services/CteRetRecepcao";//MG

            string nRecibo = "351000021269582"; //SP
            //string nRecibo = "311000132168662"; //MG
            //string nRecibo = "423000019343703"; //SC
            //string nRecibo = ""; //RJ


            string ambiente = "2";
            string serial = "008D575AAE3BF71E968EDCAD2E";//SP
            //string serial = "7BC33D104042A1A4D74E8128";//MG
            //string serial = "00F67DBE0BC5A0541DB79A3F1A";//SC
            //string serial = "64A1B5EEF54E0B942434B018";//RJ

            var monta = new MontaXMLCTeService();

            var xmlConsulta = monta.MontaXMLCteRetRecepcao(ambiente,nRecibo);

            var soap2 =
            "<?xml version=\"1.0\" encoding=\"utf - 8\"?>" +
            "<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">" +
            "<soap12:Header>" +
            "<cteCabecMsg xmlns=\"http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao\">" +
            "<cUF>35</cUF>" +
            "<versaoDados>3.00</versaoDados>" +
            "</cteCabecMsg>" +
            "</soap12:Header>" +
            "<soap12:Body>" +
            "<cteDadosMsg xmlns=\"http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao\">" +
            xmlConsulta +
            "</cteDadosMsg>" +
            "</soap12:Body>" +
            "</soap12:Envelope>";

            soap2 = soap2.Replace("<consReciCTe>", "<consReciCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"3.00\">");

            soap2 = StringTolls.RemoveEspacoTagsXML(soap2);
            string procSef;
            var cert = CertificadoDigital.ObterX509Store(OpenFlags.ReadOnly);

            foreach (var item in cert.Certificates)
            {
                if (item.SerialNumber != null && item.SerialNumber.ToUpper().Equals(serial.ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                {
                    certificado = item;

                    var documento = new XmlDocument { PreserveWhitespace = true };

                    string certBase = certificado.SignatureAlgorithm.FriendlyName;

                    break;
                }
            }
            return procSef = consultaStatus.ResquestStatus(soap2, certificado, urlConsulta);       
        }
        */
        #endregion
    }
}
