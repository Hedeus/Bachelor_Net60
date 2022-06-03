using Bachelor_Net60.Services.Interfaces;
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
    internal class ProductsManagementViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Products> _ProductsRepository;

        //private readonly IDataService _DataService;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Главное окно";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/

        ProductsManagementViewModel(IUserDialog UserDialog)
        {
            _UserDialog = UserDialog;
        }

    }
}
