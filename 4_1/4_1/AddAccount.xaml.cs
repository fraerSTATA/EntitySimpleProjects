using Microsoft.EntityFrameworkCore;
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


namespace _4_1
{
    /// <summary>
    /// Логика взаимодействия для AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        private static readonly Encoding encoding = Encoding.Unicode;
        ApplicationContext DB;
        public AddAccount()
        {
            InitializeComponent();
            DB = new ApplicationContext();
            DB.Accounts.Load();
            List<PasswordToString> accich = new List<PasswordToString>();
            foreach(var acc in DB.Accounts.Local.ToList())
            {
                var ac = new PasswordToString();
                ac.login = acc.login;
                ac.passwordHash = BitConverter.ToString(acc.passwordHash).Replace("-", "").ToLower();
                ac.Id = acc.Id;
                accich.Add(ac);
            }
            MainGrid.ItemsSource = accich;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var login = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@login",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 50,
                    Value = Login.Text.ToString()
                };
                var password = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 50,
                    Value = Password.Text.ToString()
                };
                var result = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@result",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 250
                };
                db.Database.ExecuteSqlRaw("AddAccount @login, @password, @result OUTPUT", login, password, result);
                
            }
        }
    }
}

