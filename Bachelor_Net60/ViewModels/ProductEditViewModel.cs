using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
using Bachelor_Net60.ViewModels.Base;
using CifrovikDEL.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductEditViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;

        /*---------------------------------------Свойства---------------------------------------------*/
        private readonly ProductsManager _ProductsManager;

        #region Category : string - назва обраної категорії
        private string _Category;
        public string Category
        {
            get => _Category;
            set => Set(ref _Category, value);
        }
        #endregion

        #region Product : string - Назва обраного продукту
        private string _Product;
        public string Product
        {
            get => _Product;
            set => Set(ref _Product, value);
        }
        #endregion

        #region Prices: Таблиця цін в залежності від кількості для обраного продукту
        private ObservableCollection<ProductPrice> _Prices = new ObservableCollection<ProductPrice>();
        public ObservableCollection<ProductPrice> Prices
        {
            get => _Prices;
            set => Set(ref _Prices, value);
        }
        #endregion

        private bool IsAdd;
        private Products SelectedProduct = new Products();

        /*-----------------------------------------Методы---------------------------------------------*/


        /*----------------------------------------Команды----------------------------------------------*/

        #region CancelEditCommand
        private Command _CancelEditCommand;
        public Command CancelEditCommand => _CancelEditCommand
            ??= new LambdaCommand(OnCancelEditCommandExecuted, CanCancelEditCommandExecute);
        private bool CanCancelEditCommandExecute() => true;
        private void OnCancelEditCommandExecuted()
        {
            _ProductsManager.CurrentModel = new ProductDetailsViewModel(_UserDialog, _ProductsManager);
        }
        #endregion

        #region AddRowCommand
        private Command _AddRowCommand;
        public Command AddRowCommand => _AddRowCommand
            ??= new LambdaCommand(OnAddRowCommandExecuted, CanAddRowCommandExecute);
        private bool CanAddRowCommandExecute() => _ProductsManager.SelectedCategory != null;
        private void OnAddRowCommandExecuted()
        {
            Products newProduct = SelectedProduct != null ? SelectedProduct : new Products();
            SelectedProduct ??= newProduct;
            ProductPrice newprice = new ProductPrice()
            {
                //ProductId = newProduct.Id,
                Amount = 0,
                Price = 0.0M
            };
            Prices.Add(newprice);
        }
        #endregion

        #region SaveChangesCommand
        private Command _SaveChangesCommand;
        public Command SaveChangesCommand => _SaveChangesCommand
            ??= new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);
        private bool CanSaveChangesCommandExecute() => true;
        private void OnSaveChangesCommandExecuted()
        {
            if (IsAdd)
            {
                SelectedProduct ??= new Products();
                SelectedProduct.CategoryId = _ProductsManager.SelectedCategory.Id;
                SelectedProduct.Name = Product;
                var newProduct = _ProductsManager.ProductsAdd(SelectedProduct);
                foreach (var price in Prices)
                    price.ProductId = newProduct.Id;
                _ProductsManager.ProductPriceAdd(Prices);
            }
            else
            {
                _ProductsManager.ProductsUpdate(SelectedProduct);
                foreach (var price in Prices)
                    price.ProductId = SelectedProduct.Id;
                _ProductsManager.ProductPriceUpdate(Prices);
            }
            _ProductsManager.CurrentModel = new ProductDetailsViewModel(_UserDialog, _ProductsManager);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public ProductEditViewModel(IUserDialog userDialog, ProductsManager productsManager, bool isAdd = false)        
        {
            _UserDialog = userDialog;
            _ProductsManager = productsManager;
            _Category = _ProductsManager.SelectedCategory.Name;
            IsAdd = isAdd;
            if (!isAdd)
                SelectedProduct = _ProductsManager.SelectedProduct;
            _Product = "Продукт не выбрана";
            if (SelectedProduct != null)
            {
                Product = SelectedProduct.Name;
                foreach (var price in _ProductsManager.Prices.Where(price => price.ProductId == SelectedProduct.Id))
                    Prices.Add(price);  
            }            
        }
    }
}
