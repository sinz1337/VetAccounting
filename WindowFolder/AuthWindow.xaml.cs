using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VetAccounting.ClassFolder;
using VetAccounting.DataFolder;

namespace VetAccounting.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CapchaPB.Image = CreateCapcha(
                CapchaPB.Width,
                CapchaPB.Height);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(LoginTB.Text) &&
                    !string.IsNullOrWhiteSpace(PasswordPB.Password))
                {
                    LoginBtn_Click(sender, e);
                }
                else
                {
                    if (LoginTB.IsFocused)
                        PasswordPB.Focus();
                    else
                        LoginTB.Focus();
                }
            }
        }

        int k = 0;
        private  void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            //if (CapchaTB.Text == text)
            //{
            //    var user = DBEntities.GetContext()
            //            .User
            //            .FirstOrDefault(u => u.LoginUser == LoginTB.Text);

            //    if (PasswordPB.Password != user.PasswordUser && PasswordPB.IsEnabled)
            //    {
            //        k++;
            //        if (k == 3)
            //        {
            //            PasswordPB.IsEnabled = false;
            //            await Task.Delay(10000);
            //            PasswordPB.IsEnabled = true;
            //            k = 0;
            //        }
            //        else
            //        {
            //            MBClass.ErrorMB("Неправильный логин или пароль");
            //        }
            //    }
            //    else
            //    {
            //        switch (user.IdRole)
            //        {
            //            case 1:
            //                new MainWindow().Show();
            //                this.Close();
            //                break;
            //            case 2:
            //                new AdminWindow().Show();
            //                this.Close();
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    MBClass.ErrorMB("Введена неправильная капча!");
            //    CapchaTB.Text = "";
            //    CapchaPB.Focus();
            //    CapchaPB.Image = CreateCapcha(
            //        CapchaPB.Width,
            //        CapchaPB.Height);
            //}
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private string text = String.Empty;

        private Bitmap CreateCapcha(int Width, int Heigh)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Heigh);

            int Xpos = rnd.Next(25, Width - 75);
            int Ypos = rnd.Next(15, Heigh - 25);

            System.Drawing.Brush colors =
                System.Drawing.Brushes.Black;

            Graphics graphics = Graphics
                .FromImage((System.Drawing.Image)result);

            graphics.Clear(System.Drawing.Color.Gray);

            text = String.Empty;

            string ALF = "1234567890";

            for (int i = 0; i < 5; i++)
            {
                text += ALF[rnd.Next(ALF.Length)];
            }

            graphics.DrawString(text, new Font("SF Pro Display", 18),
                colors, new PointF(Xpos, Ypos));

            graphics.DrawLine(Pens.Black,
                new System.Drawing.Point(0, 0),
                new System.Drawing.Point(Width - 1, Heigh - 1));

            graphics.DrawLine(Pens.Black,
                new System.Drawing.Point(0, Heigh - 1),
                new System.Drawing.Point(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Heigh; ++j)
                {
                    if (rnd.Next() % 20 == 0)
                    {
                        result.SetPixel(i, j,
                            System.Drawing.Color.White);
                    }
                }
            }

            return result;
        }

        private void CapchaPB_Click(object sender, EventArgs e)
        {
            CapchaPB.Image = CreateCapcha(
                CapchaPB.Width,
                CapchaPB.Height);
        }
    }
}
