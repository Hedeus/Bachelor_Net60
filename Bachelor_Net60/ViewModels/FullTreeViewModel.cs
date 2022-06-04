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

        private TreeViewModel? AddItem(Categories Cat)
        {
            if (Cat is null) return null;
            var chilCollection = new ObservableCollection<TreeViewModel>();

            foreach (var t in _Tree.Items.Where(i => i.Ancestor.Id == Cat.Id))
            {
                var child = _Categories.Get(t.DescendantId ?? 0);
                chilCollection.Add(new TreeViewModel(AddItem(child)));
            }
            var Item = new TreeViewModel(Cat, children: chilCollection);
            return Item;
        }

        public FullTreeViewModel(IRepository<Categories> Categories, IRepository<CategoryTree> Tree)
        {
            _Categories = Categories;
            _Tree = Tree;


            var ancestorIsNull = (from c in Categories.Items
                                  join t in Tree.Items on c.Id equals t.DescendantId into CategoryInTree
                                  from subc in CategoryInTree.DefaultIfEmpty()
                                  where subc.AncestorId == null
                                  select new { c }).ToList();


            foreach (var cat in ancestorIsNull)
            {
                var subTree = _Tree.Items.Where(i => i.AncestorId == cat.c.Id).ToList();
                var chilCollection = new ObservableCollection<TreeViewModel>();
                foreach (var t in subTree)
                {
                    var child = Categories.Get(t.DescendantId ?? 0);
                    chilCollection.Add(new TreeViewModel(AddItem(child)));
                }
                Items.Add(new TreeViewModel(cat, children: chilCollection));
            }
        }
    }
}
