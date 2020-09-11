import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { GetRequestPage } from './get-request.page';

describe('GetRequestPage', () => {
  let component: GetRequestPage;
  let fixture: ComponentFixture<GetRequestPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetRequestPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(GetRequestPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
