import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirtHistoryCardComponent } from './dirt-history-card.component';

describe('DirtHistoryCardComponent', () => {
  let component: DirtHistoryCardComponent;
  let fixture: ComponentFixture<DirtHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DirtHistoryCardComponent]
    });
    fixture = TestBed.createComponent(DirtHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
