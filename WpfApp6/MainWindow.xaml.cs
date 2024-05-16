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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private qqEntities dbContext = new qqEntities();
        qqEntities qqEntities = new qqEntities();
        public MainWindow()
        {
            InitializeComponent();
            Person.ItemsSource = qqEntities.Person.ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Poisk(object sender, RoutedEventArgs e)
        {
            string poisk = vvod.Text;
            
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            
        }

        private void Button_red(object sender, RoutedEventArgs e)
        {

        }

        private void Button_del(object sender, RoutedEventArgs e)
        {
            if (Person.SelectedItem != null)
            {
                Person selectedPerson = Person.SelectedItem as Person;

                // Удаление из DataGrid
                qqEntities.Person.Remove(selectedPerson);
                Person.Items.Refresh();

                // Удаление из базы данных
                qqEntities.Person.Remove(selectedPerson);
                qqEntities.SaveChanges();
            }
        }

        private void Button_gen(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Person entity = new Person
                {
                    Name = GetRandomName(),
                    invnum = GetRandomInvNum(),
                    invtype = GetRandomInvType(),
                    price = GetRandomPrice(),
                    adress = GetRandomAddress(),            
                };

                dbContext.Person.Add(entity);
            }

            dbContext.SaveChanges();
        }
        private string GetRandomName()
        {
            string[] fullNames = { "Романов Роман Романович", "Морозов Александр Николаевич", "Иванов Иван Иванович", "Попов Дмитрий Владимирович", "Скворцов Сергей Александрович",  "Скворцов Сергей Александрович" };
            Random random = new Random();
            int index = random.Next(fullNames.Length);
            return fullNames[index];
        }

        private int GetRandomInvNum()
        {
            Random random = new Random();
            return random.Next(4556, 6467);
        }

        private string GetRandomInvType()
        {
            string[] invtype = { "Сервер", "Принтер", "Компьютер", "Клавиатура", "Мышь", "Наушники", };
            Random random = new Random();
            int index = random.Next(invtype.Length);
            return invtype[index];
        }

        private float GetRandomPrice()
        {
            Random random = new Random();
            return random.Next(4657, 8957);
        }

        private string GetRandomAddress()
        {
            string[] adress = { "ул Карбышева 175 оф 5", "ул Пушкина 31 оф 5", "ул Ленина 37 каб 4", "ул Пушкина 23 оф 3",  "ул Набережная 1 каб 3", "ул Ленина 122 оф 7" };
            Random random = new Random();
            int index = random.Next(adress.Length);
            return adress[index];
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo.SelectedIndex == 0)
            {
                var source = qqEntities.Person.OrderBy(x => x.Name).ToList();
                Person.ItemsSource = source;
            }
            if (Combo.SelectedIndex == 1)
            {
                var source = qqEntities.Person.OrderBy(x => x.invnum).ToList();
                Person.ItemsSource = source;
            }
            if (Combo.SelectedIndex == 2)
            {
                var source = qqEntities.Person.OrderBy(x => x.invtype).ToList();
                Person.ItemsSource = source;
            }
            if (Combo.SelectedIndex == 3)
            {
                var source = qqEntities.Person.OrderBy(x => x.price).ToList();
                Person.ItemsSource = source;
            }
            if (Combo.SelectedIndex == 4)
            {
                var source = qqEntities.Person.OrderBy(x => x.adress).ToList();
                Person.ItemsSource = source;
            }     
        }
    }
}
