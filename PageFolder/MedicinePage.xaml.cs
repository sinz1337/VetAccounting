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
    /// Логика взаимодействия для MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        DBEntities dBEntities = new DBEntities();
        public MedicinePage()
        {
            InitializeComponent();
            ListLB.ItemsSource = DBEntities.GetContext()
                .Medicines.ToList().OrderBy(a => a.NameMedicines);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMedecinePage());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void EdidMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите объект для редактирование");
            }
            else
            {
                Medicines medicines = ListLB.SelectedItem as Medicines;
                NavigationService.Navigate
                    (new EditMedecinePage(ListLB.SelectedItem as Medicines));
            }
        }

        private void RefreshData()
        {
            List<Medicines> listMedicines = dBEntities.Medicines.ToList();

            var searchString = SearchTB.Text;
            if (!string.IsNullOrEmpty(searchString))
            {
                listMedicines = listMedicines.Where(x => x.NameMedicines.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ListLB.ItemsSource = listMedicines;
        }
    }
}
