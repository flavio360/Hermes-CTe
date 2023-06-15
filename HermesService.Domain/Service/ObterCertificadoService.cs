using HermesService.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HermesService.Domain.Service
{
    public class ObterCertificadoService : IObterCertificadoService
    {
        X509Certificate2 certificado = null;
        public X509Certificate2 Retx509Certificate2(X509Store objcerti,string nSerie, string ambiente)
        {
            foreach (var item in objcerti.Certificates)
            {
                if (item.SerialNumber.Equals(nSerie))
                {
                    certificado = item;
                    break;
                }
            }

        return certificado;
        }
    }
}
