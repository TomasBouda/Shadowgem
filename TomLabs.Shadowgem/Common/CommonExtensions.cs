using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace TomLabs.Shadowgem.Common
{
	/// <summary>
	/// Common Extension methods
	/// </summary>
	public static class CommonExtensions
	{
		/// <summary>
		/// Determines if an instance is contained in a sequence
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="list"></param>
		/// <returns></returns>
		public static bool IsIn<T>(this T source, params T[] list)
		{
			if (null == source) throw new ArgumentNullException(nameof(source));
			return list.Contains(source);
		}

		/// <summary>
		/// Simulates coin toss. Returns randomly <c>true</c> or <c>false</c>
		/// </summary>
		/// <param name="rng"></param>
		/// <returns>Returns randomly <c>true</c> or <c>false</c></returns>
		public static bool CoinToss(this Random rng)
		{
			return rng.Next(2) == 0;
		}

		/// <summary>
		/// Returns random element from given params collection
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="rnd"></param>
		/// <param name="things"></param>
		/// <returns></returns>
		public static T OneOf<T>(this Random rnd, params T[] things)
		{
			return things[rnd.Next(things.Length)];
		}

		/// <summary>
		/// Indicates whether the regular expression specified by <paramref name="pattern"/>
		///     finds a match in a specified input <see cref="string"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="pattern"></param>
		/// <returns><c>true</c> if there is a match</returns>
		public static bool Match(this string value, string pattern)
		{
			Regex regex = new Regex(pattern);
			return regex.IsMatch(value);
		}

		/// <summary>Serializes an object of type T in to an XML string</summary>
		/// <typeparam name="T">Any class type</typeparam>
		/// <param name="obj">Object to serialize</param>
		/// <returns>A string that represents XML, empty otherwise</returns>
		public static string XmlSerialize<T>(this T obj) where T : class, new()
		{
			if (obj == null) throw new ArgumentNullException("obj");

			var serializer = new XmlSerializer(typeof(T));
			using (var writer = new StringWriter())
			{
				serializer.Serialize(writer, obj);
				return writer.ToString();
			}
		}

		/// <summary>Deserializes an xml string into an object of Type T</summary>
		/// <typeparam name="T">Any class type</typeparam>
		/// <param name="xml">XML as string to deserialize from</param>
		/// <returns>A new object of type T if successful, null if failed</returns>
		public static T XmlDeserialize<T>(this string xml) where T : class, new()
		{
			if (xml == null) throw new ArgumentNullException("xml");

			var serializer = new XmlSerializer(typeof(T));
			using (var reader = new StringReader(xml))
			{
				try { return (T)serializer.Deserialize(reader); }
				catch { return null; } // Could not be deserialized to this type.
			}
		}

		/// <summary>
		/// Returns default value of given object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static T GetDefaultValue<T>(this T? source) where T : struct
		{
			return source ?? default(T);
		}

		/// <summary>
		/// Returns given <see cref="decimal"/> value formated as currency
		/// </summary>
		/// <param name="value"></param>
		/// <param name="cultureName"></param>
		/// <returns></returns>
		public static string ToCurrency(this double value, string cultureName)
		{
			CultureInfo currentCulture = new CultureInfo(cultureName);
			return (string.Format(currentCulture, "{0:C}", value));
		}

		/// <summary>
		/// Shortcut for <see cref="string.IsNullOrWhiteSpace(string)"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		private static bool IsNullOrEmpty<T>(this T obj)
		{
			if (obj == null)
				return true;
			else if (string.IsNullOrWhiteSpace(obj.ToString()))
				return true;
			else
				return false;
		}

		/// <summary>
		/// Makes a copy from the object.
		/// Doesn't copy the reference memory, only data.
		/// </summary>
		/// <typeparam name="T">Type of the return object.</typeparam>
		/// <returns>Returns the copied object.</returns>
		public static T DeepClone<T>(this T input) where T : ISerializable
		{
			using (var stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, input);
				stream.Position = 0;
				return (T)formatter.Deserialize(stream);
			}
		}

		/// <summary>
		/// Limit a value to a certain range. When the value is smaller/bigger than the range, snap it to the range border.
		/// </summary>
		/// <typeparam name = "T">The type of the value to limit.</typeparam>
		/// <param name = "source">The source for this extension method.</param>
		/// <param name = "start">The start of the interval, included in the interval.</param>
		/// <param name = "end">The end of the interval, included in the interval.</param>
		public static T Clamp<T>(this T source, T start, T end)
			where T : IComparable
		{
			bool isReversed = start.CompareTo(end) > 0;
			T smallest = isReversed ? end : start;
			T biggest = isReversed ? start : end;

			return source.CompareTo(smallest) < 0
				? smallest
				: source.CompareTo(biggest) > 0
					? biggest
					: source;
		}

		/// <summary>
		/// <paramref name="object"/> == null
		/// </summary>
		/// <param name="object"></param>
		/// <returns></returns>
		public static bool IsNull(this object @object)
		{
			return @object == null;
		}

		/// <summary>
		/// Returns <c>true</c> if given string is path to a directory
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static bool IsDirectory(this string path)
		{
			if (Directory.Exists(path))
			{
				FileAttributes attr = File.GetAttributes(path);
				return (attr.HasFlag(FileAttributes.Directory));
			}
			else
				return false;
		}

		/// <summary>
		/// Returns <c>true</c> if given string is path to a file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static bool IsFile(this string path)
		{
			if (File.Exists(path))
			{
				FileAttributes attr = File.GetAttributes(path);
				return !(attr.HasFlag(FileAttributes.Directory));
			}
			else
				return false;
		}
	}
}
