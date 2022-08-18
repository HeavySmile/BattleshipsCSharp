
namespace BattleshipsLib
{
    public class Ship
    {
        private List<Tile> tiles;
        private int size;
        private int hp;
        public List<Tile> Tiles
        {
            get { return tiles; }
        }
        public int Size 
        { 
            get { return size; }
        }
        public int Hp 
        { 
            get { return hp; } 
        }
        public Ship(List<Tile> shipTiles)
        {
            tiles = shipTiles;
            size = shipTiles.Count;
            hp = shipTiles.Count;
        }
        public void takeDamage()
        {
            if(hp > 0) hp--;
        }
        public bool isShipSunk()
        {
            return hp == 0;
        }
    }
}