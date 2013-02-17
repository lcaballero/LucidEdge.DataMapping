using System;
using System.Collections.Generic;
using LucidEdge.DataMapping;


namespace LucidEdge.DataMapping.Samples.DomainObjects
{
	public class BaseDomainObject : DomainObject
	{
		public long? Id { get { return Map["Id"].ToValue<long?>(); } }
		public int? Version { get { return Map["Version"].ToValue<int?>(); } }
		public DateTime? Created_At { get { return Map["Created_At"].ToValue<DateTime?>(); } }
		public DateTime? Updated_On { get { return Map["Updated_On"].ToValue<DateTime?>(); } }
		public bool IsActive { get { return Map["IsActive"].ToValue<bool>(); } }
		public bool IsLocked { get { return Map["IsLocked"].ToValue<bool>(); } }
	}

	public class User : BaseDomainObject
	{
		public string UserName { get { return Map["UserName"].ToValue<string>(); } }
		public string Password { get { return Map["Password"].ToValue<string>(); } }
		public int? UserGroup_Id { get { return Map["UserGroup_Id"].ToValue<int?>(); } }

		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
