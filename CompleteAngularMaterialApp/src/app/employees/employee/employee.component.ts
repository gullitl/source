import { NotificationService } from './../../shared/notification.service';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../shared/employee.service';
import { Sexe } from 'src/app/helper/enumeration/sexe.enum';
import { Professeur } from 'src/app/model/vo/professeur.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  departments = [
    { id: 3, value: 'Dep 1'},
    { id: 2, value: 'Dep 2'},
    { id: 1, value: 'Dep 3'}
  ];

  constructor(public service: EmployeeService<Professeur>,
              public notificationService: NotificationService) { }

  ngOnInit(): void {
    // this.service.getEmplyees();
  }

  onClear() {
    this.service.form.reset();
    this.service.initializeFormGroup();
  }

  onSubmit() {
    if (this.service.form.valid) {
      let test: any;

      const professeur: Professeur = {
        id: this.service.form.value.id,
        nom: this.service.form.value.nom,
        postnom: this.service.form.value.postnom,
        prenom: this.service.form.value.prenom,
        sexe: Number(this.service.form.value.sexe) as Sexe,
        photo: this.service.form.value.photo,
        email: this.service.form.value.email,
        titreFormation: this.service.form.value.titreFormation
      };
      this.service.insertEmployee(professeur)
      .subscribe(p => {
        test = p;
        console.log(test);
        this.onClear();
        this.notificationService.sucess(':: Submitted successfully');
      }, error => {
        console.log('Oops', error);
        this.notificationService.sucess('::: Error: '.concat(error));
      });
    }
  }

}
