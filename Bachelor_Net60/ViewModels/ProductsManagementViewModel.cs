using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.ProductsCategories;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductsManagementViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;        
        private readonly ProductsManager _ProductsManager;       

        public ObservableCollection<TreeViewModel> Items { get; set; } = new ObservableCollection<TreeViewModel>();
        public IEnumerable<Categories> Cats => _ProductsManager.Cats;
        public IEnumerable<Products> Prods => _ProductsManager.Prods;
        public IEnumerable<ProductPrice> Prices => _ProductsManager.Prices;
        public IEnumerable<CategoryTree> Tree => _ProductsManager.Tree;

        #region SelCatProducts : IEnumerable<Products> - Продукты выбранной категории
        private IEnumerable<Products> _SelCatProducts = null;
        public IEnumerable<Products> SelCatProducts
        {
            get => _SelCatProducts;            
            set => Set(ref _SelCatProducts, value);
        }   
        #endregion

        #region CurrentModel : ViewModel - текущая вьюмодель (редактирование, добавление, удаление категорий или продуктов)
        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }
        #endregion

        #region SelectedCategory : TreeViewModel - Выбранная категория
        private TreeViewModel _SelectedCategory = null;
        public TreeViewModel SelectedCategory 
        {
            get => _SelectedCategory;            
            set
            {
                Set(ref _SelectedCategory, value);
                SelCatProducts = SelectedCategory == null ? Prods : Prods.Where(i => i.Category == value.Node);                
                _ProductsManager.SelectedCategory = value is null ? null : (Categories) value.Node;
                
            }         
        }
        #endregion

        #region SelectedProduct : Products - Выбранный продукт
        private Products _SelectedProduct;
        public Products SelectedProduct
        {
            get => _SelectedProduct;
            set
            {
                Set(ref _SelectedProduct, value);
                _ProductsManager.SelectedProduct = value;                
            }
        }
        #endregion

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Управление услугами";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        /*----------------------------------------Методы---------------------------------------------*/

        #region AddNode - метод для наполнения дерева при построении
        //private void TreeViewRefresh()
        //{
        //    Items.Clear();
        //    var localTree = (from t in Tree select t).ToList();
        //    var localCats = (from c in Cats select c).ToList();


        //    TreeViewModel ? AddNode(Categories Cat)
        //    {
        //        if (Cat is null) return null;
        //        var childCollection = new ObservableCollection<TreeViewModel>();

        //        foreach (var t in localTree.Where(i => i.Ancestor.Id == Cat.Id))
        //        {
        //            var child = localCats.FirstOrDefault(i => i.Id == t.DescendantId);
        //            if (child != null)
        //                childCollection.Add(new TreeViewModel(AddNode(child)));
        //        }
        //        var Item = new TreeViewModel(Cat, children: childCollection);
        //        return Item;
        //    }

        //    var ancestorIsNull = (from c in Cats
        //                          join t in Tree on c.Id equals t.Descendant.Id into CategoryInTree
        //                          from subc in CategoryInTree.DefaultIfEmpty()
        //                          where subc.Ancestor.Id == null
        //                          select c).ToList();

        //    foreach (var cat in ancestorIsNull)
        //    {
        //        var subTree = Tree.Where(i => i.AncestorId == cat.Id).ToList();
        //        var childCollection = new ObservableCollection<TreeViewModel>();
        //        foreach (var t in subTree)
        //        {
        //            var child = Cats.FirstOrDefault(i => i.Id == t.DescendantId);
        //            if (child != null)
        //                childCollection.Add(new TreeViewModel(AddNode(child)));
        //        }
        //        Items.Add(new TreeViewModel(cat, children: childCollection));
        //    }
        //}   
        private void TreeViewRefresh()
        {
            Items.Clear();
            //var localCats = (from c in Cats select c).ToList();
            foreach (var cat in Cats)
                Items.Add(new TreeViewModel(cat));
        }
        #endregion

        #region OnProductsManagerPropertyChanged
        private void OnProductsManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentModel");
            {
                if (_ProductsManager.CurrentModel != null)
                    this.CurrentModel = _ProductsManager.CurrentModel;
            }
        } 
        #endregion

        /*----------------------------------------Команды---------------------------------------------*/

        #region AddCategoryViewCommand
        private ICommand _AddCategoryViewCommand;
        public ICommand AddCategoryViewCommand => _AddCategoryViewCommand
            ??= new LambdaCommand(OnAddCategoryViewCommandExecuted, CanAddCategoryViewCommandExecute);
        private bool CanAddCategoryViewCommandExecute(object p) =>
            SelectedCategory != null || (string)p == "True";
        private void OnAddCategoryViewCommandExecuted(object p)
        {
            CurrentModel = new CategoryEditViewModel(_ProductsManager, (string)p == "True");
        }
        #endregion        

        #region AddProductViewCommand
        private Command _AddProductViewCommand;
        public Command AddProductViewCommand => _AddProductViewCommand
            ??= new LambdaCommand(OnAddProductViewCommandExecuted, CanAddProductViewCommandExecute);
        private bool CanAddProductViewCommandExecute() => SelectedCategory != null;
        private void OnAddProductViewCommandExecuted()
        {
            CurrentModel = new ProductEditViewModel(_ProductsManager, SelectedProduct != null);
        }
        #endregion

        #region ShowProducDetailsCommand
        private Command _ShowProducDetailsCommand;
        public Command ShowProducDetailsCommand => _ShowProducDetailsCommand
            ??= new LambdaCommand(OnShowProducDetailsCommandExecuted, CanShowProducDetailsCommandExecute);
        private bool CanShowProducDetailsCommandExecute() => true;
        private void OnShowProducDetailsCommandExecuted()
        {
            CurrentModel = new ProductDetailsViewModel(_ProductsManager);
        }
        #endregion

        #region Обновление дерева

        private ICommand _TreeRefreshCommand;
        public ICommand TreeRefreshCommand => _TreeRefreshCommand
            ??= new LambdaCommand(OnTreeRefreshCommandExecuted, CanTreeRefreshCommandExecute);
        private bool CanTreeRefreshCommandExecute() => true;
        private void OnTreeRefreshCommandExecuted()
        {
            SelCatProducts = null;
            SelectedCategory = null;
            TreeViewRefresh();
        }

        #endregion

        private ICommand _RemoveCategoryCommand;
        public ICommand RemoveCategoryCommand => _RemoveCategoryCommand
            ??= new LambdaCommand(OnRemoveCategoryCommandExecuted, CanRemoveCategoryCommandExecute);
        private bool CanRemoveCategoryCommandExecute() => SelectedCategory != null;
        private void OnRemoveCategoryCommandExecuted()
        {
            var categoryToRemove = (Categories)SelectedCategory.Node;
            if (!_UserDialog.Confirm($"Вы хотите удалить категорию {categoryToRemove.Name}?", "Удаление категории!"))
                return;
            _ProductsManager.CategoriesRemove(categoryToRemove.Id);
            SelectedCategory = null;
            TreeViewRefresh();
        }

        /*--------------------------------------Конструктор---------------------------------------------*/

        public ProductsManagementViewModel(IUserDialog UserDialog,                                           
                                           ProductsManager productsManager
                                          )
        {
            _UserDialog = UserDialog;            
            _ProductsManager = productsManager;
            productsManager.PropertyChanged += OnProductsManagerPropertyChanged;

            
        }       
    }
}
