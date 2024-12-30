
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

    public struct Move
    {
        public Position StartPos { get; private set; }
        public Position DestinationPos { get; private set; }

        public Move(Position i_StartPos, Position i_DestionationPos)
        {
            StartPos = i_StartPos;
            DestinationPos = i_DestionationPos;
        }
    }
}
