using System.Xml.Serialization;

namespace HermesService.Domain.Entity.Certificado
{
    public class CanonicalizationMethod
    {
        /// <summary>
        ///     XS04 - Atributo Algorithm de CanonicalizationMethod: http://www.w3.org/TR/2001/REC-xml-c14n-20010315
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }
    }
}
