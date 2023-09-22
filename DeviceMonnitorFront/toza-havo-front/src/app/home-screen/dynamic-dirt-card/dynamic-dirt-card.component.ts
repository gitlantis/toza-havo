import { Component } from '@angular/core';
import * as Highcharts from 'highcharts';
import HeatmapModule from 'highcharts/modules/heatmap';
import HighchartsMore from 'highcharts/highcharts-more';
import { DataService } from 'src/services/data.service';
import { RequestHeatBoxplot } from 'src/helpers/request-heatboxplot.model';
import { HeatBoxPlot } from 'src/helpers/heatboxplot.model';

HighchartsMore(Highcharts);
HeatmapModule(Highcharts);

@Component({
  selector: 'app-dynamic-dirt-card',
  templateUrl: './dynamic-dirt-card.component.html',
  styleUrls: ['./dynamic-dirt-card.component.css']
})

export class DynamicDirtCardComponent {
  params: Record<string, string> = { "pm1_0": "Chang (PM 1.0)", "pm2_5": "Chang (PM 2.5)", "pm10": "Chang (PM 10)", "co2": "CO2" }
  HeatmapChart: typeof Highcharts = Highcharts;
  AudioBoxPlot: typeof Highcharts = Highcharts;

  heatmapOptions: Highcharts.Options = {};
  audioOptions: Highcharts.Options = {};
  updateFlag: boolean = true;
  request: RequestHeatBoxplot = { id: "3fa85f64-5717-4562-b3fc-2c963f66afa6", param: "pm1_0" };
  heatboxplot?: HeatBoxPlot | undefined;
  public cardTitle: string = this.params["pm1_0"];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.heatmapPlot(null);
    this.boxPlot(null);
    this.drawPlot(this.request);
  }

  drawPlot(request: RequestHeatBoxplot) {
    this.dataService.getHeatBoxPlot(this.request).subscribe(res => {
      this.heatboxplot = res as HeatBoxPlot;
      this.heatmapPlot(this.heatboxplot.heatmap);
      this.boxPlot(this.heatboxplot.boxPlot, this.heatboxplot.boxplotMedian);
    })
  }

  selectParam(param: string) {
    if (this.request.param !== param) {
      this.cardTitle = this.params[param];
      this.request.param = param;
      this.drawPlot(this.request)
    }
  }

  heatmapPlot(data: any) {
    this.heatmapOptions = {
      chart: {
        type: 'heatmap',
        marginTop: 20,
        marginBottom: 70,
        plotBorderWidth: 1
      },
      title: {
        text: '',
      },
      subtitle: {
        text: '',
      },
      xAxis: {
        categories: [
          '00:00', '01:00', '02:00', '03:00', '04:00', '05:00', '06:00', '07:00',
          '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00',
          '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00'
        ]
      },

      yAxis: {
        categories: setCategories(),
        title: {
          text: ''
        }
        // reversed: true
      },

      accessibility: {
        point: {
          descriptionFormat: '{(add index 1)}. ' +
            '{series.xAxis.categories.(x)} sales ' +
            '{series.yAxis.categories.(y)}, {value}.'
        }
      },

      colorAxis: {
        min: 0,
        minColor: '#FFFFFF',
      },

      legend: {
        align: 'right',
        layout: 'vertical',
        margin: 0,
        verticalAlign: 'top',
        y: 25,
        symbolHeight: 280
      },

      tooltip: {
        format: '<b>{series.xAxis.categories.(point.x)}</b> sold<br>' +
          '<b>{point.value}</b> items on <br>' +
          '<b>{series.yAxis.categories.(point.y)}</b>'
      },

      series: [{
        type: 'heatmap',
        borderWidth: 1,
        data: data,
        dataLabels: {
          enabled: false,
        }
      }],

      responsive: {
        rules: [{
          condition: {
            maxWidth: 500
          },
          chartOptions: {
            yAxis: {
              labels: {
                format: ''
              }
            },
          }
        }]
      }

    }
  };
  boxPlot(data: any, median?: number) {
    this.audioOptions = {
      chart: {
        type: 'boxplot',
        marginTop: 20,
        marginBottom: 60,
        plotBorderWidth: 1
      },
      title: {
        text: '',
      },
      xAxis: {
        categories: setCategories()?.reverse(),
      },
      yAxis: {
        plotLines: [{
          value: median,
          color: 'red',
          width: 1,
          zIndex: 7,
          label: {
            text: `Umumiy o'rtacha: ${median}`,
            align: 'center',
            style: {
              color: 'gray'
            }
          }
        }],
        title: {
          text: '',
        },
      },
      series: [
        {
          type: 'boxplot',
          showInLegend: false,
          data: data,
        },
      ],
    }

  }
}
function setCategories(): string[] | undefined {
  const options: Intl.DateTimeFormatOptions = {
    weekday: 'short',
    day: 'numeric',
    month: 'short',
  };

  var categories: string[] = [];

  for (let i = 0; i < 7; i++) {
    const date: Date = new Date();
    date.setDate(date.getDate() - i);
    const formattedDate: string = date.toLocaleDateString('en-US', options);
    categories.push(formattedDate)
  }
  return categories;
}

