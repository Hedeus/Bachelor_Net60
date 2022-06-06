using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.Services.ProductsCategories
{
    class ProductsManager : ViewModel
    {
        private readonly IRepository<Products> _Products;
        private readonly IRepository<Categories> _Categories;
        private readonly IRepository<ProductPrice> _ProductPrice;
        private readonly IRepository<CategoryTree> _CatsTree;

        public IQueryable<Products> Prods => _Products.Items;
        public IQueryable<Categories> Cats => _Categories.Items;
        public IQueryable<ProductPrice> Prices => _ProductPrice.Items;
        public IQueryable<CategoryTree> Tree => _CatsTree.Items;

        #region Общие свойства
        private Categories _SelectedCategory;
        public Categories SelectedCategory { get => _SelectedCategory; set => Set(ref _SelectedCategory, value); }

        public Products _SelectedProduct;
        public Products SelectedProduct { get => _SelectedProduct; set => Set(ref _SelectedProduct, value); }

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel { get => _CurrentModel; set => Set(ref _CurrentModel, value); } 
        #endregion


        public ProductsManager(IRepository<Categories> categories,
                               IRepository<Products> products,
                               IRepository<ProductPrice> productPrice,
                               IRepository<CategoryTree> CatsTree)
        {
            _Products = products;
            _Categories = categories;
            _ProductPrice = productPrice;
            _CatsTree = CatsTree;
        }

        public  void ProductsUpdate(Products Product) =>  _Products.Update(Product);
        public async void ProductsUpdateAsync(Products Product) => await _Products.UpdateAsync(Product);

        public void CategoriesUpdate(Categories Category) => _Categories.Update(Category);
        public async void CategoriesUpdateAsync(Categories Category) => await _Categories.UpdateAsync(Category);

        public void ProductPriceUpdate(ProductPrice productPrice) => _ProductPrice.Update(productPrice);
        public async void ProductPriceUpdateAsync(ProductPrice productPrice) => await _ProductPrice.UpdateAsync(productPrice);

        public void CategoryTreeUpdate(CategoryTree categorisTree) => _CatsTree.Update(categorisTree);
        public async void CategoryTreeUpdateAsync(CategoryTree categorisTree) => await _CatsTree.UpdateAsync(categorisTree);

    }
}
