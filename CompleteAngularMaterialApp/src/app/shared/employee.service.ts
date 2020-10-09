import { Observable, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EmployeeUrlService } from '../app-url/employee-url-service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService<T> {

  constructor(private http: HttpClient, private employeeUrlService: EmployeeUrlService) { }

  form: FormGroup = new FormGroup({
    id: new FormControl(0),
    nom: new FormControl('', Validators.required),
    postnom: new FormControl('', Validators.required),
    prenom: new FormControl('', Validators.required),
    sexe: new FormControl('1'),
    photo: new FormControl(''),
    email: new FormControl('', Validators.email),
    titreFormation: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  initializeFormGroup() {
    this.form.setValue({
      id: 0,
      nom: '',
      postnom: '',
      prenom: '',
      sexe: '1',
      photo: '',
      email: '',
      titreFormation: ''
    });
  }

  public getEmplyees(): Observable<T[]> {
    const test = this.http.get<T[]>(this.employeeUrlService.urlGetAllProfesseurs());
    return test;
  }

  public insertEmployee(employee: T): Observable<T> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    const test = this.http.post<T>(this.employeeUrlService.urlCreateProfesseur(), employee, httpOptions);
    return test;
  }

}
