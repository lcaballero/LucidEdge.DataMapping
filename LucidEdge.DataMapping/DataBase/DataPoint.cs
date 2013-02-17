using System;
using System.Data;


namespace LucidEdge.DataMapping
{
	/// <summary>
	/// A single DataPoint instance typically maps to a single field
	/// in a single row.
	/// </summary>
	public class DataPoint
	{
		/// <summary>
		/// The column or name of the data point.
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// The Type of the Value for this data point.
		/// </summary>
		public Type DataType { get; set; }

		/// <summary>
		/// This is a less used properties that is not always
		/// provided and represents the position of the field
		/// in the given row.
		/// </summary>
		public int? Ordinal { get; set; }

		/// <summary>
		/// The raw value either being sent to the DataBase or
		/// a result of a query.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Default contructor provided so that clients can use
		/// the initializer syntax if they should prefer that
		/// instead.
		/// </summary>
		public DataPoint() { }

		/// <summary>
		/// Creates a DataPoint where the value is tied to the
		/// given name.
		/// </summary>
		/// <param name="col">
		/// The name or column of the data point.
		/// </param>
		/// <param name="value">
		/// The value which this DataPoint wraps.
		/// </param>
		public DataPoint(string col, object value)
		{
			Value = value;
			ColumnName = col;
			DataType = value.GetType();
		}
	}
}
