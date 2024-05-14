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
    /// Логика взаимодействия для PhotoMedicinePage.xaml
    /// </summary>
    public partial class PhotoMedicinePage : Page
    {
        public PhotoMedicinePage(Medicines medicines)
        {
            InitializeComponent();
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(medicines.PhotoMedicines);
            NameTB.Text = $"Название:   {medicines.NameMedicines}";
            InfoTB.Text = $"Информация:   {medicines.InfoMedicines}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedicinePage());
        }
    }
}
