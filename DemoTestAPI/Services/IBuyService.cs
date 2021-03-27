using System.Collections.Generic;

using DemoAPI.Models;

namespace DemoAPI.Services
{
    public interface IBuyService
    {
        IEnumerable<BuyItem> GetAllItems();
        BuyItem Add(BuyItem newItem);
        BuyItem GetById(int id);
        void Remove(int id);
    }
}
