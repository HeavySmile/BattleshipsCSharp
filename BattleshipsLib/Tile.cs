
namespace BattleshipsLib
{
    public enum Content { HIT, MISS, SHIP, EMPTY}
    
    // public class Tile
    // {
    //     private int x;
    //     private int y;
    //     private Content content;
    //     private Ship? shipRef;
    //     public int X 
    //     {
    //         get { return x;}
    //         set { x = value;}
    //     }
    //     public int Y 
    //     {
    //         get { return y;}
    //         set { y = value;}
    //     }
    //     public Content Content 
    //     { 
    //         get { return content; }
    //     }
    //     public Ship? ShipRef 
    //     { 
    //         get { return shipRef; }
    //         set 
    //         { 
    //             shipRef = value; 
    //             content = Content.SHIP;
    //         }
    //     }

    //     public Tile(int x, int y)
    //     {
    //         this.x = x;
    //         this.y = y;
    //         content = Content.EMPTY;
    //         shipRef = null;
    //     }

    //     public void takeShot()
    //     {
    //         if(content == Content.SHIP && shipRef != null)
    //         {
    //             shipRef.takeDamage();
    //             content = Content.HIT;
    //             shipRef = null;
    //             return;
    //         }

    //         content = Content.MISS;
    //     }
    //     public void printAsFriend()
    //     {
    //         string output;
    //         switch (Content)
    //         {
    //             case Content.HIT:
    //                 output = "[X]";
    //                 break;
    //             case Content.MISS:
    //                 output = "[M]";
    //                 break;
    //             case Content.SHIP:
    //                 output = "[0]";
    //                 break;
    //             default:
    //                 output = "[~]";
    //                 break;     
    //         }
    //         Console.Write(output);
    //     }
    //     public void printAsEnemy()
    //     {
    //         string output;
    //         switch (Content)
    //         {
    //             case Content.HIT:
    //                 output = "[X]";
    //                 break;
    //             case Content.MISS:
    //                 output = "[M]";
    //                 break;
    //             default:
    //                 output = "[~]";
    //                 break;     
    //         }
    //         Console.Write(output);
    //     }
    // }
    
    public class Tile
    {
        private int x;
        private int y;

        private Content content;
        public int X 
        { 
            get { return x; }
        }
        public int Y 
        { 
            get { return y; }
        }
        public Content Content
        { 
            get { return content; }
            set { content = value; }
        }
        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.content = Content.EMPTY;
        }
        public static bool CompareXY(Tile a, Tile b)
        {
            return a.x == b.x && a.y == b.y;
        }
    }
}