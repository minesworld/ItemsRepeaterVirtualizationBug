using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.UI.Xaml;

namespace ItemsRepeaterVirtualizationBug
{
    public partial class Logger : ObservableObject
    {
        [ObservableProperty]
        private string _text = "";

        private List<string> collectedMessages = new();

        public bool CanAppendCollectedMessages { get => collectedMessages.Count > 0; } 

        public bool LogToDebug = true;

        public void WriteLine(string message)
        {
            // message = string.Format("{0} {1}", DateTime.Now.Ticks, message);

            if (collectedMessages.Count == 0 || collectedMessages.Last() != message) collectedMessages.Add(message);
            if (LogToDebug) Debug.WriteLine(message);

            OnPropertyChanged(nameof(CanAppendCollectedMessages));
        }

        public void AppendCollectedMessages(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new(collectedMessages.Count + 1);

            for (int i = collectedMessages.Count - 1; i >= 0; i--)
            {
                sb.AppendLine(collectedMessages[i]);
            }
            sb.Append(_text);

            Text = sb.ToString();

            collectedMessages.Clear();

            OnPropertyChanged(nameof(CanAppendCollectedMessages));
        }

        public Logger(bool logToDebug)
        {
            LogToDebug = logToDebug;
        }
    }
}
