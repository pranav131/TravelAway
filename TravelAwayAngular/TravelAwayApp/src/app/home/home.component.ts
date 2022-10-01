import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userRole: string;
  customerLayout: boolean = false;
  commonLayout: boolean = false;
  employeeLayout: boolean = false;
  constructor() {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole == "Customer") {
      this.customerLayout = true;
    }
    else if (this.userRole == "Employee") {
      this.employeeLayout = true;
    }
    else {
      this.commonLayout = true;
    }
  }

  ngOnInit(): void {
  }

}
