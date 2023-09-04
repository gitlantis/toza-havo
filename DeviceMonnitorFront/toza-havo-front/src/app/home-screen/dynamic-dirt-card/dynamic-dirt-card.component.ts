import { Component } from '@angular/core';
import * as Highcharts from 'highcharts';
import HeatmapModule from 'highcharts/modules/heatmap';
import HighchartsMore from 'highcharts/highcharts-more';

HighchartsMore(Highcharts);
HeatmapModule(Highcharts);

@Component({
  selector: 'app-dynamic-dirt-card',
  templateUrl: './dynamic-dirt-card.component.html',
  styleUrls: ['./dynamic-dirt-card.component.css']
})

export class DynamicDirtCardComponent {
  HeatmapChart: typeof Highcharts = Highcharts;
  AudioBoxPlot: typeof Highcharts = Highcharts;

  heatmapOptions: Highcharts.Options = {};
  audioOptions: Highcharts.Options = {};
  updateFlag: boolean = true;

  constructor() { }

  ngOnInit() {
    this.plotHeatmap();
    this.plotAudio();
  }

  plotHeatmap() {
    this.heatmapOptions = {
      chart: {
        type: 'heatmap',
        marginTop: 40,
        marginBottom: 80,
        plotBorderWidth: 1
      },
      title: {
        text: '',
        style: {
          fontSize: '1em'
        }
      },

      xAxis: {
        categories: [
          '00:00', '01:00', '02:00', '03:00', '04:00', '05:00', '06:00', '07:00',
          '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00',
          '16:00', '17:00', '18:00', '20:00', '21:00', '22:00', '23:00'
        ]
      },

      yAxis: {
        categories: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
        reversed: true
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
        // maxColor: Highcharts.getOptions().colors[0]
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
        name: 'Sales per employee',
        borderWidth: 1,
        data: [[0, 0, 10], [0, 1, 19], [0, 2, 8], [0, 3, 24], [0, 4, 67],
        [1, 0, 92], [1, 1, 58], [1, 2, 78], [1, 3, 117], [1, 4, 48],
        [2, 0, 35], [2, 1, 15], [2, 2, 123], [2, 3, 64], [2, 4, 52],
        [3, 0, 72], [3, 1, 132], [3, 2, 114], [3, 3, 19], [3, 4, 16],
        [4, 0, 38], [4, 1, 5], [4, 2, 8], [4, 3, 117], [4, 4, 115],
        [5, 0, 88], [5, 1, 32], [5, 2, 12], [5, 3, 6], [5, 4, 120],
        [6, 0, 13], [6, 1, 44], [6, 2, 88], [6, 3, 98], [6, 4, 96],
        [7, 0, 31], [7, 1, 1], [7, 2, 82], [7, 3, 32], [7, 4, 30],
        [8, 0, 85], [8, 1, 97], [8, 2, 123], [8, 3, 64], [8, 4, 84],
        [9, 0, 47], [9, 1, 114], [9, 2, 31], [9, 3, 48], [9, 4, 91],
        [10, 0, 47], [10, 1, 114], [10, 2, 31], [10, 3, 48], [10, 4, 91],
        [11, 0, 47], [11, 1, 114], [11, 2, 31], [11, 3, 48], [11, 4, 91],
        [12, 0, 47], [12, 1, 114], [12, 2, 31], [12, 3, 48], [12, 4, 91],
        [13, 0, 47], [13, 1, 114], [13, 2, 31], [13, 3, 48], [13, 4, 91],
        [14, 0, 47], [14, 1, 114], [14, 2, 31], [14, 3, 48], [14, 4, 91],
        [15, 0, 47], [15, 1, 114], [15, 2, 31], [15, 3, 48], [15, 4, 91],
        [16, 0, 47], [16, 1, 114], [16, 2, 31], [16, 3, 48], [16, 4, 91],
        [17, 0, 47], [17, 1, 114], [17, 2, 31], [17, 3, 48], [17, 4, 91],
        [18, 0, 47], [18, 1, 114], [18, 2, 31], [18, 3, 48], [18, 4, 91],
        [19, 0, 47], [19, 1, 114], [19, 2, 31], [19, 3, 48], [19, 4, 91],
        [20, 0, 47], [20, 1, 114], [20, 2, 31], [20, 3, 48], [20, 4, 91],
        [21, 0, 47], [21, 1, 114], [21, 2, 31], [21, 3, 48], [21, 4, 91],
        [22, 0, 47], [22, 1, 114], [22, 2, 31], [22, 3, 48], [22, 4, 91],
        [23, 0, 47], [23, 1, 114], [23, 2, 31], [23, 3, 48], [23, 4, 91],
        ],
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
                format: '{substr value 0 1}'
              }
            }
          }
        }]
      }

    }
  };
  plotAudio() {
    this.audioOptions = {
      chart: {
        type: 'boxplot',
      },
      title: {
        text: '',
      },
      xAxis: {
        categories: ['Dushanba', 'Seshanba', 'Chorshanba', 'Payshanba', 'Juma', 'Shanba', 'Yakshanba'],
      },
      yAxis: {
        title: {
          text: 'Value',
        },
      },
      series: [
        {
          type: 'boxplot',
          showInLegend: false,
          data: [
            [760, 801, 848, 895, 965],
            [733, 853, 939, 980, 1080],
            [714, 762, 817, 870, 918],
            [724, 802, 806, 871, 950],
            [724, 802, 806, 871, 950],
            [733, 853, 939, 980, 1080],
            [733, 853, 939, 980, 1080],

          ],
        },
      ],
    }

  }
}
