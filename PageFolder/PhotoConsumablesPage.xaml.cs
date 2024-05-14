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
using VetAccounting.DataFolder;
using VetAccounting.ClassFolder;

namespace VetAccounting.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для PhotoConsumablesPage.xaml
    /// </summary>
    public partial class PhotoConsumablesPage : Page
    {
        public PhotoConsumablesPage(Consumables consumables)
        {
            InitializeComponent();
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(consumables.PhotoConsumables);
            NameTB.Text = $"Название:   {consumables.NameConsumables}";
            InfoTB.Text = $"Информация:   {consumables.InfoConsumables}";
            SizeTB.Text = $"Размер:   {consumables.SizeConsumables}";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsumablesPage());
        }
    }
}
