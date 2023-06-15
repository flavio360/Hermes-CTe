using Hermes.BLL.Ferramentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.BLL
{
    public class CTe
    {
        private string tpAmb = "2";  //Ambiente  1 - Produção; 2 - Homologação.
        private string procEmi = "0"; //emissão de CT-e com aplicativo do contribuinte;3 - emissão CT-e pelo contribuinte com aplicativo fornecido pelo Fisco.
        private string verProc = string.Empty; //nformar a versão do processo de emissão do CT-e utilizado (aplicativo emissor de CT-e).
        private string tpEmiss = "1";
        private string mod = "57";
        private string modal = "01";
        private string retira = "1";
        private string tomador = "<toma3>< toma > 0 </ toma >< toma3 > ";
        private string xmlSchemaPronto = string.Empty;
        private string enviCTe = string.Empty;
        private string infCTe = string.Empty;
        private string idLote = string.Empty;
        private string nodePaiCTe = string.Empty;


        public string  MontarObjRequisicaoCTe(string TESTE_REMOVER_ESTE_PARAMETRO)
        {           



            
              
            //======================================================================

            #region CARREGA DADOS PARA O CTe




            #endregion



            //======================================================================

            #region FINALIZA O XMLCTE EM LOTE


            #endregion

            //======================================================================

            return xmlSchemaPronto;
        }
    }
}
