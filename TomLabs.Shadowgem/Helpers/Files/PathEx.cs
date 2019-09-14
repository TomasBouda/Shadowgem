using System.IO;

namespace TomLabs.Shadowgem.Helpers.IO
{
	/// <summary>
	/// Provides extension methods for Path
	/// </summary>
	public static class PathEx
	{
		/// <summary>
		/// Goes up in given <paramref name="path"/>/directory tree by number of specified times(<paramref name="count"/>)
		/// </summary>
		/// <param name="path"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GoUp(string path, int count = 1)
		{
			if (count < 1)
			{
				return path;
			}

			return GoUp(Path.GetFullPath(Path.Combine(path, @"..\")), --count);
		}
	}
}