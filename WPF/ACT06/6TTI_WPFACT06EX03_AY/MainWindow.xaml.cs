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

namespace _6TTI_WPFACT06EX03_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string getAsset(int i)
        {
            string res;
            switch(i)
            {
                case 0:
                case 7:
                    res = "t";
                    break;
                case 1:
                case 6:
                    res = "kn";
                    break;
                case 2:
                case 5:
                    res = "b";
                    break;
                case 3:
                    res = "k";
                    break;
                case 4:
                    res = "q";
                    break;
                default:
                    res = "";
                    break;
            }

            return "assets/" + res + ".png";
        }

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
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
                    button.Height = window.Height / 8;
                    button.Width = window.Width / 8;
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

                    if (j == 0 || j == 1 || j == 6 || j ==  7)
                    {
                        BitmapImage imageBouton = new BitmapImage();
                        imageBouton.BeginInit();
                        imageBouton.UriSource = new Uri((j == 1 || j == 6) ? "assets/p.png" : (getAsset(i)), UriKind.Relative);
                        imageBouton.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = imageBouton;
                        imBouton.Stretch = Stretch.None;
                        button.Content = imBouton;
                    }

                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    grdMain.Children.Add(button);
                }
            }
        }
    }
}
