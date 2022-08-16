

namespace BattleshipsLib
{
    
    public class GameBoard
    {
        public List<List<Tile>> Grid { get; }
        public List<Ship> Ships { get; }
        public GameBoard()
        {
            Grid = new List<List<Tile>>(10);
            for(int i = 0; i < 10; i++)
            {
                Grid.Add(new List<Tile>(10));
                for(int j = 0; j < 10; j++)
                {
                    Grid[i].Add(new Tile(i + 1,j + 1));
                }
            }
            Ships = new List<Ship>(10);
        }
        public void addShip(Ship ship)
        {
            Ships.Add(ship);
            foreach (var tile in ship.Tiles)
            {
                Grid[tile.Y - 1][tile.X - 1].Content = TileContent.SHIP;
            }
        }
        public bool takeShot(Tile shotTile)
        {
            if(Grid[shotTile.Y - 1][shotTile.X - 1].Content == TileContent.SHIP)
            {
                Grid[shotTile.Y - 1][shotTile.X - 1].Content = TileContent.HIT;
                return true;
            }

            return false;
        }
        public void print()
        {
            Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i != 9 ? $"[ {i+1}]" : $"[{i+1}]");
                foreach(Tile tile in Grid[i])
                {
                    tile.print();
                }    
                Console.Write("\n");
            }
        }
    }
}