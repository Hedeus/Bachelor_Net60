﻿using Bachelor_Net60.ViewModels.Base;
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

        public IEnumerable<Products> Prods => _Products.Items.ToList();
        public IEnumerable<Categories> Cats => _Categories.Items.ToList();
        public IEnumerable<ProductPrice> Prices => _ProductPrice.Items.ToList();
        public IEnumerable<CategoryTree> Tree => _CatsTree.Items.ToList();

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
                               IRepository<CategoryTree> catsTree)
        {
            _Products = products;
            _Categories = categories;
            _ProductPrice = productPrice;
            _CatsTree = catsTree;            
        }

        /*------------------------------------------------Методы-----------------------------------------------*/
        #region Update методы - Обновление существующих в базе записей
        public void ProductsUpdate(Products product) => _Products.Update(product);
        public async void ProductsUpdateAsync(Products product) => await _Products.UpdateAsync(product);

        public void CategoriesUpdate(Categories category) => _Categories.Update(category);
        public async void CategoriesUpdateAsync(Categories category) => await _Categories.UpdateAsync(category);

        public void ProductPriceUpdate(ProductPrice productPrice) => _ProductPrice.Update(productPrice);
        public async void ProductPriceUpdateAsync(ProductPrice productPrice) => await _ProductPrice.UpdateAsync(productPrice);

        public void CategoryTreeUpdate(CategoryTree categorisTree) => _CatsTree.Update(categorisTree);
        public async void CategoryTreeUpdateAsync(CategoryTree categorisTree) => await _CatsTree.UpdateAsync(categorisTree);
        #endregion

        #region Add методы - добавление новых записей в базу
        public void ProductsAdd(Products product) => _Products.Add(product);
        public async void ProductsAddAsync(Products product) => await _Products.AddAsync(product);        

        public void CategoriesAdd(Categories category) => _Categories.Add(category);
        public async void CategoriesAddAsync(Categories category) => await _Categories.AddAsync(category);

        public void ProductPriceAdd(ProductPrice productPrice) => _ProductPrice.Add(productPrice);
        public async void ProductPriceAddAsync(ProductPrice productPrice) => await _ProductPrice.AddAsync(productPrice);

        public void CategoryTreeAdd(CategoryTree categorisTree) => _CatsTree.Add(categorisTree);
        public async void CategoryTreeAddAsync(CategoryTree categorisTree) => await _CatsTree.AddAsync(categorisTree);
        #endregion

        #region Add методы - добавление новых записей в базу
        public void ProductsRemove(Products product) => _Products.Remove(product.Id);
        public async void ProductsRemoveAsync(Products product) => await _Products.RemoveAsync(product.Id);

        public void CategoriesRemove(int Id) => _Categories.Remove(Id);
        public async void CategoriesRemoveAsync(int Id) => await _Categories.RemoveAsync(Id);

        public void ProductPriceRemove(ProductPrice productPrice) => _ProductPrice.Remove(productPrice.Id);
        public async void ProductPriceRemoveAsync(ProductPrice productPrice) => await _ProductPrice.RemoveAsync(productPrice.Id);

        public void CategoryTreeRemove(CategoryTree categorisTree) => _CatsTree.Remove(categorisTree.Id);
        public async void CategoryTreeRemoveAsync(CategoryTree categorisTree) => await _CatsTree.RemoveAsync(categorisTree.Id);
        #endregion

    }
}
