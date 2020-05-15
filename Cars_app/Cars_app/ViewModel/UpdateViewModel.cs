using Cars_app.Model;
using Cars_app.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.VievModel
{
    public class UpdateViewModel : ViewModelBase
    {


        private string name;
        private string registration;
        private int year;
        private int _id;
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

        public UpdateViewModel(CarModel Car)
        {
            CarModel _car = new CarModel();
            _car = Car;
            _id = _car.ID;
            Name = _car.Name;
            Registration = _car.Registration;
            Year = _car.Year;
            SaveCommand = new Command(Save);
        }

        public ICommand SaveCommand { get; private set; }

        public async void Save()
        {

            CarModel _newcar = new CarModel()
            {
                Name = Name,
                Registration = Registration,
                Year = Year,
                ID = _id
            };

            await MainViewModel.NavigationStog.PopAsync();
            MessagingCenter.Send<UpdateViewModel, CarModel>(this, "hi", _newcar);


        }

    }
}
