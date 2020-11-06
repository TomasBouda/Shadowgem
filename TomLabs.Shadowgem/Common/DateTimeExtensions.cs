using System;
using System.Globalization;

namespace TomLabs.Shadowgem.Common
{
	/// <summary>
	/// <see cref="DateTime"/> related extension methods
	/// </summary>
	public static class DateTimeExtensions
	{
		#region Elapsed extension

		/// <summary>
		/// Elapsed the time.
		/// </summary>
		/// <example>
		///	var yesterday = DateTime.Now.AddDays(-1);
		/// yesterday.Elapsed();
		/// </example>
		/// <param name="datetime">The datetime.</param>
		/// <returns>TimeSpan</returns>
		public static TimeSpan Elapsed(this DateTime datetime)
		{
			return DateTime.Now - datetime;
		}

		#endregion Elapsed extension

		#region Week of year

		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <example>
		///	DateTime.Now.WeekOfYear(System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
		/// </example>
		/// <param name="datetime">The datetime.</param>
		/// <param name="weekRule">The weekRule.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			return currentCulture.Calendar.GetWeekOfYear(datetime, weekRule, firstDayOfWeek);
		}

		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
		{
			DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
			CalendarWeekRule weekRule = dateInfo.CalendarWeekRule;
			return WeekOfYear(datetime, weekRule, firstDayOfWeek);
		}

		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="weekRule">The weekRule.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, CalendarWeekRule weekRule)
		{
			DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;
			return WeekOfYear(datetime, weekRule, firstDayOfWeek);
		}

		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime)
		{
			DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
			CalendarWeekRule weekRule = dateInfo.CalendarWeekRule;
			DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;
			return WeekOfYear(datetime, weekRule, firstDayOfWeek);
		}

		#endregion Week of year

		#region Get Datetime for Day of Week

		/// <summary>
		/// Gets the date time for day of week.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="day">The day.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static DateTime GetDateTimeForDayOfWeek(this DateTime datetime, DayOfWeek day, DayOfWeek firstDayOfWeek)
		{
			int current = DaysFromFirstDayOfWeek(datetime.DayOfWeek, firstDayOfWeek);
			int resultDay = DaysFromFirstDayOfWeek(day, firstDayOfWeek);
			return datetime.AddDays(resultDay - current);
		}

		/// <summary>
		/// Gets the date time for day of week.
		/// </summary>
		/// <param name="datetime"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		public static DateTime GetDateTimeForDayOfWeek(this DateTime datetime, DayOfWeek day)
		{
			DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;
			return GetDateTimeForDayOfWeek(datetime, day, firstDayOfWeek);
		}

		/// <summary>
		/// Firsts the date time of week.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <returns></returns>
		public static DateTime FirstDateTimeOfWeek(this DateTime datetime)
		{
			DateTimeFormatInfo dateInfo = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;
			return FirstDateTimeOfWeek(datetime, firstDayOfWeek);
		}

		/// <summary>
		/// Firsts the date time of week.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static DateTime FirstDateTimeOfWeek(this DateTime datetime, DayOfWeek firstDayOfWeek)
		{
			return datetime.AddDays(-DaysFromFirstDayOfWeek(datetime.DayOfWeek, firstDayOfWeek));
		}

		/// <summary>
		/// Days from first day of week.
		/// </summary>
		/// <param name="current">The current.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		private static int DaysFromFirstDayOfWeek(DayOfWeek current, DayOfWeek firstDayOfWeek)
		{
			//Sunday = 0,Monday = 1,..., Saturday = 6
			int daysBetween = current - firstDayOfWeek;
			if (daysBetween < 0)
			{
				daysBetween = 7 + daysBetween;
			}

			return daysBetween;
		}

		#endregion Get Datetime for Day of Week

		/// <summary>
		/// Figure out if DateTime holds a date value that is a weekend
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsWeekend(this DateTime value)
		{
			return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
		}

		/// <summary>
		/// Returns given time as string formatted to dd.MM.yyyy HH:mm:ss
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string Readable(this DateTime dateTime)
		{
			return dateTime.ToString("dd.MM.yyyy HH:mm:ss");
		}

		/// <summary>
		/// Returns given time as string formatted to dd.MM.yyyy HH:mm:ss:ms
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string ReadableMs(this DateTime dateTime)
		{
			return dateTime.ToString("dd.MM.yyyy HH:mm:ss:ms");
		}

		/// <summary>
		/// Returns given unix timestamp as <see cref="DateTime"/>
		/// </summary>
		/// <param name="unixTimeStamp"></param>
		/// <returns></returns>
		public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}
	}
}