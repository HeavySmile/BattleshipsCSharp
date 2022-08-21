
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
            if(enemyBoard == null) return false;
            
            return enemyBoard.takeShot(tile);
        }
        public bool addShip(Ship ship)
        {
            return board.addShip(ship);
        }

        public void display()
        {
            if(enemyBoard == null) throw new Exception("No enemy declared");
            board.display();
            enemyBoard.display();
        }
    }
}