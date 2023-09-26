using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.Averbacao
{
    public class CTeAverbacao
    {
        public CTeAverbacao()
        {
            InfAdic = "null"; // Define "null" como valor padrão para InfAdic  
            
        }
        public string Processado { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string Filial { get; set; }
        public string CNPJCli { get; set; }
        public string TpDoc { get; set; }
        public string InfAdic { get; set; }
        public Averbado Averbado { get; set; }
        public Erros Erros { get; set; }
        public Infos Infos { get; set; }
        public string CodEntrega { get; set; }
        public string CodCliente { get; set; }
    }

    public class Averbado
    {
        public string DhAverbacao { get; set; }
        public string Protocolo { get; set; }
        public List<DadosSeguro> DadosSeguro { get; set; }
    }

    public class DadosSeguro
    {
        public DadosSeguro()
        {
            TpDDR = "null";
        }
        public string NumeroAverbacao { get; set; }
        public string CNPJSeguradora { get; set; }
        public string NomeSeguradora { get; set; }
        public string NumApolice { get; set; }
        public string TpMov { get; set; }
        public string TpDDR { get; set; }
        public string ValorAverbado { get; set; }
        public string RamoAverbado { get; set; }
    }

    public class Infos
    {
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class Erros
    {
        public List<Erro> Erro { get; set; }
    }

    public class Erro
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public string ValorInformado { get; set; }
    }
}
