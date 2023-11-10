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
    /// Логика взаимодействия для PersonalArea.xaml
    /// </summary>
    public partial class PersonalArea : Page
    {
        public PersonalArea()
        {
            InitializeComponent();
            PrintUser();
        }
        public void PrintUser()
        {
            
            TbLogin.Text = SingInLoggin.User.Login.ToString();

            tbFio.Text = SingInLoggin.User.Patronymic.ToString() + " ";
            tbFio.Text += SingInLoggin.User.LastName.ToString() + " ";
            tbFio.Text += SingInLoggin.User.FirstName.ToString();
            
            tbxEmail.Text = SingInLoggin.User.Email.ToString();

            tbPhone.Text = SingInLoggin.User.PhoneNumber.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.NavigationClass.navFrame.Navigate(new Pages.CatalogPages());
        }
    }
}
