using System.Collections.Generic;
using System.Text;


namespace LucidEdge.DataMapping
{
	/// <summary>
	/// The result of some SQL query typically, where the data has been
	/// mapped to a list of lists of data points, where each list of
	/// data points is a row.
	/// </summary>
	public class OutputResult
	{
		/// <summary>
		/// The number of fields in this particular result.  The number of
		/// fields is typically the number of columns in a row.
		/// </summary>
		public int? FieldCount { get; set; }

		/// <summary>
		/// The name of the table from which this result was queried and
		/// created from.
		/// </summary>
		public string TableName { get; set; }

		/// <summary>
		/// The columns found in the table.
		/// </summary>
		public List<DataPoint> Columns { get; set; }

		/// <summary>
		/// Accumulates a list of data points in the form of Results and
		/// Rows.  Each data point typically maps to a column and those
		/// columns are typically mapped to a property in a strongly
		/// typed map.
		/// </summary>
		public List<List<DataPoint>> Rows { get; set; }

		/// <summary>
		/// Produces a string of the data in this form:
		/// 
		/// 0.column-name:data-type:value
		/// 1.column-name:data-type:value
		/// 2.column-name:data-type:value
		/// ...
		/// </summary>
		/// <returns>
		/// A simple format providing most of the data found in this
		/// result.
		/// </returns>
		public override string ToString()
		{
			return
			Rows
				.Aggregate(
					new StringBuilder(),
					(acc, result, n) =>
					result.Aggregate(
						acc,
						(acc2, dps, k) =>
						acc2.AppendFormat("{0}.{1}.", n, k)
							.Append(dps.ColumnName)
							.AppendFormat(":{0}", dps.DataType.Name)
							.AppendFormat(":{0}", dps.Value)
							.AppendLine()),
						0)
				.ToString();
		}
	}
}
