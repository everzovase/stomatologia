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
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Avtorizacia()
        {
            InitializeComponent();
        }

        private void KnopkaLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = App.Context.User.FirstOrDefault(p => p.Login == PoleLogin.Text && p.Password == PoleParol.Password);

                if (currentUser != null)
                {
                    App.CurrentUser = currentUser;
                    if (App.CurrentUser.RoleId == 3)
                    {
                        NavigationService.Navigate(new ZapisiVracha());

                    }
                    else
                    {
                        NavigationService.Navigate(new Uslugi());
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует пользователь с такими данными", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void KnopkaReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registracia());
        }
    }
}
