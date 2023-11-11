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
using static ClothingStore.Classes.EF;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SingIn : Page
    {
        public bool Singin = false;
        public SingIn()
        {
            InitializeComponent();
        }
        
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Context.User.ToList().Where(i => i.Login == tbxLoggin.Text && i.Password == psbPassword.Password).FirstOrDefault();
            if (userAuth!=null)
            {
                var employeeAuth = Context.Employee.Where(i => i.IDUser == userAuth.IDUser).FirstOrDefault();

                if (employeeAuth != null)
                {
                    switch (employeeAuth.IDPosition)
                    {
                        case 1:
                            SingInLoggin.User = userAuth;
                            SingInLoggin.Position = "Директор";
                            Classes.NavigationClass.navFrame.Navigate(new Pages.DirectorMain());
                            break;

                        case 2:
                            SingInLoggin.User = userAuth;

                            SingInLoggin.Position = "Работник";
                            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
                            break;

                        case 3:
                            SingInLoggin.User = userAuth;
                            SingInLoggin.Position = "Покупатель";
                            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
                            break;

                        default:
                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.Registration());
        }

        private void btnSignCatalog_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
        }
    }
}
