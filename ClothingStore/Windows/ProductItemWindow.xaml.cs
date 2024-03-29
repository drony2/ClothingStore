﻿using System;
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

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductItemWindow.xaml
    /// </summary>
    public partial class ProductItemWindow : Window
    {
        public ProductItemWindow()
        {
            InitializeComponent();
            Classes.NavigationClass.navFrame = ProductNavFrame;
            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
        }
    }
}
