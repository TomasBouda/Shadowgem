using System.IO;

namespace TomLabs.Shadowgem.Helpers.IO
{
	/// <summary>
	/// Provides methods for working with files
	/// </summary>
	public static class FileHelper
	{
		/// <summary>
		/// Removes ReadOnly attribute on given file
		/// </summary>
		/// <param name="path"></param>
		public static void RemoveReadOnlyAttribute(string path)
		{
			if (File.Exists(path))
			{
				FileAttributes attributes = File.GetAttributes(path);

				if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
					File.SetAttributes(path, attributes);
				}
			}
		}

		private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
		{
			return attributes & ~attributesToRemove;
		}
	}
}