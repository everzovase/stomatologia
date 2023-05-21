using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace stomatology
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BD.kursovayaEntities1 Context
        { get; } = new BD.kursovayaEntities1();

        public static BD.User CurrentUser = null;

    }
}
