using System;
using System.Collections.Generic;
using System.Text;
using TipMilTracks.Models;
using TipMilTracks.Repositories;

namespace TipMilTracks.ModelViews
{
    public class TrackItemViewModel : ViewModel
    {
        public event EventHandler ItemStatusChanged;

        public TrackItemViewModel(TrackItemModel item)
        {
            TrackItem = item;
        }

        /// <summary>
        /// The item object
        /// </summary>
        public TrackItemModel TrackItem { get; set; }
        /// <summary>
        /// Cell Color depending on the item type
        /// </summary>
        public string ValueView => (TrackItem.ValueType == "Tip")? $"{TrackItem.Value:C}": $"{TrackItem.Value} miles";
    }
}
