using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
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
        private readonly IUserDialog _UserDialog;

        /*--------------------------------------Свойства---------------------------------------------*/

        private readonly ProductsManager _ProductsManager;

        private string _Category;
        public string Category
        {
            get => _Category;
            set => Set(ref _Category, value);
        }
        public bool IsAdd { get; set; }
        private string OldName;

        /*----------------------------------------Методы---------------------------------------------*/



        /*----------------------------------------Команды---------------------------------------------*/

        #region CancelEditCommand
        private Command _CancelEditCommand;
        public Command CancelEditCommand => _CancelEditCommand
            ??= new LambdaCommand(OnCancelEditCommandExecuted, CanCancelEditCommandExecute);
        private bool CanCancelEditCommandExecute() => true;
        private void OnCancelEditCommandExecuted()
        {
            _ProductsManager.CurrentModel = new ProductDetailsViewModel(_UserDialog ,_ProductsManager);
        }
        #endregion

        #region AddCategoryCommand
        private Command _AddCategoryCommand;
        public Command AddCategoryCommand => _AddCategoryCommand
            ??= new LambdaCommand(OnAddCategoryCommandExecuted, CanAddCategoryCommandExecute);
        private bool CanAddCategoryCommandExecute() => true;
        private void OnAddCategoryCommandExecuted()
        {
            if (IsAdd)
            {
                Categories newCategory = new Categories()
                {
                    Name = Category
                };
                //await _ProductsManager.CategoriesAddAsync(newCategory).ConfigureAwait(false);                
                _ProductsManager.CategoriesAdd(newCategory);                
                if (_ProductsManager.SelectedCategory != null)
                {
                    //CategoryTree newTree = new CategoryTree();
                    //newTree.Ancestor = _ProductsManager.SelectedCategory;
                    //newTree.Descendant = newCategory;
                    //_ProductsManager.CategoryTreeAdd(newTree);
                } 
                _ProductsManager.CurrentModel = new ProductDetailsViewModel(_UserDialog, _ProductsManager);                
            }
            //else
            //{
            //    _ProductsManager.CurrentModel = new ProductDetailsViewModel(_UserDialog, _ProductsManager);
            //}              
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public CategoryEditViewModel(IUserDialog userDialog,
                                     ProductsManager productsManager,
                                     bool isAdd = false)
        {
            _UserDialog = userDialog;
            _ProductsManager = productsManager;
            IsAdd = isAdd;
            if (isAdd)
                Category = "Введите название";
            else
            {
                Category = _ProductsManager.SelectedCategory.Name;
                OldName = Category;
            }
        }
    }   
}
