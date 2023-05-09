using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
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

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Page
    {
        Entities e = new Entities();
        public EditEmployee()
        {
            InitializeComponent();
            GetList();
        }


        public void GetList()
        {
            //сотрудник
            if (NavigationClass.EmplUser == 0)
            {
                var query =
               from User in e.User
               join E in e.Employee on User.IDUser equals E.IDUser
               join G in e.Gender on User.IDGender equals G.IDGender
               where E.IDPosition == 3
               select new { User.LastName, User.FirstName, User.Patronymic, User.Email, User.PhoneNumber, User.Birthday, G.GenderName };
                DG1.ItemsSource = query.ToList();

            }
            else if(NavigationClass.EmplUser == 1)
            {
                //покупаель  
                btnEditUser.Visibility = Visibility.Collapsed;
                btnAddUser.Visibility = Visibility.Collapsed;
 
                var query =
               from User in e.User
               join E in e.Employee on User.IDUser equals E.IDUser
               join G in e.Gender on User.IDGender equals G.IDGender
               where E.IDPosition == 2
               select new { User.LastName, User.FirstName, User.Patronymic, User.Email, User.PhoneNumber, User.Birthday, G.GenderName };
                DG1.ItemsSource = query.ToList();
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navFrame.Navigate(new Pages.DirectorMain());
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navFrame.Navigate(new Pages.EditAddClientEmployee());
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
