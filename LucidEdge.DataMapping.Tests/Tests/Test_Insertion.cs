using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.DataMapping.Samples;
using LucidEdge.DataMapping.Samples.SqlScripts;


namespace LucidEdge.DataMapping.Tests
{
	[TestFixture]
	public class Test_Insertion : AssertionHelper
	{
		private Random Rand = new Random();

		[Test]
		public void Insert_New_User()
		{
			var dps = new List<DataPoint>()
				.Add("id", Rand.Next())
				.Add("version", Rand.Next())
				.Add("created_at", DateTime.Now)
				.Add("updated_on", DateTime.Now)
				.Add("isactive", true)
				.Add("islocked", true)
				.Add("usergroup_id", Rand.Next())
				.Add("password", "w4llst")
				.Add("username", "lucas.caballero");

			UserScripts.Insert_User.Insert(dps);
		}

		[Test]
		public void Read_All_Users()
		{
		}
	}
}
