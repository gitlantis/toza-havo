import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvapotranspiratsiyaHistoryCardComponent } from './evapotranspiratsiya-history-card.component';

describe('EvapotranspiratsiyaHistoryCardComponent', () => {
  let component: EvapotranspiratsiyaHistoryCardComponent;
  let fixture: ComponentFixture<EvapotranspiratsiyaHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EvapotranspiratsiyaHistoryCardComponent]
    });
    fixture = TestBed.createComponent(EvapotranspiratsiyaHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
