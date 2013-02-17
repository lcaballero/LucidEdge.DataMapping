using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.DataMapping.Samples.SqlScripts;


namespace LucidEdge.DataMapping.Samples.SqlScripts
{
	public static class UserScripts
	{
		public static string Create_Tables { get { return UserSqlScripts.Create_Tables; } }
		public static string Drop_Tables { get { return UserSqlScripts.Drop_Tables; } }
		public static string Insert_User { get { return UserSqlScripts.Insert_User; } }
		public static string Read_All_Users { get { return UserSqlScripts.Read_All_Users; } }
		public static string Read_User_1 { get { return UserSqlScripts.Read_User_1; } }
	}
}
