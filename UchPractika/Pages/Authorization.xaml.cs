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
using UchPractika.AppData;

namespace UchPractika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passwBox.Password.Trim();
            Users authUser = null;
            using (AISUchetEntities1 d = new AISUchetEntities1())
            {
                authUser = d.Users.Where(b =>
                b.NameUsers == login && b.PasswordUsers == pass).FirstOrDefault();
            }
            if (authUser == null)
            {
                MessageBox.Show("Неверный логин и/или пароль", "ERROR");
            }
            else
            {
                Nav.MainFrame.Navigate(new EquipmentPage());
            }
        }
    }
}
