
using Common.Interfaces;

namespace Common.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// joins a list of strings
		/// </summary>
		/// <typeparam name="TEnt"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="sep"></param>
		/// <returns></returns>
		public static string GetJoinedStr<TEnt>(this IEnumerable<TEnt> enumerable, string sep = ", ")
		{
			// ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
			string ret = string.Join(sep, enumerable ?? Enumerable.Empty<TEnt>());
			return ret;
		}

		/// <summary>
		/// joins a list of strings fetched from the properties of s list of objects
		/// </summary>
		/// <typeparam name="TEnt">entity type</typeparam>
		/// <typeparam name="TProp">property type</typeparam>
		/// <param name="enumerable"></param>
		/// <param name="propSelector"></param>
		/// <param name="sep"></param>
		/// <returns></returns>
		public static string GetJoinedStr<TEnt, TProp>(this IEnumerable<TEnt> enumerable, 
			Func<TEnt, TProp> propSelector,
			string sep = ", ")
		{
			var list = enumerable
				.Select(propSelector)
				.ToList()
				.Select(e => e?.ToString() ?? "");
			return GetJoinedStr(list, sep);
		}

		/// <summary>
		/// get a string by joining the first specified items in a provided enumerable
		/// </summary>
		/// <typeparam name="TEnt">entity type</typeparam>
		/// <param name="enumerable">enumerable</param>
		/// <param name="max">max items to join</param>
		/// <param name="sep">separator</param>
		/// <returns></returns>
		public static string GetJoinedPartialStr<TEnt>(this IEnumerable<TEnt> enumerable, int max = 10, string sep = ", ")
		{
			var list = enumerable.ToList();
			bool requiresPlus = list.Count > max;
			var firstItems = list.Take(max);

			string itemStr = GetJoinedStr(firstItems, sep);
			string ret = requiresPlus ? $"{itemStr} + {list.Count - max}" : itemStr;
			return ret;
		}

		/// <summary>
		/// provides a page from an IQueryable
		/// </summary>
		/// <param name="entities"></param>
		/// <param name="pagingInfo"></param>
		/// <param name="defaultSize"></param>
		/// <returns></returns>
		public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> entities, IPaginationInfo pagingInfo, int defaultSize = 10)
		{
			int actualPageIndex = Math.Max(pagingInfo.PageIndex, 0);
			int actualPageSize = pagingInfo.PageSize > 0 ? pagingInfo.PageSize : defaultSize;

			var ret = entities
				.Skip(actualPageIndex + actualPageSize)
				.Take(actualPageSize);
			return ret;
		}
	}
}
