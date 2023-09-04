import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemperatureHistoryCardComponent } from './temperature-history-card.component';

describe('TemperatureHistoryCardComponent', () => {
  let component: TemperatureHistoryCardComponent;
  let fixture: ComponentFixture<TemperatureHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TemperatureHistoryCardComponent]
    });
    fixture = TestBed.createComponent(TemperatureHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
