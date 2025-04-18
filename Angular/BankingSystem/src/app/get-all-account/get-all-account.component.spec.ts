import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllAccountComponent } from './get-all-account.component';

describe('GetAllAccountComponent', () => {
  let component: GetAllAccountComponent;
  let fixture: ComponentFixture<GetAllAccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetAllAccountComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
