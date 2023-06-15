using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.Certificado
{
    [Serializable]
    public class ConfigWebService
    {
        //public Estado UfEmitente { get; set; }
        //public TipoAmbiente Ambiente { get; set; }
        public short Serie { get; set; }
        public long Numeracao { get; set; }
        //public versao Versao { get; set; }
        public string CaminhoSchemas { get; set; }
        public int TimeOut { get; set; }
    }
}
