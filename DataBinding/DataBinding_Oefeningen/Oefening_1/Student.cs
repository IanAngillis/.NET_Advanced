using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_1
{
    public class Student : INotifyPropertyChanged
    {
        //Private variables
        private string _name;
        private string _street;
        private string _city;
        private string _state;
        private string _zip;
        private string _phone;
        private string _cell;

        //Constructor
        public Student(string name, string street, string city, string state, string zip, string phone, string cell)
        {
            Name = name;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            Cell = cell;
        }


        //Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public string Cell
        {
            get { return _cell; }
            set
            {
                _cell = value;
                NotifyPropertyChanged();
            }
        }


        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                NotifyPropertyChanged();
            }
        }


        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                NotifyPropertyChanged();
            }
        }


        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyPropertyChanged();
            }
        }


        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyPropertyChanged();
            }
        }


        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                NotifyPropertyChanged();
            }
        }

        //Implementation interface INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
