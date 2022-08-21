
namespace BattleshipsLib
{
    public enum Content { HIT, MISS, SHIP, EMPTY}
    
    public class Tile
    {
        public const int XY_MAX_VALUE = 10;
        public const int XY_MIN_VALUE = 1;
        private int x;
        private int y;

        private Content content;
        public int X 
        { 
            get { return x; }
        }
        public int Y 
        { 
            get { return y; }
        }
        public Content Content
        { 
            get { return content; }
            set { content = value; }
        }
        static public bool isXYValid(int x, int y)
        {
            return x >= XY_MIN_VALUE && x <= XY_MAX_VALUE && 
                   y >= XY_MIN_VALUE && y <= XY_MAX_VALUE;
        }
        public Tile(int x, int y)
        {
            if(!isXYValid(x,y)) throw new Exception("Invalid xy initialization");
            this.x = x;
            this.y = y;
            this.content = Content.EMPTY;
        }
        public static bool CompareXY(Tile a, Tile b)
        {
            return a.x == b.x && a.y == b.y;
        }
    }
}