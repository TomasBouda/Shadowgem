using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TomLabs.Shadowgem.Helpers.Enums
{
	/// <summary>
	/// Provides helper methods for <see cref="Enum"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class EnumHelper<T> where T : struct
	{
		/// <summary>
		/// Gets value of enum description attribute
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetEnumDescription(string value)
		{
			Type type = typeof(T);
			var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

			if (name == null)
			{
				return string.Empty;
			}
			var field = type.GetField(name);
			var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
		}

		/// <summary>
		/// Converts given enum to dictionary
		/// </summary>
		/// <returns></returns>
		public static Dictionary<int, string> ToDictionary()
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException("Type T must be an enum.");

			return Enum.GetValues(typeof(T))
			   .Cast<T>()
			   .ToDictionary(t => (int)Convert.ChangeType(t, t.GetType()), t => t.ToString());
		}
	}
}
