using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HermesService.Domain.Interfaces.Services.WS
{
    public interface ICommunicationSefazService
    {
        //#TODO mudar o retorno paar o tipo das propriedades do retorno da SEFAZ.
        string RequestReception(string xmlfinal, string ufEmissao, X509Certificate2 cert);

        void RecordResponse(string xmlResponse, string codEntrega);

        string ResquestStatus(string soap, X509Certificate2 cert, string url_webservice);

    }
}
