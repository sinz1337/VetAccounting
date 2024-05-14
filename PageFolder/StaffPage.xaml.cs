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
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        DBEntities dBEntities = new DBEntities();
        public StaffPage()
        {
            InitializeComponent();
            ListLB.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(a => a.SurnameStaff);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStaffPage());
        }

        private void EdidMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите объект для редактирование");
            }
            else
            {
                Staff staff = ListLB.SelectedItem as Staff;
                NavigationService.Navigate
                    (new EditStaffPage(ListLB.SelectedItem as Staff));
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var staff = ListLB.SelectedItem as Staff;
            bool delete = MBClass.QuestionMB($"Вы действительно хотите удалить {staff.SurnameStaff}?");
            if (delete)
            {
                try
                {
                    DBEntities.GetContext()
                        .Staff.Remove(staff);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Удалено!");
                    NavigationService.Navigate(new StaffPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex.Message);
                    return;
                }
            }
        }

        private void RefreshData()
        {
            List<Staff> listStaff = dBEntities.Staff.ToList();

            var searchString = SearchTB.Text;
            if (!string.IsNullOrEmpty(searchString))
            {
                listStaff = listStaff.Where(x => x.SurnameStaff.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ListLB.ItemsSource = listStaff;
        }

        private void PhotoMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите объект");
            }
            else
            {
                Staff staff = ListLB.SelectedItem as Staff;
                NavigationService.Navigate
                    (new PhotoStaffPage(ListLB.SelectedItem as Staff));
            }
        }
    }
}
