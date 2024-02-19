import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserStocktobuyComponent } from './user-stocktobuy.component';

describe('UserStocktobuyComponent', () => {
  let component: UserStocktobuyComponent;
  let fixture: ComponentFixture<UserStocktobuyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserStocktobuyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserStocktobuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
