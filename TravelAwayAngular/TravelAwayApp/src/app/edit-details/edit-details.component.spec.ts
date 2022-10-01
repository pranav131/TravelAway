import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDetailsComponent } from './edit-details.component';

describe('EditDetailsComponent', () => {
  let component: EditDetailsComponent;
  let fixture: ComponentFixture<EditDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
