using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace HermesService.Domain.Service
{
    public class MontaXMLCTeService : IMontaXMLCTeService
    {
        private string xmls = "http://www.portalfiscal.inf.br/cte";
        //private string baseC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><infCte Id=\"{0}\" versao=\"3.00\" ><CTe></CTe></infCte>";
        private string baseC = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><infCte versao=\"3.00\" Id=\"{0}\"><CTe></CTe></infCte>";
        private string xobs = "A carga foi disponibilizada no endereco da emitente pelo Expedidor por conta e ordem do tomador do servico";
        private string infcte = string.Empty;
        /// <summary>
        /// MontaXMLCTeService <c> Usa a propriedade dos objetos gerados para montar o objeto final de cada elemento do XML do CTe </c>
        /// </summary>


        #region <dest>
        public string FormataTagDest(DestDTO objDest)
        {
            /// <summary>
            /// FormataTagDest <c> Dados do elemento "Dest" que compoe o XML do CTe </c>
            /// </summary>
            /// <param name="DestDTO"></param>
            /// <returns>String no formato xml do elemento "Dest".</returns>
            if (objDest.xBairro == string.Empty)
            {
                objDest.xBairro = "BAIRRO NAO CADASTRADO";
            }

            
            string tpDoc = "CPF";
            if (objDest.Cpf.Length == 14)
            {
                tpDoc = "CNPJ";
            }
            if (string.IsNullOrEmpty(objDest.nro.Replace(" ","")))
            {
                objDest.nro = "S/N";
            }


            XElement xmlSec = new XElement("dest",
                              new XElement(tpDoc, objDest.Cpf),
                              new XElement("IE", "ISENTO"),
                              new XElement("xNome", objDest.xNome),
                              string.IsNullOrEmpty(objDest.fone) ? null : new XElement("fone", objDest.fone),
                              new XElement("enderDest",
                              new XElement("xLgr", objDest.xLgr.Trim()),
                              new XElement("nro", objDest.nro),                              
                              new XElement("xBairro", objDest.xBairro),
                              new XElement("cMun", objDest.cMun),
                              new XElement("xMun", objDest.xMun),
                              new XElement("CEP", objDest.CEP),
                              new XElement("UF", objDest.Uf),
                              new XElement("cPais", (int)CTEEnums.CodigoPais.Brasil),
                              new XElement("xPais", CTEEnums.CodigoPais.Brasil)));


            return xmlSec.ToString();
             
        }
        #endregion

        #region <exped>
        public string FormataTagExped(ExpedDTO objExped)
        {
            if (string.IsNullOrEmpty(objExped.nro))
            {
                objExped.nro = "S/N";
            }
            try
            {
                XElement xmlSec =
                        new XElement("exped",
                            new XElement("CNPJ", objExped.CNPJ),// "11497307000166"),
                            new XElement("IE", objExped.IE), //"258951486"),
                            new XElement("xNome", objExped.xNome),//"CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"),
                            new XElement("fone", objExped.fone),//"11999999999"),
                        new XElement("enderExped",
                            new XElement("xLgr", objExped.xLgr), // "R ANFILOQUIO NUNES PIRES DE 2702 A 4440 LADO PAR"),
                            new XElement("nro", objExped.nro), // "3500"),
                            new XElement("xCpl", objExped.nro == null ? "S/N" : objExped.nro),
                            new XElement("xBairro", objExped.xBairro), //"BELA VISTA"),
                            new XElement("cMun", objExped.cMun), // "4205902"),
                            new XElement("xMun", objExped.xMun),//"Gaspar"),
                            new XElement("CEP", objExped.CEP), //"89110645"),
                            new XElement("UF", objExped.UF), // "SC"),
                            new XElement("cPais", (int)CTEEnums.CodigoPais.Brasil),
                            new XElement("xPais", CTEEnums.CodigoPais.Brasil)));

                return xmlSec.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region <emit>
        public string FormataTagEmit(EmitDTO objEmit)
        {

            if (string.IsNullOrEmpty(objEmit.nro))
            {
                objEmit.nro = "S/N";
            }

            XElement xmlSec =
            new XElement("emit",
                new XElement("CNPJ", objEmit.CNPJ),
                new XElement("IE", objEmit.IE),
                new XElement("xNome", objEmit.xNome),
                new XElement("xFant", objEmit.xNome),
            new XElement("enderEmit",
                new XElement("xLgr", objEmit.xLgr),
                new XElement("nro", objEmit.nro),
               // !string.IsNullOrEmpty(objEmit.nro) ? new XElement("nro", objEmit.nro) : null,
                new XElement("xBairro", objEmit.xBairro),
                new XElement("cMun", objEmit.cMun),
                new XElement("xMun", objEmit.xMun),
                new XElement("CEP", objEmit.CEP),
                new XElement("UF", objEmit.UF),
                //new XElement("fone", objEmit.fone)));
                !string.IsNullOrEmpty(objEmit.fone) ? new XElement("fone", objEmit.fone) : null));




            return xmlSec.ToString();
        }
        #endregion

        #region <ide>        
        public string FormataTagIde(IdeDTO objIde)
        {
            XElement xmlSec =
                new XElement("ide",
                new XElement("cUF", objIde.CUF),
                new XElement("cCT", objIde.CCT),
                new XElement("CFOP", objIde.CFOP),
                new XElement("natOp", objIde.NatOp),
                new XElement("mod", objIde.Mod),
                new XElement("serie", "1"),
                new XElement("nCT", objIde.NCT),
                new XElement("dhEmi", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")),
                new XElement("tpImp", objIde.TpImp),
                new XElement("tpEmis", "1"),
                new XElement("cDV", objIde.CDV),
                new XElement("tpAmb", objIde.TpAmb),
                new XElement("tpCTe", objIde.TpCTe),
                new XElement("procEmi", objIde.ProcEmi),
                new XElement("verProc", "V1"),
                new XElement("cMunEnv", objIde.CMunEnv),
                new XElement("xMunEnv", objIde.XMunEnv),
                new XElement("UFEnv", objIde.UFEnv),
                new XElement("modal", objIde.Modal.PadLeft(2,'0')),
                new XElement("tpServ", objIde.TpServ),
                new XElement("cMunIni", objIde.CMunIni),
                new XElement("xMunIni", objIde.XMunIni),
                new XElement("UFIni", objIde.UFIni),
                new XElement("cMunFim", objIde.CMunFim),
                new XElement("xMunFim", objIde.XMunFim),
                new XElement("UFFim", objIde.UFFim),
                new XElement("retira", objIde.Retira),
                new XElement("indIEToma", "1"),
                new XElement("toma3",
                    new XElement("toma", 0)));

            return xmlSec.ToString();
        }
        #endregion

        #region  <imp>
        public string FormataTagImp(ImpDTO objImp)
        {
            //#todo ajuste da fortamcao da aliq do icms.

            var aliq_icms = Convert.ToDecimal(objImp.PICMS).ToString("N2").Replace(",",".");

            XElement xmlSec =
                new XElement("imp",
                new XElement("ICMS",
                new XElement("ICMS00",
                    new XElement("CST", objImp.CST),
                    new XElement("vBC", objImp.VBC),
                    new XElement("pICMS", objImp.PICMS),
                    new XElement("vICMS", objImp.VICMS))),
                new XElement("vTotTrib", objImp.VICMS),
                new XElement("infAdFisco", objImp.VICMS));    

            return xmlSec.ToString();
        }
        #endregion

        #region <rem>
        public string FormataTagRem(RemDTO objRem)
        {
            XElement xmlSec =
            new XElement("rem",
                new XElement("CNPJ", objRem.CNPJ),
                new XElement("IE", objRem.IE),
                new XElement("xNome", objRem.xNome),
                new XElement("xFant", objRem.xNome),
                //new XElement("fone", objRem.fone),
                !string.IsNullOrEmpty(objRem.fone) ? new XElement("fone", objRem.fone) : null,
            new XElement("enderReme",
                new XElement("xLgr", objRem.xLgr),
                new XElement("nro", objRem.nro == null ? "S/N" : objRem.nro),
                new XElement("xCpl", objRem.nro == null ? "S/N" : objRem.nro),
                new XElement("xBairro", objRem.xBairro),
                new XElement("cMun", objRem.cMun),
                new XElement("xMun", objRem.xMun),
                new XElement("CEP", objRem.CEP),
                new XElement("UF", objRem.UF),
                new XElement("cPais", (int)CTEEnums.CodigoPais.Brasil),
                new XElement("xPais", CTEEnums.CodigoPais.Brasil)));

            return xmlSec.ToString();
        }
        #endregion

        #region <vprest>
        public string FormataTagVPrest(VPrestDTO objVPrest)
        {
            XElement xmlSec =
                new XElement("vPrest",
                    new XElement("vTPrest", objVPrest.VTPrest),
                    new XElement("vRec", objVPrest.VRec),
                new XElement("Comp",
                    new XElement("xNome", "Frete Valor"),
                    new XElement("vComp", objVPrest.VCompFrete)),
                new XElement("Comp",
                new XElement("xNome", "Valor do ICMS"),
                    new XElement("vComp", objVPrest.VCompICMS)));

            return xmlSec.ToString();
        }
        #endregion 

        #region Tags <autXML>| <tagCompl> | <infCteComp>
        public Tuple<string, string, string> FormataTagXMLCondicional(Entregas_cte_dados_gerados_detalhe objDetalhe)
        {

            if (string.IsNullOrEmpty(objDetalhe.Numero_Emit))
            {
                objDetalhe.Numero_Emit = "S/N";
            }

            var xmlSec =
                new XElement("receb",
                    new XElement("CNPJ", objDetalhe.CNPJ_Emissor),
                    new XElement("IE", objDetalhe.Insc_est_Emit),
                    new XElement("xNome", objDetalhe.Emitente_nome),
                    new XElement("xFant", objDetalhe.Emitente_nome),
                new XElement("enderEmit",
                    new XElement("xLgr", objDetalhe.Endereco_Emit),
                    new XElement("nro", objDetalhe.Numero_Emit),
                    new XElement("xBairro", objDetalhe.Bairro_Emit),
                    new XElement("cMun", objDetalhe.Emitente_cidade_cod_ibge),
                    new XElement("xMun", objDetalhe.Cidade_Emit),
                    new XElement("CEP", objDetalhe.Cep_Emit),
                    new XElement("UF", objDetalhe.Emitente_uf),
            //new XElement("fone", objDetalhe.Destinatario_telefone))).ToString();
            !string.IsNullOrEmpty(objDetalhe.Destinatario_telefone) ? new XElement("fone", objDetalhe.Destinatario_telefone) : null)).ToString();
                 // --1
                 var tagAutXML =
                     new XElement("autXML",
                     new XElement("CNPJ", objDetalhe.Emitente_cnpj)).ToString();

                 // --2
                 XNamespace aw = "xCampo";

            string xCaracAd = string.Empty;

            if (objDetalhe.Cte_tipo == "0") //#TODO VALIDAR COMO VALIDAR SE O PEDIDO É, DEVOLUÇÃO/ NORMAL ETC, ETC...
            {
                xCaracAd = CTEEnums.Operacao.NORMAL.ToString(); 
            }
            else if (objDetalhe.Cte_tipo == "2")
            {

            }


            if (objDetalhe.Cte_cancelamento_motivo != "null")
            {
                xobs = objDetalhe.Cte_cancelamento_motivo;
            }

            var tagCompl =
                new XElement("compl",
                new XElement("xCaracAd", xCaracAd),
                new XElement("Entrega",
                new XElement("semData",
                new XElement("tpPer", 0)),
                new XElement("semHora",
                new XElement("tpHor", 0))),
                new XElement("xObs", xobs),
                new XElement("ObsCont", 
                new XElement("xTexto", "O valor aproximado dos tributos e de RS " + objDetalhe.Vlr_icms))).ToString().Replace(",",".");

            tagCompl = tagCompl.Replace("<ObsCont>", "<ObsCont xCampo=\"Lei da Transparencia\">");
            // --3 infCteComp

            string tagCTeCompl = string.Empty;

            if (objDetalhe.Cte_tipo == CTEEnums.TipoCTe.Complementar.ToString())
            {
                tagCTeCompl = new XElement("chCTe", objDetalhe.Cte_chave_anterior).ToString();
            }


            // --4  infCteAnu Anulação

            string taginfCteAnu = string.Empty;
            if (objDetalhe.Cte_tipo == CTEEnums.TipoCTe.Anulacao.ToString())
            {
                taginfCteAnu = new XElement("chCTe", objDetalhe.Cte_chave_anterior,
                               new XElement("dEmi",   ""     )).ToString();
            }


            return new Tuple<string, string, string>(tagCompl, xmlSec, tagCTeCompl); 
        } 
        #endregion

        public Tuple<string, string, string> FormataTagXMLConst(Entregas_cte_dados_gerados_detalhe objDetalhe)
        {
            throw new NotImplementedException();
        }

        public string AssinaXml(string xmlassinatura)
        {
            string xmlFinal = string.Empty;

            return xmlFinal;
        }
        public string FormataTagInfCTeNorm(Entregas_cte_dados_gerados_detalhe objDetalhe)
        {
            string ret = string.Empty;

            string peso = objDetalhe.Peso_arquivo.ToString("0.0000").Replace(",", ".");

            switch (objDetalhe.Cte_tipo)
            {
             
                case "0":
                    var taginfCTeNorm =
                new XElement("infCTeNorm",
                    new XElement("infCarga",
                        new XElement("vCarga", objDetalhe.Vlr_nfe),
                        new XElement("proPred", "DIVERSOSDIVERSO"),
                        new XElement("xOutCat", "DIVERSOS"), 
                        new XElement("infQ",
                            new XElement("cUnid", "01"),
                            new XElement("tpMed", "PESO"),
                            new XElement("qCarga", peso)),
                        new XElement("vCargaAverb", objDetalhe.Vlr_nfe)),
                    new XElement("infDoc",
                        new XElement("infNFe",
                            new XElement("chave", objDetalhe.Nfe_chave),
                            new XElement("dPrev", DateTime.Now.AddDays(3).ToString("yyyy-MM-dd")))), //#TODO PREVISAO ENTREGA
                    new XElement("infModal",
                    new XElement("rodo",
                    new XElement("RNTRC", objDetalhe.Emitente_Rntrc.TrimStart('0'))
                    )));


                    ret = taginfCTeNorm.ToString();
                    break;

                case "1":
                    //Complementar
                    break;

                case "2":
                    //Anulacao
                    break;
            }
            return ret;
        }

        public string FormataXMLFinal(string xml, string assinatura, string chaveCTe)
        {
            var xmls = XElement.Parse(xml);
            var assign = XElement.Parse(assinatura);

            xmls.Add(new XElement(assinatura));

            string infCTe = string.Empty;
            string idCte = "CTe" + chaveCTe;
            string versao = "3.00";
            //infCTe = "<infCte  Id=\"{1}\" versao=\"{0}\">";
            infCTe = "<infCte  versao=\"{0}\" Id=\"{1}\">";
            infCTe = string.Format(infCTe, versao, idCte);


            xmls.Element("cte").Element("infCte").Add(assign);

            return xml;
        }

        #region Uni todos Nodes no XML
        public Tuple<string,string> FormataXMLFinal(string TESTE,string objCompl, string objInfCTeNorm, string objDest, string objExped, string objRem, string objIde, string objImp, string objEmit, string objVPrest, 
                                      Entregas_cte_dados_gerados_detalhe objDetalhe, Tuple<string, string, string> propGerais)
        {
            string idCte = "CTe" + objDetalhe.Cte_chave;

            try
            {
                string infCTeF = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><infCte versao=\"3.00\" Id=\""+"CTe" + objDetalhe.Cte_chave + "\"><CTe></CTe></infCte>";
                infcte = string.Format(infCTeF, "CTe" + objDetalhe.Cte_chave);
                XNamespace aw = xmls ;

                var ide = XElement.Parse(objIde);
                var compl = XElement.Parse(objCompl);

                var emit = XElement.Parse(objEmit);
                var rem = XElement.Parse(objRem);
                var exped = XElement.Parse(objExped);
                var dest = XElement.Parse(objDest);
                var vprest = XElement.Parse(objVPrest);
                var imp = XElement.Parse(objImp);               
                var infCTeNorm = XElement.Parse(objInfCTeNorm);
                var autXML = XElement.Parse(propGerais.Item2);

                string qrCodCTe = "https://homologacao.nfe.fazenda.sp.gov.br/cteConsulta/qrCode?chCTe={0}&tpAmb={1}";
                qrCodCTe = string.Format(qrCodCTe, objDetalhe.Cte_chave, "2");

                XElement xml = new XElement("CTe", "",
                               new XElement("infCte", ""),
                               new XElement("infCTeSupl","",
                               new XElement("qrCodCTe", qrCodCTe))
                             );

                var teste = xml.ToString();

                xml.Element("infCte").Add(ide);
                xml.Element("infCte").Add(compl);
                xml.Element("infCte").Add(emit);
                xml.Element("infCte").Add(rem);
                xml.Element("infCte").Add(exped);
                xml.Element("infCte").Add(dest);
                xml.Element("infCte").Add(vprest);
                xml.Element("infCte").Add(imp);
                xml.Element("infCte").Add(infCTeNorm);


                xml = XElement.Parse(xml.ToString().Replace("<cte xmlns=\"\">", "<cte>"));
                xml = XElement.Parse(xml.ToString().Replace("<infModal>", "<infModal versaoModal=\"3.00\">"));

                var xmlFormated = ReplacePropriedadesCTe(xml.ToString(), objDetalhe.Cte_chave);
                
                var xmlBruto = xml.ToString(); 

                return new Tuple<string, string>(xmlFormated, xmlBruto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public string MontaXMLCteRetRecepcao(string tpAmb, string nRec)
        {
            string soap =
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
                "{0}" +
                "</cteDadosMsg>" +
                "</soap12:Body>" +
                "</soap12:Envelope>";

            var xml =
                new XElement("consReciCTe",
                new XElement("tpAmb", tpAmb),
                new XElement("nRec", nRec)).ToString();

            xml = string.Format(soap, xml);
            xml = xml.Replace("<consReciCTe>", "<consReciCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"3.00\">");
            xml = StringTolls.RemoveEspacoTagsXML(xml);

            return xml;
        }

        public string ReplacePropriedadesCTe(string xml, string chaveCTe)
        {
            string infCTe = string.Empty;
            string idCte = "CTe" + chaveCTe;
            string versao = "3.00";
            infCTe = "<infCte Id=\"{1}\" versao=\"{0}\">";
            infCTe = string.Format(infCTe, versao, idCte);

            xml = xml.Replace("<cte xmlns=\"\">", "<cte>");
            xml = xml.Replace("<CTe>", "<CTe xmlns=\"http://www.portalfiscal.inf.br/cte\">");   
            xml = xml.Replace(@"<infCte>", infCTe);

            var config = xml.ToString();

            xml = xml.ToString().Replace("&quot;", "\"");

            return xml;
        }

        #region Elemento para CTe complementar
        public string FormataTagComplementar(Entregas_cte_dados_gerados_detalhe objDetalhe)
        {
            var test = CTEEnums.TipoCTe.Normal.ToString();
            throw new NotImplementedException();
        }

        #endregion
    }
}
