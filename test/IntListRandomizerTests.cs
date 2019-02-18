using AMT.LinqExtensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;


namespace Test.AMT.LinqExtensions
{
    // TODO: include when doing code coverage
    // [ExcludeFromCodeCoverage]

	public class IntListRandomizerTests : IClassFixture<IntListTestFixture>
	{
		IntListTestFixture _testData;


		public IntListRandomizerTests(IntListTestFixture testData)
		{
			_testData = testData;
		}


		#region Positive tests

		[Fact]
		public void random_element_from_int_list()
		{
			IEnumerable<int> enr = _testData.TestList as IEnumerable<int>;

			for (int i = 0; i < _testData.TestList.Count; ++i)
			{
				// Test via the method taking ICollection
				int curr = _testData.TestList.Random();
				curr.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);

				// Test via the method taking IEnumerable
				curr = enr.Random();
				curr.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);
			}
		}


		[Fact]
		public void random_element_from_single_item_list()
		{
			// Create a list with only 1 element
			int knownInt = 7466;
			List<int> list = new List<int>();
			list.Add(knownInt);
			IEnumerable<int> enr = list as IEnumerable<int>;

			// Get random from the list several times. Should only receive the single element.
			for (int i = 0; i < 5; ++i)
			{
				// Test via the method taking ICollection
				(list.Random()).Should().Be(knownInt);

				// Test via the method taking IEnumerable
				(enr.Random()).Should().Be(knownInt);
			}
		}


		[Fact]
		public void random_element_from_Dictionary()
		{
			// Create a collection with asso'd enumerator, and populate it.
			Dictionary<int, string> dict = new Dictionary<int, string>();
			IEnumerable<KeyValuePair<int, string>> enr = dict as IEnumerable<KeyValuePair<int, string>>;
			for (int i = 0; i < 250; ++i) { dict.Add(i, i.ToString()); }


			for (int i = 0; i < dict.Count; ++i)
			{
				// Test via the method taking ICollection
				var curr = dict.Random();
				curr.Key.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);
				curr.Value.Should().BeEquivalentTo(curr.Key.ToString());

				// Test via the method taking IEnumerable
				curr = enr.Random();
				curr.Key.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);
				curr.Value.Should().BeEquivalentTo(curr.Key.ToString());
			}
		}


		[Fact]
		public void random_element_from_SortedList()
		{
			// Create a collection with asso'd enumerator, and populate it.
			SortedList<int, string> list = new SortedList<int, string>();
			IEnumerable<KeyValuePair<int, string>> enr = list as IEnumerable<KeyValuePair<int, string>>;
			for (int i = 0; i < 250; ++i) { list.Add(i, i.ToString()); }

			for (int i = 0; i < list.Count; ++i)
			{
				// Test via the method taking ICollection
				var curr = list.Random();
				curr.Key.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);
				curr.Value.Should().BeEquivalentTo(curr.Key.ToString());

				// Test via the method taking IEnumerable
				curr = enr.Random();
				curr.Key.Should().BeGreaterOrEqualTo(IntListTestFixture.MinTestValue);
				curr.Value.Should().BeEquivalentTo(curr.Key.ToString());
			}
		}

		#endregion Positive tests
		


		#region Negative tests

		// Verify the correct exception occurs when passed an empty list
		[Fact]
		public void verify_excp_on_empty_list()
		{
			List<string> list = new List<string>();

			// Test via the method taking ICollection
			Action act = () => list.Random();
			act.Should().Throw<ArgumentOutOfRangeException>();

			// Test via the method taking IEnumerable
			act = () => (list as IEnumerable<string>).Random();
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		#endregion Negative tests
		
	}

}
