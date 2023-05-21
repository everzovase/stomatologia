using Microsoft.SqlServer.Server;
using stomatology.BD;
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

namespace stomatology.Stranici
{
    /// <summary>
    /// Логика взаимодействия для StrUslugi.xaml
    /// </summary>
    public partial class StrUslugi : Page
    {
        private BD.Uslugi _currentUsluga = null;
        public StrUslugi()
        {
            InitializeComponent();
        }
        public StrUslugi(BD.Uslugi usluga)
        {
            InitializeComponent();
            if (App.CurrentUser.RoleId == 1)
            {
                Zapis.Content = "Редактировать";
            }
            else
            {
               Zapis.Content = "Записаться";
            }
            _currentUsluga= usluga;
            if (_currentUsluga.ImageUsl != null)
                KartUsl.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_currentUsluga.ImageUsl);
            OpisanieUsl.Text = _currentUsluga.Opisanie;
            StoimostUsl.Text = _currentUsluga.Stoimost_Uslugi.ToString()+" рублей";
            NazvanieUsl.Text = _currentUsluga.Nazvanie_Uslugi;
        }
        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser.RoleId == 1)
            {
                NavigationService.Navigate(new AddEditUslugu(_currentUsluga));
            }
            else
            {
                Zapis zapis = new Zapis(_currentUsluga);
                zapis.ShowDialog();
            }
        }
    }
}
