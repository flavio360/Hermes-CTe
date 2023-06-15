using HermesService.Application.Utilities.CTe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static HermesService.Application.Utilities.CTe.CTeEnums;

namespace Hermes.BLL.Ferramentas
{
    public class CTeTools
    {   
        private string siglaUF = string.Empty;

        private string sChaveCTe = string.Empty;

        public string GerarNumeroCTe(string siglaUF, string CNPJEmitente, string tpEmiss, string codCliente, string numeroCTe, string cct)
        {
            var modal = new CTeEnums();
             /*
             chCTe;   //44  - Código de acesso CTe

                      //QTD - DESCRIÇÃO
             uf;      //2   - Código da UF
             aamm;    //4   - AAMM da emissão
             cnpj;    //14  - CNPJ Emitente
             modelo;  //2   - Modelo 57
             serie;   //3   - Série
             ncte;    //9   - Número do CTe
             tpEmiss; //1   - Forma de emissão
             cct;     //8   - Código Numérico (aleatório)
             dv;      //1   - DV
             */

            sChaveCTe = RetornaCodigoUF(siglaUF);
            sChaveCTe = sChaveCTe + DateTime.UtcNow.ToString("yyMM");
            sChaveCTe = sChaveCTe + CNPJEmitente;
            sChaveCTe = sChaveCTe + ((int)ModeloCTe.ModalRodoviario).ToString();
            sChaveCTe = sChaveCTe + "001"; //#TODO ajuste para enviar em produção; 
            //sChaveCTe = sChaveCTe + "123456789";
            sChaveCTe = sChaveCTe + numeroCTe.PadLeft(9,'0');
            sChaveCTe = sChaveCTe + "1";
            sChaveCTe = sChaveCTe + cct;
            sChaveCTe = sChaveCTe + CalculaDV(sChaveCTe);
            

            return sChaveCTe;
        }
        public string RetornaCodigoUF(string siglaUF)
        {
            string codUF = string.Empty;

            switch (siglaUF)
            {
                case "AC":
                    codUF = "12";
                    break;
                case "AL":
                    codUF = "27";
                    break;
                case "AP":
                    codUF = "16";
                    break;
                case "AM":
                    codUF = "13";
                    break;
                case "BA":
                    codUF = "29";
                    break;
                case "CE":
                    codUF = "23";
                    break;
                case "DF":
                    codUF = "53";
                    break;
                case "ES":
                    codUF = "32";                    
                    break;
                case "GO":
                    codUF = "52";
                    break;
                case "MA":
                    codUF = "21";
                    break;
                case "MT":
                    codUF = "51";
                    break;
                case "MS":
                    codUF = "50";
                    break;
                case "MG":
                    codUF = "31";
                    break;
                case "PA":
                    codUF = "15";
                    break;
                case "PB":
                    codUF = "25";
                    break;
                case "PR":
                    codUF = "41";
                    break;
                case "PE":
                    codUF = "26";
                    break;
                case "PI":
                    codUF = "22";
                    break;
                case "RJ":
                    codUF = "33";
                    break;
                case "RN":
                    codUF = "24";
                    break;
                case "RS":
                    codUF = "43";
                    break;
                case "RO":
                    codUF = "11";
                    break;
                case "RR":
                    codUF = "14";
                    break;
                case "SC":
                    codUF = "42";
                    break;
                case "SP":
                    codUF = "35";
                    break;
                case "SE":
                    codUF = "28";
                    break;
                case "TO":
                    codUF = "17";
                    break;
            }
            return codUF;
        }

        internal static string CalculaDV(string chCTe)
        {
            int total = 0;
            int m = 2;
            int n;
            int atu;
            int mod_total;
            int dv;
            for (n = chCTe.Length - 1; n >= 0; n--)
            {
                if (m > 9)
                {
                    m = 2;
                }
                atu = Convert.ToInt32(chCTe.Substring(n, 1));
                total += atu * m;
                m++;
            }
            mod_total = total % 11;
            if (mod_total < 2)
            {
                dv = 0;
            }
            else
            {
                dv = 11 - mod_total;
            }

            return dv.ToString().Trim();
        }      



        public static void GravaLog(string localGravacao, string msg, string code = null, string pedido = null )
        {
            StreamWriter lObjEscreveTexto = new StreamWriter(@"C:\HermesCTe\"+ localGravacao + @"\Registro_Execucao_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);

            lObjEscreveTexto.WriteLine(string.Concat(pedido + " Status da execução em " + DateTime.UtcNow.AddHours(-3).ToString("dd/MM/yyyy HH:mm:ss") + " Observação: " + msg, " | " + code, Environment.NewLine));

            lObjEscreveTexto.Flush();
            lObjEscreveTexto.Close();
            lObjEscreveTexto.Dispose();
        }

        public static void GravaCTe(string nCTe, string xmlCTe, string localGravacao, string clienteDescricao)
        {
            StreamWriter lObjEscreveTexto = new StreamWriter(@"C:\HermesCTe\XMLCTe\" + localGravacao + "\" " + clienteDescricao  + @"\" + nCTe +  DateTime.Now.ToString("yyyy-MM-dd") + ".xml", true);

            //lObjEscreveTexto.WriteLine(string.Concat(pedido + " Status da execução em " + DateTime.UtcNow.AddHours(-3).ToString("dd/MM/yyyy HH:mm:ss") + " Observação: " + msg, " | " + code, Environment.NewLine));

            lObjEscreveTexto.Flush();
            lObjEscreveTexto.Close();
            lObjEscreveTexto.Dispose();
        }




    }
}
