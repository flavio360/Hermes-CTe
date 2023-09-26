using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.Averbacao;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service.Base;
using HermesService.Domain.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using static HermesService.Domain.Utilities.AverbacaoEnums;

namespace HermesService.Domain.Service.WS.ATM
{
    public class EnviaCTeAverbacaoService :BaseService,  IEnviaCTeAverbacaoService
    {

        private readonly IAverbacaoRepository _DbAverbacao;

        public EnviaCTeAverbacaoService
        (
            IEntityRepository repo,
            IAverbacaoRepository Averbacao
        ) : base(repo)
        {
            _DbAverbacao = Averbacao;
        }

        public CTeAverbacao RequestAverbacao(string token, string Cte_xml, string URLWS, string codCliente, string codEntrega, Autenticacao_info_seguradora dadosToken)

        {
            CTeAverbacao post;
            WebResponse response;
            HttpStatusCode statusCode;
            var dados = Encoding.UTF8.GetBytes(Cte_xml);
            Uri serverUri = new Uri("http://" + URLWS);
            var requisicaoWeb = WebRequest.CreateHttp(serverUri);
            requisicaoWeb.Method = "POST";
            requisicaoWeb.Accept = "application/json";
            requisicaoWeb.ContentType = "application/xml";
            requisicaoWeb.ContentLength = dados.Length;
            requisicaoWeb.Headers.Add("Accept-Encoding", "gzip, deflate");
            requisicaoWeb.Headers.Add("Cache-Control", "no-cache");
           // requisicaoWeb.Headers.Add("Connection", "keep-alive");
            //requisicaoWeb.Headers.Add("cache-control", "no-cache");
            requisicaoWeb.Headers.Add("Authorization", $"Bearer {token}");

            StreamReader reader = null;
            Stream streamDados;
            try
            {
                using (var stream = requisicaoWeb.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }
                using (response = requisicaoWeb.GetResponse())
                {
                    streamDados = response.GetResponseStream();
                    reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                   // string json = "{\"Numero\":1063,\"Serie\":\"1\",\"Filial\":\"\",\"CNPJCli\":\"08957212000505\",\"TpDoc\":\"6\",\"InfAdic\":null,\"Averbado\":{\"dhAverbacao\":\"2023-08-29T15:54:16\",\"Protocolo\":\"TESTE\",\"DadosSeguro\":[{\"NumeroAverbacao\":\"0675110230895721200050557001000001063183\",\"CNPJSeguradora\":\"33065699000127\",\"NomeSeguradora\":\"SURA\",\"NumApolice\":\"25501008866\",\"TpMov\":\"1\",\"TpDDR\":\"3\",\"ValorAverbado\":\"682.05\",\"RamoAverbado\":\"55\"}]}}";
                    
                    post = JsonConvert.DeserializeObject<CTeAverbacao>(objResponse.ToString());

                    if (post.Erros != null)
                    {
                        string codigoErro = string.Empty;
                        post.Processado = "false";
                        foreach (var erro in post.Erros.Erro)
                        {
                            codigoErro = erro.Codigo;
                            continue;
                        }
                        //tratar os erros aqui.
                        if (codigoErro == ((int)ResponseSeguradora.token_invalido).ToString())
                        {
                            //token = _TokenRequestService.TokenRequestAsync();
                        }
                        
                    }

                    if (post.Averbado == null || post.Averbado.DhAverbacao == null)
                    {
                        post.Averbado = new Averbado
                        {
                            DhAverbacao = "1900-01-01 00:00:00"
                        };
                    }

                    if (response is HttpWebResponse httpResposta)
                    {
                        statusCode = httpResposta.StatusCode;
                        post.Processado = "true";
                        post.CodCliente = codCliente;
                        post.CodEntrega = codEntrega;
                        if (statusCode == HttpStatusCode.Created)
                        {                            
                            //GRAVAR DADOS RESPONSE
                            using (DalSession dalSession = new DalSession())
                            {
                                UnitOfWork UoW = dalSession.UnitOfWork;

                                _DbAverbacao.InstanciarUnidade(UoW);
                                var objWS = _DbAverbacao.InsertAverbacao(post);
                                
                            }
                        }
                    }
                }
                streamDados.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //if (statusCode. = HttpStatusCodeEnum.OK)
            //json = "{\"Numero\":1063,\"Serie\":\"1\",\"Filial\":\"\",\"CNPJCli\":\"08957212000505\",\"TpDoc\":\"6\",\"InfAdic\":null,\"Averbado\":{\"dhAverbacao\":\"2023-08-29T15:54:16\",\"Protocolo\":\"TESTE\",\"DadosSeguro\":[{\"NumeroAverbacao\":\"0675110230895721200050557001000001063183\",\"CNPJSeguradora\":\"33065699000127\",\"NomeSeguradora\":\"SURA\",\"NumApolice\":\"25501008866\",\"TpMov\":\"1\",\"TpDDR\":\"3\",\"ValorAverbado\":\"682.05\",\"RamoAverbado\":\"55\"}]}}}";

            //json = Newtonsoft.Json.JsonConvert.SerializeObject(json);
            //json = json.Replace(@"\", "");
            //CTeAverbacao cteAverbacao = Newtonsoft.Json.JsonConvert.DeserializeObject<CTeAverbacao>(json);


            throw new NotImplementedException();
        }
    }
}
