import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NbAuthModule, NbDummyAuthStrategy, NbPasswordAuthStrategy } from '@nebular/auth';
import { NbSecurityModule, NbRoleProvider } from '@nebular/security';
import { of as observableOf } from 'rxjs';

import { throwIfAlreadyLoaded } from './module-import-guard';
import {
  AnalyticsService,
  LayoutService,
  PlayerService,
  SeoService,
  StateService,
} from './utils';
import { UserData } from './data/users';
import { ElectricityData } from './data/electricity';
import { SmartTableData } from './data/smart-table';
import { UserActivityData } from './data/user-activity';
import { OrdersChartData } from './data/orders-chart';
import { ProfitChartData } from './data/profit-chart';
import { TrafficListData } from './data/traffic-list';
import { EarningData } from './data/earning';
import { OrdersProfitChartData } from './data/orders-profit-chart';
import { TrafficBarData } from './data/traffic-bar';
import { ProfitBarAnimationChartData } from './data/profit-bar-animation-chart';
import { TemperatureHumidityData } from './data/temperature-humidity';
import { SolarData } from './data/solar';
import { TrafficChartData } from './data/traffic-chart';
import { StatsBarData } from './data/stats-bar';
import { CountryOrderData } from './data/country-order';
import { StatsProgressBarData } from './data/stats-progress-bar';
import { VisitorsAnalyticsData } from './data/visitors-analytics';
import { SecurityCamerasData } from './data/security-cameras';

import { UserService } from './mock/users.service';
import { ElectricityService } from './mock/electricity.service';
import { SmartTableService } from './mock/smart-table.service';
import { UserActivityService } from './mock/user-activity.service';
import { OrdersChartService } from './mock/orders-chart.service';
import { ProfitChartService } from './mock/profit-chart.service';
import { TrafficListService } from './mock/traffic-list.service';
import { EarningService } from './mock/earning.service';
import { OrdersProfitChartService } from './mock/orders-profit-chart.service';
import { TrafficBarService } from './mock/traffic-bar.service';
import { ProfitBarAnimationChartService } from './mock/profit-bar-animation-chart.service';
import { TemperatureHumidityService } from './mock/temperature-humidity.service';
import { SolarService } from './mock/solar.service';
import { TrafficChartService } from './mock/traffic-chart.service';
import { StatsBarService } from './mock/stats-bar.service';
import { CountryOrderService } from './mock/country-order.service';
import { StatsProgressBarService } from './mock/stats-progress-bar.service';
import { VisitorsAnalyticsService } from './mock/visitors-analytics.service';
import { SecurityCamerasService } from './mock/security-cameras.service';
import { MockDataModule } from './mock/mock-data.module';

const socialLinks = [
  {
    url: 'https://github.com/akveo/nebular',
    target: '_blank',
    icon: 'github',
  },
  {
    url: 'https://www.facebook.com/akveo/',
    target: '_blank',
    icon: 'facebook',
  },
  {
    url: 'https://twitter.com/akveo_inc',
    target: '_blank',
    icon: 'twitter',
  },
];

const DATA_SERVICES = [
  { provide: UserData, useClass: UserService },
  { provide: ElectricityData, useClass: ElectricityService },
  { provide: SmartTableData, useClass: SmartTableService },
  { provide: UserActivityData, useClass: UserActivityService },
  { provide: OrdersChartData, useClass: OrdersChartService },
  { provide: ProfitChartData, useClass: ProfitChartService },
  { provide: TrafficListData, useClass: TrafficListService },
  { provide: EarningData, useClass: EarningService },
  { provide: OrdersProfitChartData, useClass: OrdersProfitChartService },
  { provide: TrafficBarData, useClass: TrafficBarService },
  { provide: ProfitBarAnimationChartData, useClass: ProfitBarAnimationChartService },
  { provide: TemperatureHumidityData, useClass: TemperatureHumidityService },
  { provide: SolarData, useClass: SolarService },
  { provide: TrafficChartData, useClass: TrafficChartService },
  { provide: StatsBarData, useClass: StatsBarService },
  { provide: CountryOrderData, useClass: CountryOrderService },
  { provide: StatsProgressBarData, useClass: StatsProgressBarService },
  { provide: VisitorsAnalyticsData, useClass: VisitorsAnalyticsService },
  { provide: SecurityCamerasData, useClass: SecurityCamerasService },
];

export class NbSimpleRoleProvider extends NbRoleProvider {
  getRole() {
    // here you could provide any role based on any auth flow
    return observableOf('guest');
  }
}

export const NB_CORE_PROVIDERS = [
  ...MockDataModule.forRoot().providers,
  ...DATA_SERVICES,
  ...NbAuthModule.forRoot({

    strategies: [
      NbPasswordAuthStrategy.setup({
        name: 'email',
        token: {
          key: 'data.access_token',
        },

        baseEndpoint: '',
        login: {
          endpoint: '/auth/sign-in',
          method: 'post',
        },
        register: {
          endpoint: '/auth/sign-up',
          method: 'post',
        },
        logout: {
          endpoint: '/auth/sign-out',
          method: 'post',
        },
        requestPass: {
          endpoint: '/auth/request-pass',
          method: 'post',
        },
        resetPass: {
          endpoint: '/auth/reset-pass',
          method: 'post',
        },
      }),
    ],
    
    forms: {
      login: {
        redirectDelay: 500, // delay before redirect after a successful login, while success message is shown to the user
        strategy: 'email',  // strategy id key.
        rememberMe: true,   // whether to show or not the `rememberMe` checkbox
        showMessages: {     // show/not show success/error messages
          success: true,
          error: true,
        },
        socialLinks: socialLinks, // social links at the bottom of a page
      },
      register: {
        redirectDelay: 500,
        strategy: 'email',
        showMessages: {
          success: true,
          error: true,
        },
        terms: true,
        socialLinks: socialLinks,
      },
      requestPassword: {
        redirectDelay: 500,
        strategy: 'email',
        showMessages: {
          success: true,
          error: true,
        },
        socialLinks: socialLinks,
      },
      resetPassword: {
        redirectDelay: 500,
        strategy: 'email',
        showMessages: {
          success: true,
          error: true,
        },
        socialLinks: socialLinks,
      },
      logout: {
        redirectDelay: 500,
        strategy: 'email',
      },
      validation: {
        password: {
          required: true,
          minLength: 4,
          maxLength: 50,
        },
        email: {
          required: true,
        },
        fullName: {
          required: false,
          minLength: 4,
          maxLength: 50,
        },
      },
    },

  }).providers,

  NbSecurityModule.forRoot({
    accessControl: {
      guest: {
        view: '*',
      },
      user: {
        parent: 'guest',
        create: '*',
        edit: '*',
        remove: '*',
      },
    },
  }).providers,

{
  provide: NbRoleProvider, useClass: NbSimpleRoleProvider,
},
  AnalyticsService,
  LayoutService,
  PlayerService,
  SeoService,
  StateService,
];

@NgModule({
  imports: [
    CommonModule,
  ],
  exports: [
    NbAuthModule,
  ],
  declarations: [],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }

  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [
        ...NB_CORE_PROVIDERS,
      ],
    };
  }
}
