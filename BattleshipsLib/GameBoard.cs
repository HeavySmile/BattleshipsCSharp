

namespace BattleshipsLib
{
    public class GameBoard
    {
        protected const int BOARD_SIZE = 10;
        private List<List<Tile>> grid;
        private List<Ship> ships;

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

        public void addShip(Ship ship)
        {
            ships.Add(ship);
            foreach (Tile tile in ship.Tiles)
            {
                grid[tile.Y - 1][tile.X - 1].Content = Content.SHIP;
            }
        }
        public bool takeShot(Tile shotTile)
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
        public void printShipStats()
        {
            foreach (Ship ship in ships)
            {
                Console.WriteLine($"HP:{ship.Hp} Size:{ship.Size}");
            }
        }
        public void printBoard()
        {
            int currRow = Console.CursorTop;
            int currCol = Console.CursorLeft;
            
            Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
            
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.Write(i != BOARD_SIZE - 1 ? $"[ {i+1}]" : $"[{i+1}]");
                foreach(Tile tile in grid[i])
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
                Console.Write("\n");
            }
            
        }
    } 
    
    // public abstract class GameBoard
    // {
    //     protected const int BOARD_SIZE = 10; 
    //     public List<List<Tile>> Grid { get; }
    //     public List<Ship> Ships { get; }
    //     public GameBoard()
    //     {
    //         Grid = new List<List<Tile>>(BOARD_SIZE);
    //         for(int i = 0; i < BOARD_SIZE; i++)
    //         {
    //             Grid.Add(new List<Tile>(BOARD_SIZE));
    //             for(int j = 0; j < BOARD_SIZE; j++)
    //             {
    //                 Grid[i].Add(new Tile(i + 1,j + 1));
    //             }
    //         }
    //         Ships = new List<Ship>(BOARD_SIZE);
    //     }
        // public void addShip(Ship ship)
        // {
        //     Ships.Add(ship);
        //     foreach (var tile in ship.Tiles)
        //     {
        //         Grid[tile.Y - 1][tile.X - 1].Content = TileContent.SHIP;
        //     }
        // }
    //     public bool takeShot(Tile shotTile)
    //     {
    //         if(Grid[shotTile.Y - 1][shotTile.X - 1].Content == TileContent.SHIP)
    //         {
    //             Grid[shotTile.Y - 1][shotTile.X - 1].Content = TileContent.HIT;
    //             return true;
    //         }

    //         Grid[shotTile.Y - 1][shotTile.X - 1].Content = TileContent.MISS;
    //         return false;
    //     }
    //     public abstract void print();
    // }

    // public class FriendlyGameBoard : GameBoard
    // {
    //     public override void print()
    //     {
    //         Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
            
    //         for (int i = 0; i < BOARD_SIZE; i++)
    //         {
    //             Console.Write(i != BOARD_SIZE - 1 ? $"[ {i+1}]" : $"[{i+1}]");
    //             foreach(Tile tile in Grid[i])
    //             {
    //                 tile.printAsFriend();
    //             }    
    //             Console.Write("\n");
    //         }
    //     }
    // }

    // public class EnemyGameBoard : GameBoard
    // {
    //     const int BOARD_WIDTH_CHAR = 34;
    //     const int SPACE_BETWEEN_BOARDS = 3;
    //     const int BOARD_HEIGHT_CHAR = 11;

    //     public override void print()
    //     {
    //         int currRow = Console.CursorTop;
    //         int currCol = Console.CursorLeft;
            
    //         Console.SetCursorPosition(currCol += BOARD_WIDTH_CHAR + SPACE_BETWEEN_BOARDS, currRow -= BOARD_HEIGHT_CHAR);
    //         Console.WriteLine("[  ][A][B][C][D][E][F][G][H][I][J]");
    //         Console.SetCursorPosition(currCol, currRow++);
            
    //         for (int i = 0; i < BOARD_SIZE; i++)
    //         {
    //             Console.SetCursorPosition(currCol, currRow++);
    //             Console.Write(i != BOARD_SIZE - 1 ? $"[ {i+1}]" : $"[{i+1}]");
    //             foreach(Tile tile in Grid[i])
    //             {
    //                 tile.printAsEnemy();
    //             }    
                
    //         }
    //         Console.Write("\n");
    //     }
    // }

}