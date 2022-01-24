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

namespace TabuGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TabuGameVM tabuGameVm;
        public MainWindow()
        {
            var settings = new Settings();
            settings.ShowDialog();
            int number = 40;
            int.TryParse(settings.NumberOfCardsTextBox.Text, out number);
            tabuGameVm = new TabuGameVM(2, 40, 5);
            
            DataContext = tabuGameVm;
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var g = b.DataContext as Group;
            g.AddCard();

            tabuGameVm.CardDecrease();
            
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabuGameVm.StartTimer();
        }
    }
}
