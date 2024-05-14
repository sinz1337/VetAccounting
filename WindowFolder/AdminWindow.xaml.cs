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
using VetAccounting.ClassFolder;
using VetAccounting.PageFolder;

namespace VetAccounting.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StaffPage());
        }

        private void Staff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new StaffPage());
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LogOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AuthWindow().Show();
            this.Close();
        }
    }
}
