using System;

namespace TomLabs.Shadowgem.Types.Attributes
{
	/// <summary>
	///  Attribute for marking properties to exclude them from copy from - <see cref="ReflectionExtensions.CopyFrom{T}(T, T)"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class CopyFromIgnoreAttribute : Attribute
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

		public CopyFromIgnoreAttribute()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		{
		}
	}
}