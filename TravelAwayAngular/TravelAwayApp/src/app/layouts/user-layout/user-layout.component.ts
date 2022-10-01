import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-layout',
  templateUrl: './user-layout.component.html',
  styleUrls: ['./user-layout.component.css']
})
export class UserLayoutComponent implements OnInit {
  userRole: string;
  constructor(private router: Router) { this.userRole = sessionStorage.getItem('userRole'); }

  ngOnInit(): void {
  }
  logOut() {
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('userRole');
    this.router.navigate(['/login/1']);
  }
}
