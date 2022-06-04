using Bachelor_Net60.Infrastructure.Commands;
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
using System.Windows.Input;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductsManagementViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Products> _ProductsRepository;
        private readonly IRepository<Categories> _CategoriesRepository;

        public Products[] Products { get; set; }
        //private TreeViewModel _SelectedCategory;
        //public TreeViewModel SelectedCategory
        //{
        //    get => _SelectedCategory;
        //    set => Set(ref _SelectedCategory, value);
        //} 

        #region CurrentModel
        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }
        #endregion

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Управление услугами";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion


        /*----------------------------------------Команды---------------------------------------------*/

        #region AddCategoryCommand
        private ICommand _AddCategoryCommand;
        public ICommand AddCategoryCommand => _AddCategoryCommand
            ??= new LambdaCommand(OnAddCategoryCommandExecuted, CanAddCategoryCommandExecute);
        private bool CanAddCategoryCommandExecute() => true;
        private void OnAddCategoryCommandExecuted()
        {
            CurrentModel = new CategoryEditViewModel(_CategoriesRepository);
        }
        #endregion

        #region AddProductCommand
        private ICommand _AddProductCommand;
        public ICommand AddProductCommand => _AddProductCommand
            ??= new LambdaCommand(OnAddProductCommandExecuted, CanAddProductCommandExecute);
        private bool CanAddProductCommandExecute() => true;
        private void OnAddProductCommandExecuted()
        {
            CurrentModel = new ProductEditViewModel(_ProductsRepository);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/

        public ProductsManagementViewModel(IUserDialog UserDialog,
                                           IRepository<Products> ProductsRepository
                                          )
        {
            _UserDialog = UserDialog;
            _ProductsRepository = ProductsRepository;
            Products = ProductsRepository.Items.Take(ProductsRepository.Items.Count()).ToArray();
            //Title = SelectedCategory
        }

    }
}
