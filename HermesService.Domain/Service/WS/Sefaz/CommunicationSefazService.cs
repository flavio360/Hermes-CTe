using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace HermesService.Domain.Service.WS.Sefaz
{
    public class CommunicationSefazService : ICommunicationSefazService
    {
        protected string result = "";

        #region CTeRecepcao 
        public string RequestReception(string xml, string urlSefaz, X509Certificate2 cert)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSefaz);

                req.Timeout = 30000; //30000ms -> 30s
                req.ContentType = "application/soap+xml; charset=utf-8";
                req.Method = "POST";
                req.ClientCertificates.Add(cert);

                using (Stream stm = req.GetRequestStream())
                {
                    stm.ReadTimeout = 20000; //20000ms -> 20s
                    stm.WriteTimeout = 20000;
                    using (StreamWriter stmw = new StreamWriter(stm, new UTF8Encoding(false)))
                    {
                        stmw.Write(xml);
                        stmw.Close();
                    }
                }

                WebResponse response = req.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);

                result = sr.ReadToEnd();
                sr.Close();                
            }
            catch (Exception ex)
            {
                WriteFile.WriteWSCTeLog("Erro serviço de requisição CTe",null, ex.Message + " Na URL: "+ urlSefaz + " ,verificar o certificado!");
            }

            return result;
        }
        #endregion

        #region CTeRetRecepcao
        public string ResquestStatus(string soap, X509Certificate2 cert, string url_webservice)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url_webservice);
            
            req.ContentType = "application/soap+xml; charset=utf-8";
            req.Method = "POST";
            req.ClientCertificates.Add(cert);
            
            using (Stream stm = req.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm, new UTF8Encoding(false)))
                {
                    stmw.Write(soap);
                    stmw.Close();
                }
            }
            
            WebResponse response = req.GetResponse();
            Stream responseStream = response.GetResponseStream();
            
            response = req.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            result = sr.ReadToEnd();
            sr.Close();
            
            return result.ToString();

        }
        #endregion

        public string RequestServiceStatus()
        {

            return "";
        }

        public void RecordResponse(string xmlResponse, string codEntrega)
        {
            Entregas_cte_erro cteErro = new Entregas_cte_erro();
            var retSefaz = new XmlDocument();
            retSefaz.LoadXml(xmlResponse);

            XmlNodeList objRetEnviCte = retSefaz.GetElementsByTagName("retEnviCte");

            string cStat = objRetEnviCte[0]["cStat"].ChildNodes[0].InnerText;
            string xMotivo = objRetEnviCte[0]["xMotivo"].ChildNodes[0].InnerText;
            string xNrecibo = objRetEnviCte[0]["infRec"].ChildNodes[0].InnerText;
            string uf = objRetEnviCte[0]["cUF"].ChildNodes[0].InnerText;
            string dhRecbto = objRetEnviCte[0]["infRec"].ChildNodes[1].InnerText;
            string tMed = objRetEnviCte[0]["infRec"].ChildNodes[2].InnerText;


            if (!cStat.Equals(((int)CTEEnums.STATUS_SEFAZ.LoteRecebido).ToString()))//#TODO Fazer review dos status para comparação do response.!
            {
                cteErro.Cod_cte_id = cStat;
                cteErro.Cod_entrega = codEntrega;
                cteErro.Data_correcao = null;
                cteErro.Data_inclusao = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                cteErro.Usuario_correcao = null;
                cteErro.Observacao_erro = xMotivo;
            }
            else
            {
                //cteResponseSefaz.cod_entrega = codEntrega;
                //cteResponseSefaz.cte_data_registro_ret_sefaz = dhRecbto;
                //cteResponseSefaz.cte_hambiente_emissao = objIde.TpAmb;
                //cteResponseSefaz.cte_id_lote = objIde.NCT;
                //cteResponseSefaz.cte_numero = objIde.NCT;
                //cteResponseSefaz.cte_recibo_sefaz = xNrecibo;
                //cteResponseSefaz.cte_status = cStat;
                //cteResponseSefaz.id = " ";
                //cteResponseSefaz.uf_sefaz = uf;
            }
        }
    }

}
