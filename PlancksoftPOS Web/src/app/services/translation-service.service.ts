import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subject } from 'rxjs';


export interface Locale {
	lang: string;
	// tslint:disable-next-line:ban-types
	data: Object;
}


@Injectable({
  providedIn: 'root'
})
export class TranslationServiceService {

  private langIds: any = [];
	public langSubject = new Subject<any>();
  constructor(private translate: TranslateService,
    public router: Router,
		public route: ActivatedRoute) {
      this.translate.addLangs(['en']);

      // this language will be used as a fallback when a translation isn't found in the current language
      this.translate.setDefaultLang('en');
     }

  loadTranslations(...args: Locale[]): void {
    
		const locales = [...args];

		locales.forEach(locale => {
			// use setTranslation() with the third argument set to true
			// to append translations instead of replacing them
			this.translate.setTranslation(locale.lang, locale.data, true);

			this.langIds.push(locale.lang);
		});

		// add new languages to the list
		this.translate.addLangs(this.langIds);

	}

  setLanguage(lang) {
		if (lang) {
			this.translate.use(this.translate.getDefaultLang());
			this.translate.use(lang);
			localStorage.setItem('language', lang);
			let model = {
				lang: lang,
				pageName: this.router.url.split('/')[this.router.url.split('/').length - 1]
			}
			this.langSubject.next(model);
		}
 
	}

  getSelectedLanguage(): any {
		return localStorage.getItem('language') || this.translate.getDefaultLang();
	}

	getTranslation(key): Observable<any> {
		return this.translate.get(key)
	}

}
