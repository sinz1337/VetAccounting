using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddPurchasePage.xaml
    /// </summary>
    public partial class AddPurchasePage : Page
    {
        public AddPurchasePage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var purchaseAdd = new Purchase()
                {
                    TypePurchase = TypeTB.Text,
                    ProvidePurchaser = ProviderTB.Text,
                    CostPurchase = CostTB.Text,
                    StatysPurchase = "В сборке"
                };
                DBEntities.GetContext().Purchase.Add(purchaseAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Добавленно");
                NavigationService.Navigate(new PurchasePage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
