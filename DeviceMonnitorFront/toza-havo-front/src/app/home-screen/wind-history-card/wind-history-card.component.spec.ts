import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WindHistoryCardComponent } from './wind-history-card.component';

describe('WindHistoryCardComponent', () => {
  let component: WindHistoryCardComponent;
  let fixture: ComponentFixture<WindHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WindHistoryCardComponent]
    });
    fixture = TestBed.createComponent(WindHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
