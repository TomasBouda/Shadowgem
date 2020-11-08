using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TomLabs.Shadowgem.Data.Json
{
	/// <summary>
	/// Defines formatting for json serialization
	/// </summary>
	public enum JsonFormatting
	{
		/// <summary>
		/// No special formatting is applied. This is the default.
		/// </summary>
		None = 0,

		/// <summary>
		/// Causes child objects to be indented according to the <see cref="JsonTextWriter.Indentation"/> and <see cref="JsonTextWriter.IndentChar"/> settings.
		/// </summary>
		Indented = 1
	}

	/// <summary>
	/// Specifies null value handling options for the <see cref="JsonSerializer"/>.
	/// </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeNullValueHandlingObject" title="NullValueHandling Class" />
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeNullValueHandlingExample" title="NullValueHandling Ignore Example" />
	/// </example>
	public enum JsonNullValueHandling
	{
		/// <summary>
		/// Include null values when serializing and deserializing objects.
		/// </summary>
		Include = 0,

		/// <summary>
		/// Ignore null values when serializing and deserializing objects.
		/// </summary>
		Ignore = 1
	}

	/// <summary>
	/// Specifies default value handling options for the <see cref="JsonSerializer"/>.
	/// </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeDefaultValueHandlingObject" title="DefaultValueHandling Class" />
	///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeDefaultValueHandlingExample" title="DefaultValueHandling Ignore Example" />
	/// </example>
	[Flags]
	public enum JsonDefaultValueHandling
	{
		/// <summary>
		/// Include members where the member value is the same as the member's default value when serializing objects.
		/// Included members are written to JSON. Has no effect when deserializing.
		/// </summary>
		Include = 0,

		/// <summary>
		/// Ignore members where the member value is the same as the member's default value when serializing objects
		/// so that it is not written to JSON.
		/// This option will ignore all default values (e.g. <c>null</c> for objects and nullable types; <c>0</c> for integers,
		/// decimals and floating point numbers; and <c>false</c> for booleans). The default value ignored can be changed by
		/// placing the <see cref="DefaultValueAttribute"/> on the property.
		/// </summary>
		Ignore = 1,

		/// <summary>
		/// Members with a default value but no JSON will be set to their default value when deserializing.
		/// </summary>
		Populate = 2,

		/// <summary>
		/// Ignore members where the member value is the same as the member's default value when serializing objects
		/// and set members to their default value when deserializing.
		/// </summary>
		IgnoreAndPopulate = Ignore | Populate
	}

	/// <summary>
	/// Defines parameters for json serialization
	/// </summary>
	public class JsonSerializationParams
	{
		/// <summary>
		/// Defines formatting for json serialization
		/// </summary>
		public JsonFormatting Formatting { get; set; } = JsonFormatting.Indented;

		/// <summary>
		/// Gets or sets which character to use for indenting when <see cref="JsonWriter.Formatting"/> is set to <see cref="JsonFormatting.Indented"/>.
		/// </summary>
		public char IndentChar { get; set; } = '\t';

		/// <summary>
		/// Gets or sets how many <see cref="JsonTextWriter.IndentChar"/>s to write for each level in the hierarchy when <see cref="JsonWriter.Formatting"/> is set to <see cref="JsonFormatting.Indented"/>.
		/// </summary>
		public int Indentation { get; set; } = 1;

		/// <summary>
		/// Specifies null value handling options for the <see cref="JsonSerializer"/>.
		/// </summary>
		public JsonNullValueHandling NullValueHandling { get; set; }

		/// <summary>
		/// Specifies default value handling options for the <see cref="JsonSerializer"/>.
		/// </summary>
		public JsonDefaultValueHandling DefaultValueHandling { get; set; }
	}
}
