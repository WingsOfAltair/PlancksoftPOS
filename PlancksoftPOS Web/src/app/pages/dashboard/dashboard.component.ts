import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { NbThemeService, NbWindowService } from "@nebular/theme";
import { takeWhile } from "rxjs/operators";
import { SolarData } from "../../@core/data/solar";
import { StateService } from "../../@core/utils";
import { OpenRegisterModalComponent } from "../main-window/open-register-modal/open-register-modal.component";
import { CloseModelRegisterComponent } from "../main-window/close-model-register/close-model-register.component";
import { PublisherService } from "../../services/publisher.service";

interface CardSettings {
  title: string;
  iconClass: string;
  type: string;
}

@Component({
  selector: "ngx-dashboard",
  styleUrls: ["./dashboard.component.scss"],
  templateUrl: "./dashboard.component.html",
})
export class DashboardComponent implements OnDestroy, OnInit {
  private alive = true;

  Client:any
  solarValue: number;
  invoice:any
  itemreminder: any
  clientcount:any
  Item:any
  ItemCount:any

  rollerShadesCard: CardSettings = {
    title: "Today Invoice",
    iconClass: "nb-roller-shades",
    type: "success",
  };
  wirelessAudioCard: CardSettings = {
    title: "Item Reminder",
    iconClass: "nb-audio",
    type: "info",
  };
  coffeeMakerCard: CardSettings = {
    title: "Client Count",
    iconClass: "nb-coffee-maker",
    type: "warning",
  };
  lightCard: CardSettings = {
    title: "Register",
    iconClass: "nb-lightbulb",
    type: "primary",
  };

  statusCards: string;

  commonStatusCardsSet: CardSettings[] = [
    this.lightCard,
    this.rollerShadesCard,
    this.wirelessAudioCard,
    this.coffeeMakerCard,
  ];

  statusCardsByThemes: {
    default: CardSettings[];
    cosmic: CardSettings[];
    corporate: CardSettings[];
    dark: CardSettings[];
  } = {
    default: this.commonStatusCardsSet,
    cosmic: this.commonStatusCardsSet,
    corporate: [
      {
        ...this.rollerShadesCard,
        type: "primary",
      },
      {
        ...this.wirelessAudioCard,
        type: "danger",
      },
      {
        ...this.coffeeMakerCard,
        type: "info",
      },
      {
        ...this.lightCard,
        type: "warning",
      },
    ],
    dark: this.commonStatusCardsSet,
  };
  openclose_edit: any;
  message: any;
  userID: any;
  Userdata: any;

  constructor(
    private themeService: NbThemeService,
    public stateService: StateService,
    private solarService: SolarData,
    private windowService: NbWindowService,
    private publisherService: PublisherService,

  ) {
    this.themeService
      .getJsTheme()
      .pipe(takeWhile(() => this.alive))
      .subscribe((theme) => {
        this.statusCards = this.statusCardsByThemes[theme.name];
      });

    this.solarService
      .getSolarData()
      .pipe(takeWhile(() => this.alive))
      .subscribe((data) => {
        this.solarValue = data;
      });
  }

  ngOnDestroy() {
    this.alive = false;
  }

  ngOnInit(): void {
    
    var dt = this.stateService.getSidebarStates();
    dt.subscribe((res) => {
      
      console.log(res);
      this.stateService.setSidebarState(res[0]);
    });

    this.CientCount();
    this.ItemReminder();
    this.TodayInvoice();

    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;

    var obj = {
      UserID: this.userID,
    };

    this.publisherService
      .PostRequest("RetrieveUserPermissions", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        ;
        var responce = JSON.parse(res);
        this.message = responce.ResponseMessage;

        var list = [];
        ;
        this.openclose_edit = this.message.openclose_edit;
      });

  }

  CientCount(){
    this.publisherService
    .PostRequest("RetrieveClientCount", "")
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var array = JSON.parse(responce.ResponseMessage);

      this.clientcount = array.length

    });
  }

  TodayInvoice(){

    var obj ={
      StartDate: this.convertDateToJSONFormat(new Date()),
      EndDate : this.convertDateToJSONFormat(new Date()),
      QuantityEnd: 0
    }

    this.publisherService
    .PostRequest("RetrieveBillsCountByDate", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var array = responce.ResponseMessage;

     
      this.invoice = array;

    });
  }

  ItemReminder(){

    var obj ={
      Date: this.convertDateToJSONFormat(new Date())
    }

    this.publisherService
    .PostRequest("RetrieveExpireStockToday", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var array = responce.ResponseMessage.Item1;

      this.ItemCount = array.length

    });

  }

  convertDateToJSONFormat(date) {
    
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  on = true;
  onLightCardClick() {
    
    if(this.on){
      var obj = this.windowService.open(OpenRegisterModalComponent, {
        title: `Open Register`,
      });;
      obj.onClose.subscribe((res) => {
        this.on = !this.on;
      })
    }
    else{
      var obj = this.windowService.open(CloseModelRegisterComponent, {
        title: `Close Register`,
      });;
      obj.onClose.subscribe((res) => {
        this.ngOnInit()
      })
    }
    
    
  }
}
