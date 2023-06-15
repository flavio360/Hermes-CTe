using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.Utilities.CTe
{
    public class DefinirTipoCTe
    {
        public string DefineTipoCTe(string tpEmissao, string chaveCTeAnterior=null)
        {
            string tpCTe = string.Empty;

            if (tpEmissao=="0" && chaveCTeAnterior==null)
            {
                tpCTe = "NORMAL";
            }
            else if (tpEmissao == "0" && chaveCTeAnterior != null)
            {
                tpCTe = "SUBCONTRACAO";
            }
            else if (tpEmissao == "1")
            {
                tpCTe = "COMPLEMENTAR";
            }
            else if (tpEmissao == "2")
            {
                tpCTe = "CANCELAMENTO";
            }
            else if (tpEmissao == "4")
            {
                tpCTe = "SUBSTITUICAO";
            }

            return tpCTe;
        }
    }
}
