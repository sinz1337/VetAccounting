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
    /// Логика взаимодействия для EditStaffPage.xaml
    /// </summary>
    public partial class EditStaffPage : Page
    {
        public string selectedFileName = "";
        byte[] Photo;
        bool IsPhoto;
        Staff staff = new Staff();
        Role role = new Role();
        public EditStaffPage(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;
            this.staff.IdStaff = staff.IdStaff;
            NameTB.Text = staff.NameStaff;
            SurnameTB.Text = staff.SurnameStaff;
            MiddleNameTB.Text = staff.MiddleNameStaff;
            NumberTB.Text = staff.NumberStaff;
            RoleCB.ItemsSource = DBEntities.GetContext().Role.ToList();
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(staff.PhotoStaff);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staff = DBEntities.GetContext().Staff.FirstOrDefault(c => c.IdStaff == staff.IdStaff);
                role = DBEntities.GetContext().Role.FirstOrDefault(c => c.IdRole == role.IdRole);
                staff.NameStaff = NameTB.Text;
                staff.SurnameStaff = SurnameTB.Text;
                staff.MiddleNameStaff = MiddleNameTB.Text;
                staff.NumberStaff = NumberTB.Text;
                staff.IdRole = Int32.Parse(RoleCB.SelectedValue.ToString());
                staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Информация успешно отредактирована");
                NavigationService.Navigate(new StaffPage());
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
                    staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(staff.PhotoStaff);
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
