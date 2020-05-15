using Cars_app.Model;
using Cars_app.View;
using Cars_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cars_app.VievModel
{
    public class MainViewModel : ViewModelBase
    {

        private CarModel _selectedCar { get; set; }
        public static int IdGenerator = 0;
        public ObservableCollection<CarModel> Lista = new ObservableCollection<CarModel>
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
        public static INavigation NavigationStog;
        public MainViewModel(INavigation Navigation)
        {
            NavigationStog = Navigation;
            CarList = Lista;
            AddCar = new Command(Add);
            MessageReceived();
        }

        public ObservableCollection<CarModel> CarList
        {
            get { return Lista; }
            set
            {
                SetProperty(ref Lista, value);
            }

        }

        public CarModel SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                if (_selectedCar != value)
                {
                    CarModel var = new CarModel();
                    var = value;
                    _selectedCar = value;
                    HandleSelectedItem(SelectedCar);

                }
            }

        }
        public ICommand AddCar { get; set; }
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



        private async void HandleSelectedItem(CarModel car)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Edit", "Are you sure you want to edit this", "yes", "no");
            if (answer)
            {
                await NavigationStog.PushAsync(new UpdateCarPage(car));
            }


        }



        public async void Add()
        {

            await NavigationStog.PushAsync(new AddCarPage());

        }
        private void MessageReceived()
        {
            MessagingCenter.Subscribe<AddViewModel, CarModel>(this, "hi2", (sender, arg) =>
                 {

                     Lista.Add(arg);

                 });
            MessagingCenter.Subscribe<UpdateViewModel, CarModel>(this, "hi", (sender, arg) =>
            {
                CarModel _car = new CarModel();
                int i = 0;
                _car = arg;
                foreach (CarModel x in Lista)
                {
                    if (x.ID == arg.ID)
                        break;
                    i++;
                }
                Lista[i] = _car;



            });


        }
    }

}

