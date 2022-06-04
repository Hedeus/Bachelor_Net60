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
        private IRepository<Products> _Products;

        public ProductEditViewModel(IRepository<Products> ProductRepository)
        {
            _Products = ProductRepository;
        }
    }
}
