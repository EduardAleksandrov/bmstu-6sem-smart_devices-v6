using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MVVMv1.Views;
using Xamarin.Forms;

namespace MVVMv1.ViewModels
{
    public class CarsListViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<CarViewModel> Cars { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateCarCommand { protected set; get; }
        public ICommand DeleteCarCommand { protected set; get; }
        public ICommand SaveCarCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        CarViewModel selectedCar;

        public INavigation Navigation { get; set; }

        public CarsListViewModel()
        {
            Cars = new ObservableCollection<CarViewModel>();
            CreateCarCommand = new Command(CreateCar);
            DeleteCarCommand = new Command(DeleteCar);
            SaveCarCommand = new Command(SaveCar);
            BackCommand = new Command(Back);
        }

        private void CreateCar()
        {
            Navigation.PushAsync(new CarPage(new CarViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveCar(object carObject)
        {
            CarViewModel car = carObject as CarViewModel;
            if (car != null && car.IsValid)
            {
                Cars.Add(car);
            }
            Back();
        }
        private void DeleteCar(object carObject)
        {
            CarViewModel car = carObject as CarViewModel;
            if (car != null)
            {
                Cars.Remove(car);
            }
            Back();
        }

        public CarViewModel SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (selectedCar != value)
                {
                    CarViewModel tempCar = value;
                    selectedCar = null;
                    OnPropertyChanged("SelectedCar");
                    Navigation.PushAsync(new CarPage(tempCar));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }




    }
}
