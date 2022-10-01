import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeLayoutComponent } from './employee-layout.component';

describe('EmployeeLayoutComponent', () => {
  let component: EmployeeLayoutComponent;
  let fixture: ComponentFixture<EmployeeLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
