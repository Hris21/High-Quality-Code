namespace CohesionAndCoupling
{
    using System;

    internal class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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
                this.height = value;
                Validator.ValidatePropertyValue(value, "Height");
            }
        }
        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                this.depth = value;
                Validator.ValidatePropertyValue(value, "Depth");
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
