using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TomLabs.Shadowgem.Extensions.Linq
{
	/// <summary>
	/// <see cref="System.Linq"/> related extension methods
	/// <para></para>
	/// http://extensionoverflow.codeplex.com/SourceControl/latest#ExtensionMethods
	/// </summary>
	public static class LinqExtensions
	{

		/// <summary>
		/// Converts the Linq data to a comma separated string including header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static string ToCSVString(this IOrderedQueryable data)
		{
			return ToCSVString(data, "; ");
		}

		/// <summary>
		/// Converts the Linq data to a comma separated string including header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <returns></returns>
		public static string ToCSVString(this IOrderedQueryable data, string delimiter)
		{
			return ToCSVString(data, "; ", null);
		}

		/// <summary>
		/// Converts the Linq data to a comma separated string including header.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <param name="nullvalue">The null value.</param>
		/// <returns></returns>
		public static string ToCSVString(this IOrderedQueryable data, string delimiter, string nullvalue)
		{
			StringBuilder csvdata = new StringBuilder();
			string replaceFrom = delimiter.Trim();
			string replaceDelimiter = ";";
			PropertyInfo[] headers = data.ElementType.GetProperties();
			switch (replaceFrom)
			{
				case ";":
					replaceDelimiter = ":";
					break;
				case ",":
					replaceDelimiter = "¸";
					break;
				case "\t":
					replaceDelimiter = "    ";
					break;
				default:
					break;
			}
			if (headers.Length > 0)
			{
				foreach (var head in headers)
				{
					csvdata.Append(head.Name.Replace("_", " ") + delimiter);
				}
				csvdata.Append("\n");
			}
			foreach (var row in data)
			{
				var fields = row.GetType().GetProperties();
				for (int i = 0; i < fields.Length; i++)
				{
					object value = null;
					try
					{
						value = fields[i].GetValue(row, null);
					}
					catch { }
					if (value != null)
					{
						csvdata.Append(value.ToString().Replace("\r", "\f").Replace("\n", " \f").Replace("_", " ").Replace(replaceFrom, replaceDelimiter) + delimiter);
					}
					else
					{
						csvdata.Append(nullvalue);
						csvdata.Append(delimiter);
					}
				}
				csvdata.Append("\n");
			}
			return csvdata.ToString();
		}

		/// <summary>
		/// Shortcut for foreach statement
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enum"></param>
		/// <param name="mapFunction"></param>
		public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
		{
			foreach (var item in @enum) mapFunction(item);
		}

		/// <summary>
		/// Orders Enumerable using given sort expression
		/// Example: users.OrderBy("Name desc")
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="sortExpression">Property and sort direction</param>
		/// <returns></returns>
		public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
		{
			sortExpression += "";
			string[] parts = sortExpression.Split(' ');
			bool descending = false;
			string property = "";

			if (parts.Length > 0 && parts[0] != "")
			{
				property = parts[0];

				if (parts.Length > 1)
				{
					descending = parts[1].ToLower().Contains("esc");
				}

				PropertyInfo prop = typeof(T).GetProperty(property);

				if (prop == null)
				{
					throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
				}

				if (descending)
					return list.OrderByDescending(x => prop.GetValue(x, null));
				else
					return list.OrderBy(x => prop.GetValue(x, null));
			}

			return list;
		}

		/// <summary>
		/// Returns randomly ordered Enumerable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="target"></param>
		/// <returns></returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target)
		{
			Random r = new Random();

			return target.OrderBy(x => (r.Next()));
		}

		/// <summary>
		/// Convert a <see cref="IEnumerable{T}"/>to a <see cref="Collection{T}"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerable"></param>
		/// <returns></returns>
		public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
		{
			var collection = new Collection<T>();
			foreach (T i in enumerable)
				collection.Add(i);
			return collection;
		}

		/// <summary>
		/// <see cref="Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/> and <see cref="Enumerable.OrderByDescending{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/> shortcut
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="keySelector"></param>
		/// <param name="descending"></param>
		/// <returns></returns>
		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector, bool descending)
		{
			if (enumerable == null)
			{
				return null;
			}
			if (descending)
			{
				return enumerable.OrderByDescending(keySelector);
			}

			return enumerable.OrderBy(keySelector);
		}

		/// <summary>
		/// Order by multiple properties
		/// http://www.extensionmethod.net/csharp/ienumerable-t/orderby
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="keySelector1"></param>
		/// <param name="keySelector2"></param>
		/// <param name="keySelectors"></param>
		/// <returns></returns>
		public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, IComparable> keySelector1, Func<TSource, IComparable> keySelector2, params Func<TSource, IComparable>[] keySelectors)
		{
			if (enumerable == null)
			{
				return null;
			}

			IEnumerable<TSource> current = enumerable;

			if (keySelectors != null)
			{
				for (int i = keySelectors.Length - 1; i >= 0; i--)
				{
					current = current.OrderBy(keySelectors[i]);
				}
			}

			current = current.OrderBy(keySelector2);

			return current.OrderBy(keySelector1);
		}

		/// <summary>
		/// OrderBy by multiple properties
		/// http://www.extensionmethod.net/csharp/ienumerable-t/orderby
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="descending">True if descending</param>
		/// <param name="keySelector"></param>
		/// <param name="keySelectors"></param>
		/// <returns></returns>
		public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, bool descending, Func<TSource, IComparable> keySelector, params Func<TSource, IComparable>[] keySelectors)
		{
			IEnumerable<TSource> current = enumerable;
			if (enumerable == null)
			{
				return null;
			}
			if (keySelectors != null)
			{
				for (int i = keySelectors.Length - 1; i >= 0; i--)
				{
					current = current.OrderBy(keySelectors[i], descending);
				}
			}

			return current.OrderBy(keySelector, descending);
		}

		/// <summary>
		/// Allows you to filter an <see cref="IEnumerable{T}"/>
		/// http://www.extensionmethod.net/csharp/ienumerable-t/filter
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="filterParam"></param>
		/// <returns></returns>
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam)
		{
			return list.Where(filterParam);
		}

		/// <summary>
		/// Adds an element to an <see cref="IEnumerable{T}"/> 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="target"></param>
		/// <param name="element"></param>
		/// <returns></returns>
		public static IEnumerable<T> Concat<T>(this IEnumerable<T> target, T element)
		{
			foreach (T e in target) yield return e;
			yield return element;
		}

		/// <summary>
		/// Concatenates the members of a constructed <see cref="System.Collections.Generic.IEnumerable{T}"/>
		///     collection of type <see cref="string"/>, using the specified separator between each
		///     member.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string JoinItems<T>(this T collection, string separator) where T : IEnumerable<string>
		{
			return string.Join(separator, collection);
		}
	}
}
