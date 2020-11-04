using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TomLabs.Shadowgem.Text
{
	/// <summary>
	/// Provides extension methods applied to <see cref="string"/>
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// "SQL Like" function
		/// </summary>
		/// <param name="toSearch"></param>
		/// <param name="toFind"></param>
		/// <returns></returns>
		public static bool Like(this string toSearch, string toFind)
		{
			return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
		}

		/// <summary>
		/// Searches the input string for the first occurrence of the specified regular expression, using the specified matching options.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="pattern"></param>
		/// <param name="regexOptions"></param>
		/// <returns></returns>
		public static Match Match(this string text, string pattern, RegexOptions regexOptions = RegexOptions.None)
		{
			return Regex.Match(text, pattern, regexOptions);
		}

		/// <summary>
		///	Checks wether the input string matches the first occurrence of the specified regular expression, using the specified matching options.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="pattern"></param>
		/// <param name="regexOptions"></param>
		/// <returns></returns>
		public static bool IsMatch(this string text, string pattern, RegexOptions regexOptions = RegexOptions.None)
		{
			return text.Match(pattern, regexOptions).Success;
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
			return int.TryParse(s, out int res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="int"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int ToInt(this string s, NumberStyles style, IFormatProvider provider, int defaultValue = default(int))
		{
			return int.TryParse(s, style, provider, out int res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="Nullable"/> <see cref="int"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int? ToIntN(this string s, int? defaultValue = default(int?))
		{
			return int.TryParse(s, out int res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="Nullable"/> <see cref="int"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int? ToIntN(this string s, NumberStyles style, IFormatProvider provider, int? defaultValue = default(int?))
		{
			return int.TryParse(s, style, provider, out int res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="double"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static double ToDouble(this string s, double defaultValue = default(double))
		{
			return double.TryParse(s, out double res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="double"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static double ToDouble(this string s, NumberStyles style, IFormatProvider provider, double defaultValue = default(double))
		{
			return double.TryParse(s, style, provider, out double res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="float"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static float ToFloat(this string s, float defaultValue = default(float))
		{
			return float.TryParse(s, out float res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="float"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static float ToFloat(this string s, NumberStyles style, IFormatProvider provider, float defaultValue = default(float))
		{
			return float.TryParse(s, style, provider, out float res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="decimal"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static decimal ToDecimal(this string text, decimal defaultValue = 0)
		{
			return decimal.TryParse(text.Trim(), out var value) ? value : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="decimal"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="text"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static decimal ToDecimal(this string text, NumberStyles style, IFormatProvider provider, decimal defaultValue = 0)
		{
			return decimal.TryParse(text.Trim(), style, provider, out var value) ? value : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="DateTime"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime ToDate(this string s, DateTime defaultValue = default(DateTime))
		{
			return DateTime.TryParse(s, out DateTime res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to <see cref="DateTime"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="style"></param>
		/// <param name="provider"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime ToDate(this string s, DateTimeStyles style, IFormatProvider provider, DateTime defaultValue = default)
		{
			return DateTime.TryParse(s, provider, style, out DateTime res) ? res : defaultValue;
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
		/// Converts given string to <see cref="bool"/> or returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="s"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static bool ToBool(this string s, bool defaultValue = default(bool))
		{
			return bool.TryParse(s, out var res) ? res : defaultValue;
		}

		/// <summary>
		/// Converts given string to Base64 encoded string
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		public static string ToBase64(this string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		/// <summary>
		/// Decodes given Base64 encoded string
		/// </summary>
		/// <param name="base64EncodedData"></param>
		/// <returns></returns>
		public static string FromBase64(this string base64EncodedData)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
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
			catch
			{
				return default(T);
			}
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
		/// <param name="maxLength"></param>
		/// <param name="suffix"></param>
		/// <returns></returns>
		public static string MaxLength(this string str, int maxLength, string suffix = "...")
		{
			return str.Length <= maxLength ? str : str.Substring(0, maxLength) + suffix;
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
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Determines whether given string is a valid URL using <see cref="Regex"/>
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
		/// Determines whether given string is a valid email address  using <see cref="Regex"/>
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
		/// Indicates whether the specified string is NOT null or an System.String.Empty string.
		/// <para>
		/// Inverse function of <see cref="string.IsNullOrEmpty(string)"/>
		/// </para>
		/// </summary>
		/// <param name="s"></param>
		/// <returns>false if the value parameter is null or an empty string (""); otherwise, true.</returns>
		public static bool IsFilled(this string s)
		{
			return !string.IsNullOrEmpty(s);
		}

		/// <summary>
		/// Indicates whether the specified string is null or an System.String.Empty string.
		/// <para>
		/// Shortcut for <see cref="string.IsNullOrEmpty(string)"/>
		/// </para>
		/// </summary>
		/// <param name="s"></param>
		/// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
		public static bool IsNullOrEmpty(this string s)
		{
			return string.IsNullOrEmpty(s);
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
			{
				return false;
			}
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
			{
				return false;
			}
		}

		/// <summary>
		/// Capitalizes all words in a given sentence
		/// </summary>
		/// <param name="s"></param>
		/// <param name="wordSeperator"><see cref="Regex"/> pattern to split words</param>
		/// <returns></returns>
		public static string CapitalizeSentence(this string s, string wordSeperator = " ")
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}

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
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}

			var sb = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				sb.Append(i == 0 ? char.ToUpper(s[i]) : s[i]);
			}

			return sb.ToString();
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
		/// Removes diacritics from given string
		/// </summary>
		/// <param name="text"></param>
		/// <returns>string without diacritics</returns>
		public static string RemoveDiacritics(this string text)
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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
		/// Converts text with spaces to PascalCaseText
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToPascalCase(this string text)
		{
			TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

			return $"{(text.Contains(" ") ? textInfo.ToTitleCase(text) : text)}".Replace(" ", "");
		}

		/// <summary>
		/// Converts given string to Uppercase and replaces spaces with underscore
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToUpperUnderscored(this string text)
		{
			return text.ReplaceRgx("([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToUpper();
		}

		/// <summary>
		/// Removes all special characters from given string. Keeping a-zA-Z0-9
		/// </summary>
		/// <param name="str"></param>
		/// <param name="charsToKeep">chars that won't be removed</param>
		/// <returns></returns>
		public static string RemoveSpecialCharacters(this string str, params char[] charsToKeep)
		{
			var sb = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || charsToKeep.Any(ch => ch == c))
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
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

		#endregion HTMLHelper
	}
}