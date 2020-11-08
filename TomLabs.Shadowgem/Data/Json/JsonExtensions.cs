using System;
using Newtonsoft.Json;

namespace TomLabs.Shadowgem.Data.Json
{
	/// <summary>
	/// Json related extensions
	/// </summary>
	public static class JsonExtensions
	{
		/// <summary>
		/// Deep clone using Json serialization
		/// </summary>
		/// <typeparam name="T">Type of object to clone</typeparam>
		/// <param name="source">Object to clone</param>
		/// <returns>Deep object clone</returns>
		public static T CloneJson<T>(this T source)
		{
			return source == null
				? default(T)
				: JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
		}

		/// <summary>
		/// Serializes the specified object to a JSON string using <see cref="JsonConvert.SerializeObject(object)"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToJson<T>(this T obj) where T : class, new()
		{
			if (obj == null)
			{
				return null;
			}

			try
			{
				return JsonConvert.SerializeObject(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Deserializes the specified object to a JSON string using <see cref="JsonConvert.DeserializeObject{T}(string)"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objStr"></param>
		/// <returns></returns>
		public static T FromJson<T>(this string objStr) where T : class, new()
		{
			if (string.IsNullOrEmpty(objStr))
			{
				return null;
			}

			try
			{
				return JsonConvert.DeserializeObject<T>(objStr);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}
	}
}