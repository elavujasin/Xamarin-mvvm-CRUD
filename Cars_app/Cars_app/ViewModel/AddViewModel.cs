using Cars_app.Model;
using Cars_app.VievModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.ViewModel
{
    class AddViewModel : ViewModelBase
    {


        private string name;
        private string registration;
        private int year;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        public string Registration
        {
            get { return registration; }
            set
            {
                registration = value;
                OnPropertyChanged("Registration");
            }
        }


        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public AddViewModel()
        {

            SaveCar = new Command(Save);

        }
        public ICommand SaveCar { get; set; }

        public async void Save()
        {
            CarModel _newcar = new CarModel()
            { Name = Name, Registration = Registration, Year = Year, ID = MainViewModel.IdGenerator++ };
            await MainViewModel.NavigationStog.PopAsync();
            MessagingCenter.Send<AddViewModel, CarModel>(this, "hi2", _newcar);
        }
    }
}
