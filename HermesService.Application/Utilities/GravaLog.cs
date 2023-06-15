using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HermesService.Application.Utilities
{
    public class GravaLog
    {
        public GravaLog()
        {

        }

        public GravaLog(string nomefolder, string nomeArquivo)
        {
            Nomefolder = nomefolder;
            NomeArquivo = nomeArquivo;
        }

        public string Nomefolder { get; set; }

        public string NomeArquivo { get; set; }

        public void GravarLog(string pMensagem, bool removeData = false)
        {
            DateTime dataAgora = DateTime.Now;

            if (!Directory.Exists(Nomefolder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(Nomefolder);
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@Nomefolder + @NomeArquivo, true))
            {
                // REMOVE DATA PARA GRAVAR SOMENTE A MENSAGEM 
                if (removeData)
                {
                    writer.WriteLine(pMensagem);
                    //Fechando o arquivo
                    writer.Close();
                    //Limpando a referencia dele da memória
                    writer.Dispose();
                    return;
                }

                writer.WriteLine(dataAgora.ToString() + " - " + pMensagem);

                //Fechando o arquivo
                writer.Close();

                //Limpando a referencia dele da memória
                writer.Dispose();
            }
        }

        public void GravarLogJson(object mensagem, bool removeData = false)
        {
            try
            {
                DateTime dataAgora = DateTime.Now;

                if (mensagem == null)
                {
                    throw new Exception();
                }

                string json = JsonConvert.SerializeObject(mensagem);

                if (!Directory.Exists(Nomefolder))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(Nomefolder);
                }

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter($"{@Nomefolder}{@NomeArquivo}", true))
                {
                 
                    if (removeData)
                    {
                        writer.WriteLine(json);
                        //Fechando o arquivo
                        writer.Close();
                        //Limpando a referencia dele da memória
                        writer.Dispose();
                        return;
                    }

                    writer.WriteLine(dataAgora.ToString("o") + " - " + json);

                    //Fechando o arquivo
                    writer.Close();

                    //Limpando a referencia dele da memória
                    writer.Dispose();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro no log");
            }
        }
    }
}
