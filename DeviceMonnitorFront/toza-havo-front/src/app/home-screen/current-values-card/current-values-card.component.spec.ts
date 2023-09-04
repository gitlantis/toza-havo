import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CurrentValuesCardComponent } from './current-values-card.component';


describe('CurrentValuesCardComponent', () => {
  let component: CurrentValuesCardComponent;
  let fixture: ComponentFixture<CurrentValuesCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurrentValuesCardComponent]
    });
    fixture = TestBed.createComponent(CurrentValuesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
