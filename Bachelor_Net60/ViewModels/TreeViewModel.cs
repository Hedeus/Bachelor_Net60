using Bachelor_Net60.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.ViewModels
{
    internal class TreeViewModel : ViewModel
    {
        public object Node { get; set; }

        private string _Foreground;
        public string Foreground
        {
            get => _Foreground;
            set => Set(ref _Foreground, value);
        }

        private bool _IsExpander;
        public bool IsExpander
        {
            get => _IsExpander;
            set => Set(ref _IsExpander, value);
        }
        public ObservableCollection<TreeViewModel> Children { get; set; } = new ObservableCollection<TreeViewModel>();
        public TreeViewModel(object node , string foreground = "black", bool isExpander = false, ObservableCollection<TreeViewModel> children = null)
        {
            Node = node;
            Foreground = foreground;
            IsExpander = isExpander;
            if (children != null)
                Children = children;
        }
    }
}
