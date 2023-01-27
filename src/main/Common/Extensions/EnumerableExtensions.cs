
namespace Common.Extensions
{
	public static class EnumerableExtensions
	{
		public static string GetJoinedStr<TEnt>(this IEnumerable<TEnt> enumerable, string sep = ", ")
		{
			string ret = string.Join(sep, enumerable ?? Enumerable.Empty<TEnt>());
			return ret;
		}
	}
}