using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.Certificado
{
    public class KeyInfo
    {
        public KeyInfo()
        {
            X509Data = new X509Data();
        }

        /// <summary>
        ///     XS20 - Grupo X509
        /// </summary>
        public X509Data X509Data { get; set; }
    }
}
