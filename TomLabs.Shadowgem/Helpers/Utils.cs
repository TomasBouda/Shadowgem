using System.Net;

namespace KeypadX.Core.Helpers
{
	public static class Utils
	{
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