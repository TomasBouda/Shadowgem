using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace TomLabs.Shadowgem.Types
{
	/// <summary>
	/// Class for storing property tree that is constructed by <see cref="TypeExtensions.CreatePropertyTree"/> for given <see cref="Type"/>
	/// </summary>
	public class PropertyTree
	{
		/// <summary>
		/// Name of property
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Property type
		/// </summary>
		public Type Type { get; private set; }

		/// <summary>
		/// Gets
		/// </summary>
		public bool IsEnum => Type?.IsEnum ?? false;

		/// <summary>
		/// Property Value
		/// </summary>
		public object Value { get; private set; }

		/// <summary>
		/// Child properties if property is not simple type <seealso cref="TypeExtensions.IsSimple"/>
		/// </summary>
		public List<PropertyTree> ChildProperties { get; private set; }

		/// <summary>
		/// Constructs <see cref="PropertyTree"/>
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="childProperties"></param>
		public PropertyTree(string name, Type type, object value, List<PropertyTree> childProperties)
		{
			Name = name;
			Type = type;
			Value = value;
			ChildProperties = childProperties;
		}
	}
}
