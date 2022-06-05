using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.ProductsCategories;
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
        //private readonly IRepository<Products> _ProductsRepository;
        //private readonly IRepository<Categories> _CategoriesRepository;
        private readonly ProductsManager _ProductsManager;
        public ObservableCollection<TreeViewModel> Items { get; set; } = new ObservableCollection<TreeViewModel>();
        public IQueryable<Categories> Cats => _ProductsManager.Cats;
        public IQueryable<Products> Prods => _ProductsManager.Prods;
        public IQueryable<ProductPrice> Prices => _ProductsManager.Prices;
        public IQueryable<CategoryTree> Tree => _ProductsManager.Tree;


        //public Products[] Products { get; set; }
        //private TreeViewModel _SelectedCategory;
        //public TreeViewModel SelectedCategory
        //{
        //    get => _SelectedCategory;
        //    set => Set(ref _SelectedCategory, value);
        //} 

        #region CurrentModel : ViewModel - текущая вьюмодель (редактирование, добавление, удаление категорий или продуктов)
        private ViewModel _CurrentModel;
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            private set => Set(ref _CurrentModel, value);
        }
        #endregion

        #region SelectedCategory : TreeViewModel - Выбранная категория
        private TreeViewModel _SelectedCategory;
        public TreeViewModel SelectedCategory 
        {
            get => _SelectedCategory;
            set => Set(ref _SelectedCategory, value);
             //if (!(_SelectedCategory is null))
             //    Title = _SelectedCategory.Node.ToString();
                      
        }
        #endregion

        #region SelectedProduct : Products - Выбранный продукт
        private Products _SelectedProduct;
        public Products SelectedProduct { get => _SelectedProduct; set => Set(ref _SelectedProduct, value); }
        #endregion

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Управление услугами";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }        

        #endregion

        /*----------------------------------------Методы---------------------------------------------*/

        #region AddNode - метод для наполнения дерева при построении
        private TreeViewModel? AddNode(Categories Cat)
        {
            if (Cat is null) return null;
            var childCollection = new ObservableCollection<TreeViewModel>();

            foreach (var t in Tree.Where(i => i.Ancestor.Id == Cat.Id))
            {
                var child = Cats.FirstOrDefault(i => i.Id == t.DescendantId);
                childCollection.Add(new TreeViewModel(AddNode(child)));
            }
            var Item = new TreeViewModel(Cat, children: childCollection);
            return Item;
        } 
        #endregion

        /*----------------------------------------Команды---------------------------------------------*/

        #region AddCategoryCommand
        private ICommand _AddCategoryCommand;
        public ICommand AddCategoryCommand => _AddCategoryCommand
            ??= new LambdaCommand(OnAddCategoryCommandExecuted, CanAddCategoryCommandExecute);
        private bool CanAddCategoryCommandExecute() => true;
        private void OnAddCategoryCommandExecuted()
        {
            CurrentModel = new CategoryEditViewModel(_ProductsManager);
        }
        #endregion

        #region AddProductCommand
        private ICommand _AddProductCommand;
        public ICommand AddProductCommand => _AddProductCommand
            ??= new LambdaCommand(OnAddProductCommandExecuted, CanAddProductCommandExecute);
        private bool CanAddProductCommandExecute() => true;
        private void OnAddProductCommandExecuted()
        {
            CurrentModel = new ProductEditViewModel(_ProductsManager);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/

        public ProductsManagementViewModel(IUserDialog UserDialog,
                                           //IRepository<Products> ProductsRepository,
                                           //IRepository<Categories> CategoriesRepo,
                                           //IRepository
                                           ProductsManager ProdManager
                                          )
        {
            _UserDialog = UserDialog;            
            _ProductsManager = ProdManager;

            //if (SelectedCategory != null)
            //    Title = SelectedCategory.ToString();

            var ancestorIsNull = (from c in Cats
                                  join t in Tree on c.Id equals t.DescendantId into CategoryInTree
                                  from subc in CategoryInTree.DefaultIfEmpty()
                                  where subc.AncestorId == null                                  
                                  select c).ToList();

            foreach (var cat in ancestorIsNull)
            {
                var subTree = Tree.Where(i => i.AncestorId == cat.Id).ToList();
                var chilCollection = new ObservableCollection<TreeViewModel>();
                foreach (var t in subTree)
                {
                    var child = Cats.FirstOrDefault(i => i.Id == t.DescendantId);
                    chilCollection.Add(new TreeViewModel(AddNode(child)));
                }
                Items.Add(new TreeViewModel(cat, children: chilCollection));
            }
        }
    }
}
