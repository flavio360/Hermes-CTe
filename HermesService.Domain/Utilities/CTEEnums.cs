using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace HermesService.Domain.Utilities
{
    public static class CTEEnums
    {
        public enum CodigoPais
        {
            Brasil = 1058
        }

        public enum TipoEmissao
        {
            Normal = 1,
            EPEC_SVC = 4,
            Contigencia_FSDA =5,
            SVC_RS = 7,
            SVC_SP = 8
        }

        public enum Ambiente
        {
            producao = 1,
            homologacacao = 2
        }

        public enum TipoCTe
        {
            Normal = 0,
            Complementar = 1,
            Anulacao = 2,
            Substituicao = 3,
            Cancelamento = 4,
        }

        public enum Empresas
        {
            MG = 1,
            SP = 2,
            RJ = 3,
            SC = 4
        }

        public enum Modal
        {
            Rodoviario = 1,
            Aereo = 02,
            Aquaviario = 03,
            Ferroviario = 04,
            Duoviario = 05,
            Multimodal =06
        }

        public enum AppEmissor
        {
            AppContribuente = 0
        }

        public enum Servico 
        {
            Normal = 0 ,
            Subcontratacao = 1,
            Redespacho = 2,
            Redespacho_Intermediario = 3,
            Multimodal = 4
        }

        public enum Toma
        {
            Remetente = 0,
            Expedidor = 1,
            Recebedor = 2,
            Destinatario = 3,
            Outros = 4
        }

        public enum Retira
        {
            Sim = 0,
            Nao =1
        }

        public enum Operacao
        {
            NORMAL,
            REENTREGA,
            COLETA,
            COMPLEMENTAR,
            DEVOLUCAO
        }

        public enum FUNCAO
        {
            CTeRecepcao,
            CTeRetRecepcao,
            CTeInutilizacao,
            CTeConsulta,
            CTeStatusServico,
            CTeRecepcaoEvento,
            CTeRecepcaoOS,
            QRCode,
            CTeRecepcaoGTVe
        }

        public enum STATUS_SEFAZ
        {
            LoteRecebido = 103,
            LoteProcesado = 104,
            Autorizado = 100
        }

        public enum STATUS_CTE_IL
        {
            PendenteEnvio = 1,
            Enviado = 2
        }

        public enum INCOSISTENCIA_DADOS
        {
            CODIGO_IBGE_NULL = 0
        }
        public enum CST
        {
            /// <summary>
            /// 00 - Tributação normal ICMS
            /// </summary>
            [Description("Tributação normal ICMS")]
            [XmlEnum("00")]
            ICMS00 = 00,

            /// <summary>
            /// 20 - Tributação com BC reduzida do ICMS
            /// </summary>
            [Description("Tributação com BC reduzida do ICMS")]
            [XmlEnum("20")]
            ICMS20 = 20,

            /// <summary>
            /// 40 - ICMS isenção
            /// </summary>
            [Description("ICMS isenção")]
            [XmlEnum("40")]
            ICMS40,

            /// <summary>
            /// 41 - ICMS não tributada
            /// </summary>
            [Description("ICMS não tributada")]
            [XmlEnum("41")]
            ICMS41,

            /// <summary>
            /// 51 - ICMS diferido
            /// </summary>
            [Description("ICMS diferido")]
            [XmlEnum("51")]
            ICMS51,

            /// <summary>
            /// 60 - ICMS cobrado por substituição tributária
            /// </summary>
            [Description("ICMS cobrado por substituição tributária")]
            [XmlEnum("60")]
            ICMS60,

            /// <summary>
            /// 90 - Outros
            /// </summary>
            [Description("Outros")]
            [XmlEnum("90")]
            ICMS90
        }
    }
}
