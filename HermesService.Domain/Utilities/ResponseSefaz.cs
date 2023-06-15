using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HermesService.Domain.Utilities
{
    public static class ResponseSefaz
    {
        public static dynamic StringToObjReceivedSefaz(string xmlString, Entregas_cte_dados_gerados_detalhe dadosPedido)
        {
            var retSefaz = new XmlDocument();
            retSefaz.LoadXml(xmlString);
            var objReceived = new Entregas_cte_transmitido();
            XmlNodeList objRetEnviCte = retSefaz.GetElementsByTagName("retEnviCte");

            string cStat = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;

            if (cStat.Equals(((int)CTEEnums.STATUS_SEFAZ.LoteRecebido).ToString()))
            {             
                objReceived.cte_data_registro_ret_sefaz = objRetEnviCte[0]["infRec"].ChildNodes[1].InnerText;
                objReceived.cod_entrega = dadosPedido.Cod_entrega;
                objReceived.cte_recibo_sefaz = objRetEnviCte[0]["infRec"].ChildNodes[0].InnerText;
                objReceived.cte_numero = dadosPedido.Cte_numero;
                objReceived.cte_verAplic = objRetEnviCte[0]["verAplic"].ChildNodes[0].InnerText; 
                objReceived.cte_hambiente_emissao = objRetEnviCte[0]["tpAmb"].ChildNodes[0].InnerText; ;
                objReceived.cte_status = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;
                objReceived.uf_sefaz = dadosPedido.Emitente_uf;
                objReceived.cte_data_registro_ret_sefaz = objRetEnviCte[0]["infRec"].ChildNodes[1].InnerText;
            }
            else
            {
                objReceived.cte_data_registro_ret_sefaz = objRetEnviCte[0]["infRec"].ChildNodes[1].InnerText;
                objReceived.cod_entrega = dadosPedido.Cod_entrega;
                objReceived.cte_numero = dadosPedido.Cte_numero;
                objReceived.cte_hambiente_emissao = "";
                objReceived.cte_protocolo_sefaz = "";
                objReceived.cte_status = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;
            }

            return objReceived;

        }

        public static Entregas_cte_transmitido StringXML_X_ObjRetRecpcao(string xml)
        {
            Entregas_cte_transmitido objReceived = new Entregas_cte_transmitido();
            XmlNodeList objRetEnviCte = null;
            var retSefaz = new XmlDocument();
            retSefaz.LoadXml(xml);
            string cstat = string.Empty;
            objRetEnviCte = retSefaz.GetElementsByTagName("retConsReciCTe");
            var infprot = retSefaz.GetElementsByTagName("infProt");
            XmlNode elemento = retSefaz.SelectSingleNode("infProt");


            if (infprot.Count != 0)
            {                    
                objReceived.cte_recibo_sefaz = objRetEnviCte[0]["nRec"].ChildNodes[0].InnerText;

                objRetEnviCte = retSefaz.GetElementsByTagName("infProt");
                objReceived.cte_hambiente_emissao = objRetEnviCte[0]["tpAmb"].ChildNodes[0].InnerText;
                objReceived.xMotivo = objRetEnviCte[0]["xMotivo"].ChildNodes[0].InnerText;
                objReceived.cte_status = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;
                objReceived.cte_verAplic = objRetEnviCte[0]["verAplic"].ChildNodes[0].InnerText;
                objReceived.chCTe = objRetEnviCte[0]["chCTe"].ChildNodes[0].InnerText;

                if (objReceived.cte_status == "100")
                {
                    objReceived.cte_protocolo_sefaz = objRetEnviCte[0]["nProt"].ChildNodes[0].InnerText;
                    objReceived.digVal = objRetEnviCte[0]["digVal"].ChildNodes[0].InnerText;
                    objReceived.cte_data_registro_ret_sefaz = objRetEnviCte[0]["dhRecbto"].ChildNodes[0].InnerText;
                }

            }
            else
            {
                //caso rejeição
                objRetEnviCte = retSefaz.GetElementsByTagName("retConsReciCTe");
                objReceived.cte_verAplic = objRetEnviCte[0]["verAplic"].InnerText;
                objReceived.cte_recibo_sefaz = objRetEnviCte[0]["nRec"].ChildNodes[0].InnerText;
                objReceived.cte_status = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;
                objReceived.xMotivo = objRetEnviCte[0]["xMotivo"].ChildNodes[0].InnerText;
                objReceived.cte_hambiente_emissao = objRetEnviCte[0]["tpAmb"].ChildNodes[0].InnerText;
            }
            return objReceived;

        }
    }
}
