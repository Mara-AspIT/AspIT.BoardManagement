using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspIT.BoardManagement.Entities;

namespace AspIT.BoardManagement.Tests.EntitiesTests
{
	[TestClass]
	public class SummaryTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			//Arrange:
			Summary s = new Summary("123");			
			string s1 = "123456";
			//Act:
			s.Append("456");
			//Assert:
			Assert.AreEqual(s1, s.Content);
		}
	}
}
