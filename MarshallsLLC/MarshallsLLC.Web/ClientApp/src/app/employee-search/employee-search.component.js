"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.EmployeeSearchComponent = void 0;
var core_1 = require("@angular/core");
//interface SalaryDetailResult { }
var EmployeeSearchComponent = /** @class */ (function () {
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
    function EmployeeSearchComponent(http) {
        this.http = http;
        //this.LoadData(this.uriService);
    }
    EmployeeSearchComponent.prototype.ngOnInit = function () { };
    EmployeeSearchComponent = __decorate([
        core_1.Component({
            selector: 'app-employee-search',
            templateUrl: './employee-search.component.html'
        })
    ], EmployeeSearchComponent);
    return EmployeeSearchComponent;
}());
exports.EmployeeSearchComponent = EmployeeSearchComponent;
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
//# sourceMappingURL=employee-search.component.js.map