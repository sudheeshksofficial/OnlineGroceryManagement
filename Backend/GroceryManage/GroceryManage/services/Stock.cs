using GroceryManage.DataAccess;
using GroceryManage.models;
using GroceryManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.services
{
    public class Stock : IStock
    {
        private GroceryDbContext _context;

        public Stock(GroceryDbContext context)
        {
            _context = context;
        }

        public Response DeleteStock(int stockId)
        {
            Response model = new Response();
            try
            {
                Stocks _temp = GetStockDetailsById(stockId);
                if (_temp != null)
                {
                    _context.Remove<Stocks>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Stock Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Stock Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Stocks GetStockDetailsById(int stockId)
        {
            Stocks usr;
            try
            {
                usr = _context.Find<Stocks>(stockId);
            }
            catch (Exception)
            {
                throw;
            }
            return usr;
        }

        public List<Stocks> GetStocksList()
        {
           // List<Stocks> stockList;
            try
            {
                //stockList = _context.Set<Stocks>().ToList();
                var stockList = _context.stocks.ToList();
                return stockList;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Response SaveStock(Stocks stockModel)
        {
            Response model = new Response();
            try
            {
                Stocks _temp = GetStockDetailsById(stockModel.Id);
                if (_temp != null)
                {

                    _temp.Title = stockModel.Title;
                    _temp.Price = stockModel.Price;
                    _temp.Category = stockModel.Category;
                    _temp.Image = stockModel.Image;
                    _temp.Stars = stockModel.Stars;
                    _context.Update<Stocks>(_temp);
                    model.Messsage = "Stock details Update Successfully";
                }
                else
                {
                    _context.Add<Stocks>(stockModel);
                    model.Messsage = "Stocks Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;

        }
    }
}
