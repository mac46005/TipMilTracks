﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipMilTracks.Models;
using TipMilTracks.Repositories;
using Xamarin.Forms;

namespace TipMilTracks.ModelViews
{
    public class AddUpdateItemViewModel : ViewModel
    {
        private readonly TrackItemRepository _repo;
        public AddUpdateItemViewModel(TrackItemRepository repo)
        {
            _repo = repo;

        }

        public TrackItemModel Item { get; set; } = new TrackItemModel();

        public ICommand Save => new Command(async () =>
        {
            if (Item.Id == 0)
            {
                await _repo.AddItem(Item);
                await Navigation.PopAsync();
            }
            else
            {
                await _repo.AddOrUpdateItem(Item);
                await Navigation.PopToRootAsync();
            }


        });
    }
}
