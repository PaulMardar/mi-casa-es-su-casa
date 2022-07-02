import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailedElectionComponent } from './detailed-election.component';

describe('DetailedElectionComponent', () => {
  let component: DetailedElectionComponent;
  let fixture: ComponentFixture<DetailedElectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailedElectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailedElectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
