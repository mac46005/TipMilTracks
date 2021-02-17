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
    public partial class EditDeleteMenuView : ContentPage
    {
        public EditDeleteMenuView(EditDeleteMenuViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;

        }
    }
}