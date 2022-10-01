import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBookingsComponent } from './view-bookings.component';

describe('ViewBookingsComponent', () => {
  let component: ViewBookingsComponent;
  let fixture: ComponentFixture<ViewBookingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewBookingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewBookingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
