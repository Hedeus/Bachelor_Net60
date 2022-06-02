using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System.Linq;

namespace Bachelor_Net60.ViewModels
{
    internal class MainWindowViewModel : ViewModel
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

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов!";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        public MainWindowViewModel(IUserDialog UserDialog,
                                   IRepository<Products> ProductsRepository/*, IDataService DataService*/)
        {
            _UserDialog = UserDialog;
            //_DataService = DataService;
            _ProductsRepository = ProductsRepository;
            //var prod = ProductsRepository.Items.Take(10).ToArray();
        }
    }
}
