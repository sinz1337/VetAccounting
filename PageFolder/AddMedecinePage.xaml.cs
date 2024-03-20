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
    /// Логика взаимодействия для AddMedecinePage.xaml
    /// </summary>
    public partial class AddMedecinePage : Page
    {
        public AddMedecinePage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medecineAdd = new Medicines()
                {
                    NameMedicines = NameTB.Text,
                    ManufacturerMedicines = ManufactureTB.Text,
                    QuantityMedicines = QantityTB.Text,
                    RemainsMedicines = QantityTB.Text
                };
                DBEntities.GetContext().Medicines.Add(medecineAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Добавленно");
                NavigationService.Navigate(new MedicinePage());
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    }
}
