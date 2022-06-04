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
        private readonly IRepository<Categories> _Categories;

        public CategoryEditViewModel(IRepository<Categories> CategoriesRepository)
        {
            _Categories = CategoriesRepository;
        }
    }   
}
