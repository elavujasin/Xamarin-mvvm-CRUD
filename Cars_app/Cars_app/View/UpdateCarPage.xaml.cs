using Cars_app.Model;
using Cars_app.VievModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cars_app.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateCarPage : ContentPage
	{
       
        public UpdateCarPage(CarModel Car)
        {
            InitializeComponent();
            this.BindingContext = new UpdateViewModel(Car);
           
        }
       
	}
}