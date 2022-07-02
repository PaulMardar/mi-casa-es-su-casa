import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinishedProposalsComponent } from './finished-proposals.component';

describe('FinishedProposalsComponent', () => {
  let component: FinishedProposalsComponent;
  let fixture: ComponentFixture<FinishedProposalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinishedProposalsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FinishedProposalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
