import { Injectable } from '@angular/core';
import { AppUrlService } from '../app-url/app-url.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeUrlService extends AppUrlService {
  private urlProfesseurController: string;

  constructor() {
    super();
    this.urlProfesseurController = '/professeur';
  }

  public urlGetAllProfesseurs(): string {
    return this.baseUrl.concat(this.urlProfesseurController).concat('/getallprofesseurs');
  }
  public urlGetProfesseurById(id: number): string {
    return this.baseUrl.concat(this.urlProfesseurController).concat('/getprofesseurbyid/').concat(id.toString());
  }
  public urlCreateProfesseur(): string {
    return this.baseUrl.concat(this.urlProfesseurController).concat('/createprofesseur');
  }
  public urlUpdateProfesseur(): string {
    return this.baseUrl.concat(this.urlProfesseurController).concat('/updateprofesseur');
  }
  public urlDeleteProfesseurById(id: number): string {
    return this.baseUrl.concat(this.urlProfesseurController).concat('/deleteprofesseurbyid/').concat(id.toString());
  }

}
