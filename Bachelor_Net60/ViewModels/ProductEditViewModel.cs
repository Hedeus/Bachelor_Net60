using Bachelor_Net60.Services.ProductsCategories;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductEditViewModel : ViewModel
    {        
        private readonly ProductsManager _ProductsManager;

        private Categories _Category;
        public Categories Category
        {
            get => _Category;
            set => Set(ref _Category, _ProductsManager.SelectedCategory);
        }

        private Products _Product;
        public Products Product
        {
            get => _Product;
            set => Set(ref _Product, _ProductsManager.SelectedProduct);
        }

        //private IRepository<Products> _Products;

        //public ProductEditViewModel(ProductsManager ProdManager, Categories SelectedCategory, bool IsAdd = false)
        //{
        //    //_Products = ProductRepository;
        //    _ProdManager = ProdManager;
        //}
        public ProductEditViewModel(ProductsManager productsManager, bool IsAdd)
        {
            _ProductsManager = productsManager;
        }
    }
}
