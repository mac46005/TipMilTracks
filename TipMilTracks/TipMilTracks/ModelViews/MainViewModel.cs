using System;
using System.Collections.Generic;
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
        private Task LoadData()
        {
            return null;
        }
    }
}
