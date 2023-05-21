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
    /// Логика взаимодействия для ZapisiVracha.xaml
    /// </summary>
    public partial class ZapisiVracha : Page
    {
        public ZapisiVracha()
        {
            InitializeComponent();
            UpdateZapis();
        }


        private void UpdateZapis()
        {
            var zapisi = App.Context.Zapisi.Where(c => c.Vrach == App.CurrentUser.ID_User).ToList();
            zapisi = zapisi.ToList();
            ZapisiGrid.ItemsSource = zapisi;

        }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(ZapisiGrid, "Записи врача");
            }
        }
    }
}
