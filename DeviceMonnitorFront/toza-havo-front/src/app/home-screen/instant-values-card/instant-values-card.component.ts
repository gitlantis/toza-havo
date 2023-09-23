import { Component, Input } from '@angular/core';
import * as Highcharts from 'highcharts';
import HighchartsMore from 'highcharts/highcharts-more';
import { InstantData } from 'src/helpers/instant-data.model';


HighchartsMore(Highcharts);

@Component({
  selector: 'app-instant-values-card',
  templateUrl: './instant-values-card.component.html',
  styleUrls: ['./instant-values-card.component.css'],
})
export class CurrentValuesCardComponent {
  private _instantData?: InstantData = {};
  @Input()
  set instantData(value: InstantData | undefined) {
    this._instantData = value;
    this.getArcs();
  };
  get instantData() {
    return this._instantData;
  };

  ArcChart: typeof Highcharts = Highcharts;
  arcOptionsPM1_0: Highcharts.Options = {};
  arcOptionsPM2_5: Highcharts.Options = {};
  arcOptionsPM10: Highcharts.Options = {};
  arcOptionsCO2: Highcharts.Options = {};

  getArcs() {
    this.arcOptionsPM1_0 = this.getArchOption(this._instantData?.pm1_0, 400, "Chang (PM1.0)", "μg/m<pro>3</pro>", "Good");
    this.arcOptionsPM2_5 = this.getArchOption(this._instantData?.pm2_5, 600, "Chang (PM2.5)", "μg/m<pro>3</pro>", "Good");
    this.arcOptionsPM10 = this.getArchOption(this._instantData?.pm10, 500, "Chang (PM10)", "μg/m<pro>3</pro>", "Good");
    this.arcOptionsCO2 = this.getArchOption(this._instantData?.co2, 2000, "CO2", "ppm", "Good");
  }

  getArchOption(param: number = 0, max: number, name?: string, unit?: string, text?: string): Highcharts.Options {
    return {
      chart: {
        plotBorderWidth: 0,
        plotShadow: false,
      },
      title: {
        text: `${text} (${param})`,
        align: "center",
        verticalAlign: "middle",
        y: 60,
      },
      tooltip: {
        pointFormat: `{series.name}: <b>${param}${unit}</b>`,
      },
      accessibility: {
        point: {
          valueSuffix: unit,
        },
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: false,
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
          name: name,
          innerSize: "50%",
          data: [
            {
              name: "",
              y: param,
              dataLabels: {
                enabled: false,
              },
            },
            {
              name: "",
              y: max - param,
              dataLabels: {
                enabled: false,
              },
              events: {
                mouseOver: () => {
                  return false
                }
              }
            },
          ],
        },
      ],
    }
  }
}
