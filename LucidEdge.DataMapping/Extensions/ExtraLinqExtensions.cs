using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace LucidEdge.DataMapping
{
	public static class ExtraLinqExtensions
	{
		/// <summary>
		/// Creates an IEnumerable of ints producing the sequence [from, to).
		/// </summary>
		/// <remarks>
		/// Currently this function only provides a forward sequence such
		/// that from is less than to, and doesn't attempt to enforce
		/// that either.
		/// </remarks>
		/// <param name="from">
		/// The inclusive lower bound.
		/// </param>
		/// <param name="to">
		/// The exclusive upper bound.
		/// </param>
		/// <returns>
		/// IEnumerable of the ints in the range [from, to).
		/// </returns>
		public static IEnumerable<int> To(this int from, int to)
		{
			for (int i = from; i < to; i++)
			{
				yield return i;
			}
		}

		/// <summary>
		/// The normal Aggregate function which also includes the index
		/// of each item in the collection.
		/// </summary>
		/// <typeparam name="TSource">
		/// The type of the collection.
		/// </typeparam>
		/// <typeparam name="TAccumulate">
		/// The resulting (reduced) type.
		/// </typeparam>
		/// <param name="source">
		/// Collection which can be iterated over.
		/// </param>
		/// <param name="n">
		/// The starting index for items in the collection, defaulting to 0.
		/// </param>
		/// <param name="seed">
		/// The starting value off the accumulation.
		/// </param>
		/// <param name="func">
		/// Function that returns accumulation, takes an item and the index.
		/// </param>
		/// <returns>
		/// The reduced/aggregate value.
		/// </returns>
		public static TAccumulate Aggregate<TSource, TAccumulate>(
			this IEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate, TSource, int, TAccumulate> func,
			int n = 0)
		{
			return source.Aggregate(seed, (acc, item) => func(acc, item, n++));
		}

		/// <summary>
		/// A while construct that produces new values that are collected in
		/// the resulting IEnumerable.
		/// </summary>
		/// <typeparam name="TItem">
		/// The type of items produced by the itemProvider.
		/// </typeparam>
		/// <typeparam name="TReader">
		/// The type of the the initial value that is consulted during each
		/// iteration.
		/// </typeparam>
		/// <param name="reader">
		/// Some variable that is consulted to control the continuation of
		/// the looping.
		/// </param>
		/// <param name="continueFn">
		/// The function that returns true and causes the loop to continue
		/// and producing addtional elements.
		/// </param>
		/// <param name="itemProvider">
		/// Function that takes the reader and the index of the and produces
		/// a new value for the collection.
		/// </param>
		/// <returns>
		/// A new collection of items.
		/// </returns>
		public static IEnumerable<TItem> While<TItem,TReader>(
			this TReader reader,
			Predicate<TReader> continueFn,
			Func<TReader, int, TItem> itemProvider)
		{
			int row = 0;
			while (continueFn(reader))
			{
				yield return itemProvider(reader, row++);
			}
		}
	}
}
