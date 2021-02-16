using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TipMilTracks.Repositories;

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
        public ObservableCollection<TrackItemViewModel> ItemsList { get; set; }
        public string TotalT { get; set; }
        public string TotalM { get; set; }
        private Task LoadData()
        {
            return null;
        }



    }
}
