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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using stomatology.BD;

namespace stomatology.Stranici
{
    /// <summary>
    /// Логика взаимодействия для Uslugi.xaml
    /// </summary>
    public partial class Uslugi : Page
    {
        public Uslugi()
        {
            InitializeComponent();

            if (App.CurrentUser.RoleId == 1)
            {
                BtnAddUsl.Visibility = Visibility.Visible;
                ZapisiBtn.Visibility = Visibility.Collapsed;
                Registracia_AdminaBtn.Visibility = Visibility.Visible;
            }
            else
            {
                ZapisiBtn.Visibility = Visibility.Visible;
                BtnAddUsl.Visibility = Visibility.Collapsed;
                Registracia_AdminaBtn.Visibility = Visibility.Collapsed;

            }

            SortByType.ItemsSource = App.Context.Tip_uslugi.Select(c => c.Nazvanie_Tipa_Uslugi).ToList();
            ComboSortBy.SelectedIndex = 0;
            UpdateStom();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentUsl = (sender as Button).DataContext as BD.Uslugi;
            NavigationService.Navigate(new AddEditUslugu(currentUsl));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentUsl = (sender as Button).DataContext as BD.Uslugi;

            var check = App.Context.Zapisi.Where(c => c.Uslugi.ID_Uslugi == currentUsl.ID_Uslugi).Where(c => c.Date_priema >= DateTime.Now);
            if (check.Any())
            {
                MessageBox.Show("Нельзя удалить услугу, так как на нее запланирована запись.", "Внимание!");
            }
            else
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить услугу: " + $"{currentUsl.Nazvanie_Uslugi}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.Context.Uslugi.Remove(currentUsl);
                    App.Context.SaveChanges();
                    UpdateStom();
                }
            }
           
        }
        private void BtnAddUsl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditUslugu());
        }
        

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStom();

        }
        private void UpdateStom()
        {

            var uslugis = App.Context.Uslugi.ToList();

            if (ComboSortBy.SelectedIndex == 0)
                uslugis = uslugis.OrderBy(c => c.Stoimost_Uslugi).ToList();
            else
                uslugis = uslugis.OrderByDescending(c => c.Stoimost_Uslugi).ToList();

            if (SortByType.SelectedIndex == 0)
                uslugis = uslugis.Where(c => c.ID_Tipa_Uslugi == 1).ToList();
            if (SortByType.SelectedIndex == 1)
                uslugis = uslugis.Where(c => c.ID_Tipa_Uslugi == 2).ToList();
            if (SortByType.SelectedIndex == 2)
                uslugis = uslugis.Where(c => c.ID_Tipa_Uslugi == 3).ToList();
            if (SortByType.SelectedIndex == 3)
                uslugis = uslugis.Where(c => c.ID_Tipa_Uslugi == 4).ToList();

            uslugis = uslugis.Where(c => c.Nazvanie_Uslugi.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewUslugi.ItemsSource = uslugis;
        }

        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStom();
        }

        private void SortByType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStom();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStom();
        }

       

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentUsluga = (sender as Grid).DataContext as BD.Uslugi;

            NavigationService.Navigate(new StrUslugi(currentUsluga));
        }

        private void ZapisiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Zapisi());
        }

      

        private void SpecialistiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Specialisti());

        }

        private void Registracia_AdminaBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistraciaAdministratora());

        }
    }
}
