using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipMilTracks.Models;
using TipMilTracks.Repositories;
using TipMilTracks.Views;
using Xamarin.Forms;

namespace TipMilTracks.ModelViews
{
    public class EditDeleteMenuViewModel : ViewModel
    {
        TrackItemRepository _repo;
        public EditDeleteMenuViewModel(TrackItemRepository repo)
        {
            _repo = repo;
        }
        public TrackItemModel Item { get; set; }
        public ICommand DeleteItem => new Command(async () =>
        {
            await _repo.DeleteItem(Item);
            await Navigation.PopToRootAsync();
        });
        public ICommand Edit => new Command(async () =>
        {
            var editView = Resolver.Resolve<AddUpdateView>();
            var viewContext = editView.BindingContext as AddUpdateItemViewModel;
            viewContext.Item = Item;
            await Navigation.PushAsync()
        });
    }
}
