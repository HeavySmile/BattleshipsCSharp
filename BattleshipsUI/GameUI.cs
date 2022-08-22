using BattleshipsLib;
using System.Text.RegularExpressions;

namespace BattleshipsUI
{
    public class GameUI : Game
    {
        private Tile? parseUserTileInput(string? userInput)
        {
            if(userInput == null) return null;

            Match regexMatch = Regex.Match(userInput, @"^(?<x>[A-J])(?<y>[1-9]|10){1}$");
            
            return !regexMatch.Success ? null : new Tile (regexMatch.Groups["x"].Value[0] - 'A' + 1, 
                                                          Int32.Parse(regexMatch.Groups["y"].Value));
        }
        private List<Tile>? parseUserShipInput(string? userInput)
        {
            if(userInput == null) return null;

            Match regexMatch = Regex.Match(userInput, @"^(?<tile>[A-J]([1-9]|10))\s(?<dir>R|L|T|B)\s(?<len>[2-5]){1}$");
            
            if(!regexMatch.Success) return null;
            
            int length = Int32.Parse(regexMatch.Groups["len"].Value);
            string direction = regexMatch.Groups["dir"].Value;
            List<Tile> shipTiles = new List<Tile>();
            Tile? initialTile = parseUserTileInput(regexMatch.Groups["tile"].Value);
                
            if(initialTile == null) return null;
            
            for (int i = 0; i < length; i++)
            {
                int x, y;
                
                if(String.Equals(direction, "R"))
                {
                    x = initialTile.X + i;
                    y = initialTile.Y;
                }
                else if(String.Equals(direction, "L")) 
                {
                    x = initialTile.X - i;
                    y = initialTile.Y;
                }
                else if(String.Equals(direction, "T"))
                {
                    x = initialTile.X;
                    y = initialTile.Y - i;
                }
                else
                {
                    x = initialTile.X;
                    y = initialTile.Y + i;
                }
                
                if(!Tile.isXYValid(x,y)) return null;
                shipTiles.Add(new Tile(x, y));
            }
           
            return shipTiles;
        }
        private void turn(Player player)
        {
            bool endTurn = false;
            
            Console.WriteLine();
            player.display();
            
            do
            {
                Console.WriteLine();
                Console.Write("Choose position to fire at: ");
                Tile? shotTile = parseUserTileInput(Console.ReadLine());
                
                if(shotTile == null) continue;
                
                endTurn = true;
                if(player.fire(shotTile))
                {
                    Console.Clear();
                    player.display();
                    Console.WriteLine();
                    Console.WriteLine("Successful hit!");
                    endTurn = false;
                }
            }
            while(endTurn != true);
        }
        
        public void startPrep()
        {
            int counter = 20;
            Player currPlayer = player1;
    
            do
            {
                string? userInput;

                Console.Clear();
                if(counter == 10)
                {
                    currPlayer.display();
                    Console.WriteLine("Press Enter to continue\n");
                    Console.ReadLine();    
                    
                    Console.Clear();
                    currPlayer = player2;
                    Console.WriteLine("Now Player 2 must deploy their fleet\n");    
                }
                else
                {
                    Console.WriteLine("Now Player 1 must deploy their fleet\n");    
                }

                currPlayer.display();
                
                Console.Write("\nDeploy your ship: ");
                
                userInput = Console.ReadLine();
                
                List<Tile>? shipTiles = parseUserShipInput(userInput);
                
                if(shipTiles == null)
                {
                    Console.WriteLine("Invalid ship configuration. Press Enter to continue.");
                    Console.ReadLine();
                    continue;
                }
                
                if(!currPlayer.addShip(new Ship(shipTiles)))
                {
                    Console.Write("Too close to already set ship");
                    Console.ReadLine();
                    continue;
                }
                
                counter--;
            }
            while(counter != 0);
        }
        public void startGame()
        {
            bool turnTicker = true;
            int i = 0;
            do
            {
                Player currPlayer;
                
                Console.Clear();
                if(turnTicker) 
                {
                    Console.WriteLine("Now turns: Player 1");
                    currPlayer = player1;
                }
                else
                {
                    Console.WriteLine("Now turns: Player 2");
                    currPlayer = player2;
                }

                turn(currPlayer);
                i++;
            }
            while(i != 4);
        }
    }
    
}