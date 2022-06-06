﻿using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.ProductsCategories;
using Bachelor_Net60.ViewModels.Base;
using CifrovikDEL.Entities;
using System;
using System.ComponentModel;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductDetailsViewModel : ViewModel
    {
        /*--------------------------------------Свойства---------------------------------------------*/
        private readonly ProductsManager _ProductsManager;        
        private Categories _Category;
        public Categories Category
        {
            get => _Category;            
            set => Set(ref _Category, value);
        }

        private Products _Product;
        public Products Product
        {
            get => _Product;            
            set => Set(ref _Product, value);
        }

        /*---------------------------------------Методы---------------------------------------------*/


        /*--------------------------------------Команды---------------------------------------------*/

        #region AddProductCommandViewCommand
        private Command _AddProductViewCommand;
        public Command AddProductViewCommand => _AddProductViewCommand
            ??= new LambdaCommand(OnAddProductViewCommandExecuted, CanAddProductViewCommandExecute);
        private bool CanAddProductViewCommandExecute(object p) => _ProductsManager.SelectedCategory != null;
        private void OnAddProductViewCommandExecuted(object p)
        {
            _ProductsManager.CurrentModel = new ProductEditViewModel(_ProductsManager, false);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public ProductDetailsViewModel(ProductsManager productsManager)
        {
            _ProductsManager = productsManager;

            productsManager.PropertyChanged += OnProductsManagerChanged;            
        }

        private void OnProductsManagerChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedCategory")
                this.Category = ((ProductsManager)sender).SelectedCategory;
            if (e.PropertyName == "SelectedProduct")
                this.Product = ((ProductsManager)sender).SelectedProduct;
        }
    }
}
