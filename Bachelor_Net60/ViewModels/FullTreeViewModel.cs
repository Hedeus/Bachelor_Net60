using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bachelor_Net60.ViewModels
{
    internal class FullTreeViewModel : ViewModel
    {
        public ObservableCollection<TreeViewModel> Items { get; set; } = new ObservableCollection<TreeViewModel>();
        private readonly IRepository<Categories> _Categories;
        private readonly IRepository<CategoryTree> _Tree;

        private ObservableCollection<TreeViewModel>? AddItem(Categories Item)
        {
            if (Item is null) return null;
            var item = new ObservableCollection<TreeViewModel>();
            
            foreach (var t in _Tree.Items.Where(i => i.Ancestor.Id == Item.Id))
            {
                var child = _Categories.Get(t.DescendantId ?? 0);
                item.Add(new TreeViewModel(Item, children: AddItem(child)));
            }
            
            return item;
        }

        public FullTreeViewModel(IRepository<Categories> Categories, IRepository<CategoryTree> Tree)
        {
            //var language = new ObservableCollection<TreeViewModel>()
            //{
            //    new TreeViewModel("Russian"),
            //    new TreeViewModel("English", "Red"),
            //    new TreeViewModel("Spanish")
            //};
            //Items.Add(new TreeViewModel("Languages", isExpander: true, children: language));
            //var people = new ObservableCollection<TreeViewModel>()
            //{
            //    new TreeViewModel("Vasia"),
            //    new TreeViewModel("Masha"),
            //    new TreeViewModel("Vova", children: new ObservableCollection<TreeViewModel>{new TreeViewModel("Ania") })
            //};
            //Items.Add(new TreeViewModel("People", "Blue", children: people));

            _Categories = Categories;
            _Tree = Tree;

            var item = new ObservableCollection<TreeViewModel>();
            var ancestorIsNull = (from c in Categories.Items
                                 join t in Tree.Items on c.Id equals t.DescendantId into CategoryInTree
                                 from subc in CategoryInTree.DefaultIfEmpty()
                                 where subc.AncestorId == null
                                 select new {c}).ToList();


            foreach (var cat in ancestorIsNull)
            {
                var subTree = _Tree.Items.Where(i => i.AncestorId == cat.c.Id).ToList();
                foreach (var t in subTree)
                {                    
                    var child = Categories.Get( t.DescendantId ?? 0);
                    item.Add(new TreeViewModel(cat, children: AddItem(child)));
                }
            }
            Items.Add(new TreeViewModel(item));
        }
    }
}
