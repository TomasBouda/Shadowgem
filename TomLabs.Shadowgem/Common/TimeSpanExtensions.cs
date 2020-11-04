using System;

namespace TomLabs.Shadowgem.Common
{
	/// <summary>
	/// <see cref="TimeSpan"/> related extension methods
	/// </summary>
	public static class TimeSpanExtensions
	{
		private enum TimeUnit
		{
			Day,
			Hour,
			Minute,
			Second
		}

		/// <summary>
		/// Adds specified time unit to given string
		/// </summary>
		/// <param name="value"></param>
		/// <param name="unit"></param>
		/// <param name="shortUnit"></param>
		/// <returns></returns>
		private static string AddTimeUnit(int value, TimeUnit unit, bool shortUnit = false)
		{
			string multi = value > 1 && !shortUnit ? "s" : "";
			string space = shortUnit ? "" : " ";
			switch (unit)
			{
				case TimeUnit.Day:
					return $"{value}{space}{(shortUnit ? "d" : unit.ToString().ToLower())}{multi}";
				case TimeUnit.Hour:
					return $"{value}{space}{(shortUnit ? "h" : unit.ToString().ToLower())}{multi}";
				case TimeUnit.Minute:
					return $"{value}{space}{(shortUnit ? "min" : unit.ToString().ToLower())}{multi}";
				case TimeUnit.Second:
					return $"{value}{space}{(shortUnit ? "s" : unit.ToString().ToLower())}{multi}";
				default:
					throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
			}
		}

		/// <summary>
		/// Returns string in human readable representation. e.g. 1 day 20 hours 5 minutes
		/// </summary>
		/// <param name="timeSpan">timespan to convert</param>
		/// <param name="showSeconds">Sets whether to show seconds in output</param>
		/// <param name="shortUnits">Sets whether to show only short time units. e.g. '1d 20h' instead of '1 day 20 hours'</param>
		/// <returns>Human readable timespan string</returns>
		public static string ToReadableString(this TimeSpan timeSpan, bool showSeconds = false, bool shortUnits = false)
		{
			return $"{(timeSpan.Days > 0 ? AddTimeUnit(timeSpan.Days, TimeUnit.Day, shortUnits) : "")}" +
				   $"{(timeSpan.Hours > 0 ? " " + AddTimeUnit(timeSpan.Hours, TimeUnit.Hour, shortUnits) : "")}" +
				   $"{(timeSpan.Minutes > 0 ? " " + AddTimeUnit(timeSpan.Minutes, TimeUnit.Minute, shortUnits) : "")}" +
				   (showSeconds ? $"{(timeSpan.Seconds > 0 ? " " + AddTimeUnit(timeSpan.Seconds, TimeUnit.Second, shortUnits) : "")}" : "");
		}
	}
}
