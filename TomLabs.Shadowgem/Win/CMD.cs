using System.Diagnostics;
using System.Text;

namespace TomLabs.Shadowgem.Win
{
	/// <summary>
	/// Windows command line helper class
	/// </summary>
	public class CMD
	{
		/// <summary>
		/// Executes given command in windows command line
		/// </summary>
		/// <param name="arguments"></param>
		/// <param name="workingDirectory">directory context</param>
		/// <returns></returns>
		public static string RunCommand(string arguments, string workingDirectory)
		{
			Process cmd = new Process();
			var startInfo = new ProcessStartInfo("cmd", $"/c {arguments}")
			{
				WorkingDirectory = workingDirectory,
				RedirectStandardOutput = true,
				CreateNoWindow = true,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden
			};

			cmd.StartInfo = startInfo;
			cmd.Start();
			cmd.WaitForExit();

			return cmd.StandardOutput.ReadToEnd();
		}

		/// <summary>
		/// Returns line of characters
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string MultipleChars(char ch, int count)
		{
			var sb = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				sb.Append(ch);
			}
			return sb.ToString();
		}
	}
}
