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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Person person;
        qqEntities qqEntities = new qqEntities();
        public Window2(Person selected)
        {
            InitializeComponent();

            this.person = selected;

            // Заполняем поля окна данными выбранного элемента
            newname.Text = person.Name;
            newinvnum.Text = person.invnum.ToString();
            newinvtype.Text = person.invtype;
            newprice.Text = person.price.ToString();
            newadress.Text = person.adress;
        }

       
        private void RedPerson_Click(object sender, RoutedEventArgs e)
        {

            // Сохраняем измененные данные обратно в объект Person
            person.Name = newname.Text;

            int num;
            if (int.TryParse(newinvnum.Text, out num))
            {
                person.invnum = num;
            }
            person.invtype = newinvtype.Text;
            int price1;
            if (int.TryParse(newprice.Text, out price1))
            {
                person.price = price1;
            }
            person.adress = newadress.Text;
            qqEntities.SaveChanges();
            // Закрываем окно после сохранения изменений
            this.Close();
        }
    }
}
