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
    /// Логика взаимодействия для EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEquipment(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = Oborud.SelectedItems.Cast<Equipment>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Assignment.Any(x => x.IdEquipment == delClient.IdEquipment) || Connect.context.Maintenance.Any(x => x.IdEquipment == delClient.IdEquipment) || Connect.context.Price.Any(x => x.IdEquipment == delClient.IdEquipment))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Equipment.RemoveRange(delClients);
            }
            try
            {
                Connect.context.SaveChanges();
                Oborud.ItemsSource = Connect.context.Equipment.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void textChange(object sender, TextChangedEventArgs e)
        {
            Oborud.ItemsSource = Connect.context.Equipment.Where(x => x.NameEquipment.StartsWith(Poisk.Text)).ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEquipment((sender as Button).DataContext as Equipment));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Oborud.ItemsSource = Connect.context.Equipment.ToList();
        }
    }
}
