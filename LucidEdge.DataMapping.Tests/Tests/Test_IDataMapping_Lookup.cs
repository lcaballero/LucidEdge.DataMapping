using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LucidEdge.DataMapping.Tests
{
	[TestFixture]
	public class Test_IDataMapping_Lookup : AssertionHelper
	{
public class UserProfile : DomainObject
{
	public long? Id { get { return Map["Id"].ToValue<long?>(); } }
	public int? Version { get { return Map["Version"].ToValue<int?>(); } }
	public DateTime? Created_At { get { return Map["Created_At"].ToValue<DateTime?>(); } }
	public DateTime? Updated_On { get { return Map["Updated_On"].ToValue<DateTime?>(); } }
	public bool IsActive { get { return Map["IsActive"].ToValue<bool>(); } }
	public bool IsLocked { get { return Map["IsLocked"].ToValue<bool>(); } }

	public string UserName { get { return Map["UserName"].ToValue<string>(); } }
	public string Password { get { return Map["Password"].ToValue<string>(); } }
	public int? UserGroup_Id { get { return Map["UserGroup_Id"].ToValue<int?>(); } }

	public string Phone { get; set; }
	public string Email { get; set; }
}

		[Test]
		public void Conversion_DataPoints_To_IDataMapping()
		{
			Random rand = new Random();

			var id = (long)rand.Next();
			var version = rand.Next();
			var created_at = DateTime.Now;
			var updated_on = DateTime.Now;
			var group_id = rand.Next();

			var dps =
				new List<DataPoint>()
					.Add("id", id)
					.Add("version", version)
					.Add("created_at", created_at)
					.Add("updated_on", updated_on)
					.Add("isactive", true)
					.Add("islocked", true)
					.Add("usergroup_id", group_id)
					.Add("password", "password")
					.Add("username", "username")
					.ToDataMapping<UserProfile>();

			Expect(dps.Id, Is.EqualTo(id));
			Expect(dps.Version, Is.EqualTo(version));
			Expect(dps.Created_At, Is.EqualTo(created_at)); 
			Expect(dps.Updated_On, Is.EqualTo(updated_on));
			Expect(dps.UserGroup_Id, Is.EqualTo(group_id));
		}
	}
}
