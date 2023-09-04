import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolarRadiationHistoryCardComponent } from './solar-radiation-history-card.component';

describe('SolarRadiationHistoryCardComponent', () => {
  let component: SolarRadiationHistoryCardComponent;
  let fixture: ComponentFixture<SolarRadiationHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SolarRadiationHistoryCardComponent]
    });
    fixture = TestBed.createComponent(SolarRadiationHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
