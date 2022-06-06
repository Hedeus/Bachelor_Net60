using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
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
        /*--------------------------------------Свойства---------------------------------------------*/
               
        private readonly ProductsManager _ProductsManager;

        private string _Category;
        public string Category
        {
            get => _Category;
            set => Set(ref _Category, value);
        }
        public bool IsAdd { get; set; }

        /*----------------------------------------Методы---------------------------------------------*/



        /*----------------------------------------Команды---------------------------------------------*/

        #region CancelEditCommand
        private Command _CancelEditCommand;
        public Command CancelEditCommand => _CancelEditCommand
            ??= new LambdaCommand(OnCancelEditCommandExecuted, CanCancelEditCommandExecute);
        private bool CanCancelEditCommandExecute() => _ProductsManager.SelectedCategory != null;
        private void OnCancelEditCommandExecuted()
        {
            _ProductsManager.CurrentModel = new ProductDetailsViewModel(_ProductsManager);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public CategoryEditViewModel(ProductsManager productsManager, bool isAdd = false)
        {
            _ProductsManager = productsManager;
            IsAdd = isAdd;
            Category = _ProductsManager.SelectedCategory.Name;
        }
    }   
}
