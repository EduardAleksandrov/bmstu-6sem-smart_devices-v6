using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MVVMv1.Models;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;

namespace MVVMv1.ViewModels
{
    public class CarViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        CarsListViewModel lvm;

        public Car Car { get; private set; }

        public CarViewModel()
        {
            Car = new Car();
        }

        public CarsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Car.Name; }
            set
            {
                if (Car.Name != value)
                {
                    Car.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string CTC
        {
            get { return Car.CTC; }
            set
            {
                if (Car.CTC != value)
                {
                    Car.CTC = value;
                    OnPropertyChanged("CTC");
                }
            }
        }
        public string Owner
        {
            get { return Car.Owner; }
            set
            {
                if (Car.Owner != value)
                {
                    Car.Owner = value;
                    OnPropertyChanged("Owner");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name)) ||
                    (!string.IsNullOrEmpty(CTC)) ||
                    (!string.IsNullOrEmpty(Owner)));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }





    }
}
