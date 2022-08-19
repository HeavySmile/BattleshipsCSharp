

namespace BattleshipsLib
{
    public interface IAlly
    {
        void addShip(Ship ship);
        void printShipsInfo();
        void display();

    }
    public interface IEnemy
    {
        const int BOARD_WIDTH_CHAR = 34;
        const int SPACE_BETWEEN_BOARDS = 3;
        const int BOARD_HEIGHT_CHAR = 11;
        bool takeShot(Tile tile);
        void display();
    }
    public class GameBoard : IAlly, IEnemy
    {
        private const int BOARD_SIZE = 10;
        private List<List<Tile>> grid;
        private List<Ship> ships;

        private void printTileAsAlly(Tile tile)
        {
            string output;
            switch(tile.Content)
            {
                case Content.HIT:
                    output = "[X]";
                    break;
                case Content.MISS:
                    output = "[M]";
                    break;
                case Content.SHIP:
                    output = "[O]";
                    break;
                default:
                    output = "[~]";
                    break;
            }
            Console.Write(output);
        }
        private void printTileAsEnemy(Tile tile)
        {
            string output;
            switch(tile.Content)
            {
                case Content.HIT:
                    output = "[X]";
                    break;
                case Content.MISS:
                    output = "[M]";
                    break;
                default:
                    output = "[~]";
                    break;
            }
            Console.Write(output);
        }
        public GameBoard()
        {
            grid = new List<List<Tile>>(BOARD_SIZE);
            for(int i = 0; i < BOARD_SIZE; i++)
            {
                grid.Add(new List<Tile>(BOARD_SIZE));
                for(int j = 0; j < BOARD_SIZE; j++)
                {
                    grid[i].Add(new Tile(i + 1,j + 1));
                }
            }
            ships = new List<Ship>(BOARD_SIZE);
        }
        
        void IAlly.addShip(Ship ship)
        {
            ships.Add(ship);
            foreach (Tile tile in ship.Tiles)
            {
                grid[tile.Y - 1][tile.X - 1].Content = Content.SHIP;
            }
        }
        void IAlly.printShipsInfo()
        {
            foreach (Ship ship in ships)
            {
                Console.WriteLine($"HP:{ship.Hp} Size:{ship.Size}");
            }
        }

        void IAlly.display()
        {
            Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
            
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.Write(i != BOARD_SIZE - 1 ? $"[ {i+1}]" : $"[{i+1}]");
                foreach(Tile tile in grid[i])
                {
                    printTileAsAlly(tile);
                }    
                Console.Write("\n");
            }
        }
        bool IEnemy.takeShot(Tile shotTile)
        {
            if(grid[shotTile.Y - 1][shotTile.X - 1].Content == Content.SHIP)
            {
                grid[shotTile.Y - 1][shotTile.X - 1].Content = Content.HIT;
                
                foreach(Ship ship in ships)
                {
                    foreach (Tile shipTile in ship.Tiles)
                    {
                        if(Tile.CompareXY(shipTile, shotTile))
                        {
                            ship.takeDamage();
                            if(ship.isShipSunk()) ships.Remove(ship);
                            return true;
                        }
                    }
                }
            }

            grid[shotTile.Y - 1][shotTile.X - 1].Content = Content.MISS;
            return false;
        }
        void IEnemy.display()
        {
            int currRow = Console.CursorTop;
            int currCol = Console.CursorLeft;
            
            currCol += IEnemy.BOARD_WIDTH_CHAR + IEnemy.SPACE_BETWEEN_BOARDS;
            currRow -= IEnemy.BOARD_HEIGHT_CHAR;

            Console.SetCursorPosition(currCol, currRow);
            Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
            Console.SetCursorPosition(currCol, currRow++);
            
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.SetCursorPosition(currCol, currRow++);
                Console.Write(i != BOARD_SIZE - 1 ? $"[ {i+1}]" : $"[{i+1}]");
                foreach(Tile tile in grid[i])
                {
                    printTileAsEnemy(tile);
                }     
            }
            Console.Write("\n");
        }
    } 
}