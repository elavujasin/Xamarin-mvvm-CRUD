using Cars_app.Model;
using Cars_app.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.VievModel
{
    class MainViewModel : ViewModelBase
    {
        public ICommand AddCar { get; set; }
        public static int IdGenerator = 0;
        public static ObservableCollection<CarModel> Lista = new ObservableCollection<CarModel>
           {
              new CarModel
              {
                  Name ="car",
                  Registration="dghdh",
                  Year=1998,
                  ID=IdGenerator

              },
              new CarModel
              {
                  Name ="car2",
                  Registration="akdka",
                  Year=1900,
                  ID=IdGenerator++

              },

       };

        public ObservableCollection<CarModel> CarList
        {
            get { return Lista; }
            set
            {
                SetProperty(ref Lista, value);
            }

        }
    

        public MainViewModel()
        {
            CarList = Lista;
            AddCar = new Command(Add);
        }

        public ICommand DeleteCar
        {
            get
            {
                return new Command(async (e) =>
                {
                    var item = (e as CarModel);
                    bool answer = await Application.Current.MainPage.DisplayAlert("Delete alarm", "Are you sure you want to delete this alarm", "Yes", "No");

                    if (answer)
                    {
                        Lista.Remove(item);
                        

                    }
                });
            }
        }
    
        private CarModel selectedCar { get; set; }
        public CarModel SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if(selectedCar!=value)
                    {
                    CarModel var = new CarModel();
                    var = value;
                    selectedCar = value;
                    HandleSelectedItem(var);
                    
                   
                    
                   
                }
            }

        }

        private async void HandleSelectedItem(CarModel car)
        { 
            bool answer = await Application.Current.MainPage.DisplayAlert("Edit","Are you sure you want to edit this","yes","no");
            if (answer)
            {
                Application.Current.MainPage = new NavigationPage(new UpdateCarPage(car.ID));
              
            }
            

        }

        public void Add()
        {
            Application.Current.MainPage = new NavigationPage(new AddCarPage());

        }

    }
}
