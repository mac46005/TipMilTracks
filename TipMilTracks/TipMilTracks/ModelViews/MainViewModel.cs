using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TipMilTracks.Repositories;
using TipMilTracks.Views;
using Xamarin.Forms;
using System.Linq;
using TipMilTracks.Models;

namespace TipMilTracks.ModelViews
{
    public class MainViewModel : ViewModel
    {
        private readonly TrackItemRepository _repo;
        public MainViewModel(TrackItemRepository repo)
        {
            _repo = repo;
            Task.Run(async () => await LoadData());

            _repo.OnItemAdded += (sender, item) => Task.Run(async () => await LoadData()); //ItemsList.Add(CreateTrackItemViewModel(item));
            _repo.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadData());
            _repo.OnItemDeleted += (sender, item) => Task.Run(async () => await LoadData());
        }
        public string CurrentDate { get; set; } = DateTime.Now.ToString("D");
        public ObservableCollection<TrackItemViewModel> ItemsList { get; set; }
        public string TotalT { get; set; }
        public string TotalM { get; set; }
        private async Task LoadData()
        {
            var items = await _repo.GetItems();
            var itemVM = items.Select(i => CreateTrackItemViewModel(i));

            ItemsList = new ObservableCollection<TrackItemViewModel>(itemVM);
        }
        private TrackItemViewModel CreateTrackItemViewModel(TrackItemModel item)
        {
            var vm = new TrackItemViewModel(item);
            //EVENTHANDLER ??
            return vm;
        }

        public ICommand AUD_Item => new Command(async () =>
        {
            var audView = Resolver.Resolve<AddUpdateView>();
            await Navigation.PushAsync(audView);
        });


        public TrackItemViewModel SelectedItem
        {
            get => null;
            set
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await NavigateToEditDeleteMenu(value);
                    OnPropertyChanged(nameof(SelectedItem));
                });
            }
        }

        private async Task NavigateToEditDeleteMenu(TrackItemViewModel itemVM)
        {
            if (itemVM == null)
            {
                return;
            }

            var edVM = Resolver.Resolve<EditDeleteMenuView>();
            var vm = edVM.BindingContext as EditDeleteMenuViewModel;
            vm.Item = itemVM.TrackItem;
            await Navigation.PushAsync(edVM);
        }

    }
}
