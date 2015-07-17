namespace CohesionAndCoupling
{
    using System;

    public static class Validator
    {
        public static void ValidatePropertyValue(double propertyValue, string propertyName)
        {
            if (propertyValue <= 0)
            {
                throw new ArgumentException(propertyName + " must be positive.", propertyName);
            }
        }
    }
}
