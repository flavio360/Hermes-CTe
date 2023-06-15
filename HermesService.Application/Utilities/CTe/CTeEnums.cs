using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HermesService.Application.Utilities.CTe
{
    public class CTeEnums
    {
        public enum TipoCTe
        {
            Normal = 0,
            Complementar = 1,
            Anulacao =2,
            Substituicao = 3,
        }

        public enum ModeloCTe
        {
            [Description("Modal Rodoviário")]
            ModalRodoviario = 57
        }

        public enum Empresas
        {
            MG = 1,
            SP = 2,
            RJ = 3,
            SC = 4

        }
    }
}
