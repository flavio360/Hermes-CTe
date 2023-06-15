using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.Certificado
{
    public class X509Data
    {
        /// <summary>
        ///     XS21 - Certificado Digital X509 em Base64
        /// </summary>
        public string X509Certificate { get; set; }
    }
}
