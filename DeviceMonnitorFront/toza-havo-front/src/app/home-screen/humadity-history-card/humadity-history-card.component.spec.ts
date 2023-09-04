import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HumadityHistoryCardComponent } from './humadity-history-card.component';

describe('HumadityHistoryCardComponent', () => {
  let component: HumadityHistoryCardComponent;
  let fixture: ComponentFixture<HumadityHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HumadityHistoryCardComponent]
    });
    fixture = TestBed.createComponent(HumadityHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
