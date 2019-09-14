using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NUnit.Framework;
using TomLabs.Shadowgem.Common;

namespace TomLabs.Shadowgem.Tests.Common
{
	internal class ChildDescription : System.ComponentModel.DescriptionAttribute
	{
		public ChildDescription() : base()
		{
		}

		public ChildDescription(string description) : base(description)
		{
		}
	}

	internal enum SomeEnum
	{
		[System.ComponentModel.Description("one desc")]
		[ChildDescription("one child desc")]
		one,

		[System.ComponentModel.Description("two desc")]
		two,

		[System.ComponentModel.Description("three desc")]
		three,

		[System.ComponentModel.Description("four desc")]
		four,

		[System.ComponentModel.Description("five desc")]
		five,

		[System.ComponentModel.Description("six desc")]
		six,

		[System.ComponentModel.Description("seven desc")]
		seven,

		eight
	}

	[Flags]
	internal enum Flags
	{
		none,
		one,
		two = 2,
		three = 4,
		four = one | two | three
	}

	[TestFixture]
	internal class EnumTests
	{
		[TestCase]
		public void GetDescriptionTest()
		{
			Assert.AreEqual("one desc", SomeEnum.one.GetDescription());
			Assert.AreEqual("one child desc", SomeEnum.one.GetDescription<SomeEnum, ChildDescription>(typeof(ChildDescription)));

			Assert.AreEqual(string.Empty, SomeEnum.eight.GetDescription());
		}
	}
}