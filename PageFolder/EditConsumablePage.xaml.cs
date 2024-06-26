﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для EditConsumablePage.xaml
    /// </summary>
    public partial class EditConsumablePage : Page
    {
        public string selectedFileName = "";
        byte[] Photo;
        bool IsPhoto;
        Consumables consumables = new Consumables();
        public EditConsumablePage(Consumables consumables)
        {
            InitializeComponent();
            DataContext = consumables;
            this.consumables.IdConsumables = consumables.IdConsumables;
            NameTB.Text = consumables.NameConsumables;
            ManufactureTB.Text = consumables.ManufacturerConsumables;
            QantityTB.Text = consumables.QuantityConsumables;
            RemainsTB.Text = consumables.RemainsConsumables;
            InfoTB.Text = consumables.InfoConsumables;
            SizeTB.Text = consumables.SizeConsumables;
            PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(consumables.PhotoConsumables);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                consumables = DBEntities.GetContext().Consumables.FirstOrDefault(c => c.IdConsumables == consumables.IdConsumables);
                consumables.NameConsumables = NameTB.Text;
                consumables.ManufacturerConsumables = ManufactureTB.Text;
                consumables.RemainsConsumables = RemainsTB.Text;
                consumables.QuantityConsumables = QantityTB.Text;
                consumables.InfoConsumables = InfoTB.Text;
                consumables.SizeConsumables = SizeTB.Text;
                consumables.PhotoConsumables = ImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Информация успешно отредактирована");
                NavigationService.Navigate(new ConsumablesPage());
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
                    consumables.PhotoConsumables = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoImg.ImageSource = ImageClass.ConvertByteArrayToImage(consumables.PhotoConsumables);
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
