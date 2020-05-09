import { TestBed } from '@angular/core/testing';

import { TokerInterceptorService } from './toker-interceptor.service';

describe('TokerInterceptorService', () => {
  let service: TokerInterceptorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TokerInterceptorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
