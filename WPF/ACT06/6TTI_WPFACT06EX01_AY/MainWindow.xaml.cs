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
using static System.Net.Mime.MediaTypeNames;

namespace _6TTI_WPFACT06EX01_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int tailleDamier = 10;

            for (int i = 0; i < tailleDamier; i++)
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
                    button.Height = window.Height / tailleDamier;
                    button.Width = window.Width / tailleDamier;
                    button.VerticalAlignment = VerticalAlignment.Center;
                    button.HorizontalAlignment = HorizontalAlignment.Center;

                    if ((i + j) % 2 == 0)
                    {
                        button.Background = Brushes.White;
                    } else
                    {
                        button.Background = Brushes.Black;
                    }

                    button.Content = (i + 1) + (j * tailleDamier);
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
