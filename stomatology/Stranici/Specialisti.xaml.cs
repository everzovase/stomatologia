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
using stomatology.BD;


namespace stomatology.Stranici
{
    /// <summary>
    /// Логика взаимодействия для Specialisti.xaml
    /// </summary>
    public partial class Specialisti : Page
    {
        public Specialisti()
        {
            InitializeComponent();

            UpdateSpec();
        }
       

        private void UpdateSpec()
        {
            var specialiti = App.Context.User.Where(c => c.RoleId == 3).ToList();

            specialiti = specialiti.ToList();
            LViewSpecialisti.ItemsSource = specialiti;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateSpec();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentSpec = (sender as Button).DataContext as BD.User;
            NavigationService.Navigate(new AddSpecialista(currentSpec));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentVrach = (sender as Button).DataContext as BD.User;
            var check = App.Context.Zapisi.Where(c => c.Vrach == currentVrach.ID_User).Where(c => c.Date_priema >= DateTime.Now);
            if (check.Any())
            {
                MessageBox.Show("Нельзя удалить специалиста, так как у него запланированы записи.", "Внимание!");
            }
            else
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить специалиста " + $"{currentVrach.Familia} " + $"{currentVrach.Name} " + $"{currentVrach.Otchestvo}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.Context.User.Remove(currentVrach);
                    App.Context.SaveChanges();
                    UpdateSpec();
                }
            }
           
        }

    }
}

