using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hermes.BLL.Ferramentas
{
    public class TrataString
    {
        public string RemoveCaracteres(string stringTratar, bool allowSpace = true)
        {
			if (string.IsNullOrEmpty(stringTratar))
				return stringTratar;

			stringTratar.Replace(@"³", "");
			stringTratar.Replace(@"©", "");

			return new string(stringTratar
			.Normalize(NormalizationForm.FormD)
			.Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
			.ToArray());
		}

		public string RemoveEspacos(string stringTratar)
        {
			if (string.IsNullOrEmpty(stringTratar))
				return stringTratar;
			return stringTratar.Replace(" ","");
        }
		public string RemoveFormatacao(string stringTratar)
		{
			if (string.IsNullOrEmpty(stringTratar))
				return stringTratar;

			return Regex.Replace(stringTratar, "[^0-9]", "");
		}

		public string RemoveDiacriticas(string text)
		{

			if (string.IsNullOrEmpty(text))
				return text;

			text = text.Replace("³", "");
			text = text.Replace("©", "");

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] > 255)
					sb.Append(text[i]);
				else
					sb.Append(s_Diacritics[text[i]]);
			}

			return sb.ToString();
		}

		private static readonly char[] s_Diacritics = GetDiacritics();
		private static char[] GetDiacritics()
		{
			char[] accents = new char[256];

			for (int i = 0; i < 256; i++)
				accents[i] = (char)i;

			accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
			accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

			accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
			accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

			accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
			accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

			accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
			accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

			accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
			accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

			accents[(byte)'ç'] = 'c';
			accents[(byte)'Ç'] = 'C';

			accents[(byte)'ñ'] = 'n';
			accents[(byte)'Ñ'] = 'N';

			accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
			accents[(byte)'Ý'] = 'Y';

			return accents;
		}
	}
}
