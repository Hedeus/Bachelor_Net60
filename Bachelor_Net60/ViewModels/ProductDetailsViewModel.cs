using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
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
            _ProductsManager.CurrentModel = new ProductEditViewModel(_ProductsManager, (string)p == "True");
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public ProductDetailsViewModel(ProductsManager productsManager)
        {
            _ProductsManager = productsManager;

            productsManager.PropertyChanged += OnProductsManagerPropertyChanged;            
        }

       
    }
}
