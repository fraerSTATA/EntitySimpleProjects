using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Contact : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string phone;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }

        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
