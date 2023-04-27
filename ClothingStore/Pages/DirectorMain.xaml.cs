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

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectorMain.xaml
    /// </summary>
    public partial class DirectorMain : Page
    {
        public DirectorMain()
        {
            InitializeComponent();
        }

        private void btnMainCatakog_Click(object sender, RoutedEventArgs e)
        {
            
            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.EmplUser = 0;
            Classes.NavigationClass.navFrame.Navigate(new Pages.EditEmployee());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.EmplUser = 1;

            Classes.NavigationClass.navFrame.Navigate(new Pages.EditEmployee());
        }
    }
}
