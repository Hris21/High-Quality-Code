namespace Abstraction
{
    using System;

    public class Rectangle : Figure, IFigure
    {
        private double width;
        private double height;
        private double radius;

        public Rectangle(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Width");
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
                Validator.ValidatePropertyValue(value, "Height");
                this.height = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Radius");
                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
