using System;
using System.Collections.Generic;

namespace TomLabs.Shadowgem.Helpers.Comparers
{
	/// <summary>
	/// Allows you to compare inline in Linq query
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class InlineComparer<T> : IEqualityComparer<T>
	{
		private readonly Func<T, T, bool> _getEquals;
		private readonly Func<T, int> _getHashCode;

		/// <summary>
		/// Creates instance of <see cref="InlineComparer{T}"/>
		/// </summary>
		/// <param name="equals">Pass lambda expression for comparison <code>(t1, t2) => t1.Id == t2.Id</code></param>
		/// <param name="hashCode">Pass lambda expression for GetHashCode function. <code>i => i.Id.GetHashCode()</code></param>
		public InlineComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
		{
			_getEquals = equals;
			_getHashCode = hashCode;
		}

		/// <summary>
		/// Determines whether the specified object <paramref name="x"/> is equal to the object <paramref name="y"/>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool Equals(T x, T y)
		{
			return _getEquals(x, y);
		}

		/// <summary>
		/// Returns hash code for <paramref name="obj"/>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int GetHashCode(T obj)
		{
			return _getHashCode(obj);
		}
	}
}