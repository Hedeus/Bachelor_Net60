using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
using Bachelor_Net60.ViewModels.Base;
using CifrovikDEL.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductDetailsViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;

        /*--------------------------------------Свойства---------------------------------------------*/
        private readonly ProductsManager _ProductsManager;

        #region Category : Categories - Обрана категорія
        private Categories _Category;
        public Categories Category
        {
            get => _Category;
            set => Set(ref _Category, value);
        } 
        #endregion

        #region Product : Products - Обраний продукт
        private Products _Product;
        public Products Product
        {
            get => _Product;
            set => Set(ref _Product, value);
        }
        #endregion

        #region Таблиця цін в залежності від кількості для обраного продукту
        private IEnumerable<ProductPrice> _Prices;
        public IEnumerable<ProductPrice> Prices
        {
            get => _Prices;
            set => Set(ref _Prices, value);
        }
        #endregion

        public bool IsAdd { get; set; }

        /*---------------------------------------Методы---------------------------------------------*/

        #region OnProductsManagerPropertyChanged
        private void OnProductsManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedCategory")
                this.Category = ((ProductsManager)sender).SelectedCategory;
            if (e.PropertyName == "SelectedProduct")
            {
                this.Product = ((ProductsManager)sender).SelectedProduct;
                this.Prices = Product is null ? null : ((ProductsManager)sender).Prices.Where(price => price.ProductId == Product.Id);
            }
        }
        #endregion

        /*--------------------------------------Команды---------------------------------------------*/

        #region AddProductViewCommand - команда редактирования или добавления продукта в зависимости от параметра p (true - добавление)
        private Command _AddProductViewCommand;
        public Command AddProductViewCommand => _AddProductViewCommand
            ??= new LambdaCommand(OnAddProductViewCommandExecuted, CanAddProductViewCommandExecute);
        private bool CanAddProductViewCommandExecute(object p) =>
            _ProductsManager.SelectedCategory != null &&
            (_ProductsManager.SelectedProduct != null || (string)p == "True");
        private void OnAddProductViewCommandExecuted(object p)
        {
            _ProductsManager.CurrentModel = new ProductEditViewModel(_UserDialog, _ProductsManager, (string)p == "True");
        }
        #endregion

        #region RemoveProductCommand - команда редактирования или добавления продукта в зависимости от параметра p (true - добавление)
        private Command _RemoveProductCommand;                                                                    
        public Command RemoveProductCommand => _RemoveProductCommand                                                     
            ??= new LambdaCommand(OnRemoveProductCommandExecuted, CanRemoveProductCommandExecute);                       
        private bool CanRemoveProductCommandExecute() => _ProductsManager.SelectedProduct != null;                             
        private void OnRemoveProductCommandExecuted()                                                     
        {
            var productToRemove = _ProductsManager.SelectedProduct;
            if (!_UserDialog.Confirm($"Вы хотите удалить {productToRemove.Name}?", "Удаление продукта!"))
                return;            
            _ProductsManager.SelectedProduct = null;
            _ProductsManager.ProductsRemove(productToRemove);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public ProductDetailsViewModel(IUserDialog UserDialog, ProductsManager productsManager)
        {
            _UserDialog = UserDialog;
            _ProductsManager = productsManager;

            productsManager.PropertyChanged += OnProductsManagerPropertyChanged;            
        }

       
    }
}
