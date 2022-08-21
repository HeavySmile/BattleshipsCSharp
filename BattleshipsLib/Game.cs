using System.Text.RegularExpressions;

namespace BattleshipsLib
{
    public class Game
    {
        protected Player player1;
        protected Player player2;

        public Game()
        {
            player1 = new Player();
            player2 = new Player();
            player1.setEnemy(player2);
            player2.setEnemy(player1);
        }
        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.player1.setEnemy(player2);
            this.player2.setEnemy(player1);
        }
    }
}