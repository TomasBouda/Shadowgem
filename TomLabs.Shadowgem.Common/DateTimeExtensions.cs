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
		/// <param name="datetime">The datetime.</param>
		/// <returns>TimeSpan</returns>
		public static TimeSpan Elapsed(this DateTime datetime)
		{
			return DateTime.Now - datetime;
		}
		#endregion

		#region Week of year
		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="weekrule">The weekrule.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, CalendarWeekRule weekrule, DayOfWeek firstDayOfWeek)
		{
			CultureInfo ciCurr = CultureInfo.CurrentCulture;
			return ciCurr.Calendar.GetWeekOfYear(datetime, weekrule, firstDayOfWeek);
		}
		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
		{
			DateTimeFormatInfo dateinf = new DateTimeFormatInfo();
			CalendarWeekRule weekrule = dateinf.CalendarWeekRule;
			return WeekOfYear(datetime, weekrule, firstDayOfWeek);
		}
		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="weekrule">The weekrule.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime, CalendarWeekRule weekrule)
		{
			DateTimeFormatInfo dateinf = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateinf.FirstDayOfWeek;
			return WeekOfYear(datetime, weekrule, firstDayOfWeek);
		}
		/// <summary>
		/// Weeks the of year.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <param name="weekrule">The weekrule.</param>
		/// <returns></returns>
		public static int WeekOfYear(this DateTime datetime)
		{
			DateTimeFormatInfo dateinf = new DateTimeFormatInfo();
			CalendarWeekRule weekrule = dateinf.CalendarWeekRule;
			DayOfWeek firstDayOfWeek = dateinf.FirstDayOfWeek;
			return WeekOfYear(datetime, weekrule, firstDayOfWeek);
		}
		#endregion

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
			int resultday = DaysFromFirstDayOfWeek(day, firstDayOfWeek);
			return datetime.AddDays(resultday - current);
		}


		public static DateTime GetDateTimeForDayOfWeek(this DateTime datetime, DayOfWeek day)
		{
			DateTimeFormatInfo dateinf = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateinf.FirstDayOfWeek;
			return GetDateTimeForDayOfWeek(datetime, day, firstDayOfWeek);
		}

		/// <summary>
		/// Firsts the date time of week.
		/// </summary>
		/// <param name="datetime">The datetime.</param>
		/// <returns></returns>
		public static DateTime FirstDateTimeOfWeek(this DateTime datetime)
		{
			DateTimeFormatInfo dateinf = new DateTimeFormatInfo();
			DayOfWeek firstDayOfWeek = dateinf.FirstDayOfWeek;
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
		/// Dayses from first day of week.
		/// </summary>
		/// <param name="current">The current.</param>
		/// <param name="firstDayOfWeek">The first day of week.</param>
		/// <returns></returns>
		private static int DaysFromFirstDayOfWeek(DayOfWeek current, DayOfWeek firstDayOfWeek)
		{
			//Sunday = 0,Monday = 1,...,Saturday = 6
			int daysbetween = current - firstDayOfWeek;
			if (daysbetween < 0) daysbetween = 7 + daysbetween;
			return daysbetween;
		}
		#endregion

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
		/// Returns given time as string formated to dd.MM.yyyy HH:mm:ss
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string Readable(this DateTime dateTime)
		{
			return dateTime.ToString("dd.MM.yyyy HH:mm:ss");
		}

		/// <summary>
		/// Returns given time as string formated to dd.MM.yyyy HH:mm:ss:ms
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
