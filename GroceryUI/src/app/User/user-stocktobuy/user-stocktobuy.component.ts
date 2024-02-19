import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { StocksService } from 'src/app/shared/stocks.service';

@Component({
  selector: 'app-user-stocktobuy',
  templateUrl: './user-stocktobuy.component.html',
  styleUrls: ['./user-stocktobuy.component.css']
})
export class UserStocktobuyComponent implements OnInit {

  constructor(public stocksService:StocksService, public toast:ToastrService,private router : Router) { }

  ngOnInit() {
    this.stocksService.getStocks().subscribe(data=>{
      this.stocksService.listStock=data;
    });
  }
  delete(id:number)
  {
    if(confirm('Are you really want to buy this record?'))
    {
      this.stocksService.deleteStocks(id).subscribe(data=> {
        this.stocksService.getStocks().subscribe(data=>{
          this.stocksService.listStock=data;
          this.toast.success('Sucess','product purchase delete');
        });
      },
      err=>{
      });
    }
  }

}
