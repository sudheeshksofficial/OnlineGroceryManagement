import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Purchase } from 'src/app/shared/models/purchase.model';
import { StocksService } from 'src/app/shared/stocks.service';
import { PurchaseEditComponent } from './purchase-edit/purchase-edit.component';

@Component({
  selector: 'app-purchse',
  templateUrl: './purchse.component.html',
  styleUrls: ['./purchse.component.css']
})
export class PurchseComponent implements OnInit {

  constructor(public stocksService:StocksService, public toast:ToastrService,public router : Router) { }

  @ViewChild('checkbox1') checkBox:ElementRef;
  isSlide:string='off';
  temp: PurchaseEditComponent;
  ngOnInit() {
    this.stocksService.getPurchase().subscribe(data=>{
      this.stocksService.listPurchase=data;
    });
  }
  populateEmployee(selectedStock:Purchase)
  {
     var lists = [];
     lists[1] = selectedStock.id;
     lists[2] = selectedStock.title;
     lists[3] = selectedStock.price;
     lists[4] = selectedStock.category;
     lists[5] = selectedStock.image;
     lists[6] = selectedStock.stars;
    this.stocksService.purchaseData=selectedStock;
    console.log(selectedStock);
    console.log(lists);
   this.router.navigate(['purchases']);
    if(this.temp.isSlide==='off')
    {
     this.temp.hideShowSlide();
    }
  }
  delete(id:number)
  {
    if(confirm('Are you really want to delete this record?'))
    {
      this.stocksService.deletePurchse(id).subscribe(data=> {
        this.stocksService.getPurchase().subscribe(data=>{
          this.stocksService.listPurchase=data;
          this.toast.error('Sucess','Record Deleted');
        });
      },
      err=>{
      });
    }
    this.router.navigate(['purchases']);
  }

}
