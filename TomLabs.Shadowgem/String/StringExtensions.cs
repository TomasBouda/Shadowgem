using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TomLabs.Shadowgem.String
{
	/// <summary>
	/// Provides extension methods applied to <see cref="string"/>
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// "SQL" Like function that works with wildcards
		/// </summary>
		/// <param name="toSearch"></param>
		/// <param name="toFind"></param>
		/// <returns></returns>
		public static bool Like(this string toSearch, string toFind)
		{
			return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
		}

		/// <summary>
		/// String.Format shortcut
		/// </summary>
		/// <param name="s"></param>
		/// <param name="args">Arguments</param>
		/// <returns></returns>
		public static string FillIn(this string s, params object[] args)
		{
			return string.Format(s, args);
		}

		/// <summary>
		/// Converts given string to <see cref="int"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int ToInt(this string s, int defaultValue = default(int))
		{
			if (int.TryParse(s, out int res))
				return res;
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="Nullable"/> <see cref="int"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int? ToIntN(this string s, int? defaultValue = default(int?))
		{
			if (int.TryParse(s, out int res))
				return res;
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="double"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static double ToDouble(this string s, double defaultValue = default(double))
		{
			if (double.TryParse(s, out double res))
				return res;
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="float"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static float ToFloat(this string s, float defaultValue = default(float))
		{
			if (float.TryParse(s, out float res))
				return res;
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="DateTime"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime ToDate(this string s, DateTime defaultValue = default(DateTime))
		{
			if (DateTime.TryParse(s, out DateTime res))
				return res;
			else
				return defaultValue;
		}

		/// <summary>
		/// Parse a string to any other type including nullable types using <see cref="TypeConverter"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T Parse<T>(this string value)
		{
			T result = default(T);
			if (!string.IsNullOrEmpty(value))
			{
				TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
				result = (T)tc.ConvertFrom(value);
			}
			return result;
		}

		/// <summary>
		/// Returns of given length. If length of given string is greater
		/// </summary>
		/// <param name="str"></param>
		/// <param name="maxLenght"></param>
		/// <param name="suffix"></param>
		/// <returns></returns>
		public static string MaxLength(this string str, int maxLenght, string suffix = "...")
		{
			if (str.Length <= maxLenght)
				return str;
			else
				return str.Substring(0, maxLenght) + suffix;
		}

		/// <summary>
		/// Returns string located between two given characters
		/// </summary>
		/// <param name="str"></param>
		/// <param name="first"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		public static string BetweenChars(this string str, char first, char last)
		{
			int startIndex = str.IndexOf(first);
			int lastIndex = str.IndexOf(last, startIndex + 1);

			if (startIndex >= 0 && lastIndex > 0)
			{
				startIndex++;
				return str.Substring(startIndex, lastIndex - startIndex);
			}
			else
				return "";
		}

		/// <summary>
		/// Checks whether string ends with given sequence
		/// </summary>
		/// <param name="toSearch"></param>
		/// <param name="extension"></param>
		/// <param name="ignoreString"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static bool EndsWith(this string toSearch, string[] extension, string ignoreString = "", bool ignoreCase = true)
		{
			foreach (string s in extension)
			{
				if (toSearch.EndsWith(ignoreString != "" ? s.Replace(ignoreString, "") : s, ignoreCase, CultureInfo.CurrentCulture))
					return true;
			}

			return false;
		}

		/// <summary>
		/// Converts string into enumerator of type T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static T ToEnum<T>(this string value, bool ignoreCase = true)
		{
			try
			{
				return (T)Enum.Parse(typeof(T), value, ignoreCase);
			}
			catch (Exception)
			{
				return default(T);
			}
		}

		/// <summary>
		/// Determines whether given string is a valid URL.
		/// </summary>
		/// <returns>
		/// <c>true</c> if is valid URL otherwise returns <c>false</c>.
		/// </returns>
		public static bool IsValidUrl(this string text)
		{
			Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
			return rx.IsMatch(text);
		}

		/// <summary>
		/// Determines whether given string is a valid email address
		/// </summary>
		/// <returns>
		/// <c>true</c> if is valid email address otherwise returns <c>false</c>.
		/// </returns>
		public static bool IsValidEmailAddress(this string email)
		{
			Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
			return regex.IsMatch(email);
		}

		/// <summary>
		/// Inverse function of IsNullOrEmpty
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static bool IsFilled(this string s)
		{
			return !string.IsNullOrEmpty(s);
		}

		/// <summary>
		/// Returns given string as <see cref="Uri"/>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static Uri ToUri(this string s)
		{
			return new Uri(s);
		}

		/// <summary>
		/// Returns true if given string is an <see cref="int"/>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static bool IsNumber(this string s)
		{
			return int.TryParse(s, out int _);
		}

		/// <summary>
		/// Capitalizes all words in a given sentence
		/// </summary>
		/// <param name="s"></param>
		/// <param name="wordSeperator"></param>
		/// <returns></returns>
		public static string CapitalizeSentence(this string s, string wordSeperator = " ")
		{
			if (string.IsNullOrEmpty(s)) return s;

			var words = s.Trim().SplitRgx(wordSeperator);
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].CapitalizeWord();
			}

			return string.Join(wordSeperator, words);
		}

		/// <summary>
		/// Capitalizes first character of given word
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string CapitalizeWord(this string s)
		{
			if (string.IsNullOrEmpty(s)) return s;

			var sb = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				sb.Append(i == 0 ? char.ToUpper(s[i]) : s[i]);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Shortcut for <see cref="Regex.Split(string)"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="pattern"></param>
		/// <param name="regexOptions"></param>
		/// <returns></returns>
		public static string[] SplitRgx(this string s, string pattern, RegexOptions regexOptions = RegexOptions.None)
		{
			return Regex.Split(s, pattern, regexOptions);
		}

		/// <summary>
		/// Shortcut for <see cref="Regex.Replace(string, string, string, RegexOptions)"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="pattern"></param>
		/// <param name="replacement"></param>
		/// <param name="regexOptions"></param>
		/// <returns></returns>
		public static string ReplaceRgx(this string s, string pattern, string replacement, RegexOptions regexOptions = RegexOptions.None)
		{
			return Regex.Replace(s, pattern, replacement, regexOptions);
		}


		/// <summary>
		/// Removes all whitespace char from given string using <see cref="Regex.Replace(string, string, string)"/>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string RemoveWhitespaces(this string s)
		{
			return Regex.Replace(s, @"\s+", "");
		}

		/// <summary>
		/// Replaces Czech accents characters in given string with neutral characters
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string RemoveCZAccents(this string s)
		{
			var pairs = new Dictionary<char, char>
			{
				{ 'ě', 'e' },
				{ 'š', 's' },
				{ 'č', 'c' },
				{ 'ř', 'r' },
				{ 'ž', 'z' },
				{ 'ý', 'y' },
				{ 'á', 'a' },
				{ 'é', 'e' },
				{ 'ú', 'u' },
				{ 'ů', 'u' },
				{ 'ť', 't' },
				{ 'ď', 'd' },
				{ 'í', 'i' },
			};

			foreach (var p in pairs)
			{
				s = s.Replace(p.Key, p.Value);
			}
			return s;
		}

		/// <summary>
		/// Removes string range between two given strings
		/// </summary>
		/// <param name="s"></param>
		/// <param name="startSequence"></param>
		/// <param name="endSequence"></param>
		/// <param name="comparsion"></param>
		/// <returns></returns>
		public static string RemoveRange(this string s, string startSequence, string endSequence, StringComparison comparsion = StringComparison.Ordinal)
		{
			int start = s.IndexOf(startSequence, comparsion);
			int end = s.IndexOf(endSequence, comparsion);

			return start >= 0 && end > start ? s.Remove(start, (end + endSequence.Length) - start) : s;
		}

		/// <summary>
		/// Replaces all occurrences of strings defined by <paramref name="sequencesToReplace"/> with given <paramref name="replaceWith"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="sequencesToReplace">Collection of strings to replace</param>
		/// <param name="replaceWith">String to replace with</param>
		/// <returns></returns>
		public static string ReplaceAll(this string s, ICollection<string> sequencesToReplace, string replaceWith)
		{
			var sb = new StringBuilder(s);
			foreach (var sequence in sequencesToReplace)
			{
				sb.Replace(sequence, replaceWith);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Replaces all occurrences of strings defined by <paramref name="toReplace"/> with given <paramref name="replaceWith"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="replaceWith">String to replace with</param>
		/// <param name="toReplace">Collection of strings to replace</param>
		/// <returns></returns>
		public static string ReplaceAll(this string s, string replaceWith, params string[] toReplace)
		{
			return ReplaceAll(s, toReplace, replaceWith);
		}

		/// <summary>
		/// Replaces <see cref="char"/> at given position with given char
		/// </summary>
		/// <param name="s"></param>
		/// <param name="pos"></param>
		/// <param name="replaceWith"></param>
		/// <returns></returns>
		public static string ReplaceAt(this string s, int pos, char replaceWith)
		{
			char[] chars = s.ToCharArray();
			chars[pos] = replaceWith;
			return new string(chars);
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

		#region HTMLHelper

		/// <summary>
		/// Converts to a HTML-encoded string
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static string HtmlEncode(this string data)
		{
			return System.Net.WebUtility.HtmlEncode(data);
		}

		/// <summary>
		/// Converts the HTML-encoded string into a decoded string
		/// </summary>
		public static string HtmlDecode(this string data)
		{
			return System.Net.WebUtility.HtmlDecode(data);
		}

		/// <summary>
		/// Encode an Url string
		/// </summary>
		public static string UrlEncode(this string url)
		{
			return System.Net.WebUtility.UrlEncode(url);
		}

		/// <summary>
		/// Converts a string that has been encoded for transmission in a URL into a
		/// decoded string.
		/// </summary>
		public static string UrlDecode(this string url)
		{
			return System.Net.WebUtility.UrlDecode(url);
		}
		#endregion
	}
}
