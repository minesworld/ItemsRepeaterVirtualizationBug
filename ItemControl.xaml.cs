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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ItemsRepeaterVirtualizationBug
{
    /* [INotifyPropertyChanged] */
    public partial class ItemControl : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty HorinzontalLinesTextProperty =
            DependencyProperty.Register(
                nameof(HorizontalLinesText),
                typeof(string),
                typeof(ItemControl),
                new PropertyMetadata(0, null));




        /* [ObservableProperty] */
        private string _horizontalLinesText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string HorizontalLinesText { 
            get => _horizontalLinesText; 
            set { 
                if (value == _horizontalLinesText) return;
                _horizontalLinesText = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nameof(HorizontalLinesText)));
            } 
        }

        public ItemControl()
        {
            this.InitializeComponent();
        }
    }
}
