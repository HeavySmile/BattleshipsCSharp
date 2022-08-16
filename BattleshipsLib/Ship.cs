
namespace BattleshipsLib
{
    public class Ship
    {
        public List<Tile> Tiles { get; }
        public int Size { get; }
        public int HP { get; }
        public Ship(List<Tile> shipTiles)
        {
            Tiles = shipTiles;
            Size = shipTiles.Count;
            HP = shipTiles.Count;
        }
        
    }
}