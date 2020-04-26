﻿using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(ProductAddInputModel productAddInputModel);

        IEnumerable<ProductViewModel> GetAll();
    }
}
