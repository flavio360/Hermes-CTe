using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.Certificado
{
    [Serializable]
    public class ConfigCertificadoDigital
    {
        public string NumeroDeSerie { get; set; }
        public string CaminhoArquivo { get; set; }
        public string Senha { get; set; }
        public bool ManterEmCache { get; set; }
    }
}
