import { Component, OnDestroy, OnInit } from "@angular/core";
import {
  NbLayoutDirection,
  NbLayoutDirectionService,
  NbMediaBreakpointsService,
  NbMenuService,
  NbSidebarService,
  NbThemeService,
} from "@nebular/theme";

import { UserData } from "../../../@core/data/users";
import { LayoutService } from "../../../@core/utils";
import { map, takeUntil } from "rxjs/operators";
import { Subject } from "rxjs";
import { Router } from "@angular/router";
import { TranslationServiceService } from "../../../services/translation-service.service";
import { MenuService } from "../../../services/menu.service";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-header",
  styleUrls: ["./header.component.scss"],
  templateUrl: "./header.component.html",
})
export class HeaderComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  user: any;
  logout: any;
  NbLayoutDirection = NbLayoutDirection;
  direction = NbLayoutDirection.LTR;
  userID: any;
  Userdata: any;

  themes = [
    {
      value: "default",
      name: "Light",
    },
    {
      value: "dark",
      name: "Dark",
    },
    {
      value: "cosmic",
      name: "Cosmic",
    },
    {
      value: "corporate",
      name: "Corporate",
    },
  ];

  currentTheme = "default";

  userMenu = [{ title: "Profile" }, { title: "Log out" }];
  message: any;
  Storename: any;
  picture: any;

  constructor(
    private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    public mainMenuService: MenuService,
    private themeService: NbThemeService,
    private userService: UserData,
    private translationService: TranslationServiceService,
    private layoutService: LayoutService,
    private route: Router,
    public nbLayoutDirectionService: NbLayoutDirectionService,
    private breakpointService: NbMediaBreakpointsService,
    private publisherService: PublisherService
  ) {

    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;

    this.picture = '../assets/images/profile.jpg' 

  }

  ngOnInit() {
    this.currentTheme = this.themeService.currentTheme;


    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService
      .onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$)
      )
      .subscribe(
        (isLessThanXl: boolean) => (this.userPictureOnly = isLessThanXl)
      );

    this.themeService
      .onThemeChange()
      .pipe(
        map(({ name }) => name),
        takeUntil(this.destroy$)
      )
      .subscribe((themeName) => (this.currentTheme = themeName));

    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        var response = JSON.parse(res);
        this.message = JSON.parse(response.ResponseMessage);

        this.Storename = this.message[0].SystemName;
      });
  }

  changeLayout() {
    this.direction = this.nbLayoutDirectionService.getDirection();

    if (this.direction == NbLayoutDirection.LTR) {
      this.nbLayoutDirectionService.setDirection(NbLayoutDirection.RTL);
      this.direction = this.nbLayoutDirectionService.getDirection();
      this.translationService.setLanguage("ar");
    } else {
      this.nbLayoutDirectionService.setDirection(NbLayoutDirection.LTR);
      this.direction = this.nbLayoutDirectionService.getDirection();
      this.translationService.setLanguage("en");
    }
    this.mainMenuService.loadMenus();
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  changeTheme(themeName: string) {
    this.themeService.changeTheme(themeName);
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, "menu-sidebar");
    this.layoutService.changeLayoutSize();

    return false;
  }

  navigateHome() {
    this.menuService.navigateHome();
    return false;
  }

  logoutFn($event) {
    setTimeout(() => {
      var dc: any = document;
      var arr = [];
      arr.push(...dc.querySelectorAll(".menu-item"));
      this.logout = arr.find((a) => a.children[0].title == "Log out");
      this.logout.addEventListener("click", () => {
        sessionStorage.removeItem("userData");
        this.route.navigate(["/auth/login"]);
      });
    }, 100);
  }
}
