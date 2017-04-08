using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GoL.Tests
{
    public class NeighbourhoodTest
    {

        Neighbourhood GetSUT(Location location)
        {
            var universe = new Universe(new List<List<Cell>>
            {
                new List<Cell> { Cell.Alive, Cell.Dead,  Cell.Dead  },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Dead  },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Alive }
            });

            return new Neighbourhood(universe, location);
        }

        [Theory]
        [InlineData("0", "0", "1")]
        [InlineData("0", "1", "2")]
        [InlineData("0", "2", "1")]
        [InlineData("1", "0", "2")]
        [InlineData("1", "1", "3")]
        [InlineData("1", "2", "3")]
        [InlineData("2", "0", "2")]
        [InlineData("2", "1", "2")]
        [InlineData("2", "2", "2")]
        public void GetNumberOfLivingNeighbours_ShouldReturnCorrectNumber(int column, int row, int expectedLivingNeighbours)
        {
            GetSUT(new Location(column, row)).GetNumberOfLivingNeighbours().Should().Equals(expectedLivingNeighbours);
        }
    }
}
