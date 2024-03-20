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
    /// Логика взаимодействия для AddConsumablePage.xaml
    /// </summary>
    public partial class AddConsumablePage : Page
    {
        public AddConsumablePage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var consumableAdd = new Consumables()
                {
                    NameConsumables = NameTB.Text,
                    ManufacturerConsumables = ManufactureTB.Text,
                    QuantityConsumables = QantityTB.Text,
                    RemainsConsumables = QantityTB.Text

                };
                DBEntities.GetContext().Consumables.Add(consumableAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Добавленно");
                NavigationService.Navigate(new ConsumablesPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
