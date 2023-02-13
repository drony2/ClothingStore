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

            GetListProduct();
        }

        private void GetListProduct()
        {
            List<DB.Product> products = new List<DB.Product>();
            products = EF.Context.Product.ToList();

            LvProduct.ItemsSource = products;
        }
    }
}

