
namespace BackEnd
{
    public struct Position
    {
        public uint Row { get; set; }
        public uint Col { get; set; }

        public Position(uint i_Row, uint i_Col)
        {
            Row = i_Row;
            Col = i_Col;
        }
    }
}
