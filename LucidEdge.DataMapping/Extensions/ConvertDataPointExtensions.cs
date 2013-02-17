using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CV = System.Convert;


namespace LucidEdge.DataMapping
{
	/// <summary>
	/// Handful of Extension functions to manipulate DataPoint or collections of DataPoint.
	/// </summary>
	public static class ConvertDataPointExtensions
	{
		/// <summary>
		/// Take the given data point and casts the DataPoint's value to the specific type.
		/// </summary>
		/// <typeparam name="T">
		/// The type of value to attempt to provide from the DataPoint.
		/// </typeparam>
		/// <param name="p">
		/// A DataPoint provided from some data source.
		/// </param>
		/// <returns>
		/// The DataPoint.Value cas to T.
		/// </returns>
		public static T ToValue<T>(this DataPoint p)
		{
			return (T)p.Value;
		}

		/// <summary>
		/// This method is provided as a convenience because most DataPoints
		/// are provided as a stream of points, and a map needs to be case
		/// insensitive because most mapping is to columns in a data base,
		/// and SQL is not case-sensitive.
		/// </summary>
		/// <param name="dps">
		/// A collection of data points (typically mapping to a row in a DB).
		/// </param>
		/// <returns>
		/// A lookup table of Columns to the DataPoint where case is ignored.
		/// </returns>
		public static IDictionary<string, DataPoint> ToDataMap(this List<DataPoint> dps)
		{
			return
			dps.ToDictionary(
				p => p.ColumnName,
				p => p,
				StringComparer.InvariantCultureIgnoreCase);
		}

		/// <summary>
		/// Maps these datapoint to a new instance which implements IDataMapping.
		/// </summary>
		/// <typeparam name="T">
		/// Class that implements IDataMapping.
		/// </typeparam>
		/// <param name="dps">
		/// List of DataPoints.
		/// </param>
		/// <returns>
		/// New instance of T with the Data points organized into a data map and
		/// set as the Map.
		/// </returns>
		public static T ToDataMapping<T>(this List<DataPoint> dps)
			where T : class, IDataMapping, new()
		{
			return new T { Map = dps.ToDataMap() };
		}
	}
}
