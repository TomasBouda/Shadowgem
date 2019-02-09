using System;
using System.Collections.Generic;
using System.Linq;

namespace TomLabs.Shadowgem.Collections
{
	public static class LinkedListExtensions
	{
		public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current, Func<T, bool> predicate)
		{
			var next = current.Next;

			return next == null
				? current.List.FirstOrDefault(predicate)
				: predicate(next.Value)
					? next
					: next.NextOrFirst(predicate) == current
						? null
						: next.NextOrFirst(predicate);
		}

		public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
		{
			return current.Next ?? current.List.First;
		}

		public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
		{
			return current.Previous ?? current.List.Last;
		}

		public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current, Func<T, bool> predicate)
		{
			return current.Previous ?? current.List.LastOrDefault(predicate);
		}

		public static LinkedListNode<T> FirstOrDefault<T>(this LinkedList<T> list, Func<T, bool> predicate)
		{
			return list.Any(predicate) ? list.Find(list.First(predicate)) : default(LinkedListNode<T>);
		}

		public static LinkedListNode<T> LastOrDefault<T>(this LinkedList<T> list, Func<T, bool> predicate)
		{
			return list.Any(predicate) ? list.Find(list.Last(predicate)) : default(LinkedListNode<T>);
		}
	}
}