using Microsoft.Win32;
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
    /// Логика взаимодействия для AddStaffPage.xaml
    /// </summary>
    public partial class AddStaffPage : Page
    {
        public string selectedFileName = "";
        byte[] Photo;
        bool IsPhoto;
        public AddStaffPage()
        {
            InitializeComponent();
            RoleCB.ItemsSource = DBEntities.GetContext().Role.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var staffAdd = new Staff()
                {
                    NameStaff = NameTB.Text,
                    SurnameStaff = SurnameTB.Text,
                    MiddleNameStaff = MiddleNameTB.Text,
                    NumberStaff = NumberTB.Text,
                    PhotoStaff = Photo,
                    IdRole = Int32.Parse(RoleCB.SelectedValue.ToString()),
                };
                DBEntities.GetContext().Staff.Add(staffAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Добавленно");
                NavigationService.Navigate(new StaffPage());
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                selectedFileName = op.FileName;
                Photo = ImageClass.ConvertImageToByteArray(selectedFileName);
                PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(Photo);
                IsPhoto = true;
            }
            else
            {
                IsPhoto = false;
                return;
            }
        }
    }
}
