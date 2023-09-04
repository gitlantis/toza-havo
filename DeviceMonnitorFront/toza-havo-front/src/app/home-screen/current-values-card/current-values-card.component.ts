import { Component } from '@angular/core';
import * as Highcharts from 'highcharts';
import HighchartsMore from 'highcharts/highcharts-more';


HighchartsMore(Highcharts);

@Component({
  selector: 'app-current-values-card',
  templateUrl: './current-values-card.component.html',
  styleUrls: ['./current-values-card.component.css'],
})
export class CurrentValuesCardComponent {
  ArcChart: typeof Highcharts = Highcharts;
  arcOptions: Highcharts.Options = {};

  ngOnInit() {
    this.plotArc();
  }

  plotArc() {
    this.arcOptions = {
      chart: {
        plotBorderWidth: 0,
        plotShadow: false,
      },
      title: {
        text: "Browser<br>shares<br>January<br>2022",
        align: "center",
        verticalAlign: "middle",
        y: 60,
      },
      tooltip: {
        pointFormat: "{series.name}: <b>{point.percentage:.1f}%</b>",
      },
      accessibility: {
        point: {
          valueSuffix: "%",
        },
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: "bold",
              color: "white",
            },
          },
          startAngle: -90,
          endAngle: 90,
          center: ["50%", "75%"],
          size: "110%",
        },
      },
      series: [
        {
          type: "pie",
          name: "Browser share",
          innerSize: "50%",
          data: [
            ["Chrome", 73.86],
            ["Edge", 11.97],
            ["Firefox", 5.52],
            ["Safari", 2.98],
            ["Internet Explorer", 1.9],
            {
              name: "Other",
              y: 3.77,
              dataLabels: {
                enabled: false,
              },
            },
          ],
        },
      ],
    }
  }

}
