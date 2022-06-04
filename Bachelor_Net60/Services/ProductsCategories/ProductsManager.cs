using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.Services.ProductsCategories
{
    class ProductsManager
    {
        private readonly IRepository<Products> _Products;
        private readonly IRepository<Categories> _Categories;
        private readonly IRepository<ProductPrice> _ProductPrice;

        //public IEnumerable<Products> Prods => _Products.Items.GetAll

        public ProductsManager(IRepository<Categories> categories,
                               IRepository<Products> products,
                               IRepository<ProductPrice> productPrice)
        {
            _Products = products;
            _Categories = categories;
            _ProductPrice = productPrice;
        }

    }
}
