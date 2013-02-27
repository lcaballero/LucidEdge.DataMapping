using System.Collections.Generic;
using System.Linq;


namespace LucidEdge.DataMapping
{
	/// <summary>
	/// Provides a data class that can create a new connection
	/// string for the PostGres data base.
	/// </summary>
	public class PostGresConnection
	{
		public string Server { get; set; }
		public int? Port { get; set; }
		public string UserId { get; set; }
		public string Password { get; set; }
		public int? Protocol { get; set; }
		public bool? Ssl { get; set; }
		public bool? Pooling { get; set; }
		public int? MinPoolSize { get; set; }
		public int? MaxPoolSize { get; set; }
		public int? Timeout { get; set; }
		public string SslMode { get; set; }
		public string Database { get; set; }

		public PostGresConnection()
		{
			Server = "localhost";
			Port = 5432;
			UserId = "postgres";
			Password = "livebig6";
			Protocol = 3;
			Ssl = false;
			Pooling = false;
			MinPoolSize = 1;
			MaxPoolSize = 20;
			Timeout = 15;
			SslMode = "Disable";
			Database = "StockGames";
		}

		/// <summary>
		/// Turns all the properties into a semi-colon separated string.
		/// </summary>
		/// <returns>
		/// Returns semi-colon separated string of properties.
		/// </returns>
		public override string ToString()
		{
			var b =
				new Dictionary<string, object>
				{
					{"Server", Server},
					{"Port", Port},
					{"Userid", UserId},
					{"Password", Password},
					{"Protocol", Protocol},
					{"SSL", Ssl},
					{"Pooling", Pooling},
					{"MinPoolSize", MinPoolSize},
					{"MaxPoolSize", MaxPoolSize},
					{"Timeout", Timeout},
					{"SslMode", SslMode},
					{"Database", Database}
				};

			var buff =
				string.Join(
					";",
					b.Where(kvp => kvp.Value != null)
						.Select(
							kvp =>
							string.Format(
								"{0}={1}",
								kvp.Key,
								Convert(kvp.Value)))
						.ToArray());

			return buff.ToString();
		}

		/// <summary>
		/// Lowercases boolean values.
		/// </summary>
		/// <param name="a">
		/// Any value.
		/// </param>
		/// <returns>
		/// The value as a string, lowercased if the value is a
		/// nullable boolean.
		/// </returns>
		private string Convert(object a)
		{
			// This function expects ONLY nullable boolean, but
			// if that should change it should check for primitive
			// bool as well.
			return
			a is bool? && ((bool?)a).HasValue
				? ((bool?)a).ToString().ToLower()
				: a.ToString();
		}
	}
}
