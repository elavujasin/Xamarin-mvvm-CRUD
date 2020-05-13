using Cars_app.Model;
using Cars_app.VievModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.ViewModel
{
   public class AddViewModel : ViewModelBase
    {
        public ICommand SaveCar { get; set; }
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
       public AddViewModel()
        {
            SaveCar = new Command(Save);
        }


        public void Save()
        {
            MainViewModel.Lista.Add(new CarModel() { Name = Name, Registration = Registration, Year = Year, ID = MainViewModel.IdGenerator++ });


            Application.Current.MainPage = new NavigationPage(new MainPage());

        }
    }
}
