
namespace BattleshipsLib
{
    public enum TileContent { HIT, MISS, SHIP, EMPTY}
    public class Tile
    {
        public int X { get; }
        public int Y { get; }
        public TileContent Content{ get; }
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            Content = TileContent.EMPTY;
        }
        
        public void print()
        {
            string output;
            switch (Content)
            {
                case TileContent.HIT:
                    output = "[X]";
                    break;
                case TileContent.MISS:
                    output = "[M]";
                    break;
                default:
                    output = "[~]";
                    break;     
            }
            Console.Write(output);
        }
    }
}