﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.Win32;
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
        public string selectedFileName = "";
        byte[] Photo;
        bool IsPhoto;
        public AddConsumablePage()
        {
            InitializeComponent();
            StaffCB.ItemsSource = DBEntities.GetContext().Staff.ToList();
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
                    RemainsConsumables = QantityTB.Text,
                    DateOfReceiptConsumables = DateTime.Now,
                    ExpirationDateConsumables = ExpirationDateTB.Text,
                    PhotoConsumables = Photo,
                    InfoConsumables = InfoTB.Text,
                    SizeConsumables = SizeTB.Text,
                    IdStaff = Int32.Parse(StaffCB.SelectedValue.ToString()),
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
