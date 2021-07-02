import { Component, OnInit } from '@angular/core';
import {
  HttpClient,
  HttpRequest,
  HttpEventType,
  HttpResponse,
} from '@angular/common/http';
import { finalize } from 'rxjs/operators';
//interface SalaryDetailResult { }
@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html'
})
export class EmployeeSearchComponent implements OnInit {
  //public errorMessages: Errors[];
  //public pageNumber = 1;
  //public pageSize = 10;
  //public filterName = "";
  //public firstPage = "";
  //public lastPage = "";
  //public nextPage = "";
  //public previousPage = "";
  //public totalPages = 0;
  //public totalRecords = 0;
  //public uriService = "https://localhost:44350/EmployeeMonthlySalary/Get/" + this.filterName + "?PageNumber=" + this.pageNumber.toString() + "&PageSize=" + this.pageSize.toString();
  //public salaryDetails: SalaryDetail[];
  //public serviceResponse: ServiceResponse;
  //salaryDetailResult: SalaryDetailResult;
  constructor(private http: HttpClient) {
    //this.LoadData(this.uriService);
  }
  ngOnInit() { }
  //LoadData(baseUri: string) {
  //  this.http.get<ServiceResponse>(baseUri)
  //    .pipe(
  //      finalize(() => {
  //        if (this.serviceResponse.validationResult.isValid) {
  //          this.salaryDetails = this.serviceResponse.data;
  //          this.pageNumber = this.serviceResponse.pageNumber;
  //          this.pageSize = this.serviceResponse.pageSize;
  //          this.firstPage = this.serviceResponse.firstPage;
  //          this.lastPage = this.serviceResponse.lastPage;
  //          this.nextPage = this.serviceResponse.nextPage === null ? "" : this.serviceResponse.nextPage;
  //          this.previousPage = this.serviceResponse.previousPage === null ? "" : this.serviceResponse.previousPage;
  //          this.totalPages = this.serviceResponse.totalPages;
  //          this.totalRecords = this.serviceResponse.totalRecords;
  //        } else {
  //          this.errorMessages = this.serviceResponse.validationResult.errors;
  //          this.cleanVars();
  //        }
  //      })
  //    )
  //    .subscribe(result => {
  //      this.serviceResponse = result;
  //    }, error => console.error(error));
  //}
  //cleanVars() {
  //  this.pageNumber = 1;
  //  this.pageSize = 10;
  //  this.filterName = "";
  //  this.firstPage = "";
  //  this.lastPage = "";
  //  this.nextPage = "";
  //  this.previousPage = "";
  //  this.totalPages = 0;
  //  this.totalRecords = 0;
  //  this.uriService = "https://localhost:44350/EmployeeMonthlySalary/Get/" + this.filterName + "?PageNumber=" + this.pageNumber.toString + "&PageSize=" + this.pageSize.toString;
  //  this.salaryDetails = null;
  //}
}
//interface SalaryDetail {
//  id: number;
//  year: number;
//  month: number;
//  office: string;
//  employeeCode: string;
//  employeeName: string;
//  employeeSurname: string;
//  division: string;
//  position: string;
//  grade: number;
//  beginDate: string;
//  birthday: string;
//  identificationNumber: number;
//  baseSalary: number;
//  productionBonus: number;
//  compensationBonus: number;
//  commission: number;
//  contributions: number;
//  totalSalary: number;
//}
//interface Errors {
//  message: string;
//}
//interface ServiceResponse {
//  data: SalaryDetail[];
//  validationResult: Validation;
//  pageNumber: number,
//  pageSize: number,
//  firstPage: string,
//  lastPage: string,
//  totalPages: number,
//  totalRecords: number,
//  nextPage: string,
//  previousPage: string
//}
//interface Validation {
//  isValid: boolean;
//  errors: Errors[];
//}
