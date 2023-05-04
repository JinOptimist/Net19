﻿namespace Data.Interface.Models.ProductPage
{
    public class ProductCategory : BaseModel
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}