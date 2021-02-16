using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipMilTracks.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipMilTracks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUpdateDeleteView : ContentPage
    {
        public AddUpdateDeleteView(AddUpdateDeleteItemViewModel vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}