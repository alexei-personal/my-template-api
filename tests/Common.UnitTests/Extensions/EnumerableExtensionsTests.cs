using Common.Dtos;
using Common.Extensions;
using FluentAssertions;

namespace Common.UnitTests.Extensions;

public class EnumerableExtensionsTests
{
	#region GetJoinedStr

	[Fact]
	public void GetJoinedStr_WithValidInput_ReturnsExpectedString()
	{
		// Arrange
		var input = new[] { "a", "b", "c" };
		const string sep = "|";

		// Act
		string result = input.GetJoinedStr(sep);

		// Assert
		string expected = string.Join(sep, input);
		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithNullInput_ReturnsEmptyString()
	{
		// Arrange
		IEnumerable<string>? input = null;

		// Act
		string result = input.GetJoinedStr();

		// Assert
		result.Should().BeEmpty();
	}

	[Fact]
	public void GetJoinedStr_WithEmptyInput_ReturnsEmptyString()
	{
		// Arrange
		var input = Enumerable.Empty<string>();

		// Act
		string result = input.GetJoinedStr();

		// Assert
		result.Should().BeEmpty();
	}

	[Fact]
	public void GetJoinedStr_WithNullSeparator_UsesDefaultSeparator()
	{
		// Arrange
		var input = new[] { "a", "b", "c" };

		// Act
		string result = input.GetJoinedStr();

		// Assert
		string expected = string.Join(", ", input);
		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithIntInput_ReturnsExpectedResult()
	{
		int[] input = { 1, 2, 3, 4, 5 };
		const string expected = "1, 2, 3, 4, 5";

		string result = input.GetJoinedStr();

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithIntInputAndCustomSeparator_ReturnsExpectedResult()
	{
		int[] input = { 1, 2, 3, 4, 5 };
		const string separator = "|";
		const string expected = "1|2|3|4|5";

		string result = input.GetJoinedStr(separator);

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithEmptyIntInput_ReturnsEmptyString()
	{
		int[] input = Array.Empty<int>();
		string expected = string.Empty;

		string result = input.GetJoinedStr();

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithNullIntInput_ReturnsEmptyString()
	{
		int[]? input = null;
		string expected = string.Empty;

		string result = input.GetJoinedStr();

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithPersonInput_ReturnsExpectedResult()
	{
		Person[] input =
		{
			new() { Id = 1, Name = "John" }, new() { Id = 2, Name = "Jane" }, new() { Id = 3, Name = "Jim" },
		};
		string expected = "1 John, 2 Jane, 3 Jim";

		string result = input.GetJoinedStr(p => $"{p.Id} {p.Name}");

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithPersonInputAndCustomSeparator_ReturnsExpectedResult()
	{
		Person[] input =
		{
			new Person { Id = 1, Name = "John" }, new Person { Id = 2, Name = "Jane" },
			new Person { Id = 3, Name = "Jim" },
		};
		string separator = "|";
		string expected = "1 John|2 Jane|3 Jim";

		string result = input.GetJoinedStr(p => $"{p.Id} {p.Name}", separator);

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithEmptyPersonInput_ReturnsEmptyString()
	{
		var input = Array.Empty<Person>();
		string expected = string.Empty;

		string result = input.GetJoinedStr(p => $"{p.Id} {p.Name}");

		result.Should().Be(expected);
	}

	[Fact]
	public void GetJoinedStr_WithNullPersonInput_ReturnsEmptyString()
	{
		Person[]? input = null;
		string expected = string.Empty;

		string result = input.GetJoinedStr(p => $"{p.Id} {p.Name}");

		result.Should().Be(expected);
	}

	#endregion GetJoinedStr

	#region GetJoinedPartialStr

	[Fact]
	public void GetJoinedPartialStr_WithInputLessThanMax_ReturnsFullString()
	{
		int[] input = { 1, 2, 3 };
		int max = 10;
		string sep = ", ";

		string result = input.GetJoinedPartialStr(max, sep);

		result.Should().Be("1, 2, 3");
	}

	[Fact]
	public void GetJoinedPartialStr_WithInputEqualToMax_ReturnsFullString()
	{
		int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		const int max = 10;
		const string sep = ", ";

		string result = input.GetJoinedPartialStr(max, sep);

		result.Should().Be("1, 2, 3, 4, 5, 6, 7, 8, 9, 10");
	}

	[Fact]
	public void GetJoinedPartialStr_WithInputGreaterThanMax_ReturnsPartialString()
	{
		int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
		const int max = 10;
		const string sep = ", ";

		string result = input.GetJoinedPartialStr(max, sep);

		result.Should().Be("1, 2, 3, 4, 5, 6, 7, 8, 9, 10 + 2");
	}

	[Fact]
	public void GetJoinedPartialStr_WithNoSeparator_UsesDefaultSeparator()
	{
		int[] input = { 1, 2, 3, 4, 5 };
		const int max = 3;

		string result = input.GetJoinedPartialStr(max);

		result.Should().Be("1, 2, 3 + 2");
	}

	[Fact]
	public void GetJoinedPartialStr_WithZeroMax_ReturnsEmptyString()
	{
		int[] input = { 1, 2, 3, 4, 5 };
		const int max = 0;
		const string sep = ", ";

		string result = input.GetJoinedPartialStr(max, sep);

		result.Should().Be("");
	}

	#endregion

	#region ApplyPaging

	[Fact]
	public void ApplyPaging_WithPositivePageIndexAndSize_SetsPaging()
	{
		var entities = Enumerable.Range(0, 100).AsQueryable();
		var pagingInfo = new PaginationInfo { PageIndex = 2, PageSize = 10 };

		var result = entities.ApplyPaging(pagingInfo);

		result.Should().HaveCount(10);
		result.Should().ContainInOrder(Enumerable.Range(10, 10));
	}

	[Fact]
	public void ApplyPaging_WithZeroPageIndexAndSize_SetsDefaultPaging()
	{
		var entities = Enumerable.Range(0, 100).AsQueryable();
		var pagingInfo = new PaginationInfo { PageIndex = 0, PageSize = 0 };

		var result = entities.ApplyPaging(pagingInfo);

		result.Should().HaveCount(10);
		result.Should().ContainInOrder(Enumerable.Range(0, 10));
	}

	[Fact]
	public void ApplyPaging_WithNegativePageIndex_UsesFirstPage()
	{
		var entities = Enumerable.Range(0, 100).AsQueryable();
		var pagingInfo = new PaginationInfo { PageIndex = -10, PageSize = 10 };

		var result = entities.ApplyPaging(pagingInfo);

		result.Should().HaveCount(10);
		result.Should().ContainInOrder(Enumerable.Range(0, 10));
	}

	[Fact]
	public void ApplyPaging_WithNegativePageSize_UsesDefaultPageSize()
	{
		var entities = Enumerable.Range(0, 100).AsQueryable();
		var pagingInfo = new PaginationInfo { PageIndex = 2, PageSize = -10 };

		var result = entities.ApplyPaging(pagingInfo);

		result.Should().HaveCount(10);
		result.Should().ContainInOrder(Enumerable.Range(10, 10));
	}

	#endregion ApplyPaging

	private class Person
	{
		public int Id { get; init; }
		public string Name { get; init; } = default!;
	}
}
