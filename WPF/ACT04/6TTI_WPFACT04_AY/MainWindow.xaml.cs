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

namespace _6TTI_WPFACT04_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Structure de la grille
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();
            grdMain.ColumnDefinitions.Add(coldef1);
            grdMain.ColumnDefinitions.Add(coldef2);
            grdMain.ColumnDefinitions.Add(coldef3);
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            grdMain.RowDefinitions.Add(rowDef1);
            grdMain.RowDefinitions.Add(rowDef2);
            grdMain.RowDefinitions.Add(rowDef3);

            // Création du texte
            TextBlock txtDyn = new TextBlock();
            txtDyn.Margin = new Thickness(0, 20, 0, 20);
            txtDyn.Text = "TextBlock créé dynamiquement";
            txtDyn.FontSize = 16;
            txtDyn.FontWeight = FontWeights.Bold;
            txtDyn.Foreground = Brushes.Red;
            txtDyn.Background = Brushes.Yellow;

            // Ajout du texte dans la première ligne
            Grid.SetColumnSpan(txtDyn, 3);
            grdMain.Children.Add(txtDyn);

            // Création des boutons
            Button btnA = new Button();
            btnA.Margin = new Thickness(20, 20, 20, 20);
            btnA.Content = "BOUTON 1";

            Button btnB = new Button();
            btnB.Margin = new Thickness(20, 20, 20, 20);
            btnB.Content = "BOUTON 2";

            Button btnC = new Button();
            btnC.Margin = new Thickness(20, 20, 20, 20);
            btnC.Content = "BOUTON 3";

            // Ajout des boutons dans la grille
            Grid.SetColumn(btnA, 0);
            Grid.SetRow(btnA, 1);
            Grid.SetColumn(btnB, 1);
            Grid.SetRow(btnB, 1);
            Grid.SetColumn(btnC, 2);
            Grid.SetRow(btnC, 1);
            grdMain.Children.Add(btnA);
            grdMain.Children.Add(btnB);
            grdMain.Children.Add(btnC);

            // Création du stackpanel
            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(0, 20, 20, 20);

            // Création du contenu du stackpanel
            TextBlock txtInfo = new TextBlock();
            txtInfo.Text = "Infos :";
            txtInfo.FontSize = 14;
            txtInfo.FontWeight = FontWeights.Bold;
            txtInfo.Background = Brushes.Yellow;
            txtInfo.Height = 60;

            TextBox inInfo = new TextBox();
            inInfo.Text = "j'attends vos infos";

            // Ajout du contenu dans le stackpanel
            stackPanel.Children.Add(txtInfo);
            stackPanel.Children.Add(inInfo);

            // Ajout du stackpanel dans la grille
            Grid.SetRow(stackPanel, 3);
            Grid.SetColumnSpan(stackPanel, 2);
            grdMain.Children.Add(stackPanel);

            // Création de la combobox
            ComboBox comboBox = new ComboBox();
            comboBox.Margin = new Thickness(20, 20, 20, 20);
            comboBox.Items.Add("Item 1");
            comboBox.Items.Add("Item 2");

            // Ajout du combobox dans la grille
            Grid.SetRow(comboBox, 3);
            Grid.SetColumn(comboBox, 3);
            grdMain.Children.Add(comboBox);
        }
    }
}
