using CommunityToolkit.Mvvm.ComponentModel;
using ItemsRepeaterVirtualizationBug.FromCommunityToolkit;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ItemsRepeaterVirtualizationBug
{

    [INotifyPropertyChanged]
    public sealed partial class VirtualizationBugPage2 : Page
    {
        [ObservableProperty]
        private Logger _wrapLayoutLogger;

        public ObservableCollection<ItemsList> ItemsListList { get; } = new();


        /* we have to wrap the selected ItemsList into a List so that the ListView can display it... */
        private ItemsList _selectedItemsList;
        public ItemsList SelectedItemsList
        {
            get => _selectedItemsList;
            set
            {
                if (SetProperty(ref _selectedItemsList, value) == false) return;

                ListOfOneItemsList.Clear();
                if (value != null) ListOfOneItemsList.Add(value);
            }
        }

        public ObservableCollection<ItemsList> ListOfOneItemsList = new();


        public VirtualizationBugPage2()
        {
            WrapLayoutLogger = FromCommunityToolkit.WrapLayout.Logger;

            this.InitializeComponent();

            // create some random example data
            Random rndGen = new();

            for (int i = 1; i <= 20; i++) // always 20 Lists of Items
            {
                int itemsCount = rndGen.Next(9) + 1; // up to 10 Item per List

                var items = Item.CreateItems(i * 100, i * 100 + itemsCount, rndGen.Next(9) + 1); // up to 10 Numbers per Item

                var itemsList = new ItemsList(i.ToString(), items, WrapLayout.Logger);

                ItemsListList.Add(itemsList);
            }
        }
    }
}
