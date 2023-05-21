using stomatology.BD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stomatology.Stranici
{
    /// <summary>
    /// Логика взаимодействия для Zapisi.xaml
    /// </summary>
    public partial class Zapisi : Page
    {
        public Zapisi()
        {
           InitializeComponent();
           UpdateZapis();
           

        }
        
        private void UpdateZapis()
        {
            var zapisi = App.Context.Zapisi.Where(c => c.Pacient == App.CurrentUser.ID_User).ToList();
            zapisi = zapisi.ToList();
            ZapisiGrid.ItemsSource = zapisi;
            

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateZapis();
        }


        private void ZapisiGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Отменить запись?", "Отмена записи", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {


                var selectedZapis = (BD.Zapisi)ZapisiGrid.SelectedItem;
                App.Context.Zapisi.Remove(selectedZapis);
                App.Context.SaveChanges();
            }
           UpdateZapis();
        }


    }
}
