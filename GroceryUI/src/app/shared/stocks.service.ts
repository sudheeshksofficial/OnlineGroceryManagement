import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Stock } from './models/stock.model';
import { Observable } from 'rxjs';
import { Purchase } from './models/purchase.model';
@Injectable({
  providedIn: 'root'
})
export class StocksService {

  constructor(private myhttp:HttpClient) { }
  stockUrl = 'https://localhost:44324/api/Stock';
  listStock:Stock[]=[]; //For Getting Data userlist
  stockData:Stock = new Stock(); //for post data / Insert data
  purchaseUrl = 'https://localhost:44324/api/Purchase';
  listPurchase:Purchase[]=[];
  purchaseData:Purchase = new Purchase();
   //https://localhost:44324/api/Stock

   getStocks():Observable<Stock[]>
   {
     return this.myhttp.get<Stock[]>(this.stockUrl);
   }
      getPurchase():Observable<Purchase[]>
   {
     return this.myhttp.get<Purchase[]>(this.purchaseUrl);
   }
   deleteStocks(id:number)
  {
    return this.myhttp.delete(`${this.stockUrl}/${id}`);
  }
  deletePurchse(id:number)
  {
    return this.myhttp.delete(`${this.purchaseUrl}/${id}`);
  }
  updateStocks()
  {
    return this.myhttp.put(`${this.stockUrl}/${this.stockData.id}` ,this.stockData);
  }
  updatePurchases()
  {
    return this.myhttp.put(`${this.purchaseUrl}/${this.purchaseData.id}` ,this.purchaseData);
  }
  saveStock()
  {
    return this.myhttp.post(this.stockUrl,this.stockData);
  }
  savePurchase()
  {
    return this.myhttp.post(this.purchaseUrl,this.purchaseData);
  }

}
