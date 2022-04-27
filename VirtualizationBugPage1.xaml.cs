using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    public sealed partial class VirtualizationBugPage1 : Page
    {
        [ObservableProperty]
        private List<Item> _items;

        public int ItemsListsIndex = 0;
        public List<List<Item>> ItemsLists { get; } = new();

        public VirtualizationBugPage1()
        {
            this.InitializeComponent();

            // create some random example data
            Random rndGen = new();

            for (int i = 1; i <= 20; i++) // always 20 Lists of Items
            {
                int itemsCount = rndGen.Next(9) + 1; // up to 10 Item per List

                var items = Item.CreateItems(i * 100, i * 100 + itemsCount, rndGen.Next(9) + 1); // up to 10 Numbers per Item

                ItemsLists.Add(items);
            }

            // show data

            Items = ItemsLists[ItemsListsIndex];
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            if (ItemsListsIndex == 0) return;

            // Items is an ObservableProperty, so everthing should be fine...
            Items = ItemsLists[--ItemsListsIndex];
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            if (ItemsListsIndex == ItemsLists.Count - 1) return;

            // Items is an ObservableProperty, so everthing should be fine...
            Items = ItemsLists[++ItemsListsIndex];
        }

    }
}
