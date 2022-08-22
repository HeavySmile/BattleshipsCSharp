
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
        public void SetEnemy(Player enemy)
        {
            enemyBoard = (IEnemy)enemy.board;
        }
        public bool Fire(Tile tile)
        {
            if(enemyBoard == null) return false;
            
            return enemyBoard.TakeShot(tile);
        }
        public bool AddShip(Ship ship)
        {
            return board.AddShip(ship);
        }

        public void Display()
        {
            if(enemyBoard == null) throw new Exception("No enemy declared");
            board.Display();
            enemyBoard.Display();
        }
    }
}