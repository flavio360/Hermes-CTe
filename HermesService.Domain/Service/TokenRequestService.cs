using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services.WS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace HermesService.Domain.Service
{
    public class TokenRequestService : ITokenRequestService
    {
        public class AuthResponse
        {
            public string Token { get; set; }
        }



        public  string TokenRequestAsync(Autenticacao_info_seguradora objAutenticacao)
        {
            string token = "";
            var body = $@"{{
                        ""usuario"": ""{objAutenticacao.Usuario}"",
                        ""senha"": ""{objAutenticacao.Senha}"",
                        ""codigoatm"": ""{objAutenticacao.Codigo}""
                        }}";

            var dados = Encoding.UTF8.GetBytes(body);
            Uri serverUri = new Uri("http://" + objAutenticacao.Ws_Endereco);
            var requisicaoWeb = WebRequest.CreateHttp(serverUri);
            requisicaoWeb.Method = "POST";
            requisicaoWeb.Accept = "application/json";
            requisicaoWeb.ContentType = "application/json";
            requisicaoWeb.ContentLength = dados.Length;
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject(objResponse.ToString());

                streamDados.Close();
                resposta.Close();

                JObject responseObject = JObject.Parse(objResponse.ToString());
                token = (string)responseObject["Bearer"];
            }

            return token;
        }


    }
}
