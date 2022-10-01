import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPackageDetailsComponent } from './view-package-details.component';

describe('ViewPackageDetailsComponent', () => {
  let component: ViewPackageDetailsComponent;
  let fixture: ComponentFixture<ViewPackageDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewPackageDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewPackageDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
