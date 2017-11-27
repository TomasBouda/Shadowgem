using System;
using System.IO;
using System.Runtime.CompilerServices;
using TomLabs.Shadowgem.Extensions.DateAndTime;

namespace TomLabs.Shadowgem.Logging
{
	/// <summary>
	/// Provides methods for logging into console and text file with additional informations
	/// </summary>
	public static class Logger
	{
		private enum LogPriority { Info, Warning, Error }

		/// <summary>
		/// Path to a log file
		/// </summary>
		public static string LogFile { get; set; }

		static Logger()
		{
			LogFile = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
		}

		/// <summary>
		/// Writes Error into console and file <seealso cref="LogFile"/> with additional information about caller method, class and line
		/// </summary>
		/// <example>
		/// <code>
		/// ...
		/// catch(Exception ex)
		/// {
		///		Logger.Log(ex);
		///	}
		/// </code>
		/// </example>
		/// <param name="ex"></param>
		/// <param name="callerName"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLine"></param>
		public static void Error(Exception ex, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber]int callerLine = -1)
		{
			Write(ex.Message, LogPriority.Error, callerName, callerFilePath, callerLine);
		}

		/// <summary>
		/// Writes Info into console and file <seealso cref="LogFile"/> with additional information about caller method, class and line
		/// </summary>
		/// <param name="text"></param>
		/// <param name="callerName"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLine"></param>
		public static void Info(string text, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber]int callerLine = -1)
		{
			Write(text, LogPriority.Info, callerName, callerFilePath, callerLine);
		}

		/// <summary>
		/// Writes Info into console and file <seealso cref="LogFile"/>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="color"></param>
		/// <param name="callerName"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLine"></param>
		public static void Info(string text, ConsoleColor color, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber]int callerLine = -1)
		{
			Write(text, color);
		}

		/// <summary>
		/// Writes Info into console and file <seealso cref="LogFile"/> with additional information about caller method, class and line
		/// </summary>
		/// <param name="text"></param>
		/// <param name="callerName"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLine"></param>
		public static void Info(object text, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber]int callerLine = -1)
		{
			Write(text.ToString(), LogPriority.Info, callerName, callerFilePath, callerLine);
		}

		/// <summary>
		/// Writes Warning into console and file <seealso cref="LogFile"/> with additional information about caller method, class and line
		/// </summary>
		/// <param name="text"></param>
		/// <param name="callerName"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLine"></param>
		public static void Warning(string text, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber]int callerLine = -1)
		{
			Write(text, LogPriority.Warning, callerName, callerFilePath, callerLine);
		}

		private static void Write(string text, LogPriority priority, string callerName = null, string callerFilePath = null, int callerLine = -1)
		{
			string message = $"*{priority.ToString().ToUpper()}* [{DateTime.Now.ReadableMs()}] '{text}' ~ METHOD: {callerName}; CLASS: {Path.GetFileName(callerFilePath)}; LINE: {callerLine}";

			Write(message, GetColor(priority));
			WriteToFile(message);
		}

		private static void Write(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();

			WriteToFile(message);
		}

		private static ConsoleColor GetColor(LogPriority priority)
		{
			switch (priority)
			{
				case LogPriority.Info: return ConsoleColor.White;
				case LogPriority.Warning: return ConsoleColor.Yellow;
				case LogPriority.Error: return ConsoleColor.Red;
				default: return ConsoleColor.White;
			}
		}

		private static void WriteToFile(string message)
		{
			try
			{
				File.AppendAllText(LogFile, message + Environment.NewLine);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
