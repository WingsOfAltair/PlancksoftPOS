import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { PublisherService } from '../../services/publisher.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-activation-key',
  templateUrl: './activation-key.component.html',
  styleUrls: ['./activation-key.component.scss']
})
export class ActivationKeyComponent implements OnInit {

  message: any

  licenseGroup: FormGroup;

  constructor(
    private publisherService: PublisherService,
    private router: Router,
    private toastrService: NbToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {

    this.licenseGroup = this.fb.group({
      license: new FormControl('')
    })

  }

  redirectpage() {
    if (this.message = "ss") {

      this.publisherService.PostRequest('CheckAdmin', '').subscribe((res: any) => {
        
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.message = response.ResponseMessage;

        console.log(this.message)

        if (this.message == true) {

          this.router.navigate(['/auth/login']);
        }
        else {
          this.router.navigate(['/auth/register']);

        }

      });



    }

    else {
      this.toastrService.danger("The system's license validity duration has ended. Please contact technical support to purchase a new valid license.", 'Try Again');
    }

  }

}
