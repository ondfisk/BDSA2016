using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace BDSA2016.Lecture02.Lib.Tests
{
    public class CollectionUtilitiesTests
    {
        [Fact]
        public void GetEven_given_1_2_3_4_5_returns_2_4()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var evens = CollectionUtilities.GetEven(numbers);

            Assert.Equal(new List<int> { 2, 4 }, evens);
        }

        [Fact]
        public void GetEven_given_1_2_3_4_5_returns_2_4_order_who_cares()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var evens = CollectionUtilities.GetEven(numbers);

            Assert.True(new HashSet<int> { 4, 2 }.SetEquals(evens));
        }

        [Fact]
        public void Find_given_1_2_3_and_2_returns_true()
        {
            int[] numbers = { 1, 2, 3 };

            var found = CollectionUtilities.Find(numbers, 2);

            Assert.True(found);
        }

        [Fact]
        public void Reverse_given_1_2_3_returns_3_2_1()
        {
            int[] numbers = { 1, 2, 3 };

            var reverse = CollectionUtilities.Reverse(numbers);

            Assert.Equal(new[] { 3, 2, 1 }, reverse);
        }

        [Fact]
        public void Sort()
        {
            var ducks = Duck.Ducks.Take(3).ToList();

            var sorted = CollectionUtilities.Sort(ducks, new DuckAgeComparer());

            var expected = new List<Duck> {
                new Duck { Id = 3 },
                new Duck { Id = 2 },
                new Duck { Id = 1 },
            };
            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void Unique_given_1_2_2_3_3_4_5_returns_1_2_3_4_5()
        {
            int[] numbers = { 1, 2, 2, 3, 3, 4, 5 };

            var unique = CollectionUtilities.Unique(numbers);

            Assert.True(new HashSet<int> { 1, 2, 3, 4, 5 }.SetEquals(unique));
        }
    }
}
