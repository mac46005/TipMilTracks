﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TipMilTracks.Models;

namespace TipMilTracks.Repositories
{
    public class TrackItemRepository : IRepository<TrackItemModel>
    {
        public event EventHandler<TrackItemModel> OnItemAdded;
        public event EventHandler<TrackItemModel> OnItemUpdated;
        public event EventHandler<TrackItemModel> OnItemDeleted;

        private SQLiteAsyncConnection _connection;

        private async Task CreateConnection()
        {
            if (_connection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TipMilTrack_DB.db");

            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<TrackItemModel>();
        }

        public async Task AddOrUpdateItem(TrackItemModel item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }

        public async Task DeleteItem(TrackItemModel item)
        {
            await CreateConnection();
            await _connection.DeleteAsync(item);
        }

        public async Task<List<TrackItemModel>> GetItems()
        {
            await CreateConnection();
            return await _connection.Table<TrackItemModel>().ToListAsync();
        }

        public async Task AddItem(TrackItemModel item)
        {
            await CreateConnection();
            await _connection.InsertAsync(item);
        }

        public async Task UpdateItem(TrackItemModel item)
        {
            await CreateConnection();
            await _connection.UpdateAsync(item);
        }

        public async Task<TrackItemModel> GetItem(TrackItemModel item)
        {
            await CreateConnection();
            return await _connection.FindAsync<TrackItemModel>(item);
        }
    }
}
