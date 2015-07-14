namespace Solutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width should not be" + " negative");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height should not" + " be negative");
                }

                this.height = value;
            }
        }

        public static Figure GetRotatedFigure(Figure figure, double angleOfTheFigureToBeRotated)
        {
            double sinusTimesWidth = Math.Abs(Math.Sin(angleOfTheFigureToBeRotated) * figure.Width);
            double cosinusTimesWidth = Math.Abs(Math.Cos(angleOfTheFigureToBeRotated) * figure.Width);
            double sinusTimesHeight = Math.Abs(Math.Sin(angleOfTheFigureToBeRotated) * figure.Height);
            double cosinusTimesHeigth = Math.Abs(Math.Cos(angleOfTheFigureToBeRotated) * figure.Height);

            double rotatedFigureWidth = cosinusTimesWidth + sinusTimesHeight;
            double rotatedFigureHeight = sinusTimesWidth + cosinusTimesHeigth;

            Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);

            return rotatedFigure;
        }
    }
}
