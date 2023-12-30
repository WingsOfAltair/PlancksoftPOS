import { Component, OnInit } from '@angular/core';

import { MENU_ITEMS } from './pages-menu';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { TranslationServiceService } from '../services/translation-service.service';
import { MenuService } from '../services/menu.service';

@Component({
  selector: 'ngx-pages',
  styleUrls: ['pages.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="menuService.menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PagesComponent implements OnInit {

  constructor(
    private translationService: TranslationServiceService,
    public menuService: MenuService,
    private route: Router
  ) {
    var user = sessionStorage.getItem("userData")
    if(user){
      
    }
    else{
      this.route.navigate(['/auth/login']);
    }
  }
  ngOnInit(){
    this.route.events.subscribe((val) => {
      if(val instanceof NavigationEnd){
        
        var user = sessionStorage.getItem("userData")
        if(user){
          
        }
        else{
          this.route.navigate(['/auth/login']);
        }
      }
      
    })
    
  }
  
}
