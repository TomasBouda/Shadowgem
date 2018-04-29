using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable CheckNamespace

namespace TomLabs.Shadowgem.Types
{
	/// <summary>
	/// <see cref="Type"/> related extension methods
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Returns <c>true</c> if given <see cref="Type"/> is primitive or Enum or <see cref="string"/> or <see cref="decimal"/> or <see cref="DateTime"/>
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool IsSimple(this Type type)
		{
			return type.IsPrimitive
					|| type.IsEnum
					|| type == typeof(string)
					|| type == typeof(decimal)
					|| type == typeof(DateTime);
		}

		/// <summary>
		/// Creates property tree from given <see cref="Type"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="refObject"></param>
		/// <param name="ignoredTypes"></param>
		/// <returns></returns>
		public static List<PropertyTree> CreatePropertyTree(this Type type, object refObject = null, params Type[] ignoredTypes)
		{
			var map = new List<PropertyTree>();
			var properties = type.GetProperties();
			foreach (var prop in properties)
			{
				var propType = prop.PropertyType;
				bool typeIsIgnored = ignoredTypes?.Any(t => t == propType) ?? false;
				bool typeIsSimple = propType.IsSimple();
				var propVal = refObject != null ? prop.GetValue(refObject, null) : null;

				try
				{
					map.Add(
						new PropertyTree(
							prop.Name,
							propType,
							typeIsSimple || typeIsIgnored ? propVal : null,
							typeIsSimple || typeIsIgnored ? null : propType.CreatePropertyTree(propVal, ignoredTypes))
						);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			return map;
		}
	}
}
