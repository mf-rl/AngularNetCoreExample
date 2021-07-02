import { Component, OnInit, Inject, Injectable } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { CommonItem, Enrollment, Salary, Errors } from '../common-item.model';
import { FormBuilder, FormGroup, FormControl, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './register-salary.component.html',
})
export class RegisterSalaryComponent implements OnInit {
  grades: number[] = Array.from(Array(20).keys());
  form: FormGroup = new FormGroup({});
  constructor(
    private http: HttpClient, 
    private dialogRef: MatDialogRef<RegisterSalaryComponent>, private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: {
      divisionList: CommonItem[], 
      officeList: CommonItem[], 
      positionList: CommonItem[],
      enrollment: Enrollment
    }) { 
      this.form = fb.group({
        compensationbonusinput: ['', [Validators.required, Validators.pattern("^[0-9]*$")]]
      })
    }

  ngOnInit(): void {
    
  }
  public closeMe() {
    this.dialogRef.close();
  }
  addSalary(salary: Salary)
    : Observable<SalaryResponse>
  {
    return this.http.post<SalaryResponse>("https://localhost:44350/SalaryDetail/Add", salary)
  }
  public saveData(){
    let errMessage: string = "";
    let salaryToSave = Object.assign(new Salary(), {
      yearMonth: (<HTMLInputElement>document.getElementById("year-month-input")).value,
      grade: (<HTMLInputElement>document.getElementById("grade-select")).value,
      productionBonus: (<HTMLInputElement>document.getElementById("production-bonus-input")).value,
      compensationBonus: (<HTMLInputElement>document.getElementById("compensation-bonus-input")).value,
      commission: (<HTMLInputElement>document.getElementById("commission-input")).value,
      contributions: (<HTMLInputElement>document.getElementById("contributions-input")).value,
      enrollmentId: this.data.enrollment.id,
    });
    if (salaryToSave.yearMonth.length == 0) errMessage+="\n- Ingresar año/mes.";
    if (salaryToSave.grade < 0) errMessage+="\n- Seleccionar grado.";
    if (errMessage.length > 0) {
      alert(errMessage);
    } else {
      this.addSalary(salaryToSave).subscribe(value => {
        if (value.validationResult.isValid) {
          this.closeMe();
        } else {
          value.validationResult.errors.forEach((e) => {
            errMessage+="\n- " + e.message;
          });
          alert(errMessage);
        }        
      })
    }
  }
}
interface SalaryResponse extends ServiceResponse {
  data: Salary;
}

interface ServiceResponse {
  validationResult: Validation;
  pageNumber: number,
  pageSize: number,
  firstPage: string,
  lastPage: string,
  totalPages: number,
  totalRecords: number,
  nextPage: string,
  previousPage: string
}
interface Validation {
  isValid: boolean;
  errors: Errors[];
}