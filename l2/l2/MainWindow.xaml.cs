using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace l2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new PeopleContext();
            db.Persons.Load();
            dgPeople.ItemsSource = db.Persons.Local.ToBindingList();
            this.Closing += MainWindow_Closing;

        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }

        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgPeople.SelectedItems.Count > 0)
            {
                for(int i=0; i < dgPeople.SelectedItems.Count; i++)
                {
                    Person phone = dgPeople.SelectedItems[i] as Person;
                    if(phone != null)
                    {
                        db.Persons.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
