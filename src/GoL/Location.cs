namespace GoL
{
    public class Location
    {
        public int RowNumber { get; private set; }
        public int ColumnNumber { get; private set; }
        
        public Location(int columnNumber, int rowNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }
    }
}
