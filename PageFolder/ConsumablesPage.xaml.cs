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
using VetAccounting.PageFolder;

namespace VetAccounting.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesPage.xaml
    /// </summary>
    public partial class ConsumablesPage : Page
    {
        DBEntities dBEntities = new DBEntities();
        public ConsumablesPage()
        {
            InitializeComponent();
            ListLB.ItemsSource = DBEntities.GetContext()
                .Consumables.ToList().OrderBy(a => a.NameConsumables);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddConsumablePage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите объект для редактирование");
            }
            else
            {
                Consumables consumables = ListLB.SelectedItem as Consumables;
                NavigationService.Navigate
                    (new EditConsumablePage(ListLB.SelectedItem as Consumables));
            }
        }

        private void RefreshData()
        {
            List<Consumables> listConsumables = dBEntities.Consumables.ToList();

            var searchString = SearchTB.Text;
            if (!string.IsNullOrEmpty(searchString))
            {
                listConsumables = listConsumables.Where(x => x.NameConsumables.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ListLB.ItemsSource = listConsumables;
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var consumables = ListLB.SelectedItem as Consumables;
            bool delete = MBClass.QuestionMB($"Вы действительно хотите удалить {consumables.NameConsumables}?");
            if (delete)
            {
                try
                {
                    DBEntities.GetContext()
                        .Consumables.Remove(consumables);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Удалено!");
                    NavigationService.Navigate(new ConsumablesPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex.Message);
                    return;
                }
            }
        }

        private void PhotoMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите объект");
            }
            else
            {
                Consumables consumables = ListLB.SelectedItem as Consumables;
                NavigationService.Navigate
                    (new PhotoConsumablesPage(ListLB.SelectedItem as Consumables));
            }
        }
    }
}
