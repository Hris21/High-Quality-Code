namespace Minesweeper
{
    public class Score
    {
        private string name;
        private int points;

        //Properties
        public string UserName
        {
            get { return name; }
            set { name = value; }
        }

        public int UserPoints
        {
            get { return points; }
            set { points = value; }
        }
        //End

        public Score(string name, int points)
        {
            this.name = UserName;
            this.points = UserPoints;
        }
    }
}