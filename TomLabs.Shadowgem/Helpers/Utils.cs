using System.Net;

namespace TomLabs.Shadowgem.Helpers
{
	/// <summary>
	/// Miscellaneous utilities
	/// </summary>
	public static class Utils
	{
		/// <summary>
		/// Returns <c>true</c> if internet connection is available
		/// </summary>
		/// <returns></returns>
		public static bool CheckInternetConnection()
		{
			try
			{
				using (var client = new WebClient())
				using (client.OpenRead("http://clients3.google.com/generate_204"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}