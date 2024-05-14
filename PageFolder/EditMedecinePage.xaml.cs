using Microsoft.Win32;
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
        public string selectedFileName = "";
        byte[] Photo;
        bool IsPhoto;
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
            InfoTB.Text = medicines.InfoMedicines;
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(medicines.PhotoMedicines);
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
                medicines.InfoMedicines = InfoTB.Text;
                medicines.PhotoMedicines = ImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Информация успешно отредактирована");
                NavigationService.Navigate(new MedicinePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BorderForImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddPhoto();
        }

        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All support graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*jpeg)|*.jpg;*jpeg|" +
                    "Portable Network Graphic (*.png|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    medicines.PhotoMedicines = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(medicines.PhotoMedicines);
                    PhotoLB.Content = "";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
