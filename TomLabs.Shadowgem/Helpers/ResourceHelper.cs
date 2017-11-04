using System;
using System.Reflection;

namespace TomLabs.Shadowgem.Helpers
{
	/// <summary>
	/// Provides methods for resource files
	/// </summary>
	public class ResourceHelper
	{
		/// <summary>
		/// Returns resource value out from given resource type by name
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="resourceType"></param>
		/// <param name="resourceName"></param>
		/// <returns></returns>
		public static T GetResourceLookup<T>(Type resourceType, string resourceName)
		{
			if ((resourceType != null) && (resourceName != null))
			{
				PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
				if (property == null)
				{
					return default(T);
				}

				return (T)property.GetValue(null, null);
			}
			return default(T);
		}
	}
}
