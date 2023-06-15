using HermesService.Domain.Entity.SICLONET.PROC;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.Utilities.CTe
{
    public class CalculaImpostos
    {
        public F_Insere_Fila_CTe CalculaImpostosCTe(F_Calcula_Frete_Tributos_Ecommerce valores)
        {
            var valoresCTe = new F_Insere_Fila_CTe();

            valoresCTe.Vlr_icms = CalculaImpostos.CalculaICMSCTe(valores.Taxa_icms, valores.Valor_frete);


            return valoresCTe;
        }
        private static decimal CalculaICMSCTe(decimal taxaICMS, decimal valorFrete)
        {
            decimal valorICMS = Math.Round((taxaICMS / 100) * valorFrete,2);
            return valorICMS;
        }

        private static decimal CalculaValorFrete(decimal valorBaseServico, decimal valorDespacho = 0, decimal aliquotaAdvalorem = 0 )
        {
            // v_valor_frete := ROUND((v_preco_normal + v_valor_despacho + v_advalorem_valor + v_gris_valor + v_icms_valor),2);
            decimal valorFrete = 0; // Math.Round(0.000,2);

            return valorFrete;
        }
    }
}
