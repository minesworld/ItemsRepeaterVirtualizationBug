using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsRepeaterVirtualizationBug
{
    public partial class Item : ObservableObject
    {
        private int Number { get; set; }
        private int LinesCount { get; set; }

        [ObservableProperty]
        private string _verticalLinesTextAsProperty;

        [ObservableProperty]
        private string _horizontalLinesTextAsProperty;

        public string VerticalLinesText
        {
            get
            {
                StringBuilder sb = new StringBuilder(LinesCount + 1);
                sb.AppendLine(string.Format("Item #{0}", Number));
                for (int i = LinesCount - 1; i > 0; i--) sb.AppendLine(i.ToString());
                sb.Append("0");
                return sb.ToString();
            }
        }

        public string HorizontalLinesText
        {
            get
            {
                StringBuilder sb = new StringBuilder(LinesCount + 1);
                sb.Append(string.Format("Item #{0}", Number));
                for (int i = LinesCount - 1; i >= 0; i--) sb.Append(string.Format(" {0}", i));
                return sb.ToString();
            }
        }

        public Item(int number, int linesCount)
        {
            Number = number;
            LinesCount = linesCount;

            VerticalLinesTextAsProperty = VerticalLinesText;
            HorizontalLinesTextAsProperty = HorizontalLinesText;
        }

        static private Random rndGen = new();

        static public List<Item> CreateItems(int firstNumber, int lastNumber, int maxLinesCount)
        {
            List<Item> items = new(lastNumber - firstNumber + 1);

            for(int number = firstNumber; number <= lastNumber; number++)
            {
                items.Add(new Item(number, rndGen.Next(maxLinesCount - 1) + 1));
            }

            return items;
        }
    }
}
