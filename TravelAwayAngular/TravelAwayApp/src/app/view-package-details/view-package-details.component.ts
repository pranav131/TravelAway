import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { PackageService } from "../../travelAway-services/package-service/package.service";
import { IPackageDetails } from '../travelAway-interfaces/PackageDetails';

@Component({
  selector: 'app-view-package-details',
  templateUrl: './view-package-details.component.html',
  styleUrls: ['./view-package-details.component.css']
})
export class ViewPackageDetailsComponent implements OnInit {
  packageId: string;
  packageName: string;
  packageDetails: IPackageDetails[];
  showMsgDiv: boolean = false;
  errMsg: string;
  userRole: string;
  customerLayout: boolean = false;
  commonLayout: boolean = false;
  constructor(private packageService: PackageService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    } else if (this.userRole == "Customer") {
      this.customerLayout = true;
    }
    this.packageId = this.route.snapshot.params['packageId'];
    this.packageName = this.route.snapshot.params['packageName'];
    this.getPackageDetails(this.packageId);

    if (this.packageDetails == null) {
      this.showMsgDiv = true;
    }
  }


  getPackageDetails(packageId: string) {
    this.packageService.getPackageDetails(packageId).subscribe(
      responseData => {
        this.packageDetails = responseData;
        console.log(this.packageDetails);
        this.showMsgDiv = false;
      },
      responseError => {
        this.packageDetails = null;
        this.errMsg = responseError;
        console.log(this.errMsg);
      },
      () => console.log("GetPackageDetails method excuted successfully")
    );
  }

  navigateToBookPackage(packageDetailsId: number) {
    this.router.navigate(['bookpkg', packageDetailsId]);
  }

}
