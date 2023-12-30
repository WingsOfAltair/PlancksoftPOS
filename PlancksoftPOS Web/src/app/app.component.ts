/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnInit } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import { SeoService } from './@core/utils/seo.service';

import { locale as enLang } from './@core/lang/en';
import { locale as arLang } from './@core/lang/ar';
import { Locale, TranslationServiceService } from './services/translation-service.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {

  constructor(
    private translate: TranslateService,
    private analytics: AnalyticsService,
    private translationService: TranslationServiceService,
     private seoService: SeoService) {

      this.translationService.loadTranslations(enLang, arLang);
      this.translationService.setLanguage('en');
  }



  ngOnInit(): void {
    this.analytics.trackPageViews();
    this.seoService.trackCanonicalChanges();
  }
}
