using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Bachelor_Net60.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly OrderManager _OrderManager;
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

        #region Categories : ObservableCollection<Categories> - Список категорий
        private ObservableCollection<Categories> _Categories = new ObservableCollection<Categories>;
        public ObservableCollection<Categories> Categories
        {
            get => _Categories;
            private set => Set(ref _Categories, value);
        }
        #endregion

        /*----------------------------------------Методы------------------------------------------------*/

        #region OnOrderManagerPropertyChanged
        //private void OnOrderManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        //{
            
        //} 
        #endregion



        /*----------------------------------------Команды-----------------------------------------------*/

        /*--------------------------------------Конструктор---------------------------------------------*/

        public MainWindowViewModel(IUserDialog UserDialog,
                                   OrderManager orderManager)
        {
            _UserDialog = UserDialog;
            _OrderManager = orderManager;
            //orderManager.PropertyChanged += OnOrderManagerPropertyChanged;
            foreach (var category in _OrderManager.Cats)
                Categories.Add(category);
        }        
    }
}
