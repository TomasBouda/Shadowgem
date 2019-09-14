using System;

namespace TomLabs.Shadowgem.Types.Attributes
{
	/// <summary>
	/// Attribute for marking properties to exclude them from deep clone - <see cref="ReflectionExtensions.DeepClone{T}"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class DeepCloneIgnoreAttribute : Attribute
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public DeepCloneIgnoreAttribute()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		{
		}
	}
}