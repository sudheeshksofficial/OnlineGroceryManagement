import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchseComponent } from './purchse.component';

describe('PurchseComponent', () => {
  let component: PurchseComponent;
  let fixture: ComponentFixture<PurchseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
