using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditUslugu.xaml
    /// </summary>
    public partial class AddEditUslugu : Page
    {
        private BD.Uslugi _currentUsluga = null;
        private byte[] _mainImageData;
        public AddEditUslugu()
        {
            InitializeComponent();
            ComboTip.ItemsSource = App.Context.Tip_uslugi.Select(c => c.Nazvanie_Tipa_Uslugi).ToList();
            ComboTip.SelectedIndex = 0;
        }
        public AddEditUslugu(BD.Uslugi uslugi)
        {

            InitializeComponent();
            ComboTip.ItemsSource = App.Context.Tip_uslugi.Select(c => c.Nazvanie_Tipa_Uslugi).ToList();
            _currentUsluga = uslugi;
            TBoxNazvanie.Text = _currentUsluga.Nazvanie_Uslugi;
            TBoxStoimost.Text = _currentUsluga.Stoimost_Uslugi.ToString();
            TBoxOpisanie.Text = _currentUsluga.Opisanie;
            ComboTip.SelectedIndex = 0;
            if (_currentUsluga.ImageUsl != null)
                ImageUsluga.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_currentUsluga.ImageUsl);
        }

        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageUsluga.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {

                var tip = App.Context.Tip_uslugi.Where(c => c.Nazvanie_Tipa_Uslugi == ComboTip.Text).Select(c => c.ID_Tipa_Uslugi).FirstOrDefault();
                if (_currentUsluga == null)
                {
                    var usluga = new BD.Uslugi
                    {
                        Nazvanie_Uslugi = TBoxNazvanie.Text,
                        Stoimost_Uslugi = decimal.Parse(TBoxStoimost.Text),
                        Opisanie = TBoxOpisanie.Text,
                        ID_Tipa_Uslugi = tip,
                        ImageUsl = _mainImageData
                    };
                    App.Context.Uslugi.Add(usluga);
                    App.Context.SaveChanges();
                }
                else
                {
                    _currentUsluga.Nazvanie_Uslugi = TBoxNazvanie.Text;
                    _currentUsluga.Stoimost_Uslugi = decimal.Parse(TBoxStoimost.Text);
                    _currentUsluga.Opisanie = TBoxOpisanie.Text;
                    _currentUsluga.ID_Tipa_Uslugi = tip;
                    if (_mainImageData != null)
                        _currentUsluga.ImageUsl = _mainImageData;
                    App.Context.SaveChanges();
                }

                NavigationService.GoBack();
            }
        }

        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxNazvanie.Text))
                errorBuilder.AppendLine("Название услуги обязательно для заполнения;");


            var uslugaFromDB = App.Context.Uslugi.ToList()
                .FirstOrDefault(p => p.Nazvanie_Uslugi.ToLower() == TBoxNazvanie.Text.ToLower());
            if (uslugaFromDB != null && uslugaFromDB != _currentUsluga)
                errorBuilder.AppendLine("Такая услуга уже есть в базе данных;");
            
            decimal cost = 0;
            if (decimal.TryParse(TBoxStoimost.Text, out cost) == false
                || cost <= 0)
                errorBuilder.AppendLine("Стоимость услуги должна быть положительным числом;");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();

        }
    }

}

