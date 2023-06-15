using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.SICLONET.PROC
{
    public class F_Calcula_Frete_Tributos_Ecommerce
    {
        public string Msg { get; set; }
        public decimal Valor_frete { get; set; }
        public decimal Valor_icms { get; set; }
        public decimal Taxa_icms { get; set; }
        public decimal Taxa_gris { get; set; }
        public decimal Valor_gris { get; set; }
        public decimal Valor_advalor { get; set; }
        public decimal Taxa_advalorem { get; set; }
        public bool Erro { get; set; }
        public decimal Preco_normal { get; set; }
        public bool Calcula_gris { get; set; }
    }
}

