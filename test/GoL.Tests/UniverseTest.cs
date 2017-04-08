using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GoL.Tests
{
    public class UniverseTest
    {

        Universe GetSUT()
        {
            return new Universe(new List<List<Cell>>
            {
                new List<Cell> { Cell.Alive, Cell.Dead,  Cell.Dead,  Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Dead,  Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Alive, Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Dead,  Cell.Dead,  Cell.Dead }
            });
        }

        [Fact]
        public void DetermineNextGeneration__ShouldReturnCorrectResult()
        {
            var SUT = GetSUT();
            var result = SUT.DetermineNextGeneration();

            result[0][0].Should().Equals(Cell.Dead);
            result[0][1].Should().Equals(Cell.Alive);
            result[0][2].Should().Equals(Cell.Dead);
            result[0][3].Should().Equals(Cell.Dead);

            result[1][0].Should().Equals(Cell.Dead);
            result[1][1].Should().Equals(Cell.Alive);
            result[1][2].Should().Equals(Cell.Dead);
            result[1][3].Should().Equals(Cell.Dead);

            result[2][0].Should().Equals(Cell.Dead);
            result[2][1].Should().Equals(Cell.Alive);
            result[2][2].Should().Equals(Cell.Alive);
            result[2][3].Should().Equals(Cell.Dead);

            result[3][0].Should().Equals(Cell.Dead);
            result[3][1].Should().Equals(Cell.Dead);
            result[3][2].Should().Equals(Cell.Dead);
            result[3][3].Should().Equals(Cell.Dead);
        }
        [Fact]
        public void GetNeighborhoodAroundLocation_CompletelyInsideUniverse_ShouldReturnCorrectCells()
        {
            var SUT = GetSUT();
            var neighborhood = SUT.GetNeighborhoodAroundLocation(new Location(1, 2));

            neighborhood[0][0].Should().Equals(Cell.Dead);
            neighborhood[0][1].Should().Equals(Cell.Alive);
            neighborhood[0][2].Should().Equals(Cell.Dead);
            neighborhood[1][0].Should().Equals(Cell.Dead);
            neighborhood[1][1].Should().Equals(Cell.Alive);
            neighborhood[1][2].Should().Equals(Cell.Alive);
            neighborhood[2][0].Should().Equals(Cell.Dead);
            neighborhood[2][1].Should().Equals(Cell.Dead);
            neighborhood[2][2].Should().Equals(Cell.Dead);
        }

        [Fact]
        public void GetNeighborhoodAroundLocation_PartiallyInsideUniverse_ShouldReturnDeadForCellsOutsideUniverse()
        {
            var SUT = GetSUT();
            var neighborhood = SUT.GetNeighborhoodAroundLocation(new Location(0, 0));

            neighborhood[0][0].Should().Equals(Cell.Dead);
            neighborhood[0][1].Should().Equals(Cell.Dead);
            neighborhood[0][2].Should().Equals(Cell.Dead);
            neighborhood[1][0].Should().Equals(Cell.Dead);
            neighborhood[1][1].Should().Equals(Cell.Alive);
            neighborhood[1][2].Should().Equals(Cell.Alive);
            neighborhood[2][0].Should().Equals(Cell.Dead);
            neighborhood[2][1].Should().Equals(Cell.Dead);
            neighborhood[2][2].Should().Equals(Cell.Alive);
        }

        [Fact]
        public void Ctor_NumberOfRowsNotEqualToNumberOfColumns_ShouldThrowException()
        {
            Action a = () => new Universe(new List<List<Cell>>
            {
                new List<Cell> {Cell.Alive, Cell.Dead}
            });

            a.ShouldThrow<InvalidOperationException>().WithMessage("NumberOfRowsNotEqualToNumberOfColums");
        }
    }
}
