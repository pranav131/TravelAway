import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee-layout',
  templateUrl: './employee-layout.component.html',
  styleUrls: ['./employee-layout.component.css']
})
export class EmployeeLayoutComponent implements OnInit {
  userRole: string;
  constructor(private router: Router) { this.userRole = sessionStorage.getItem('userRole');}

  ngOnInit(): void {
  }
  logOut() {
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('userRole');
    this.router.navigate(['/login/2']);
  }
}
