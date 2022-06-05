namespace Bachelor_Net60.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(object item);
        void ShowInformation(string Message, string Caption);
        void ShowWarning(string Message, string Caption);
        void ShowError(string Message, string Caption);
        bool Confirm(string Message, string Caption, bool Exclamation = false);
    }
}
