using System.Text;

namespace TestProj
{
	internal class DecimalToWords
	{
		private static string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
		private static string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
		private static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

		public static string ConvertDecimalToWords(decimal number)
		{
			if (number == 0)
				return "Zero";

			if (number < 0)
				return "Minus " + ConvertDecimalToWords(Math.Abs(number));

			string words = "";

			if ((decimal)((int)number) < number)
			{
				words += ConvertToWords((int)number) + " point";
				decimal fractionalPart = number - (int)number;
				words += ConvertFractionalToWords(fractionalPart);
			}
			else
			{
				words += ConvertToWords((int)number);
			}

			return words;
		}

		private static string ConvertToWords(int number)
		{
			if (number < 10)
				return units[number];
			else if (number < 20)
				return teens[number - 10];
			else
				return tens[number / 10] + ((number % 10 > 0) ? " " + units[number % 10] : "");
		}

		private static string ConvertFractionalToWords(decimal fractionalPart)
		{
			StringBuilder fractionalWords = new StringBuilder();

			while (fractionalPart > 0)
			{
				fractionalPart *= 10;
				int digit = (int)(fractionalPart);
				fractionalWords.Append(" " + units[digit]);
				fractionalPart -= digit;
			}

			return fractionalWords.ToString();
		}
	}
}
