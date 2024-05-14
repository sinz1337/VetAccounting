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
            StaffCB.ItemsSource = DBEntities.GetContext().Staff.ToList();
            TypeCB.ItemsSource = DBEntities.GetContext().Type.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var purchaseAdd = new Purchase()
                {
                    ProvidePurchaser = ProviderTB.Text,
                    CostPurchase = CostTB.Text,
                    StatysPurchase = "В сборке",
                    NumberProvidePurchase = NumberTB.Text,
                    IdStaff = Int32.Parse(StaffCB.SelectedValue.ToString()),
                    IdType = Int32.Parse(TypeCB.SelectedValue.ToString()),
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
