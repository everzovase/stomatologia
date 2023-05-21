using stomatology.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Registracia.xaml
    /// </summary>
    public partial class Registracia : Page
    {
        public Registracia()
        {
            InitializeComponent();
            Role.ItemsSource = App.Context.Role.Where(c=>c.id!=1).Select(c => c.name).ToList();
        }
        private void Zareg_Click(object sender, RoutedEventArgs e)
        {

            if (PoleRegParol.Password == string.Empty)
            {
                MessageBox.Show("Не указан пароль!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (string.IsNullOrWhiteSpace(PoleRegLogin.Text))
            {
                MessageBox.Show("Не указан логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Role.Text == String.Empty)
            {
                MessageBox.Show("Не указана роль!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (PoleRegParol.Password != PoleRegPovtParol.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (PoleRegParol.Password.Length < 8 & PoleRegParol.Password != String.Empty)
            {
                MessageBox.Show("Пароль слишком короткий!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PoleRegParol.Password.Length > 17 & PoleRegParol.Password != String.Empty)
            {
                MessageBox.Show("Пароль слишком длинный!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PoleRegLogin.Text.Length < 3 & PoleRegLogin.Text != String.Empty)
            {
                MessageBox.Show("Логин слишком короткий!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PoleRegLogin.Text.Length > 20)
            {
                MessageBox.Show("Логин слишком длинный!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!(Regex.IsMatch(PoleRegParol.Password, @"\W") &&
                  Regex.IsMatch(PoleRegParol.Password, @"\d") &&
                  Regex.IsMatch(PoleRegParol.Password, @"[a-z]") &&
                  Regex.IsMatch(PoleRegParol.Password, @"[A-Z]")))
            {
                MessageBox.Show("В пароле должна быть хотя бы одна цифра, символ, прописная и строчная латинские буквы!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var idRole = App.Context.Role.Where(c => c.name == Role.Text).Select(c => c.id).FirstOrDefault();

                var user = new BD.User
                {
                    Login = PoleRegLogin.Text,
                    Password = PoleRegParol.Password,
                    RoleId = idRole,
                    Familia = PoleRegSurname.Text,
                    Name = PoleRegName.Text,     
                    Otchestvo = PoleRegOtchestvo.Text,
                };
                App.Context.User.Add(user);
                App.Context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрированы");
                NavigationService.GoBack();
            }
        }
    }
}
