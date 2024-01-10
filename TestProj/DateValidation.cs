namespace TestProj
{
	internal class DateValidation
	{
		public bool CheckMonth(int month)
		{
			if(month > 0 && month<=12)
			{
				return true;
			}
			return false;
		}
		public bool Checkday(int year,int month,int day) 
		{
			int[] daysInMonth = new int[]
			{
				31, // January
				IsLeapYear(year) ? 29 : 28, // February (account for leap year)
				31, // March
				30, // April
				31, // May
				30, // June
				31, // July
				31, // August
				30, // September
				31, // October
				30, // November
				31  // December
			};
			if (day < 1 || day > daysInMonth[month - 1])
			{
				return false;
			}
			return true;

		}
		public static bool IsLeapYear(int year)
		{
			// Check if the year is a leap year according to the Gregorian calendar rules
			// Leap years are divisible by 4, except for years divisible by 100 but not divisible by 400
			return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
		}
	}

	public class AnoOtherDateValidation
	{
		public static bool IsValidDate(int year, int month, int day)
		{
			// Check if the year is within a reasonable range (adjust as needed)
			if (year < 1 || year > 9999)
				return false;

			// Check if the month is valid (between 1 and 12)
			if (month < 1 || month > 12)
				return false;

			// Check if the day is within a valid range for the given month
			int[] daysInMonth = new int[]
			{
			31, // January
            IsLeapYear(year) ? 29 : 28, // February (account for leap year)
            31, // March
            30, // April
            31, // May
            30, // June
            31, // July
            31, // August
            30, // September
            31, // October
            30, // November
            31  // December
			};

			if (day < 1 || day > daysInMonth[month - 1])
				return false;

			return true;
		}

		public static bool IsLeapYear(int year)
		{
			// Check if the year is a leap year according to the Gregorian calendar rules
			// Leap years are divisible by 4, except for years divisible by 100 but not divisible by 400
			return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
		}

		public static void Main()
		{
			int yearToValidate = 2024; // Change these values to the year, month, and day you want to validate
			int monthToValidate = 2;
			int dayToValidate = 29;

			if (IsValidDate(yearToValidate, monthToValidate, dayToValidate))
			{
				Console.WriteLine("Valid date.");
			}
			else
			{
				Console.WriteLine("Invalid date.");
			}
		}
	}
}
