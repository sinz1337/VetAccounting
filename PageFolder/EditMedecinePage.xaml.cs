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
    /// Логика взаимодействия для EditMedecinePage.xaml
    /// </summary>
    public partial class EditMedecinePage : Page
    {
        Medicines medicines = new Medicines();
        public EditMedecinePage(Medicines medicines)
        {
            InitializeComponent();
            DataContext = medicines;
            this.medicines.IdMedicines = medicines.IdMedicines;
            NameTB.Text = medicines.NameMedicines;
            ManufactureTB.Text = medicines.ManufacturerMedicines;
            QantityTB.Text = medicines.QuantityMedicines;
            RemainsTB.Text = medicines.RemainsMedicines;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                medicines = DBEntities.GetContext().Medicines.FirstOrDefault(c => c.IdMedicines == medicines.IdMedicines);
                medicines.NameMedicines = NameTB.Text;
                medicines.ManufacturerMedicines = ManufactureTB.Text;
                medicines.RemainsMedicines = RemainsTB.Text;
                medicines.QuantityMedicines = QantityTB.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Информация успешно отредактирована");
                NavigationService.Navigate(new MedicinePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
