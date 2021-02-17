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
    public partial class AddUpdateView : ContentPage
    {
        public AddUpdateView(AddUpdateItemViewModel vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}