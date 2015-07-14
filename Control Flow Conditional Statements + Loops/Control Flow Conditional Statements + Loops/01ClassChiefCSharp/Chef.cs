namespace Control_Flow_Conditional_Statements___Loops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowlWithVegetables = this.GetBowl();

            Potato peeledPotato = this.Peel(potato);
            Potato cuttedPotato = this.PeelCut(potato);
            bowl.Add(potato);

            Carrot carrot = this.PeelGetCarrot();
            Carrot peeledCarrot = this.Peel(carrot);
            Carrot cuttedCarrot = this.Cut(peeledCarrot);
            bowl.Add(carrot);
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }

        private void Cut(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private void Peel(Vegetable potato)
        {
            throw new NotImplementedException();
        }
    }
}