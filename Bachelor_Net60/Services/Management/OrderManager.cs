using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.Services.Management
{
    internal class OrderManager : ViewModel
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


        public OrderManager(IRepository<Categories> categories,
                               IRepository<Products> products,
                               IRepository<ProductPrice> productPrice,
                               IRepository<CategoryTree> catsTree)
        {
            _Products = products;
            _Categories = categories;
            _ProductPrice = productPrice;
            _CatsTree = catsTree;
        }
    }
}
