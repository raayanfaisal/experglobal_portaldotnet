import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffManagmentComponent } from './staff-managment.component';

describe('StaffManagmentComponent', () => {
  let component: StaffManagmentComponent;
  let fixture: ComponentFixture<StaffManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaffManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StaffManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
