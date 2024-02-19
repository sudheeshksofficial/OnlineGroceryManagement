using GroceryManage.models;
using GroceryManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.services
{
    public interface IStock
    {
        List<Stocks> GetStocksList();
        Stocks GetStockDetailsById(int stockId);
        Response SaveStock(Stocks stockModel);
        Response DeleteStock(int stockId);
    }
}
