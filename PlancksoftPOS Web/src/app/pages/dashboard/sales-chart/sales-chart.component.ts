import { Component, OnInit } from '@angular/core';
import { NbColorHelper, NbThemeService } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-sales-chart',
  templateUrl: './sales-chart.component.html',
  styleUrls: ['./sales-chart.component.scss']
})
export class SalesChartComponent implements OnInit {

  data: any;
  options: any;
  themeSubscription: any;

  constructor(
    private theme: NbThemeService,
    private publisherService: PublisherService,
    ) {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.data = {
        labels: ['2006', '2007', '2008', '2009', '2010', '2011', '2012'],
        datasets: [
          {
          data: [65, 59, 80, 81, 56, 55, 40],
          label: 'Series A',
          backgroundColor: NbColorHelper.hexToRgbA(colors.primaryLight, 0.8),
        }, 
      ],
      };

      this.options = {
        maintainAspectRatio: false,
        responsive: true,
        legend: {
          labels: {
            fontColor: chartjs.textColor,
          },
        },
        scales: {
          xAxes: [
            {
              gridLines: {
                display: false,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
          yAxes: [
            {
              gridLines: {
                display: true,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
        },
      };
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }

  ngOnInit(): void {
    // var dt =  moment()
    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);

        var array = response.ResponseMessage.Item1;

        var todaydate = new Date()
        
        var data = array.filter(a => a.Date == todaydate)
        
        var list = [];
        
        array.forEach((el) => {
          var ddate = parseInt(el["Date"].match(/\d+/)[0]);

          var obj = {
       
              // EmployeeAddress: el["Employee Address"],
              BillNumber: el["BillNumber"],
              CashierName: el["CashierName"],
              PaidAmount: el["PaidAmount"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
              paybycash: el["paybycash"],
              Date: new Date(ddate),
            
          };
      
          list.push(obj);
        });

        this.data = list;


        console.log(this.data);
      });
  }

}
