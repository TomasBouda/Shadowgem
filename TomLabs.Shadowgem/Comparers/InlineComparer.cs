using System;
using System.Collections.Generic;

namespace TomLabs.Shadowgem.Comparers
{
	/// <summary>
	/// Allows you to compare in line with linq query
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class InlineComparer<T> : IEqualityComparer<T>
	{
		private readonly Func<T, T, bool> getEquals;
		private readonly Func<T, int> getHashCode;

		/// <summary>
		/// Creates instance of <see cref="InlineComparer{T}"/>
		/// </summary>
		/// <param name="equals">Pass lambda expression like: <code>(t1, t2) => t1.Id == t2.Id</code></param>
		/// <param name="hashCode">Pass lambda expression for GetHashCode function. <code>i => i.Id.GetHashCode()</code></param>
		public InlineComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
		{
			getEquals = equals;
			getHashCode = hashCode;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool Equals(T x, T y)
		{
			return getEquals(x, y);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int GetHashCode(T obj)
		{
			return getHashCode(obj);
		}
	}
}
