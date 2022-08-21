

namespace BattleshipsLib
{
    public interface IAlly
    {
        bool addShip(Ship ship);
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
        private const int CARRIER_MAX_COUNT = 1;
        private const int BATTLESHIP_MAX_COUNT = 2;
        private const int DESTROYER_MAX_COUNT = 3;
        private const int PATROLBOAT_MAX_COUNT = 4;
        private int carrierCount;
        private int battleshipCount;
        private int destroyerCount;
        private int patrolBoatCount;

        private const int BOARD_SIZE = 10;
        private List<List<Tile>> grid;
        private List<Ship> ships;

        private void increaseShipCountByLength(int length)
        {
            switch(length)
            {
                case 5:
                    carrierCount++;
                    break;
                case 4:
                    battleshipCount++;
                    break;
                case 3:
                    destroyerCount++;
                    break;
                case 2:
                    patrolBoatCount++;
                    break;
                default:
                    return;
            }
        }
        private bool isShipLengthValid(int length)
        {
            switch(length)
            {
                case 5:
                    return carrierCount < CARRIER_MAX_COUNT ? true : false;
                case 4:
                    return battleshipCount < BATTLESHIP_MAX_COUNT ? true : false;
                case 3:
                    return destroyerCount < DESTROYER_MAX_COUNT ? true : false;
                case 2:
                    return patrolBoatCount < PATROLBOAT_MAX_COUNT ? true : false;
                default:
                    return false;
            }
        }

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
        
        bool IAlly.addShip(Ship ship)
        {   
            if(!isShipLengthValid(ship.Tiles.Count)) return false;
            
            increaseShipCountByLength(ship.Tiles.Count);
            
            ships.Add(ship);   
            foreach (Tile tile in ship.Tiles)
            {
                grid[tile.Y - 1][tile.X - 1].Content = Content.SHIP;
            }
            return true;
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