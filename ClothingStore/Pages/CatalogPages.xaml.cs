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
    /// Логика взаимодействия для CatalogPages.xaml
    /// </summary>
    public partial class CatalogPages : Page
    {
        
        public CatalogPages()
        {
            InitializeComponent();
            if (SingInLoggin.User != null)
            {
                btnSingin.Content = "Личный кабинет";
            }
            GetListProduct();

            GetCountCart();
        }

        private void GetListProduct()
        {
            if (SingInLoggin.Position == "Покупатель")
            {
                BtnAddProduct.Visibility = Visibility.Collapsed;
                
            }
            List<DB.Product> products = new List<DB.Product>();
            products = EF.Context.Product.ToList();
            
            LvProduct.ItemsSource = products;
        }

        private void BtnAddProduct_Click_1(object sender, RoutedEventArgs e)
        {
            WindowAddProduct windowAddProduct = new WindowAddProduct();
            windowAddProduct.ShowDialog();
            GetListProduct();
        }

        private void BtnMore_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            WindowAddProduct windowAddProduct = new WindowAddProduct(selectedProduct);
            windowAddProduct.ShowDialog();

            GetListProduct();
        }

        private void btnSingin_Click(object sender, RoutedEventArgs e)
        {
            if (btnSingin.Content.ToString() == "Войти")
            {
                NavigationClass.navFrame.Navigate(new Pages.SingIn());
            }
            else
            {
                NavigationClass.navFrame.Navigate(new Pages.PersonalArea());
            }
        }
        private void Discount()
        {

        }

        private void BtnAddСart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;
            ClassHelper.ProductCart.products.Add(selectedProduct);
            GetCountCart();

        }

        private void btnTransitionCast_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.Cart());
        }
        private void GetCountCart()
        {
            btCount.Text = ClassHelper.ProductCart.products.Count.ToString();
        }
    }
}
