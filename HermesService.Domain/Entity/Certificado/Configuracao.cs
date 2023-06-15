using HermesService.Domain.Entity.Certificado;
using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.Certificado
{
    [Serializable]
    public class Configuracao
    {
        public Configuracao()
        {
            Empresa = new Empresas();
            CertificadoDigital = new ConfigCertificadoDigital();
            ConfigWebService = new ConfigWebService();
        }
        public Empresas Empresa { get; set; }
        public ConfigCertificadoDigital CertificadoDigital { get; set; }
        public ConfigWebService ConfigWebService { get; set; }

        public string DiretorioSalvarXml { get; set; }
        public bool IsSalvarXml { get; set; }
    }
}