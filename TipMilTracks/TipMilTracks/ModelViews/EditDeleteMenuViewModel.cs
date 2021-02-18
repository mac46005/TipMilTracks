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
        /// <summary>
        /// the trackrepository object responisble of sending and retrieving data from sqlite db
        /// </summary>
        TrackItemRepository _repo;

        public EditDeleteMenuViewModel(TrackItemRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// The TrackItemModel to edited or deleted
        /// </summary>
        public TrackItemModel Item { get; set; }

        /// <summary>
        /// Deletes the selected TrackItemModel from the TrackItemDB
        /// </summary>
        public ICommand DeleteItem => new Command(async () =>
        {
            await _repo.DeleteItem(Item);
            await Navigation.PopToRootAsync();
        });

        /// <summary>
        /// Sends the user to the addUpdateView for editing
        /// </summary>
        public ICommand EditItem => new Command(async () =>
        {
            var editView = Resolver.Resolve<AddUpdateView>();
            var viewContext = editView.BindingContext as AddUpdateItemViewModel;
            viewContext.Item = Item;
            await Navigation.PushAsync(editView);
        });
    }
}
