using ClothingStore.Classes;
using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditAddClientEmployee.xaml
    /// </summary>
    public partial class EditAddClientEmployee : Page
    {
        Entitiess en = new Entitiess();
        private static readonly char[] Number = "0123456789".ToCharArray();
        private static readonly char[] SpecSimvol = "@%!@#$%^&*()?/>.<,:;'|}]{[_~`+=-".ToCharArray();
        private static readonly char[] StringEng = "qwertyuiopasdfghjklmnbvcxzQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
        private static readonly char[] StringRu = "йцуёкенгшщзхъэждлорпавыфячсмитьбюЙЦУКЕНГШЩЗХЪЁФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".ToCharArray();

        public EditAddClientEmployee()
        {
            InitializeComponent();
        }
        private bool Check = true;
        private int CheckGender = 1;


       
            
            

        
        private void btnRegClient_Click(object sender, RoutedEventArgs e)
        {
            CheckAllForms();

            if (Check == true)
            {
                if (rbtGirl.IsChecked == true)
                {
                    CheckGender = 2;
                }

                EF.Context.User.Add(new User()
                {
                    Login = tbxEmail.Text,
                    Password = psbPassword.Password,
                    LastName = tbxName.Text,
                    FirstName = tbxSurname.Text,
                    Patronymic = tbxPatronymic.Text,
                    Email = tbxEmail.Text,
                    PhoneNumber = tbxPhone.Text,    
                    Birthday = dprBirthday.SelectedDate.Value,
                    IDGender = CheckGender,

                });
                EF.Context.SaveChanges();

                var userAuth = EF.Context.User.ToList().Where(i => i.Login == tbxEmail.Text).FirstOrDefault();

                User user = new User();
                EF.Context.Employee.Add(new Employee()
                {
                    IDPosition = 2,
                    IDUser = userAuth.IDUser
                }) ;
                // сохранение изменений
                EF.Context.SaveChanges();


                // оповещение об успехе
                MessageBox.Show("Вы зарегестрировали сотрудника");
                Classes.NavigationClass.navFrame.Navigate(new Pages.EditEmployee());

            }
            else
            {
                MessageBox.Show("Ошибка! Заполните все поля");
            }
        }
        private void CheckAllForms()
        {
            // Проверка на пустоту
            if (string.IsNullOrWhiteSpace(tbxName.Text) || string.IsNullOrWhiteSpace(tbxEmail.Text) || string.IsNullOrWhiteSpace(dprBirthday.Text) ||
                string.IsNullOrWhiteSpace(tbxPatronymic.Text) || string.IsNullOrWhiteSpace(tbxEmail.Text) || string.IsNullOrWhiteSpace(tbxPhone.Text) ||
                string.IsNullOrWhiteSpace(psbPassword.Password) || string.IsNullOrWhiteSpace(psbResetPassword.Password))
            {
                Check = false;
            }
            //Проверка на Неверность ввода ФИО, ТЕЛЕФОН, Дата рождения
            if (tbxName.Text.IndexOfAny(Number) != -1)
            {
                tbxName.Text = "";
                MessageBox.Show("Неверно заполнено поле ИМЯ");
                Check = false;
            }
            if (tbxSurname.Text.IndexOfAny(Number) != -1)
            {
                tbxSurname.Text = "";
                MessageBox.Show("Неверно заполнено поле ФАМИЛИЯ");
                Check = false;
            }
            if (tbxPatronymic.Text.IndexOfAny(Number) != -1)
            {
                tbxPatronymic.Text = "";
                MessageBox.Show("Неверно заполнено поле ОТЧЕСТВО");
                Check = false;
            }
            if (tbxPhone.Text.IndexOfAny(StringEng) != -1 || tbxPhone.Text.IndexOfAny(StringRu) != -1)
            {
                tbxPhone.Text = "";
                MessageBox.Show("Неверно заполнено поле ТЕЛЕФОН");
                Check = false;
            }


            //Проверка на правильность создания пароля
            if (psbPassword.Password.IndexOfAny(StringEng) != -1 || psbPassword.Password.IndexOfAny(StringRu) != -1
                && psbPassword.Password.LastIndexOfAny(Number) != -1 && psbPassword.Password.LastIndexOfAny(SpecSimvol) != -1)
            {

                MessageBox.Show("Пароль должен состоять из букв ерхнего и нижнего клонтитула и спецсимвола");
                Check = false;
            }


            //Проверка на несовпадения пароля
            if (psbPassword.Password != psbResetPassword.Password)
            {
                Check = false;
                MessageBox.Show("Несовподат пароли!!!");
            }

            //Проверека номера телефона
            if (tbxPhone.Text.Contains("+7") || tbxPhone.Text.Contains("8") || tbxPhone.Text.Contains("7"))
            {

            }
            else
            {
                MessageBox.Show("Неверно введен номер телефона!");
                Check = false;
            }
        }
        }
}
