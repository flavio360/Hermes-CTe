using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HermesService.Domain.Entity.Certificado
{
    public class SignatureMethod
    {
        /// <summary>
        ///     XS06 - Atributo Algorithm de SignatureMethod: http://www.w3.org/2000/09/xmldsig#rsa-sha1
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }
    }
}
