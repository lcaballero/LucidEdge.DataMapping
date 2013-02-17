using NUnit.Framework;


namespace LucidEdge.DataMapping.Tests
{
	[TestFixture]
	public class Test_Connection_Parameters : AssertionHelper
	{
		[Test]
		public void Default_Values()
		{
			var conn = new PostGresConnection();

			Expect(conn.Server, Is.EqualTo("localhost"));
			Expect(conn.Port, Is.EqualTo(5432));
			Expect(conn.UserId, Is.EqualTo("postgres"));
			Expect(conn.Password, Is.EqualTo("livebig6"));
			Expect(conn.Protocol, Is.EqualTo(3));
			Expect(!conn.Ssl.Value);
			Expect(!conn.Pooling.Value);
			Expect(conn.MinPoolSize, Is.EqualTo(1));
			Expect(conn.MaxPoolSize, Is.EqualTo(20));
			Expect(conn.Timeout, Is.EqualTo(15));
			Expect(conn.SslMode, Is.EqualTo("Disable"));
			Expect(conn.Database, Is.EqualTo("Overflow"));
		}

		[Test]
		public void Connection_String_ToString()
		{
			var s =
				string.Join(";",
					new[]
					{
						"Server=localhost",
						"Port=5432",
						"Userid=postgres",
						"Password=livebig6",
						"Protocol=3",
						"SSL=false",
						"Pooling=false",
						"MinPoolSize=1",
						"MaxPoolSize=20",
						"Timeout=15",
						"SslMode=Disable",
						"Database=Overflow"
					});

			Expect(s, Is.EqualTo(new PostGresConnection().ToString()));
		}
	}
}
