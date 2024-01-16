using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6TTI_WPFACT06EX02_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef);
            }

            for (int i = 0; i < grdMain.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < grdMain.RowDefinitions.Count; j++)
                {
                    Button button = new Button();
                    button.Height = window.Height / 10;
                    button.Width = window.Width / 10;
                    button.VerticalAlignment = VerticalAlignment.Center;
                    button.HorizontalAlignment = HorizontalAlignment.Center;

                    if ((i % 2 != 0 && j % 2 == 0) || (j % 2 != 0 && i % 2 == 0))
                    {
                        button.Background = Brushes.Black;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }

                    if (j % 2 == 0)
                    {
                        button.Content = (i + 1) + (j * 10);
                    } else
                    {
                        button.Content = (10 - i) + (j * 10);
                    }
                    button.Foreground = Brushes.Red;
                    button.FontWeight = FontWeights.Bold;
                    button.FontSize = 26;

                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    grdMain.Children.Add(button);
                }
            }
        }
    }
}
