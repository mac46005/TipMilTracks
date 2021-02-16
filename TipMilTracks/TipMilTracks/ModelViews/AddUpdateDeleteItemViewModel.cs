using System;
using System.Collections.Generic;
using System.Text;
using TipMilTracks.Repositories;

namespace TipMilTracks.ModelViews
{
    public class AddUpdateDeleteItemViewModel : ViewModel
    {
        private readonly TrackItemRepository _repo;
        public AddUpdateDeleteItemViewModel(TrackItemRepository repo)
        {
            _repo = repo;
        }
    }
}
