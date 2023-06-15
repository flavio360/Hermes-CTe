using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.Utilities.CTe
{
    public class CFOP
    {
        public string DefinirCFOP(string ufOrigem, string ufDestino)
        {
            string cfop = string.Empty;


            if (ufOrigem == ufDestino)
            {
                cfop = "5353";
            }
            else
            {
                cfop = "6353";
            }

            return cfop;
        }
    }
}
