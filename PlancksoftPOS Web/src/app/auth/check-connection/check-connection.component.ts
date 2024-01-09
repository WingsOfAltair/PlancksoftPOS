import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../../services/auth-service.service';
import { PublisherService } from '../../services/publisher.service';
import { Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'ngx-check-connection',
  templateUrl: './check-connection.component.html',
  styleUrls: ['./check-connection.component.scss']
})
export class CheckConnectionComponent implements OnInit {

  check: any
  message: any

  constructor(
    public authService: AuthServiceService,
    private publisherService: PublisherService,
    private router: Router,
    private toastrService: NbToastrService
  ) { }

  ngOnInit(): void {

    this.message = "";

    this.publisherService.PostRequest('CheckConnection', "").subscribe((res: any) => {
      
      this.check = res.ResponseMessage;

      var response = JSON.parse(res);
      this.message = response.ResponseMessage;

      console.log(this.message);

      

      this.redirectToPage();

    });

  }

  redirectToPage() {
    if (this.message = "Database Server is up.") {
      this.router.navigate(['/auth/login']);

    }

    else{
      this.toastrService.danger('Check your connection','Try Again');
    }

  }

  
  

}
