using Cars_app.Model;
using Cars_app.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.VievModel
{
    public class UpdateViewModel : ViewModelBase
    {


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string registration;
        public string Registration
        {
            get { return registration; }
            set
            {
                registration = value;
                OnPropertyChanged("Registration");
            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public ICommand SaveCommand { get; private set; }

        private int _Id;

        public UpdateViewModel(int Id)
        {
            CarModel car = new CarModel();
            foreach (CarModel x in MainViewModel.Lista)
            {  if (x.ID == Id)
                {
                    car = x;
                    break;
                }   

            }

             _Id = car.ID;

            Name = car.Name;
            Registration = car.Registration;
            Year = car.Year;
           

            SaveCommand = new Command(Save);
        }

        public void Save()
        {
            foreach (CarModel x in MainViewModel.Lista)
            {
                if (x.ID == _Id)
                {
                    x.Name = Name;
                    x.Registration = Registration;
                    x.Year = Year;
                    break;
                }

            }
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

    }
}
