namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class AdjustableChair: Chair, IAdjustableChair
    {
        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }
    }
}
