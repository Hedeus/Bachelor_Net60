using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductsManagementViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Products> _ProductsRepository;

        public Products[] Products { get; set; }

        //private readonly IDataService _DataService;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Управление услугами";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/

        public ProductsManagementViewModel(IUserDialog UserDialog,
                                           IRepository<Products> ProductsRepository
                                          )
        {
            _UserDialog = UserDialog;
            _ProductsRepository = ProductsRepository;
            Products = ProductsRepository.Items.Take(ProductsRepository.Items.Count()).ToArray();

        }

    }
}
