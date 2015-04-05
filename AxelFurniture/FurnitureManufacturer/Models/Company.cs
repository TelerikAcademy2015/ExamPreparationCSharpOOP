namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.furnitures = new List<IFurniture>();
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                //•	Name cannot be empty, null or with less than 5 symbols
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty or null");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be with less than 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            protected set
            {
                //•	Registration number must be exactly 10 symbols and must contain only digits
                if (value == null || value.Length !=10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols");
                }
                if (!this.ContainsOnlyDigits(value))
                {
                    throw new ArgumentException("Registration number must contain only digits");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get 
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                ));

            foreach (var furniture in 
                this.furnitures
                .OrderBy(f => f.Price)
                .ThenBy(f => f.Model))
            {
                sb.AppendLine(furniture.ToString().TrimEnd());
            }

            return sb.ToString();
        }

        private bool ContainsOnlyDigits(string str)
        {
            foreach(var ch in str)
            {
                if(!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
