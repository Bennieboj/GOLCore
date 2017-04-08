using System;
using System.Collections.Generic;
using System.Linq;

namespace GoL
{
    public class Universe
    {
        private List<List<Cell>> _cells;

        public Universe(List<List<Cell>> cells)
        {
            ValidateNumberOfRowsEqualToNumberOfColums(cells);

            _cells = cells;
        }

        private void ValidateNumberOfRowsEqualToNumberOfColums(List<List<Cell>> cells)
        {
            if (cells.Any(row => row.Count != cells.Count))
            {
                throw new InvalidOperationException("NumberOfRowsNotEqualToNumberOfColums");
            }
            _cells = cells;
        }


        public List<List<Cell>> DetermineNextGeneration()
        {
            var nextGeneration = new List<List<Cell>>(_cells);

            for (int row = 0; row < _cells.Count; row++)
            {
                for (int col = 0; col < _cells[row].Count; col++)
                {
                    nextGeneration[row][col] = new Neighbourhood(this, new Location(row, col)).GetTransitionResult();
                }
            }
            return nextGeneration;
        }

        public List<List<Cell>> GetNeighborhoodAroundLocation(Location location)
        {
            var neighborhood = new List<List<Cell>>();
            for (int row = -1; row <= 1; row++)
            {
                var newrow = new List<Cell>();
                for (int col = -1; col <= 1; col++)
                {
                    var newLocation = GetRelativeLocation(location, col, row);
                    newrow.Add(GetCell(newLocation));
                }
                neighborhood.Add(newrow);
            }

            return neighborhood;
        }

        private Location GetRelativeLocation(Location location, int columnDiff, int rowDiff)
        {
            return new Location(location.ColumnNumber + columnDiff, location.RowNumber + rowDiff);
        }

        private Cell GetCell(Location location)
        {
            return Exists(location) ? _cells[location.RowNumber][location.ColumnNumber] : Cell.Dead;
        }

        private bool Exists(Location location)
        {
            return location.ColumnNumber >= 0 && location.RowNumber >= 0 && location.ColumnNumber < _cells.Count && location.RowNumber < _cells[0].Count;
        }
    }
}
