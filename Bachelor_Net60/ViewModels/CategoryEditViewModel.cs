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
    
    internal class CategoryEditViewModel : ViewModel
    {
        //private readonly IRepository<Categories> _Categories;
        private readonly ProductsManager _ProdManager;

        public CategoryEditViewModel(ProductsManager ProdManager)
        {
            //_Categories = CategoriesRepository;
            _ProdManager = ProdManager;
        }
    }   
}
