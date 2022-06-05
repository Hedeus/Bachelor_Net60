using Bachelor_Net60.Services.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Windows;

namespace Bachelor_Net60.Services
{
    internal class UserDialog : IUserDialog
    {
        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;        

        public void ShowError(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Error);

        public void ShowInformation(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Warning);

        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                default: throw new NotSupportedException($"Редактирование обьекта типа {item.GetType().Name} не поддерживается");
                case Categories category:
                    return EditCategory(category);
                case Products product:
                    return EditProduct(product);
            }
        }

        private static bool EditCategory(Categories category)
        {
            return false;
        }

        private static bool EditProduct(Products product)
        {
            return false;
        }
    }
}
