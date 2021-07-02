"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.SalaryDetailsComponent = void 0;
var core_1 = require("@angular/core");
var operators_1 = require("rxjs/operators");
var SalaryDetailsComponent = /** @class */ (function () {
    function SalaryDetailsComponent(http) {
        this.http = http;
        this.pageNumber = 1;
        this.pageSize = 10;
        this.filterName = "";
        this.firstPage = "";
        this.lastPage = "";
        this.nextPage = "";
        this.previousPage = "";
        this.totalPages = 0;
        this.totalRecords = 0;
        this.uriService = "https://localhost:44350/EmployeeMonthlySalary/Get/" + this.filterName + "?PageNumber=" + this.pageNumber.toString() + "&PageSize=" + this.pageSize.toString();
        this.LoadData(this.uriService);
    }
    SalaryDetailsComponent.prototype.ngOnInit = function () { };
    SalaryDetailsComponent.prototype.LoadData = function (baseUri) {
        var _this = this;
        this.http.get(baseUri)
            .pipe(operators_1.finalize(function () {
            if (_this.serviceResponse.validationResult.isValid) {
                _this.salaryDetails = _this.serviceResponse.data;
                _this.pageNumber = _this.serviceResponse.pageNumber;
                _this.pageSize = _this.serviceResponse.pageSize;
                _this.firstPage = _this.serviceResponse.firstPage;
                _this.lastPage = _this.serviceResponse.lastPage;
                _this.nextPage = _this.serviceResponse.nextPage === null ? "" : _this.serviceResponse.nextPage;
                _this.previousPage = _this.serviceResponse.previousPage === null ? "" : _this.serviceResponse.previousPage;
                _this.totalPages = _this.serviceResponse.totalPages;
                _this.totalRecords = _this.serviceResponse.totalRecords;
            }
            else {
                _this.errorMessages = _this.serviceResponse.validationResult.errors;
                _this.cleanVars();
            }
        }))
            .subscribe(function (result) {
            _this.serviceResponse = result;
        }, function (error) { return console.error(error); });
    };
    SalaryDetailsComponent.prototype.cleanVars = function () {
        this.pageNumber = 1;
        this.pageSize = 10;
        this.filterName = "";
        this.firstPage = "";
        this.lastPage = "";
        this.nextPage = "";
        this.previousPage = "";
        this.totalPages = 0;
        this.totalRecords = 0;
        this.uriService = "https://localhost:44350/EmployeeMonthlySalary/Get/" + this.filterName + "?PageNumber=" + this.pageNumber.toString + "&PageSize=" + this.pageSize.toString;
        this.salaryDetails = null;
    };
    SalaryDetailsComponent = __decorate([
        core_1.Component({
            selector: 'app-salary-detail',
            templateUrl: './salary-detail.component.html'
        })
    ], SalaryDetailsComponent);
    return SalaryDetailsComponent;
}());
exports.SalaryDetailsComponent = SalaryDetailsComponent;
//# sourceMappingURL=salary-detail.component.js.map