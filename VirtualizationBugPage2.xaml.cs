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
        private ObservableCollection<ValueObject> _valueObjects = new();

        public int ValueObjectsListIndex = 0;
        public List<List<ValueObject>> ValueObjectsLists { get; } = new();

        public VirtualizationBugPage2()
        {
            this.InitializeComponent();

            // create example data

            for (int i = 0; i < 20; i++)
            {
                int objectCount = 5;
                List<ValueObject> valueObjects = new(objectCount);
                for (int j = 0; j < objectCount; j++)
                {
                    valueObjects.Add(new ValueObject(string.Format("{0} {1}", i, j)));
                }

                ValueObjectsLists.Add(valueObjects);
            }

            // show data
            foreach (var valueObject in ValueObjectsLists[ValueObjectsListIndex])
            {
                ValueObjects.Add(valueObject);
            }
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            if (ValueObjectsListIndex == 0) return;

            ValueObjects.Clear();
            foreach (var valueObject in ValueObjectsLists[--ValueObjectsListIndex])
            {
                ValueObjects.Add(valueObject);
            }
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            if (ValueObjectsListIndex == ValueObjectsLists.Count - 1) return;

            ValueObjects.Clear();
            foreach (var valueObject in ValueObjectsLists[++ValueObjectsListIndex])
            {
                ValueObjects.Add(valueObject);
            }
        }

    }
}
