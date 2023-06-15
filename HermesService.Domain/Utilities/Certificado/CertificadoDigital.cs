using DFe.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HermesService.Domain.Utilities
{
    public static class CertificadoDigital
    {
        private static readonly Dictionary<string, X509Certificate2> CacheCertificado = new Dictionary<string, X509Certificate2>();
        public enum TipoCertificado
        {
            [Description("Certificado A1")]
            A1Repositorio = 0,

            [Description("Certificado A1 em arquivo")]
            A1Arquivo = 1,

            [Description("Certificado A3")]
            A3 = 2,

            [Description("Certificado A1 em byte array")]
            A1ByteArray = 3
        }
        /// <summary>
        /// Cria e devolve um objeto <see cref="X509Store"/>
        /// </summary>
        /// <param name="openFlags"></param>
        /// <returns></returns>
        /// 

        //public static X509Store ObterX509Store(OpenFlags openFlags)
        public static X509Store ObterX509Store(OpenFlags openFlags)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(openFlags);
            return store;
        }

        public static X509Certificate2 ObterCertificado(ConfiguracaoCertificado configuracaoCertificado)
        {
            if (!configuracaoCertificado.ManterDadosEmCache)
                return ObterDadosCertificado(configuracaoCertificado);

            if (!string.IsNullOrEmpty(configuracaoCertificado.CacheId) && CacheCertificado.ContainsKey(configuracaoCertificado.CacheId))
                return CacheCertificado[configuracaoCertificado.CacheId];

            var certificado = ObterDadosCertificado(configuracaoCertificado);

            var keyCertificado = string.IsNullOrEmpty(configuracaoCertificado.CacheId)
                ? certificado.SerialNumber
                : configuracaoCertificado.CacheId;

            configuracaoCertificado.CacheId = keyCertificado;

            CacheCertificado.Add(keyCertificado, certificado);

            return CacheCertificado[keyCertificado];
        }

        private static X509Certificate2 ObterDadosCertificado(ConfiguracaoCertificado configuracaoCertificado)
        {
            switch (configuracaoCertificado.TipoCertificado)
            {
                //case (DFe.Utils.TipoCertificado)TipoCertificado.A1Repositorio:
                //    return ObterDoRepositorio(configuracaoCertificado.Serial, OpenFlags.MaxAllowed);
                //case TipoCertificado.A1ByteArray:
                //    return ObterDoArrayBytes(configuracaoCertificado.ArrayBytesArquivo, configuracaoCertificado.Senha);
                //case TipoCertificado.A1Arquivo:
                //    return ObterDeArquivo(configuracaoCertificado.Arquivo, configuracaoCertificado.Senha);
                //case TipoCertificado.A3:
                //    return ObterDoRepositorioPassandoPin(configuracaoCertificado.Serial, configuracaoCertificado.Senha);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
