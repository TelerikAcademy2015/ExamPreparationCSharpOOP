namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class ConvertibleChair: Chair, IConvertibleChair
    {
        private const decimal ConvertedHight = 0.10m;

        private bool isConverted = false;
        //private decimal height;

        public ConvertibleChair(string model, Models.MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
        }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return ConvertedHight;
                }
                else
                {
                    return base.Height;
                }
            }
            protected set
            {
                base.Height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {6}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
