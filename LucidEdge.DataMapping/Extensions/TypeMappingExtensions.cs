using System;
using System.Data;
using NpgsqlTypes;


namespace LucidEdge.DataMapping
{
	public static class TypeMappingExtensions
	{
		public static DbType ToDbType(this Type t)
		{
			return
			t == typeof(string)
				? DbType.String
				:
			t == typeof(int) || t == typeof(int?)
				? DbType.Int32
				:
			t == typeof(long) || t == typeof(long?)
				? DbType.Int64
				:
			t == typeof(double) || t == typeof(float) || t == typeof(double?) || t == typeof(float?)
				? DbType.Double
				:
			t == typeof(bool) || t == typeof(bool?)
				? DbType.Boolean
				:
			t == typeof(DateTime) || t == typeof(DateTime?)
				? DbType.DateTime
				:
			t == typeof(DateTimeOffset) || t == typeof(DateTimeOffset?)
				? DbType.DateTimeOffset
				:
			DbType.Object;
		}
	}
}
