using Cars_app.VievModel;
using Cars_app.ViewModel;
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
	public partial class AddCarPage : ContentPage
	{
		public AddCarPage ()
		{
			InitializeComponent ();
            this.BindingContext = new AddViewModel();
        }
	}
}