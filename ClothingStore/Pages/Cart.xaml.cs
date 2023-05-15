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
using ClothingStore.Classes;
using ClothingStore.Windows;
using ClothingStore.DB;
using System.IO;


namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        public Cart()
        {
            InitializeComponent();
            PrintCart();
        }

        

        public void PrintCart()
        {
            LvProduct.ItemsSource = ClassHelper.ProductCart.products;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;
            ClassHelper.ProductCart.products.Remove(selectedProduct);
            
            Classes.NavigationClass.navFrame.Navigate(new Pages.Cart());
        }
    }
}
