using System;
using NUnit.Framework;
using TomLabs.Shadowgem.Text;

namespace TomLabs.Shadowgem.Tests
{
	[TestFixture]
	public class StringTests
	{
		private const string CustomString = "the swift brown fox jumped over the lazy dog";

		[TestCase]
		public void LikeTest()
		{
			Assert.IsTrue(CustomString.Like("%dog"));
			Assert.IsTrue(CustomString.Like("%fox%"));
			Assert.IsTrue(CustomString.Like("the%"));
		}

		[TestCase]
		public void FillInTest()
		{
			Assert.AreEqual("the swift brown {0} jumped over the lazy {1}".FillIn("fox", "dog"), CustomString);
		}

		[TestCase]
		public void RemoveRangeTest()
		{
			string removed = CustomString.RemoveRange("the", "over");
			Assert.AreEqual(removed, " the lazy dog");
		}

		[TestCase]
		public void ReplaceAllTest()
		{
			Assert.AreEqual(CustomString.ReplaceAll("chicken", "fox", "dog"), "the swift brown chicken jumped over the lazy chicken");
		}

		[TestCase]
		public void ReplaceAtTest()
		{
			Assert.AreEqual(CustomString.ReplaceAt(16, 'b'), "the swift brown box jumped over the lazy dog");
		}

		[TestCase]
		public void RemoveDiacriticsTest()
		{
			Console.WriteLine("Tomáš Bouda.=%_ 123456".RemoveDiacritics());
		}

		[TestCase]
		public void RemoveSpecialCharactersTest()
		{
			Console.WriteLine("Tomáš Bouda.=%_ 123456".RemoveSpecialCharacters('_'));
		}
	}
}