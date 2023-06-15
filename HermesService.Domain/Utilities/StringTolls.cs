using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Utilities
{
    public static class StringTolls
    {
        public static string RemoveEspacoTagsXML(string xml)
        {
            xml = xml.Replace("\r\n", "");
            bool replace = false;
            xml = xml.Replace(Environment.NewLine, string.Empty);
            var trataxml = xml.IndexOf("> ");

            if (trataxml != -1)
            {
                replace = true;
            }
            while (replace)
            {
                xml = xml.Replace("> ", ">");
                trataxml = xml.IndexOf("> ");
                xml = xml.Replace(" />", "/>");

                if (trataxml == -1)
                {
                    replace = false;
                }
            }
            return xml; 
        }
    }
}
