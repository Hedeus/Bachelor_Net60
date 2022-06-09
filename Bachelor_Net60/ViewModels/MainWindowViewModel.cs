using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

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

        #region Cats : ObservableCollection<Categories> - Список категорий 
        public ObservableCollection<Categories> Cats { get; set; } = new ObservableCollection<Categories>();

        #endregion

        #region Prods : IEnumerable<Categories> - Список категорий
        private IEnumerable<Products> Prods => _OrderManager.Prods;       
        #endregion

        #region SelectedCategory : Categories - Выбранная категория
        private Categories _SelectedCategory;
        public Categories SelectedCategory
        {
            get => _SelectedCategory;
            set
            {
                Set(ref _SelectedCategory, value);
                SelCatProducts = value == null ? Prods : Prods.Where(i => i.Category == value);
            }
        }
        #endregion

        #region SelectedProduct : Products - Выбранный продукт
        private Products _SelectedProduct;
        public Products SelectedProduct
        {
            get => _SelectedProduct;
            set => Set(ref _SelectedProduct, value);
        }
        #endregion

        #region SelCatProducts : IEnumerable<Products> - Продукты выбранной категории
        private IEnumerable<Products> _SelCatProducts = null;
        public IEnumerable<Products> SelCatProducts
        {
            get => _SelCatProducts;
            set => Set(ref _SelCatProducts, value);
        }
        #endregion

        /*----------------------------------------Методы------------------------------------------------*/

        #region OnOrderManagerPropertyChanged
        //private void OnOrderManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        //{

        //} 
        #endregion

        #region CategoryListRefresh - обновление списка категорий
        private void CategoryListRefresh()
        {
            Cats.Clear();
            foreach (var category in _OrderManager.Cats)
                Cats.Add(category);
        }
        #endregion

        /*----------------------------------------Команды-----------------------------------------------*/

        #region TreeRefreshCommand - Обновление дерева
        private ICommand _TreeRefreshCommand;
        public ICommand TreeRefreshCommand => _TreeRefreshCommand
            ??= new LambdaCommand(OnTreeRefreshCommandExecuted, CanTreeRefreshCommandExecute);
        private bool CanTreeRefreshCommandExecute() => true;
        private void OnTreeRefreshCommandExecuted()
        {            
            SelCatProducts = null;
            SelectedCategory = null;
            //TreeViewRefresh();
            CategoryListRefresh();
        }
        #endregion

        #region AddToOrderCommand - Обновление дерева
        private ICommand _AddToOrderCommand;
        public ICommand AddToOrderCommand => _AddToOrderCommand
            ??= new LambdaCommand(OnAddToOrderCommandExecuted, CanAddToOrderCommandExecute);
        private bool CanAddToOrderCommandExecute() => true;
        private void OnAddToOrderCommandExecuted()
        {
            Title =  $"Doubleclick по {SelectedProduct}";

        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/

        public MainWindowViewModel(IUserDialog UserDialog,
                                   OrderManager orderManager)
        {
            _UserDialog = UserDialog;
            _OrderManager = orderManager;
            //orderManager.PropertyChanged += OnOrderManagerPropertyChanged;
            //foreach (var category in _OrderManager.Cats)
            //    Categories.Add(category);
        }        
    }
}
