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
        /// <summary>
        /// the trackrepository object responisble of sending and retrieving data from sqlite db
        /// </summary>
        private readonly TrackItemRepository _repo;
        public MainViewModel(TrackItemRepository repo)
        {
            _repo = repo;
            Task.Run(async () => await LoadData());

            _repo.OnItemAdded += (sender, item) => Task.Run(async () => { await LoadData(); }); //ItemsList.Add(CreateTrackItemViewModel(item));
            _repo.OnItemUpdated += (sender, item) => Task.Run(async () => { await LoadData(); });
            _repo.OnItemDeleted += (sender, item) => Task.Run(async () => { await LoadData(); });
        }

        /// <summary>
        /// Sets the current date of today
        /// </summary>
        public string CurrentDate { get; set; } = DateTime.Now.ToString("D");

        /// <summary>
        /// A list of TrackItemViewModels used for the viewList
        /// </summary>
        public ObservableCollection<TrackItemViewModel> ItemsList { get; set; }
        public ObservableCollection<TrackItemViewModel> CurrentList { get; set; }

        /// <summary>
        /// Added tips from repo trackitem object value
        /// </summary>
        public string TotalTips { get; set; }

        /// <summary>
        /// Added miles from repo trackitem objects value
        /// </summary>
        public string TotalMiles { get; set; }

        /// <summary>
        /// Gets all Data from the tracktrp object
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            var items = await _repo.GetItems();
            var itemVM = items.Select(i => CreateTrackItemViewModel(i));

            CurrentList = new ObservableCollection<TrackItemViewModel>(itemVM);
            ItemsList = CurrentList;
            SetTotalStrings();
        }

        /// <summary>
        /// Creates a TrackItemViewModel 
        /// </summary>
        /// <param name="item">A TrackItemModel Object</param>
        /// <returns>Returns a TrackItemViewModel</returns>
        private TrackItemViewModel CreateTrackItemViewModel(TrackItemModel item)
        {
            var vm = new TrackItemViewModel(item);
            //EVENTHANDLER ??
            return vm;
        }

        /// <summary>
        /// The add button on the top right sent to View 
        /// </summary>
        public ICommand AUD_Item => new Command(async () =>
        {
            var audView = Resolver.Resolve<AddUpdateView>();
            await Navigation.PushAsync(audView);
        });



        /// <summary>
        /// The selected TrackItemViewModel sent to method NavigateToEditDeleteMenu
        /// </summary>
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



        /// <summary>
        /// When an item is clicked on the listView it is sent to a new view EditDelete Menu
        /// </summary>
        /// <param name="itemVM">TrackItemViewModel to extract TrackItemModel</param>
        /// <returns>A task thay sends the user to the editdelete View</returns>
        private async Task NavigateToEditDeleteMenu(TrackItemViewModel itemVM)
        {
            if (itemVM == null)
            {
                return;
            }

            var editDeleteView = Resolver.Resolve<EditDeleteMenuView>();
            var viewBindingContext = editDeleteView.BindingContext as EditDeleteMenuViewModel;
            viewBindingContext.Item = itemVM.TrackItem;
            await Navigation.PushAsync(editDeleteView);
        }

        /// <summary>
        /// Sets the string values of TotalTips and TotalMiles
        /// </summary>
        private void SetTotalStrings()
        {
            decimal tipAmount = 0, mileAmount = 0;
            foreach (var item in ItemsList)
            {
                if (item.TrackItem.ValueType == "Tip")
                {
                    tipAmount += item.TrackItem.Value;
                }
                if (item.TrackItem.ValueType == "Miles")
                {
                    mileAmount += item.TrackItem.Value;
                }
            }
            TotalTips = $"{tipAmount:C}";
            TotalMiles = $"{mileAmount} m";
        }

        //Toggle Function

        public string ToggleString { get; set; } = "All";
        string[] toggleNames = { "All", "Tips", "Miles" };
        public ICommand ToggleCommand => new Command(async () =>
        {
            if (ToggleString == toggleNames[0])
            {
                ToggleString = toggleNames[1];
                await ToggleFunction();
                return;
            }
            else if (ToggleString == toggleNames[1])
            {
                ToggleString = toggleNames[2];
                await ToggleFunction();
                return;
            }
            else if (ToggleString == toggleNames[2])
            {
                ToggleString = toggleNames[0]; 
                await ToggleFunction();
                return;
            }
        });
        private async Task ToggleFunction()
        {
            ItemsList = CurrentList;
            if (ToggleString == toggleNames[0])
            {
                await LoadData();//HMMMMM
            }
            else if (ToggleString == toggleNames[1])
            {
                var tipsList = CurrentList.Select(x => (x.TrackItem.ValueType == "Tip")? x : null);
                ItemsList = new ObservableCollection<TrackItemViewModel>(tipsList);
            }
            else
            {
                var milesList = CurrentList.Select(x => (x.TrackItem.ValueType == "Miles") ? x : null);
                ItemsList = new ObservableCollection<TrackItemViewModel>(milesList);
            }
        }
    }
}
