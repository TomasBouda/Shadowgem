using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace TomLabs.Shadowgem.Logging
{
	/// <summary>
	/// Thread safe logger
	/// </summary>
	public class ThreadSafeLogger
	{
		private static ThreadSafeLogger instance;
		private static string _logFilePath;
		BlockingCollection<string> _logMessages = new BlockingCollection<string>();
		static object locker = new object();

		private ThreadSafeLogger()
		{
			_logFilePath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
		}

		/// <summary>
		/// Gets logger file path
		/// </summary>
		public string LogFilePath
		{
			get { return _logFilePath; }
		}

		/// <summary>
		/// Returns instance of logger
		/// </summary>
		public static ThreadSafeLogger Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ThreadSafeLogger();
				}
				return instance;
			}
		}

		/// <summary>
		/// Sets log file location
		/// Note: Default location is application base directory
		/// </summary>
		/// <param name="pathToFile"></param>
		public static void SetLogFile(string pathToFile)
		{
			_logFilePath = pathToFile;
		}

		/// <summary>
		/// Adds message to queue
		/// </summary>
		/// <param name="message"></param>
		public void AddMessage(string message)
		{
			message = "[" + DateTime.Now.ToString("u") + "] Thread id#" + Thread.CurrentThread.Name + " " + message;

			_logMessages.Add(message);
		}

		/// <summary>
		/// Log all messages in queue
		/// </summary>
		public void DispatchMesages()
		{
			foreach (var msg in _logMessages.GetConsumingEnumerable())
			{
				Log(msg);
			}
		}

		private void Log(string message)
		{
			lock (locker)
			{
				try
				{
					Logger.Info(message);
					File.AppendAllText(_logFilePath, message + Environment.NewLine);
				}
				catch (Exception ex)
				{
					Logger.Error(ex);
				}
			}
		}
	}
}
