import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailedProposalComponent } from './detailed-proposal.component';

describe('DetailedProposalComponent', () => {
  let component: DetailedProposalComponent;
  let fixture: ComponentFixture<DetailedProposalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailedProposalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailedProposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
