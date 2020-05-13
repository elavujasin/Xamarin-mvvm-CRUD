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
       
        public UpdateCarPage(int id)
        {
            InitializeComponent();
            this.BindingContext = new UpdateViewModel(id);
           
        }
       
	}
}