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

namespace VetAccounting.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        DBEntities dBEntities = new DBEntities();
        public PurchasePage()
        {
            InitializeComponent();
            ListLB.ItemsSource = DBEntities.GetContext()
                .Purchase.ToList().OrderBy(a => a.TypePurchase);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPurchasePage());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            List<Purchase> listPurchase = dBEntities.Purchase.ToList();

            var searchString = SearchTB.Text;
            if (!string.IsNullOrEmpty(searchString))
            {
                listPurchase = listPurchase.Where(x => x.ProvidePurchaser.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ListLB.ItemsSource = listPurchase;
        }
    }
}
