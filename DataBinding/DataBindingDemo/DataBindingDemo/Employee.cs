using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataBindingDemo.Annotations;

namespace DataBindingDemo
{
    public class Employee : INotifyPropertyChanged
    {
        private string _title;

        public string Name { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                //OnPropertyChanged(nameof(Title));
                OnPropertyChanged();
            } 
        }

        //Factory method geeft instantie van de klasse terug
        public static Employee CreateSomeEmployee()
        {
            var employee = new Employee
            {
                Name = "John",
                Title = "Developer"
            };

            return employee;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
