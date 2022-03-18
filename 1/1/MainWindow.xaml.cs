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

namespace _1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (HotelEntities db = new HotelEntities())
            {
                Customers c = new Customers();
                c.Age = 100;
                c.Email = "someemaf1il#maaidl.ru";
                c.FirstName = "Peter";
                c.LastName = "Pen";
                c.PassportId = 123456;
                c.Phone = "7-21d3-211228-969-99";
                db.Customers.Add(c);
                db.SaveChanges();

            }
            

            //изменение
            using (HotelEntities db = new HotelEntities())
            {
                Customers p1 = db.Customers.Where((customer) => customer.FirstName == "Peter").FirstOrDefault();

                if (p1 != null)
                {
                    p1.Age = 30000;
                    db.SaveChanges();
                }

            }

            //удаление
            using (HotelEntities db = new HotelEntities())
            {
                Customers p1 = db.Customers.Where((customer) => customer.FirstName == "Peter").FirstOrDefault();

                if (p1 != null)
                {
                    db.Customers.Remove(p1);
                    db.SaveChanges();
                }
            }

            using (HotelEntities db = new HotelEntities())
            {
                Booking c = new Booking();
                c.ArrivalDate = new DateTime(2001, 01, 20);
                c.ArrivalTime = new TimeSpan(12, 30, 0);
                c.DepatrureDate = new DateTime(2001, 01, 20);
                c.DepartureTime = new TimeSpan(12, 30, 0);
                c.CustomerId = db.Customers.Where(customer => customer.FirstName == "Mike").FirstOrDefault().Id;
                c.RoomId = db.Rooms.FirstOrDefault().Id;
                db.Booking.Add(c);
                db.SaveChanges();

            }

            using (HotelEntities db = new HotelEntities())
            {
                var bookings = db.Booking.Join(db.Customers,
                    booking => booking.CustomerId,
                    customer => customer.Id,
                    (booking, customer) => new
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.Phone,
                        ArrivalDate = booking.ArrivalDate,
                        DepartureDate = booking.DepatrureDate,
                    }
                    );
                foreach (var b in bookings) //в впф нужно поставить
                {
                    tbOutput.Text += string.Format("({0} {1}) Phone: {2} ArrivalDate {3} DepartureDate: {4}\n",
                    b.FirstName, b.LastName, b.Phone, b.ArrivalDate, b.DepartureDate);
                }
            }

            //Получение данных из 3 таблиц
            using (HotelEntities db = new HotelEntities())
            {
                var bookings = from booking in db.Booking
                               join customer in db.Customers on booking.CustomerId equals customer.Id
                               join room in db.Rooms on booking.RoomId equals room.Id
                               select new
                               {
                                   Name = customer.FirstName,
                                   Price = room.Price,
                                   ArrivalDate = booking.ArrivalDate,
                                   DepatrureDate = booking.DepatrureDate
                               };

                foreach (var b in bookings)
                {
                    tbOutput.Text += string.Concat("Name: ", b.Name,
                        " \n Price: ", b.Price,
                        " \n ArrivalDate: ", b.ArrivalDate,
                        " \n DepatrureDate:", b.DepatrureDate,
                        " \n -------------- \n");
                }

            

        }
    }
    }
}
