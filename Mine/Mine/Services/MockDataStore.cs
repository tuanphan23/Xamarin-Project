using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Ocular Device", Description="A glass to help the wearer see the hidden symbols.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "The Meerschaum Pipe", Description="A million-dollar pipe.", Value=4 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "President’s book", Description="A book holds all the secrets to the history of the World.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Flaming gun", Description="A magical gun that can cause enemies to explode with solar energy.", Value=7 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Cape of the captain", Description="A marvelous cape with the ability to reduce the damage of the enemies.", Value=9 }
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}