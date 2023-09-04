import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SandHumadityHistoryCardComponent } from './sand-humadity-history-card.component';

describe('SandHumadityHistoryCardComponent', () => {
  let component: SandHumadityHistoryCardComponent;
  let fixture: ComponentFixture<SandHumadityHistoryCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SandHumadityHistoryCardComponent]
    });
    fixture = TestBed.createComponent(SandHumadityHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
