using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using DemoAPI.Models;
using DemoAPI.Services;


namespace DemoAPITest
{
    class BuyServiceFake : IBuyService
    {
        private readonly List<BuyItem> _buy;
        public BuyServiceFake()
        {
            _buy = new List<BuyItem>()
            {
                new BuyItem() { Id = 1, Name = "Tablet SamSung 7",
                                   Vendor ="SamSung", Price = 765.00M },
                new BuyItem() { Id = 2, Name = "IPhone",
                                   Vendor ="Apple", Price = 5000.00M },
                new BuyItem() { Id = 3, Name = "Notebook Lenovo 15",
                                   Vendor ="Lenovo", Price = 1240.00M },
                new BuyItem() { Id = 4, Name = "Monitor LG 23",
                                   Vendor ="LG", Price = 879.00M },
                new BuyItem() { Id = 5, Name = "HD SSD Asus 1T",
                                   Vendor ="Assus", Price = 612.00M }
            };
        }
        public IEnumerable<BuyItem> GetAllItems()
        {
            return _buy;
        }
        public BuyItem Add(BuyItem newItem)
        {
            newItem.Id = CreateId();
            _buy.Add(newItem);
            return newItem;
        }
        public BuyItem GetById(int id)
        {
            return _buy.Where(a => a.Id == id)
                .FirstOrDefault();
        }
        public void Remove(int id)
        {
            var item = _buy.First(a => a.Id == id);
            _buy.Remove(item);
        }
        static int CreateId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
