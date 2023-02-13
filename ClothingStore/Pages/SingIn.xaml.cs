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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClothingStore.Classes.EF;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SingIn : Page
    {
        public SingIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Context.User.ToList().Where(i => i.Login ==tbxLoggin.Text && i.Password == psbPassword.Password).FirstOrDefault();

            if (userAuth!=null)
            {
                Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());

            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.Registration());
        }
    }
}
