using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TomLabs.Shadowgem.Misc
{
	/// <summary>
	/// XML related extensions
	/// </summary>
	public static class XmlExtensions
	{
		/// <summary>
		/// Formats given XML document
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		public static string Beautify(this XDocument doc)
		{
			var sb = new StringBuilder();
			var settings = new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "\t",
				NewLineChars = Environment.NewLine,
				NewLineHandling = NewLineHandling.Replace,
				NewLineOnAttributes = true,
			};

			using (var writer = XmlWriter.Create(sb, settings))
			{
				doc.Save(writer);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Converts <see cref="XDocument"/> to <see cref="XmlDocument"/>
		/// </summary>
		/// <param name="xDocument"></param>
		/// <returns></returns>
		public static XmlDocument ToXmlDocument(this XDocument xDocument)
		{
			var xmlDocument = new XmlDocument();
			using (var xmlReader = xDocument.CreateReader())
			{
				xmlDocument.Load(xmlReader);
			}
			return xmlDocument;
		}

		/// <summary>
		/// Converts <see cref="XmlDocument"/> to <see cref="XDocument"/>
		/// </summary>
		/// <param name="xmlDocument"></param>
		/// <returns></returns>
		public static XDocument ToXDocument(this XmlDocument xmlDocument)
		{
			using (var nodeReader = new XmlNodeReader(xmlDocument))
			{
				nodeReader.MoveToContent();
				return XDocument.Load(nodeReader);
			}
		}

		/// <summary>
		/// Converts <see cref="XElement"/> to <see cref="XmlDocument"/>
		/// </summary>
		/// <param name="xElement"></param>
		/// <returns></returns>
		public static XmlDocument ToXmlDocument(this XElement xElement)
		{
			var sb = new StringBuilder();
			var xws = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false };
			using (var xw = XmlWriter.Create(sb, xws))
			{
				xElement.WriteTo(xw);
			}
			var doc = new XmlDocument();
			doc.LoadXml(sb.ToString());
			return doc;
		}

		/// <summary>
		/// Converts <see cref="XmlDocument"/> to <see cref="Stream"/>
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		public static Stream ToMemoryStream(this XmlDocument doc)
		{
			var xmlStream = new MemoryStream();
			doc.Save(xmlStream);
			xmlStream.Flush();  //	Adjust this if you want read your data
			xmlStream.Position = 0;
			return xmlStream;
		}
	}
}