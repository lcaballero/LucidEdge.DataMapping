using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.DataMapping.Samples.DomainObjects;
using LucidEdge.DataMapping.Samples;
using LucidEdge.DataMapping.Samples.SqlScripts;


namespace LucidEdge.DataMapping.Tests
{
	[TestFixture]
	public class Test_Select : AssertionHelper
	{
		[Test]
		public void Select_All()
		{
			var u =
				UserScripts.Read_All_Users.Read<User>(
					new List<DataPoint>());

			Expect(u, Is.Not.Null);
			Expect(u.Any(b => b.UserName == "lucas.caballero"));
			Expect(u.Any(b => b.Password == "w4llst"));
		}
	}
}
