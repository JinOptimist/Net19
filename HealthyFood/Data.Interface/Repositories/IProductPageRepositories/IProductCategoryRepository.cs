﻿using Data.Interface.Models;
using Data.Interface.Models.ProductPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Repositories.IProductPageRepositories
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        public ProductCategory Get(string name);
    }
}