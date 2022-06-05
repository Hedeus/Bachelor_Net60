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
        private readonly ProductsManager _ProdManager;

        //private IRepository<Products> _Products;

        public ProductEditViewModel(ProductsManager ProdManager, Categories SelectedCategory, bool IsAdd = false)
        {
            //_Products = ProductRepository;
            _ProdManager = ProdManager;
        }
    }
}
