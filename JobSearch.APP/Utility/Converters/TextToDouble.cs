using System;
using System.Linq;

namespace JobSearch.APP.Utility.Converters
{
	public class TextToDouble
	{
		public static Double ToDouble(string value)
		{
			// TODO - Remover caracteres não numéricos
			// TODO - Conversão e string para double

			value = RemoveExtraText(value);
			return Double.Parse(value);
		}

		private static string RemoveExtraText(string value)
		{
			var allowedChars = "01234567890.,";

			return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
		}

		public TextToDouble()
		{
		}
	}
}