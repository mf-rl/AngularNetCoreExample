export class CommonItem {
    public id: number = 0;
    public name: string = "";
}

export class Employee {
    public id: number = 0;
    public employeeCode: string = "";
    public employeeName: string = "";
    public employeeSurname: string = "";
    public birthday: string = "";
    public identificationNumber: number = 0;
}

export class Errors {
    public message: string = "";
}

export class MonthlySalaryDetail {
    public id: number = 0;
    public year: number = 0;
    public month: number = 0;
    public office: string = "";
    public employeeCode: string = "";
    public employeeName: string = "";
    public employeeSurname: string = "";
    public division: string = "";
    public position: string = "";
    public grade: number = 0;
    public beginDate: string = "";
    public birthday: string = "";
    public identificationNumber: number = 0;
    public baseSalary: number = 0;
    public productionBonus: number = 0;
    public compensationBonus: number = 0;
    public commission: number = 0;
    public contributions: number = 0;
    public totalSalary: number = 0;
  }
  
  export class Enrollment {
      public id: number = 0;
      public employee: Employee = new Employee();
      public office: CommonItem = new CommonItem();
      public division: CommonItem = new CommonItem();
      public position: CommonItem = new CommonItem();
      public beginDate: string = "";
      public baseSalary: number = 0;      
  }

  export class Salary {
    public id: number = 0;
    public yearMonth: string = "";
    public year: number = 0;
    public month: number = 0;
    public grade: number = 0;
    public productionBonus: number = 0;
    public compensationBonus: number = 0;
    public commission: number = 0;
    public contributions: number = 0;
    public enrollmentId: number = 0;
  }