import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SandTemperatureHistoryCardComponent } from './sand-temperature-history-card.component';

describe('SandTemperatureHistoryCardComponent', () => {
  let component: SandTemperatureHistoryCardComponent;
  let fixture: ComponentFixture<SandTemperatureHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SandTemperatureHistoryCardComponent]
    });
    fixture = TestBed.createComponent(SandTemperatureHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
