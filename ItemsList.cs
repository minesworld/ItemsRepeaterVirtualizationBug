using CommunityToolkit.Mvvm.ComponentModel;
using ItemsRepeaterVirtualizationBug.FromCommunityToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsRepeaterVirtualizationBug
{
    public partial class ItemsList : ObservableObject
    {
        public bool RecycleOnReset
        {
            get => WrapLayout.RecycleOnReset;
            set => SetProperty(ref WrapLayout.RecycleOnReset, value);
        }

        [ObservableProperty]
        private Logger _wrapLayoutLogger;

        [ObservableProperty]
        private List<Item> _items;

        [ObservableProperty]
        private string _title;

        public ItemsList(string title, List<Item> items, Logger logger)
        {
            this.Title = title;
            this.Items = items;

            this.WrapLayoutLogger = logger;
        }
    }
}
