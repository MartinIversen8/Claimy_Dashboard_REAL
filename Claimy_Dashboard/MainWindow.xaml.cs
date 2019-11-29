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

namespace Claimy_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            caseListView.Visibility = Visibility.Hidden;
        }

        private void CloseDashBoard(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowCases(object sender, MouseButtonEventArgs e)
        {
            caseListView.Visibility = Visibility.Visible;
        }
        private void HideAll(object sender, MouseButtonEventArgs e)
        {
            caseListView.Visibility = Visibility.Hidden;
        }
    }
}
