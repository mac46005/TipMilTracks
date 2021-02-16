using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipMilTracks.Models;
using TipMilTracks.Repositories;
using Xamarin.Forms;

namespace TipMilTracks.ModelViews
{
    public class AddUpdateDeleteItemViewModel : ViewModel
    {
        private readonly TrackItemRepository _repo;
        public AddUpdateDeleteItemViewModel(TrackItemRepository repo)
        {
            _repo = repo;
            
        }

        public TrackItemModel Item { get; set; } = new TrackItemModel();

        public ICommand Save => new Command(async () =>
        {
            await _repo.AddOrUpdateItem(Item);
            await Navigation.PopAsync();
        });
    }
}
