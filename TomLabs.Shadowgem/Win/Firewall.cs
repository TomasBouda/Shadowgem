using System.Diagnostics;
using System.Security.Permissions;

namespace TomLabs.Shadowgem.Win
{
	/// <summary>
	/// Class provides methods for manipulating with windows firewall
	/// </summary>
	public class Firewall
	{
		/// <summary>
		/// Adds inbound rule to allow given <paramref name="port"/> number
		/// </summary>
		/// <param name="port"></param>
		[PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
		public static void AllowAllInboundOnPort(int port)
		{
			string arguments = $"netsh advfirewall firewall add rule name=\"Allow inbound on {port}\" dir=in action=allow protocol=TCP localport={port} profile=domain";
			ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + arguments)
			{
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			Process.Start(procStartInfo);
		}
	}
}
