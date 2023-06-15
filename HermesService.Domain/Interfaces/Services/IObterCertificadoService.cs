using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IObterCertificadoService
    {
        X509Certificate2 Retx509Certificate2(X509Store objcerti, string nSerie, string ambiente );
    }
}
