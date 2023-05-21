using stomatology.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace stomatology.Stranici
{
    /// <summary>
    /// Логика взаимодействия для RegistraciaAdministratora.xaml
    /// </summary>
    public partial class RegistraciaAdministratora : Page
    {
        public RegistraciaAdministratora()
        {
            InitializeComponent();
        }

        private void KnopkaRegAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (ParolAdmin.Password == string.Empty)
            {
                MessageBox.Show("Не указан пароль!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (string.IsNullOrWhiteSpace(LoginAdmin.Text))
            {
                MessageBox.Show("Не указан логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            else if (ParolAdmin.Password != PovtorParolAdmin.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (ParolAdmin.Password.Length < 8 & ParolAdmin.Password != String.Empty)
            {
                MessageBox.Show("Пароль слишком короткий!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (LoginAdmin.Text.Length < 3 & LoginAdmin.Text != String.Empty)
            {
                MessageBox.Show("Логин слишком короткий!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (LoginAdmin.Text.Length > 20)
            {
                MessageBox.Show("Логин слишком длинный!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!(Regex.IsMatch(ParolAdmin.Password, @"\W") &&
                  Regex.IsMatch(ParolAdmin.Password, @"\d") &&
                  Regex.IsMatch(ParolAdmin.Password, @"[a-z]") &&
                  Regex.IsMatch(ParolAdmin.Password, @"[A-Z]")))
            {
                MessageBox.Show("В пароле должна быть хотя бы одна цифра, символ, прописная и строчная латинские буквы!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var user = new BD.User
                {
                    Login = LoginAdmin.Text,
                    Password = ParolAdmin.Password,
                    RoleId = 1
                };
                App.Context.User.Add(user);
                App.Context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрированы");
                NavigationService.GoBack();
            }
        }

    
    }
}
