using System;
using System.Linq;

namespace JobSearch.APP.Utility.Converters
{
	public class TextToDouble
	{
		public static Double ToDouble(string value)
		{
			if (value != null)
			{
				value = RemoveExtraText(value);
				return Double.Parse(value);
			}
			return 0;
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