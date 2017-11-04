namespace TomLabs.Shadowgem.Extensions
{
	/// <summary>
	/// <see cref="char"/> related extension methods
	/// </summary>
	public static class CharExtensions
	{
		/// <summary>
		/// Shortcut for <see cref="char.ToUpper(char)"/>
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		public static char ToUpper(this char ch)
		{
			return char.ToUpper(ch);
		}

		/// <summary>
		/// Shortcut for <see cref="char.ToLower(char)"/>
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		public static char ToLower(this char ch)
		{
			return char.ToLower(ch);
		}
	}
}
