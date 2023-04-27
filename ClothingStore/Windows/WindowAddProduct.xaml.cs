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
using System.Windows.Shapes;
using ClothingStore.Classes;
using ClothingStore.Windows;
using ClothingStore.DB;
using System.IO;
using Microsoft.Win32;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddProduct.xaml
    /// </summary>
    public partial class WindowAddProduct : Window
    {
        private string pathImageProduct = null;
        private bool isEdit = false;
        Product editProduct;


        public WindowAddProduct()
        {
            InitializeComponent();

            CmbCategory.ItemsSource = EF.Context.Category.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;
        }

        public WindowAddProduct(Product product)
        {
            InitializeComponent();

            // Заполнение комбобокса

            CmbCategory.ItemsSource = EF.Context.Category.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;

            // заполнение полей значениями 
            TbName.Text = product.Name;
            TbPrice.Text = product.Price.ToString();
            CmbCategory.SelectedItem = EF.Context.Category.ToList().Where(i => i.IDCategory == product.IDCategory).FirstOrDefault();

            // вывод фото

            if (product.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream(product.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;
                }
            }


            // Изменение заголовка и кнопки 

            TblockTitle.Text = "Изменение товара";
            BtnAddProduct.Content = "Изменить";

            // флаг на изменение
            isEdit = true;

            // выводим из контекста класса полученный продукт
            editProduct = product;
        }

        private void BtnChooseImage_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }

        private void BtnAddProduct_Click_1(object sender, RoutedEventArgs e)
        {
            // валидация 

            if (isEdit)
            {
                // редактирование

                editProduct.Name = TbName.Text;
                editProduct.Price = Convert.ToDecimal(TbPrice.Text);
                editProduct.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
                if (pathImageProduct != null)
                {
                    editProduct.Photo = File.ReadAllBytes(pathImageProduct);
                }

                EF.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                // добавление
                Product product = new Product();
                product.Name = TbName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
                if (pathImageProduct != null)
                {
                    product.Photo = File.ReadAllBytes(pathImageProduct);
                }

                EF.Context.Product.Add(product);
                EF.Context.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }


            this.Close();
        }
    }
}

