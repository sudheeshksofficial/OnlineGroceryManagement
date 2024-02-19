import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Stock } from 'src/app/shared/models/stock.model';
import { StocksService } from 'src/app/shared/stocks.service';

@Component({
  selector: 'app-stock-edit',
  templateUrl: './stock-edit.component.html',
  styleUrls: ['./stock-edit.component.css']
})
export class StockEditComponent implements OnInit {

  constructor(public stkservice:StocksService, public toast:ToastrService) { }
  @ViewChild('checkbox1') checkBox:ElementRef;
  isSlide:string='off';
  ngOnInit(): void {
  }
  submit(form:NgForm)
  {
    if(this.stkservice.stockData.id==0)
    this.insertStock(form);
   else
   this.updateStock(form);
  }
  insertStock(myform:NgForm)
  {  this.stkservice.saveStock().subscribe(d=> {
     this.resetForm(myform);
     this.refereshData();
     this.toast.success('Sucess','Record Saved');
    });
  }
  updateStock(myform:NgForm)
  {
    this.stkservice.updateStocks().subscribe(d=> {
      this.resetForm(myform);
      this.refereshData();
      this.toast.warning('Sucess','Record Updated');
    });
  }
  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.stkservice.stockData=new Stock();
    this.hideShowSlide();
  }
  refereshData()
  {
    this.stkservice.getStocks().subscribe(res=>{
      this.stkservice.listStock=res;
    });
  }
  hideShowSlide()
  {
    if(this.checkBox.nativeElement.checked)
    {
      this.checkBox.nativeElement.checked=false;
      this.isSlide='off';
    }
    else
    {
      this.checkBox.nativeElement.checked=true;
      this.isSlide='on';
    }
  }
}
