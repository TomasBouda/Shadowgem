using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using TomLabs.Shadowgem.Types.Attributes;

namespace TomLabs.Shadowgem.Types
{
	/// <summary>
	/// Reflection related extensions
	/// </summary>
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Copies properties not marked with <see cref="CopyFromIgnoreAttribute"/> from one object to another
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="to"></param>
		/// <param name="from"></param>
		public static void CopyFrom<T>(this T to, T from)
		{
			foreach (var prop in from.GetType().GetProperties().Where(p => p.GetCustomAttribute<CopyFromIgnoreAttribute>() == null))
			{
				if (prop.GetSetMethod() != null && prop.GetIndexParameters().Length == 0)   // avoid the TargetParameterCountException
				{
					to.GetType().GetProperty(prop.Name)?.SetValue(to, prop.GetValue(from));
				}
			}
		}

		/// <summary>
		/// Creates deep copy of an object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="from"></param>
		/// <param name="flags"></param>
		/// <param name="customPredicate">Custom condition to filter cloned properties</param>
		/// <param name="excludedPropertyNames"></param>
		public static T DeepClone<T>(this T from, BindingFlags? flags = null, Func<PropertyInfo, bool> customPredicate = null, params string[] excludedPropertyNames) where T : class, new()
		{
			T target = Activator.CreateInstance(from.GetType()) as T;

			var properties = flags.HasValue ? from.GetType().GetProperties(flags.Value) : from.GetType().GetProperties();
			properties = properties
				.Where(p =>
					p.GetCustomAttribute<DeepCloneIgnoreAttribute>() == null
					&& (customPredicate?.Invoke(p) ?? true)
					&& (excludedPropertyNames == null || (!excludedPropertyNames.Contains(p.Name)))
					)
				.ToArray();

			foreach (var prop in properties)
			{
				if (prop.GetSetMethod() != null)
				{
					var targetProperty = target.GetType().GetProperty(prop.Name);
					if (targetProperty.PropertyType.IsValueType)
					{
						targetProperty.SetValue(target, prop.GetValue(from));
					}
					else
					{
						var propVal = prop.GetValue(from);
						targetProperty.SetValue(target, propVal?.Clone());
					}
				}
			}

			return target;
		}

		private static T Clone<T>(this T obj) where T : class, new()
		{
			var objType = obj.GetType();
			if (typeof(ICloneable).IsAssignableFrom(objType))   // Call Clone on ICloneable
			{
				return ((ICloneable)obj).Clone() as T;
			}
			else if (typeof(IEnumerable).IsAssignableFrom(objType)) // Create new collection and DeepClone every item
			{
				var newObj = Activator.CreateInstance(objType) as IList;    // TODO test more collections
				foreach (var item in obj as IEnumerable)
				{
					var newItem = item.DeepClone();
					newObj.Add(newItem);
				}
				return newObj as T;
			}
			else
			{
				if (objType.GetConstructor(Type.EmptyTypes) != null)    // If object Type has parameterless constructor create new instance and DeepClone it
				{
					return obj.DeepClone() as T;
				}
				else
				{
					throw new Exception($"Type {objType.Name} doesn't have parameterless constructor.");
				}
			}
		}
	}
}