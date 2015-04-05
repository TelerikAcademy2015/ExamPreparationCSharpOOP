﻿namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Table: Furniture, ITable
    {
        //private string materialType;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
            this.Length = length;
            this.Width = width;
        }
        public decimal Length { get; private set; }

        public decimal Width { get; private set; }

        public decimal Area
        {
            get 
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
