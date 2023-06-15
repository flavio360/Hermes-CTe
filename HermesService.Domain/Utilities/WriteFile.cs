using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Utilities
{
    public static class WriteFile
    {
        static string pathLogrE = @"C:\CTe\";
        public static void WriteXMLCTe(string xml, string Cte_chave)
        {
            string path = @"C:\\CTe\\XMLCTe_" + DateTime.Now.ToString("yyyyMMdd");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (StreamWriter myWriter = new StreamWriter(path + "\\CTe" + Cte_chave + ".xml"))
            {
                myWriter.Write(xml);
                myWriter.Close();
            }
        }

        #region Grava o Log do serviço em execução.
        public static void WriteWSCTeLog(string dscServicoCTe = null, string pedidosFila = null, string msg = null)
        {
            try
            {
                pathLogrE = pathLogrE + dscServicoCTe;
                var data = DateTime.Now.ToString("yyyy MM dd mm ss");
                FileInfo path = new FileInfo(pathLogrE);

                if (!Directory.Exists(pathLogrE))
                {
                    Directory.CreateDirectory(pathLogrE);
                }

                pathLogrE = pathLogrE + @"\" + data.Replace(" ","") + ".txt";

                using (StreamWriter writer = new StreamWriter(pathLogrE, true))
                {

                    if (pedidosFila!=null)
                    {
                        writer.WriteLine(pedidosFila + " " + data);
                        writer.Dispose();
                    }
                    else
                    {
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")+" " + msg);
                        writer.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

         sealed class  teste {
}
    }
}
