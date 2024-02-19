import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Stock } from 'src/app/shared/models/stock.model';
import { StocksService } from 'src/app/shared/stocks.service';
import { UserserviceService } from 'src/app/shared/userservice.service';
import { StockEditComponent } from './stock-edit/stock-edit.component';

@Component({
  selector: 'app-stock-view',
  templateUrl: './stock-view.component.html',
  styleUrls: ['./stock-view.component.css']
})
export class StockViewComponent implements OnInit {

  constructor(public stocksService:StocksService, public toast:ToastrService,public router : Router) { }
  @ViewChild('checkbox1') checkBox:ElementRef;
  isSlide:string='off';
  emp: StockEditComponent;
  ngOnInit() {
    this.stocksService.getStocks().subscribe(data=>{
      this.stocksService.listStock=data;
    });
  }
//this.router.navigate(['']);
  populateEmployee(selectedStock:Stock)
  {
     var lists = [];
     lists[1] = selectedStock.id;
     lists[2] = selectedStock.title;
     lists[3] = selectedStock.price;
     lists[4] = selectedStock.category;
     lists[5] = selectedStock.image;
     lists[6] = selectedStock.stars;
    this.stocksService.stockData=selectedStock;
    console.log(selectedStock);
    console.log(lists);
   this.router.navigate(['stocksview']);
    if(this.emp.isSlide==='off')
    {
     this.emp.hideShowSlide();
    }
  }
  delete(id:number)
  {
    if(confirm('Are you really want to delete this record?'))
    {
      this.stocksService.deleteStocks(id).subscribe(data=> {
        this.stocksService.getStocks().subscribe(data=>{
          this.stocksService.listStock=data;
          this.toast.error('Sucess','Record Deleted');
        });
      },
      err=>{
      });
    }
    this.router.navigate(['stocksview']);
  }
}
