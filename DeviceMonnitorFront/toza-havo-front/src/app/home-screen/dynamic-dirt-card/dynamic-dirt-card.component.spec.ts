import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicDirtCardComponent } from './dynamic-dirt-card.component';

describe('DynamicDirtCardComponent', () => {
  let component: DynamicDirtCardComponent;
  let fixture: ComponentFixture<DynamicDirtCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DynamicDirtCardComponent]
    });
    fixture = TestBed.createComponent(DynamicDirtCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
