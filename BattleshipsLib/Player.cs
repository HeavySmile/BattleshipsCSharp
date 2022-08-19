
namespace BattleshipsLib
{
    public class Player
    {
        private IAlly board;
        private IEnemy? enemyBoard;

        public Player()
        {
            board = new GameBoard();
            enemyBoard = null;
        }
        public void setEnemy(Player enemy)
        {
            enemyBoard = (IEnemy)enemy.board;
        }
        public bool fire(Tile tile)
        {
            if(enemyBoard == null) throw new Exception("No enemy declared");
            
            return enemyBoard.takeShot(tile);
        }
        public void addShip(Ship ship)
        {
            board.addShip(ship);
        }

        public void display()
        {
            if(enemyBoard == null) throw new Exception("No enemy declared");
            board.display();
            enemyBoard.display();
        }
    }
}