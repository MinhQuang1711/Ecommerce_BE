﻿namespace Ecommerce_BE.Data.DTO.Ingredients
{
    public class CreateIngredient
    {
        public string Name { get; set; }
        public string Loss { get; set; }
        public double NetWeight { get; set; }
        public double ImportPrice { get; set; }
       
        public CreateIngredient() { }
    }
}
