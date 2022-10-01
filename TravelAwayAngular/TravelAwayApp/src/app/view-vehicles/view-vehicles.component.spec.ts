import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewVehiclesComponent } from './view-vehicles.component';

describe('ViewVehiclesComponent', () => {
  let component: ViewVehiclesComponent;
  let fixture: ComponentFixture<ViewVehiclesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewVehiclesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewVehiclesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
