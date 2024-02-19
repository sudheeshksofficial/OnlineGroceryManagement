import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Purchase } from 'src/app/shared/models/purchase.model';
import { StocksService } from 'src/app/shared/stocks.service';

@Component({
  selector: 'app-purchase-edit',
  templateUrl: './purchase-edit.component.html',
  styleUrls: ['./purchase-edit.component.css']
})
export class PurchaseEditComponent implements OnInit {

  constructor(public stkservice:StocksService, public toast:ToastrService) { }
  @ViewChild('checkbox1') checkBox:ElementRef;
  isSlide:string='off';
  ngOnInit(): void {
  }
  submit(form:NgForm)
  {
    if(this.stkservice.purchaseData.id==0)
    this.insertPurchase(form);
   else
   this.updatePurchase(form);
  }
  insertPurchase(myform:NgForm)
  {  this.stkservice.savePurchase().subscribe(d=> {
     this.resetForm(myform);
     this.refereshData();
     this.toast.success('Sucess','Record Saved');
    });
  }
  updatePurchase(myform:NgForm)
  {
    this.stkservice.updatePurchases().subscribe(d=> {
      this.resetForm(myform);
      this.refereshData();
      this.toast.warning('Sucess','Record Updated');
    });
  }
  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.stkservice.purchaseData=new Purchase();
    this.hideShowSlide();
  }
  refereshData()
  {
    this.stkservice.getPurchase().subscribe(res=>{
      this.stkservice.listPurchase=res;
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
