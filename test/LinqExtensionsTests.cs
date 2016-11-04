using AMT.LinqExtensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;


namespace Test.AMT.LinqExtensions
{
    // TODO: include when doing code coverage
    // [ExcludeFromCodeCoverage]

	public class LinqRandomizerTests
	{

		#region Positive tests

		[Fact]
		public void random_element_from_int_list()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 250; ++i) { list.Add(i); }

			// Get random elements from ~1/10 of the list.  The probability of sequential duplicates
			//	increases when covering more of the available elements.
			int prev = -1;
			for (int i = 0; i < list.Count/10; ++i)
			{
				int curr = list.Random();
				curr.Should().NotBe(prev);
				prev = curr;
			}
		}


		[Fact]
		public void random_element_from_single_item_list()
		{
			// Create a list with only 1 element
			int knownInt = 7466;
			List<int> list = new List<int>();
			list.Add(knownInt);

			// Get random from the list several times. Should only receive the single element.
			for (int i = 0; i < 5; ++i)
			{
				(list.Random()).Should().Be(knownInt);
			}
		}

		#endregion Positive tests
		

		#region Negative tests

		// Verify the correct exception occurs when passed an empty list
		[Fact]
		public void verify_excp_on_empty_list()
		{
			List<string> list = new List<string>();
			Action act = () => list.Random();
			act.ShouldThrow<ArgumentOutOfRangeException>();
		}

		#endregion Negative tests
		
	}

}
