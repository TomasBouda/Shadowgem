using Microsoft.VisualStudio.TestTools.UnitTesting;
using TomLabs.Shadowgem.String;

namespace TomLabs.Shadowgem.Tests
{
	[TestClass]
	public class StringTests
	{
		private const string CustomString = "the swift brown fox jumped over the lazy dog";

		[TestMethod]
		public void TestStringExtensionMethods()
		{
			// Like
			Assert.IsTrue(CustomString.Like("%dog"));
			Assert.IsTrue(CustomString.Like("%fox%"));
			Assert.IsTrue(CustomString.Like("the%"));

			// FillIn
			Assert.AreEqual("the swift brown {0} jumped over the lazy {1}".FillIn("fox", "dog"), CustomString);

			// RemoveRange
			string removed = CustomString.RemoveRange("the", "over");
			Assert.AreEqual(removed, " the lazy dog");

			// ReplaceAll
			Assert.AreEqual(CustomString.ReplaceAll("chicken", "fox", "dog"), "the swift brown chicken jumped over the lazy chicken");

			// ReplaceAt
			Assert.AreEqual(CustomString.ReplaceAt(16, 'b'), "the swift brown box jumped over the lazy dog");
		}
	}
}
