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
    /// Логика взаимодействия для AddSpecialista.xaml
    /// </summary>
    public partial class AddSpecialista : Page
    {
        private BD.User _currentVrach = null;
        private byte[] _mainImageData;
        public AddSpecialista()
        {
            InitializeComponent();
            ComboSpecialnost.ItemsSource = App.Context.Specialnosti.Select(c => c.Specialnost).ToList();
        }
        public AddSpecialista(BD.User vrachi)
        {

            InitializeComponent();
            ComboSpecialnost.ItemsSource = App.Context.Specialnosti.Select(c => c.Specialnost).ToList();
            _currentVrach = vrachi;
            TBoxName.Text = _currentVrach.Name;
            TBoxFamilia.Text = _currentVrach.Familia;
            if (_currentVrach.Otchestvo != null)
                TBoxOtchestvo.Text = _currentVrach.Otchestvo;
            ComboSpecialnost.SelectedValue = _currentVrach.id_specialnosti;
            if (_currentVrach.image != null)
                ImageVracha.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_currentVrach.image);
            ComboSpecialnost.SelectedIndex = 0;
        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageVracha.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
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
                var specialnost = App.Context.Specialnosti.Where(c => c.Specialnost == ComboSpecialnost.Text).Select(c => c.ID_Specialnosti).FirstOrDefault();

                _currentVrach.Name = TBoxName.Text;
                _currentVrach.Familia = TBoxFamilia.Text;
                _currentVrach.Otchestvo = TBoxOtchestvo.Text;
                _currentVrach.id_specialnosti = specialnost;
                if (_mainImageData != null)
                    _currentVrach.image = _mainImageData;
                App.Context.SaveChanges();
            }
            NavigationService.GoBack();
        }
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxName.Text))
                errorBuilder.AppendLine("Вы не указали имя!");
            if (string.IsNullOrWhiteSpace(TBoxFamilia.Text))
                errorBuilder.AppendLine("Вы не указали фамилию!");
            if (ComboSpecialnost.Text==string.Empty)
                errorBuilder.AppendLine("Вы не указали специальность!");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();

        }
    }
}
