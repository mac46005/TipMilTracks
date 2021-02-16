using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TipMilTracks.Repositories;
using TipMilTracks.Views;
using Xamarin.Forms;

namespace TipMilTracks.ModelViews
{
    public class MainViewModel : ViewModel
    {
        private readonly TrackItemRepository _repo;
        public MainViewModel(TrackItemRepository repo)
        {
            _repo = repo;
            Task.Run(async () => await LoadData());


        }
        public string CurrentDate { get; set; } = DateTime.Now.ToString("D");
        public ObservableCollection<TrackItemViewModel> ItemsList { get; set; }
        public string TotalT { get; set; }
        public string TotalM { get; set; }
        private Task LoadData()
        {
            return null;
        }


        public ICommand AUD_Item => new Command(async () =>
        {
            var audView = Resolver.Resolve<AddUpdateDeleteView>();
            await Navigation.PushAsync(audView);
        });
    }
}
