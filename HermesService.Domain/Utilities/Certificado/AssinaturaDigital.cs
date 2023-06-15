using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Security.Cryptography.Xml;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using HermesService.Domain.Service;

namespace HermesService.Domain.Utilities.Certificado
{
    public  class AssinaturaDigital
    {
        public string SignatureCTe(X509Certificate2 certificado, string chaveCTe, string xmlCTe, string xmlCTeWhitoutFormation, string digestMethod = "http://www.w3.org/2000/09/xmldsig#sha1", string signatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1")
        {
            try
            {
                var documento = new XmlDocument { PreserveWhitespace = true };

                documento.LoadXml(xmlCTe);

                var docXml = new SignedXml(documento) { SigningKey = certificado.PrivateKey };

                docXml.SigningKey = certificado.PrivateKey;

                docXml.SignedInfo.SignatureMethod = signatureMethod;

                var reference = new Reference { Uri = "#CTe" + chaveCTe, DigestMethod = digestMethod };

                // adicionando EnvelopedSignatureTransform a referencia
                var envelopedSigntature = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(envelopedSigntature);

                var c14Transform = new XmlDsigC14NTransform();
                reference.AddTransform(c14Transform);

                docXml.AddReference(reference);

                // carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo
                var keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificado));

                docXml.KeyInfo = keyInfo;
                docXml.ComputeSignature();

                //// recuperando a representacao do XML assinado
                var xmlDigitalSignatures = docXml.GetXml();

                //Assinatura
                var assinatura = xmlDigitalSignatures.OuterXml;


                xmlDigitalSignatures.AppendChild(documento.ImportNode(xmlDigitalSignatures, true));

                XmlElement xmlKeyInfo = docXml.KeyInfo.GetXml();

                XmlElement xmlSignatureValue = documento.CreateElement("SignatureValue", xmlDigitalSignatures.NamespaceURI);
                string signBase64 = Convert.ToBase64String(docXml.Signature.SignatureValue);
                XmlText text = documento.CreateTextNode(signBase64);
                xmlSignatureValue.AppendChild(text);
                xmlDigitalSignatures.AppendChild(xmlSignatureValue);
                xmlDigitalSignatures.AppendChild(documento.ImportNode(xmlKeyInfo, true));

                XmlNodeList ListCTe = documento.GetElementsByTagName("cteProc");
                XmlNode CTenode = documento.DocumentElement;

                foreach (XmlElement infCTe in ListCTe)
                {
                    CTenode = infCTe;
                }

                CTenode.AppendChild(xmlDigitalSignatures);

                var assign = assinatura.ToString();

                var objXmlCTe = XElement.Parse(xmlCTeWhitoutFormation);
                var objAss = XElement.Parse(assign);
                objXmlCTe.Add(objAss);

                var replaceElemento = new MontaXMLCTeService();
                var objFinal = replaceElemento.ReplacePropriedadesCTe(objXmlCTe.ToString(), chaveCTe);

                return objFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  string SignatureCTeBKP(X509Certificate2 certificado, string chaveCTe, string xmlCTe,string xmlCTeWhitoutFormation, string digestMethod = "http://www.w3.org/2000/09/xmldsig#sha1", string signatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1")
        {
            try
            {
                var documento = new XmlDocument { PreserveWhitespace = true };

                documento.LoadXml(xmlCTe);

                var docXml = new SignedXml(documento) { SigningKey = certificado.PrivateKey };


                docXml.SigningKey = certificado.PrivateKey; 

                docXml.SignedInfo.SignatureMethod = signatureMethod;

                var reference = new Reference { Uri = string.Empty, DigestMethod = digestMethod };
                reference.Uri = "#CTe" + chaveCTe;
                // adicionando EnvelopedSignatureTransform a referencia
                var envelopedSigntature = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(envelopedSigntature);

                var c14Transform = new XmlDsigC14NTransform();
                reference.AddTransform(c14Transform);

                docXml.AddReference(reference);

                // carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo
                var keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificado));

                docXml.KeyInfo = keyInfo;
                docXml.ComputeSignature();

                //// recuperando a representacao do XML assinado
                var xmlDigitalSignatures = docXml.GetXml();

                //Assinatura
                var assinatura = xmlDigitalSignatures.OuterXml;


                xmlDigitalSignatures.AppendChild(documento.ImportNode(xmlDigitalSignatures,true));

                XmlElement xmlKeyInfo = docXml.KeyInfo.GetXml();

                XmlElement xmlSignatureValue = documento.CreateElement("SignatureValue", xmlDigitalSignatures.NamespaceURI);
                string signBase64 = Convert.ToBase64String(docXml.Signature.SignatureValue);
                XmlText text = documento.CreateTextNode(signBase64);
                xmlSignatureValue.AppendChild(text);
                xmlDigitalSignatures.AppendChild(xmlSignatureValue);
                xmlDigitalSignatures.AppendChild(documento.ImportNode(xmlKeyInfo, true));

                XmlNodeList ListCTe = documento.GetElementsByTagName("cteProc");
                XmlNode CTenode = documento.DocumentElement;

                foreach (XmlElement infCTe in ListCTe)
                {
                    CTenode = infCTe;
                }

                CTenode.AppendChild(xmlDigitalSignatures);

                var assign = assinatura.ToString();

                var objXmlCTe = XElement.Parse(xmlCTeWhitoutFormation);
                var objAss = XElement.Parse(assign);
                objXmlCTe.Add(objAss);

                var replaceElemento = new MontaXMLCTeService();
                var objFinal = replaceElemento.ReplacePropriedadesCTe(objXmlCTe.ToString(), chaveCTe);

                return objFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GlobalSignatureCTe(X509Certificate2 certificado, string xmlCTe)
        {
            try
            {
                // Carrega o XML da Carta de Correção
                var documento = new XmlDocument();
                documento.LoadXml(xmlCTe);

                // Cria um objeto SignedXml
                var signedXml = new SignedXml(documento);

                // Obtém o elemento que será assinado (nesse caso, é o elemento <infEvento>)
                XmlElement infEventoElement = documento.GetElementsByTagName("infEvento")[0] as XmlElement;

                // Cria a referência para o elemento
                Reference reference = new Reference("#" + infEventoElement.GetAttribute("Id"));

                // Define a URI (Identificador de Recurso Uniforme) da referência
                reference.Uri = "#" + infEventoElement.GetAttribute("Id");

                // Adiciona a transformação necessária à referência
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

                // Adiciona a referência ao objeto SignedXml
                signedXml.AddReference(reference);

                // Configura a chave privada e o certificado para a assinatura
                signedXml.SigningKey = certificado.PrivateKey;
                signedXml.Signature.Id = "Signature";
                signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                signedXml.KeyInfo = new KeyInfo();
                signedXml.KeyInfo.AddClause(new KeyInfoX509Data(certificado));

                // Calcula a assinatura
                signedXml.ComputeSignature();

                // Obtém a representação XML da assinatura
                XmlElement signatureElement = signedXml.GetXml();

                // Adiciona a assinatura ao documento XML
                infEventoElement.AppendChild(signatureElement);
             
                return documento.OuterXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


