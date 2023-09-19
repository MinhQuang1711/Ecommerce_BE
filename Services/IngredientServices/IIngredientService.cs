﻿using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Services.IngredientServices
{
    public interface IIngredientService
    {
        public Task<bool> Delete(string id);

        public Task<List<Ingerdient>> GetAll();

        public Task<Ingerdient?> SearchById(string id);

        public Task<string?> Create(CreateIngredient model);

        public Task<string?> Update(UpdateIngredient model, string id);

        public List<Ingerdient> SearchByName(string name);


    }
}
