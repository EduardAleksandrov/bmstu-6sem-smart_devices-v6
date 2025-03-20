using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMv1.ViewModels;

namespace MVVMv1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarPage : ContentPage
    {
        public CarViewModel ViewModel { get; private set; }
        public CarPage(CarViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}