import { TestBed } from '@angular/core/testing';

import { InqueriesService } from './inqueries.service';

describe('InqueriesService', () => {
  let service: InqueriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InqueriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
