import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppUrlService {

    protected baseUrl: string;

     constructor() {
         this.baseUrl = 'http://localhost:59184/kelasys-esr/api';
     }

}
