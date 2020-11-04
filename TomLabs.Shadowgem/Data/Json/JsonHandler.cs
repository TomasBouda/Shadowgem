using System.Globalization;
using System.IO;
using System.Text;
using Hjson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TomLabs.Shadowgem.Data.Json
{
	/// <summary>
	/// Helper for handling json and hjson serialization/deserialization
	/// </summary>
	public static class JsonHandler
	{
		/// <summary>
		/// Deserializes given hjson file into object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="hjsonFilePath"></param>
		/// <returns></returns>
		public static T DeserializeHJson<T>(string hjsonFilePath)
		{
			return DeserializeJsonString<T>(HjsonValue.Load(hjsonFilePath).ToString());
		}

		/// <summary>
		/// Deserializes given json file into object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonFilePath"></param>
		/// <returns></returns>
		public static T DeserializeJson<T>(string jsonFilePath)
		{
			if (string.IsNullOrEmpty(jsonFilePath))
			{
				throw new System.ArgumentException("Missing json path", nameof(jsonFilePath));
			}

			return DeserializeJsonString<T>(File.ReadAllText(jsonFilePath));
		}

		private static T DeserializeJsonString<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		/// <summary>
		/// Serializes given object into hjson string
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="object"></param>
		/// <param name="params"></param>
		/// <returns></returns>
		public static string SerializeToHJson<T>(T @object, JsonSerializationParams @params = null)
		{
			return JsonValue.Parse(SerializeToJson(@object, @params)).ToString(Stringify.Hjson);
		}

		/// <summary>
		/// Serializes given object into json string
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="object"></param>
		/// <param name="params"></param>
		/// <returns></returns>
		public static string SerializeToJson<T>(T @object, JsonSerializationParams @params = null)
		{
			StringBuilder sb = new StringBuilder(256);
			StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);

			@params = @params ?? new JsonSerializationParams();

			var jsonSerializer = JsonSerializer.CreateDefault();
			using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
			{
				jsonWriter.Formatting = (Formatting)@params.Formatting;
				jsonWriter.IndentChar = @params.IndentChar;
				jsonWriter.Indentation = @params.Indentation;

				jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
				jsonSerializer.NullValueHandling = (NullValueHandling)@params.NullValueHandling;
				jsonSerializer.DefaultValueHandling = (DefaultValueHandling)@params.DefaultValueHandling;
				jsonSerializer.Serialize(jsonWriter, @object, typeof(T));
			}

			return sw.ToString();
		}
	}
}
