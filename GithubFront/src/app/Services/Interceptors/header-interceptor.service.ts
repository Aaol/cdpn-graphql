import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HeaderInterceptorService implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!req.headers.has('Content-Type') && !(req.body instanceof FormData)) {
      req = req.clone({
        headers: req.headers.set('Content-Type', 'application/json')
      });
    }
    console.log(req);

    return next.handle(req);
  }
  constructor() { }

}
