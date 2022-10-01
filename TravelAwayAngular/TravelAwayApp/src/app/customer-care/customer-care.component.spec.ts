import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCareComponent } from './customer-care.component';

describe('CustomerCareComponent', () => {
  let component: CustomerCareComponent;
  let fixture: ComponentFixture<CustomerCareComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerCareComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerCareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
