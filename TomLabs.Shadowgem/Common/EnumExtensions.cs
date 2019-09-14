using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TomLabs.Shadowgem.Common
{
	/// <summary>
	/// Enum related extension methods
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Returns <see cref="DescriptionAttribute"/> value for enum
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="enumerationValue"></param>
		/// <param name="attributeType"></param>
		/// <returns></returns>
		public static string GetDescription<T, U>(this T enumerationValue, Type attributeType)
			where T : struct
			where U : DescriptionAttribute
		{
			Type type = enumerationValue.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
			}

			//Tries to find a DescriptionAttribute for a potential friendly name
			//for the enum
			MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo != null && memberInfo.Length > 0)
			{
				object[] attrs = memberInfo[0].GetCustomAttributes(attributeType, false);

				if (attrs != null && attrs.Length > 0)
				{
					//Pull out the description value
					var attribute = attrs[0] as U;
					return attribute.Description;
				}
			}

			return string.Empty;
		}

		/// <summary>
		/// Returns <see cref="DescriptionAttribute"/> value for enum
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerationValue"></param>
		/// <returns></returns>
		public static string GetDescription<T>(this T enumerationValue) where T : struct
		{
			return enumerationValue.GetDescription<T, DescriptionAttribute>(typeof(DescriptionAttribute));
		}
	}
}