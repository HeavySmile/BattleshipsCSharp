using BattleshipsLib;

namespace BattleshipsUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Position position = new Position(3,2);
            //position.X = 2;
            //position.Y = 3;
            Console.WriteLine($"{position.X} {position.Y}");
        }
    }
}