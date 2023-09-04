import { Component } from '@angular/core';
import * as Highcharts from 'highcharts/highstock';

@Component({
  selector: 'app-evapotranspiratsiya-history-card',
  templateUrl: './evapotranspiratsiya-history-card.component.html',
  styleUrls: ['./evapotranspiratsiya-history-card.component.css']
})
export class EvapotranspiratsiyaHistoryCardComponent {
  LineChart: typeof Highcharts = Highcharts;
  lineOptions: Highcharts.Options = {};

  ngOnInit() {
    this.plotLine();
  }

  plotLine() {
    this.lineOptions = {
      chart: {
        type: 'column'
      },

      title: {
        text: 'Born persons, by girls\' name'
      },

      subtitle: {
        text: 'Resize the frame or click buttons to change appearance'
      },

      legend: {
        align: 'right',
        verticalAlign: 'middle',
        layout: 'vertical'
      },

      xAxis: {
        categories: ['2019', '2020', '2021'],
        labels: {
          x: -10
        }
      },

      yAxis: {
        allowDecimals: false,
        title: {
          text: 'Amount'
        }
      },
      series: [{
        type: 'column',
        name: 'Ava',
        data: [38, 51, 34]
      }, {
        type: 'column',
        name: 'Dina',
        data: [31, 26, 27]
      }, {
        type: 'column',
        name: 'Malin',
        data: [38, 42, 41]
      }],
      navigator: {
        enabled: true,
      },
      responsive: {
        rules: [{
          condition: {
            maxWidth: 500
          },
          chartOptions: {
            legend: {
              align: 'center',
              verticalAlign: 'bottom',
              layout: 'horizontal'
            },
            yAxis: {
              labels: {
                align: 'left',
                x: 0,
                y: -5
              },
              title: {
                text: null
              }
            },
            subtitle: {
            },
            credits: {
              enabled: false
            }
          }
        }]
      }
    }
  }
}
