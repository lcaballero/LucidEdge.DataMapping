using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;


namespace LucidEdge.DataMapping
{
	public static class DatabaseExecutionExtensions
	{
		public static OutputResult ReadResult(this IDataReader data_reader)
		{
			return ReadResult(data_reader, data_reader.GetSchemaTable());
		}

		/// <summary>
		/// Creates an OutputResult by reading each row of the dataReader
		/// and using the dataTable it can fill in things like the column
		/// name, the data type, the field position (ordinal), etc so
		/// that a full picture of the row is produced.
		/// </summary>
		/// <param name="reader">
		/// An implementation of an IDataReader at the first with the
		/// cursor at the first row such that further reading will produce
		/// subsequent rows.
		/// </param>
		/// <param name="table">
		/// The DataTable of the current row such that it will produce
		/// meta-data for the current row.
		/// </param>
		/// <returns>
		/// A new OutputResult that contains informatoin about all of
		/// the columns and the data points of the result.
		/// </returns>
		public static OutputResult ReadResult(
			this IDataReader reader, DataTable table)
		{
			return
			new OutputResult
			{
				TableName = table.TableName,
				FieldCount = reader.FieldCount,
				Columns = table.ToColumns(),
				Rows = reader.ToRows().ToList()
			};
		}

		/// <summary>
		/// Iterates over all of the rows creating a new List of DataPoints that
		/// maps to each row in the result eventually collecting up all of the
		/// rows.
		/// </summary>
		/// <param name="reader">
		/// A cursor ready to read rows.
		/// </param>
		/// <returns>
		/// Rows of columns and their data points.
		/// </returns>
		public static IEnumerable<List<DataPoint>> ToRows(this IDataReader reader)
		{
			return reader.While(HasRows, ToRow);
		}

		/// <summary>
		/// Simply checks that the Reader can indeed read another row of data,
		/// and as side effect moves the cursor forward.
		/// </summary>
		/// <param name="r">
		/// A reader, which will move forward one row if it has a next row.
		/// </param>
		/// <returns>
		/// True if there is a next row to read.
		/// </returns>
		public static bool HasRows(this IDataReader r)
		{
			return r.Read();
		}

		/// <summary>
		/// Using the reader, and provided which row the reader is reading over,
		/// will produce a List of DataPoints from the columns of data in the
		/// row.
		/// </summary>
		/// <param name="r">
		/// DataReader over the current row.
		/// </param>
		/// <param name="row">
		/// The ordinal number of the current row.
		/// </param>
		/// <returns>
		/// List of column data for the current row, where the ordinal
		/// indicates the row number not the field position.
		/// </returns>
		public static List<DataPoint> ToRow(this IDataReader r, int row)
		{
			return
			(0).To(r.FieldCount)
				.Select(
					i =>
					new DataPoint
					{
						Ordinal = row,
						ColumnName = r.GetName(i),
						DataType = r.GetFieldType(i),
						Value = r[i]
					})
				.ToList();
		}

		/// <summary>
		/// Simply pulls the column meta-data of the DataTable.
		/// </summary>
		/// <param name="table">
		/// The current DataTable to pull column information from.
		/// </param>
		/// <returns>
		/// List of columns in as DataPoints with the Ordinal indicating
		/// field position (instead of Row).
		/// </returns>
		public static List<DataPoint> ToColumns(this DataTable table)
		{
			return
			(0).To(table.Columns.Count)
				.Select(n => table.Columns[n])
				.Select(
					col =>
					new DataPoint
					{
						ColumnName = col.ColumnName,
						DataType = col.DataType,
						Ordinal = col.Ordinal
					})
				.ToList();
		}
	}
}
