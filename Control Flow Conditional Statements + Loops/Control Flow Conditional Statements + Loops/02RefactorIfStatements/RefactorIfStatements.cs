namespace Control_Flow_Conditional_Statements___Loops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class RefactorIfStatements
    {
        private const int MinX = 2;
        private const int MaxX = 5;
        private const int MinY = 1;
        private const int MaxY = 10;

        public static void Main()
        {
            Potato potato = new Potato();
            Chef chef = new Chef();

            potato.IsPeeled = true;
            potato.IsRotten = false;

            if (potato != null)
            {
                if (potato.isPeeled && !potato.IsRotten)
                {
                    chef.Cook(potato);
                }
            }
            else
            {
                Console.WriteLine("Probably potato is not the best choice for dish today. :) ");
            }

            int x = 7;
            int y = 21;

            bool shouldVisitCell = true;

            if (IsInRange(y, MaxY, MinY) && IsInRange(x, MinX, MaxX) && shouldVisitCell)
            {
                VisitCell();
            }
            else
            {
                Console.WriteLine("Cell cannot be visited");
            }
        }

        public static bool IsInRange(int value, int min, int max)
        {
            bool isInRange = value >= min && value <= max;

            return isInRange;
        }

        public static void VisitCell()
        {
            Console.WriteLine("Visited");
        }
    }
}