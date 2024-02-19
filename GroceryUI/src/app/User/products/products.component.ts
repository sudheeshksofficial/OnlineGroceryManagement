import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StocksService } from 'src/app/shared/stocks.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(public prod:StocksService, public router: Router) { }

  ngOnInit() {
    this.prod.getStocks().subscribe(data=>{
      this.prod.listStock=data;
      this.prod.listStock.forEach((a:any)=>{
          Object.assign(a,{quantity : 1,total:a.price})
      });
    })
  }
  addtoCart(){
    this.router.navigate(['/availableStocks']);
}

}
