using Bachelor_Net60.Views.Windows;
using CifrovikDEL.Entities;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Bachelor_Net60.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductEditView.xaml
    /// </summary>
    public partial class ProductEditView : UserControl
    {
        //#region ProductName : string - Название продукта
        //public static DependencyProperty ProductNameProperty =
        //    DependencyProperty.Register(
        //        nameof(Product),
        //        typeof(string),
        //        typeof(ProductEditView),
        //        new PropertyMetadata(default(string)));
        //[Description("Название продукта")]
        //public string Product { get => (string)GetValue(ProductNameProperty); set => SetValue(ProductNameProperty, value); }
        //#endregion

        //#region Category : Categories - Категория продукта
        //public static DependencyProperty CategoryProperty =
        //    DependencyProperty.Register(
        //        nameof(Category),
        //        typeof(Categories),
        //        typeof(ProductEditView),
        //        new PropertyMetadata(null));
        //[Description("Категория продукта")]
        //public Categories Category { get => (Categories)GetValue(CategoryProperty); set => SetValue(CategoryProperty, value); }
        //#endregion
        public ProductEditView()
        {
            InitializeComponent();
        }
    }
}
