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
using VetAccounting.ClassFolder;
using VetAccounting.DataFolder;

namespace VetAccounting.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для PhotoStaffPage.xaml
    /// </summary>
    public partial class PhotoStaffPage : Page
    {
        public PhotoStaffPage(Staff staff)
        {
            InitializeComponent();
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(staff.PhotoStaff);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }
    }
}
