import { EmployeeService } from './../../shared/employee.service';
import { Component, OnInit } from '@angular/core';
import { Professeur } from 'src/app/model/vo/professeur.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(public service: EmployeeService<any>) { }

  listData: MatTableDataSource<any>;
  displayedColums: string[] = ['name']

  ngOnInit(): void {
    this.service.getEmplyees().subscribe(
      list => {
        let array = list.map(item => {
          return {
            id: item.id,
            ...item.playload.val()
          };
        });
        this.listData = new MatTableDataSource(array);
      }
    );
  }

}
