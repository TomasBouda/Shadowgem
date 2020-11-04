using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TomLabs.Shadowgem.Collections
{
	/// <summary>
	/// <see cref="System.Linq"/> related extension methods
	/// <para></para>
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
		/// <param name="nullValue">The null value.</param>
		/// <returns></returns>
		public static string ToCSVString(this IOrderedQueryable data, string delimiter, string nullValue)
		{
			StringBuilder csvData = new StringBuilder();
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
			}

			if (headers.Length > 0)
			{
				foreach (var head in headers)
				{
					csvData.Append(head.Name.Replace("_", " ") + delimiter);
				}
				csvData.Append("\n");
			}

			foreach (var row in data)
			{
				var fields = row.GetType().GetProperties();
				foreach (var field in fields)
				{
					object value = null;
					try
					{
						value = field.GetValue(row, null);
					}
					catch { }

					if (value != null)
					{
						csvData.Append(value.ToString().Replace("\r", "\f").Replace("\n", " \f").Replace("_", " ").Replace(replaceFrom, replaceDelimiter) + delimiter);
					}
					else
					{
						csvData.Append(nullValue);
						csvData.Append(delimiter);
					}
				}
				csvData.Append("\n");
			}

			return csvData.ToString();
		}

		/// <summary>
		/// Shortcut for foreach statement
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="mapFunction"></param>
		public static void ForEach<T>(this IEnumerable<T> list, Action<T> mapFunction)
		{
			foreach (var item in list)
			{
				mapFunction(item);
			}
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

			return target.OrderBy(t => r.Next());
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
			{
				collection.Add(i);
			}

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
			foreach (T e in target)
			{
				yield return e;
			}

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

		/// <summary>
		/// Calls <see cref="List{T}.AddRange(IEnumerable{T})"/> only if source <see cref="List{T}"/> is not <c>null</c> and not empty
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="range"></param>
		public static void AddRangeSafe<T>(this List<T> list, List<T> range)
		{
			if (range != null && range.Count > 0)
			{
				list.AddRange(range);
			}
		}

		/// <summary>
		/// Converts <see cref="IEnumerable{T}"/> into <see cref="ObservableCollection{T}"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> list)
		{
			return new ObservableCollection<T>(list);
		}

		/// <summary>
		/// Removes <see cref="IEnumerable{T}"/> collection from given <see cref="ICollection{T}"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="toRemove"></param>
		public static void Remove<T>(this ICollection<T> list, IEnumerable<T> toRemove)
		{
			toRemove?.ToList().ForEach((r) => { list.Remove(r); });
		}

		/// <summary>
		/// Invokes a transform function on each element of a sequence and returns the minimum <see cref="int" /> value. If sequence is empty or null returns default value of <see cref="int"/>.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="sequence" />.</typeparam>
		/// <param name="sequence">A sequence of values to determine the minimum value of.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>The minimum value in the sequence.</returns>
		public static int MinOrDefault<TSource>(this IEnumerable<TSource> sequence, Func<TSource, int> selector)
		{
			if (sequence?.Any() ?? false)
			{
				return sequence.Min(selector);
			}
			else
			{
				return default(int);
			}
		}
	}
}