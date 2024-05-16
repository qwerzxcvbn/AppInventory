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
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        qqEntities qqEntities = new qqEntities();
        public Window1()
        {
            InitializeComponent();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            int invnumValue;
            if (!int.TryParse(newinvnum.Text, out invnumValue))
            {
                MessageBox.Show("Введите коректное значение инвентарного номера");
                return;
            }
            int invpriceValue;
            if (!int.TryParse(newprice.Text, out invpriceValue))
            {
                MessageBox.Show("Введите коректное значение стоимости оборудования");
                return;
            }

            Person person = new Person()
            {
                Name = newname.Text,
                invnum = invnumValue,
                invtype = newinvtype.Text,
                price = invpriceValue,
                adress = newadress.Text
            };
            qqEntities.Person.Add(person);
            qqEntities.SaveChanges();
            MessageBox.Show("Сотрудник добавлен");
        }
    }
    
    
}
