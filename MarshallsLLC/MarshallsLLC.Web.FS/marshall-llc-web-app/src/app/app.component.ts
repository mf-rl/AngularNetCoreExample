import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { CommonItem, Employee, Errors, MonthlySalaryDetail, Enrollment } from './common-item.model';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { debounceTime, tap, switchMap, finalize, debounce } from 'rxjs/operators';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ModalMessageComponent } from './modal-message/modal-message.component';
import { RegisterSalaryComponent } from './register-salary/register-salary.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'marshall-llc-web-app';
  formControl = new FormControl();
  autoFilter!: Employee[];
  monthlySalaryDetail!: MonthlySalaryDetail[];
  salarySearchValue = "";
  employee: Employee | undefined;
  isLoading = false;
  loadingSalary = false;
  selectedEmployee = "";
  errorMsg: string | undefined;
  item: any;
  divisionList: CommonItem[] = [];
  officeList: CommonItem[] = [];
  positionList: CommonItem[] = [];

  enrollment = Object.assign(new Enrollment(), {
    id: 1,
    employee: Object.assign(new Employee(), {
      id: 1
    }),
    office:  Object.assign(new CommonItem(), {
      id: 2
    }),
    division:  Object.assign(new CommonItem(), {
      id: 3
    }),
    position:  Object.assign(new CommonItem(), {
      id: 2
    }),
    beginDate: "",
    baseSalary: 0  
  });
  public employeeServiceResponse: EmployeeServiceResponse | undefined;
  public monthlySalaryServiceResponse: MonthlySalaryServiceResponse | undefined;
  public errorMessages: Errors[] | undefined;
  public pageNumber = 1;
  public pageSize = 10;
  public filterName = "";
  public firstPage = "";
  public lastPage = "";
  public nextPage = "";
  public previousPage = "";
  public totalPages = 0;
  public totalRecords = 0;
  public uriService = "";
  searchOption: string = "Ingresar nombre";
  optSearch: number = 1;
  constructor(private http: HttpClient, private dialog: MatDialog){}

  ngOnInit(){
    this.loadDataSelect("GetDivisions").subscribe(val => {
      this.divisionList = val.data; 
    });
    this.loadDataSelect("GetOffices").subscribe(val => {
      this.officeList = val.data; 
    });
    this.loadDataSelect("GetPositions").subscribe(val => {
      this.positionList = val.data;
    });

    this.formControl.valueChanges
    .pipe(
      debounceTime(500),
      tap(() => {
        this.errorMsg = "";
        this.autoFilter = [];
        this.isLoading = true;
      }),
      switchMap(value => 
        this.http.get<EmployeeServiceResponse>
        ("https://localhost:44350/Employee/Get/0/" + (this.optSearch === 1 ? value : " ") + "/" + (this.optSearch === 0 ? value : " ") + "?PageNumber=1&PageSize=10")
        .pipe(
          finalize(() => {
            this.isLoading = false
          }),
        )
      )
    )
    .subscribe(data => {
      this.employeeServiceResponse = data;
      if (this.employeeServiceResponse.validationResult.isValid){
        this.autoFilter = this.employeeServiceResponse.data;
        this.errorMsg = "";
      } else {
        this.autoFilter = [];
        this.errorMsg = this.employeeServiceResponse.validationResult.errors[0].message;
        this.item = "";
      }
      console.log(this.autoFilter);
    })
  }
  getFullName(employeeId: number) {      
    if (this.autoFilter == undefined){
      return "";
    } else {
      this.employee = this.autoFilter.find(e => e.id === employeeId);
      if (this.employee == null) {
        return "";
      } else {
        console.log("Empleado encontrado: " + this.employee.employeeName + " " + this.employee.employeeSurname);
        this.salarySearchValue = this.employee.employeeName + " " + this.employee.employeeSurname;
        this.uriService = "https://localhost:44350/EmployeeMonthlySalary/Get/" + this.salarySearchValue + "?PageNumber=" + this.pageNumber.toString() + "&PageSize=" + this.pageSize.toString();
        console.log("Request: " + this.uriService);
        this.LoadData(this.uriService);
        this.loadDataEnrollment(this.employee.id.toString()).subscribe(value => {
          if (value.validationResult.isValid) this.enrollment = value.data;
        });
        return this.optSearch === 1 ? this.employee?.employeeName + " " + this.employee?.employeeSurname : this.employee.employeeCode;
      }
    }
  }
  loadDataSelect(methodName: string) 
    : Observable<CommonServiceResponse>
  {
    return this.http
      .get<CommonServiceResponse>("https://localhost:44350/Common/" + methodName)
  }
  loadDataEnrollment(employeeId: string)
    : Observable<EnrollmentResponse>
  {
    return this.http
      .get<EnrollmentResponse>("https://localhost:44350/Enrollment/GetCurrent/" + employeeId)      
  }
  LoadData(baseUri: string){
    this.loadingSalary = true;
    this.http
      .get<MonthlySalaryServiceResponse>(baseUri)
      .pipe(
        finalize(() => {
          this.loadingSalary = false;
        })
      )
      .subscribe(result => {
        this.monthlySalaryServiceResponse = result;
        if (this.monthlySalaryServiceResponse.validationResult.isValid) {
          this.monthlySalaryDetail = this.monthlySalaryServiceResponse.data;
          this.pageNumber = this.monthlySalaryServiceResponse.pageNumber;
          this.pageSize = this.monthlySalaryServiceResponse.pageSize;
          this.firstPage = this.monthlySalaryServiceResponse.firstPage;
          this.lastPage = this.monthlySalaryServiceResponse.lastPage;
          this.nextPage = this.monthlySalaryServiceResponse.nextPage === null ? "" : this.monthlySalaryServiceResponse.nextPage;
          this.previousPage = this.monthlySalaryServiceResponse.previousPage === null ? "" : this.monthlySalaryServiceResponse.previousPage;
          this.totalPages = this.monthlySalaryServiceResponse.totalPages;
          this.totalRecords = this.monthlySalaryServiceResponse.totalRecords;
        } else {
          this.errorMessages = this.monthlySalaryServiceResponse.validationResult.errors;
          this.cleanVars();
        }
    }, error => console.error(error));
  }
  cleanVars() {
    this.pageNumber = 1;
    this.pageSize = 10;
    this.filterName = "";
    this.firstPage = "";
    this.lastPage = "";
    this.nextPage = "";
    this.previousPage = "";
    this.totalPages = 0;
    this.totalRecords = 0;
    this.monthlySalaryDetail = [];
  }
  callRegisterForm() {
      this.dialog.open(RegisterSalaryComponent, { data: {
        message: "Error!!!",
        divisionList: this.divisionList,
        officeList: this.officeList,
        positionList: this.positionList,
        enrollment: this.enrollment
      }})
      this.LoadData(this.uriService);
  }
  toogleRadio(option: number){
    this.optSearch = option;
    if (option == 0) {
      this.searchOption = "Ingresar código";
    } else {
      this.searchOption = "Ingresar nombre";
    }
    (<HTMLInputElement>document.getElementById("search-input")).value = "";
  }
}

interface EmployeeServiceResponse extends ServiceResponse {
  data: Employee[];
}
interface MonthlySalaryServiceResponse extends ServiceResponse {
  data: MonthlySalaryDetail[];
}
interface CommonServiceResponse extends ServiceResponse {
  data: CommonItem[];
}

interface EnrollmentResponse extends ServiceResponse {
  data: Enrollment;
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
