using Microsoft.SqlServer.Server;
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
using System.Windows.Shapes;

namespace stomatology
{
    /// <summary>
    /// Логика взаимодействия для Zapis.xaml
    /// </summary>
    public partial class Zapis : Window
    {
        private BD.Uslugi _currentUsluga = null;
        public Zapis()
        {
            InitializeComponent();
            Data.DisplayDateStart = DateTime.Now;
        }

        public Zapis(BD.Uslugi uslugi)
        {
            InitializeComponent();
             VrachiBox.SelectedIndex = 0;
            _currentUsluga = uslugi;
            
            Data.DisplayDateStart = DateTime.Now;
            Data.DisplayDate.ToShortDateString();
            VrachiBox.ItemsSource = App.Context.User.Where(c => c.id_specialnosti == uslugi.ID_Specialnosti).Select(c => c.Name).ToList();
        }

        private void ZapisBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var zapisi = App.Context.Zapisi.Where(c => c.Pacient == App.CurrentUser.ID_User).Where(c => c.ID_Uslugi == _currentUsluga.ID_Uslugi).Where(c => c.Date_priema == Data.SelectedDate).Select(c => c.Date_priema);

            if(zapisi.Any() == true)
            {
                MessageBox.Show("Вы уже записаны на данную дату", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Data.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату для записи", "Не выбрана дата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var idVrach = App.Context.User.Where(c => c.Name == VrachiBox.Text).Select(c => c.ID_User).FirstOrDefault();
                var zapis = new BD.Zapisi
                {
                    Pacient = App.CurrentUser.ID_User,
                    Vrach = idVrach,
                    Date_priema = Data.SelectedDate.Value.Date,
                    ID_Uslugi = _currentUsluga.ID_Uslugi,
                };
                App.Context.Zapisi.Add(zapis);
                App.Context.SaveChanges();
                if(MessageBox.Show("Вы успешно записались", "Запись", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)     // tyt kod
                {
                    this.Close();
                };
                 
            }
        }
    }
}
